using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Files;
using Posts;
using MySql.Extended;
using Strings;
using System.Globalization;
using Stndrd;
using MultimediaDatabase.Properties;
using MediaInfoLib;
using System.IO;

namespace MultimediaDatabase
{
    enum TDatabases
    {
	dbMusicVideos,
	dbMusicFiles,
	dbMovies,
	dbTVShows,
	dbVideoClips
    }

    enum TTabPages { FilesAddedPage, FilesDeletedPage, FilesUpdatedPage, None = -1 }

    public partial class TMainForm : Form
    {
	private TFiles files;
	private int FileSizeColumnIndex;
	private int FileNameColumnIndex;
	private int FilePathColumnIndex;

	public TMySQLDatabase db;
//	public TMySQLQueryResult multimediaDBs;
	public TMySQLQueryResult MySQLQueryResult;
	public string CurrentTableName;
	private string CurrentDatabaseName;

	public TListOfStrings CurrentDirs;
	public TListOfStrings CurrentBaseURLs;
	public TListOfStrings CurrentBaseWebShareURLs;
	public TListOfStrings CurrentSearchForFileTypes;

	public string CurrentArtistColumnName;
	public string CurrentArtistDBColumnName;
	public string CurrentModeString;
	private int DirQR_c;
	private TMySQLQueryResult DirQR;

	private TListOfObjectsTIndex AddedFilesmediaInfosList;
	private TListOfObjectsTIndex DeletedFilesmediaInfosList;
	public readonly TMultimediaDatabases MultimediaDatabases;

	private TMultimediaDatabase currentDatabase;

	private ListViewItem SelectedDatabaseDirectoryListViewItem;

	List<TabPage> FileReportTabPageList;
	List<ListView> FileReportListViewList;


	private TDatabases CurrentDBi;
	private bool AbortScan;

	public TMainForm()
	{
	    InitializeComponent();

	    files = new();
	    db = new();
	    MySQLQueryResult = db.QueryResult;
//	    multimediaDBs = new();
	    DirQR = new TMySQLQueryResult();

/*
	    CurrentDirs = new();
	    CurrentBaseURLs = new();
	    CurrentBaseWebShareURLs = new();
	    CurrentSearchForFileTypes = new();
*/
	    MultimediaDatabases = new TMultimediaDatabases(db);

	    AddedFilesmediaInfosList = new TListOfObjectsTIndex();
	    DeletedFilesmediaInfosList = new TListOfObjectsTIndex();

	    Program.NumColumns = 29;

	    FileReportTabPageList = new List<TabPage>();
	    FileReportTabPageList.Add(FilesAddedPage);
	    FileReportTabPageList.Add(FilesDeletedPage);
	    FileReportTabPageList.Add(FilesUpdatedPage);

	    FileReportListViewList = new List<ListView>();
	    FileReportListViewList.Add(AddedFilesListView);
	    FileReportListViewList.Add(DeletedFilesListView);
	    FileReportListViewList.Add(UpdatedFilesListView);

  

/*
//	    mediaInfo.RawDataString = System.IO.File.ReadAllText(@"C:\Temp\The X Files - Fight the future.mkv.txt");
	    mediaInfo.ReadFromFile(@"E:\multimedia\Foul Play.mkv");
*/
	}

	~TMainForm()
	{
	    db.Connected = false;
	}

	private void scanButtonClick(object sender, EventArgs e)
	{
	    int c, c2 = 0, c3;
	    int filesCount;
	    string exclude = "";

	    ClearFilesListViews();

	    if (CurrentModeString == "movies")
		exclude = "VIDEO_TS.VOB;VTS*.VOB;*.IFO";

	    AbortScan = false;
	    AbortScanButton.Visible = true;
	    filesCount = Files.File.SearchFiles(currentDatabase.Directories, currentDatabase.SearchForFileTypes, exclude, true, searchCallback, false);

	    c = AddedFilesListView.Items.Count;
	    c2 = DeletedFilesListView.Items.Count;
	    c3 = UpdatedFilesListView.Items.Count;

	    Standard.StatusbarPrint(toolStripStatusLabel2, "{0} items added to,{1} items deleted, {2} items updated from database {3}...", c, c2, c3, CurrentDatabaseName);

	    AbortScanButton.Visible = false;
	}

	private FileSearchStatus searchCallback(TFile parameter, FileSearchReason reason)
	{
	    int i, c;
	    bool j;
	    bool file_updated = false, file_found = false;
	    ulong id, sizel, oldsizel;
	    string str, filename, path, path2, datetime, sizeStr, url, webshare_url, ext;
	    string artist, title, old_datetime, old_url, old_webshare_url;
	    string what_changed_str, prev_value_str, new_value_str, filetype;

	    TString strObj;
	    TMySQLDataRow dr;
	    TMediaInfo mediaInfo = null;

	    ListViewItem li;
	    StringBuilder sb, sb2;

	    switch (reason)
	    {
		case FileSearchReason.Starting:
		    Standard.StatusbarPrint(toolStripStatusLabel2, "Fetching data from database {0}...", CurrentDatabaseName);
		    DirQR_c = db.ExecuteSelectQuery(CurrentTableName);

		    DirQR.Assign(MySQLQueryResult);           // Copy Queryresult..
		    break;
		case FileSearchReason.DirectoryFound:
		    Standard.StatusbarPrint(toolStripStatusLabel2, "Entering directory {0}", parameter.FullName);
		    break;
		case FileSearchReason.FileFound:
		    Dictionary<string, object> queryColumns = new Dictionary<string, object>();
		    List<Object> list = new List<Object>();
		    int SeasonID = 0, SeasonEpisodeID = 0;

		    sizel = parameter.Size;
		    filename = parameter.Name;
		    path = parameter.Path;
		    datetime = parameter.LastWriteTime.ToString();
		    sizeStr = MyString.FormatSizeString(sizel);
		    url = MyString.EmptyStr;
		    webshare_url = MyString.EmptyStr;

		    sb = new StringBuilder(path);
		    sb2 = new StringBuilder();

		    c = CurrentDirs.Count;
		    for (i = 0; i < c; i++)
		    {
			strObj = CurrentDirs.StringObject(i);
			str = strObj.String;

			if (path.IndexOf(str) >= 0)
			{
			    sb.Replace('\\', '/');
			    sb.Remove(0, str.Length);
			    sb2.Append(sb);

			    sb.Insert(0, CurrentBaseURLs[i]);
			    url = sb.ToString();

			    sb2.Insert(0, CurrentBaseWebShareURLs[i]);
			    webshare_url = sb2.ToString();
			    break;
			}
		    }

		    ext = parameter.FileExt.ToUpper();

		    for (i = 0; i < DirQR_c; i++)
		    {
			dr = DirQR.Rows[i];
			str = dr.String(FileNameColumnIndex);
			path2 = dr.String(FilePathColumnIndex);

			if (String.Compare(str, filename, true) == 0 && String.Compare(path2, path, true) == 0)
			{
			    id = dr.DWORDLONG(0);
			    oldsizel = dr.DWORDLONG(FileSizeColumnIndex);

			    prev_value_str = MyString.EmptyStr;
			    new_value_str = MyString.EmptyStr;

			    old_datetime = dr.StringByColumnName(Program.MySQLTableColumn_DateAndTime);
			    old_url = dr.StringByColumnName(Program.MySQLTableColumn_URL);
			    old_webshare_url = dr.StringByColumnName(Program.MySQLTableColumn_WebShareURL);

			    what_changed_str = MyString.EmptyStr;
			    str = dr.StringByColumnName(Resources.MySQLTableColumn_MediaInfoHumanReadable);

			    if (oldsizel != sizel || old_datetime != datetime || str.Length == 0)
			    {
				mediaInfo = new TMediaInfo();

				mediaInfo.ReadFromFile(parameter.FullName);

				prev_value_str = dr.StringByColumnName(Resources.MySQLTableColumn_MediaInfoRawData);
				new_value_str = mediaInfo.RawDataString;

				if (new_value_str != prev_value_str)
				{
				    j = db.AddVariable(Resources.MySQLTableColumn_MediaInfoRawData, mediaInfo.RawDataString);
				    j &= db.AddVariable(Resources.MySQLTableColumn_MediaInfoHumanReadable, mediaInfo.MediaInfoString);

				    queryColumns.Clear();
				    queryColumns.Add(Program.MySQLTableColumn_OverallBitRate, mediaInfo.OverallBitRate);
				    queryColumns.Add(Program.MySQLTableColumn_AudioSampleRate, mediaInfo.AudioSampleRate);
				    queryColumns.Add(Program.MySQLTableColumn_AudioNumChannels, mediaInfo.AudioChannelCount);
				    queryColumns.Add(Program.MySQLTableColumn_AudioCodec, mediaInfo.AudioCodec);
				    queryColumns.Add(Program.MySQLTableColumn_AudioBitDepth, mediaInfo.AudioBitDepth);
				    queryColumns.Add(Program.MySQLTableColumn_AudioBitRate, mediaInfo.AudioBitRate(0));
				    queryColumns.Add(Resources.MySQLTableColumn_MediaInfoRawData, "@MediaInfoRawData");
				    queryColumns.Add(Program.MySQLTableColumn_Duration, mediaInfo.Duration);
				    queryColumns.Add(Resources.MySQLTableColumn_MediaInfoHumanReadable, "@MediaInfoHumanReadable");

/*
					j &= db.ExecuteQuery("UPDATE {0} SET OverallBitRate={1},AudioSampleRate={2},AudioNumChannels={3},AudioBitRate={4},AudioCodec='{5}',AudioBitDepth={6} WHERE id={7}", CurrentTableName,
									mediaInfo.OverallBitRate, mediaInfo.AudioSampleRate, mediaInfo.AudioChannelCount, mediaInfo.AudioBitRate(0), mediaInfo.AudioCodec,
									mediaInfo.AudioBitDepth, id) > 0 ? true : false;
					j &= db.ExecuteQuery("UPDATE {0} SET MediaInfoRawData=@MediaInfoRawData,Duration={1} WHERE id={2}", CurrentTableName,
											mediaInfo.Duration, id) > 0 ? true : false;
*/

				    if (mediaInfo.VideoTracksCount > 0)
				    {
					queryColumns.Add(Program.MySQLTableColumn_Resolution, mediaInfo.VideoResolution);
					queryColumns.Add(Program.MySQLTableColumn_FrameRate, mediaInfo.VideoFrameRate(0));
					queryColumns.Add(Program.MySQLTableColumn_VideoBitRate, mediaInfo.VideoBitRate(0));
					queryColumns.Add(Program.MySQLTableColumn_VideoCodec, mediaInfo.VideoCodec);

//					j &= db.ExecuteQuery("UPDATE {0} SET Resolution='{1}',FrameRate={2},VideoBitRate={3},VideoCodec='{4}' WHERE id={5}", CurrentTableName, mediaInfo.VideoResolution,
//						   mediaInfo.VideoFrameRate(0), mediaInfo.VideoBitRate(0), mediaInfo.VideoCodec, id) > 0 ? true : false;
				    }

				    j &= db.ExecuteUpdateQuery(CurrentTableName, queryColumns, id) > 0 ? true : false;

				    if (j)
				    {
					Standard.StatusbarPrint(toolStripStatusLabel2, "Updated mediainfo on {0}...", filename);
					file_updated = true;
					what_changed_str = "Media Info";
				    }
				}

				if (str.Length == 0 && file_updated == false)
				{
				    queryColumns.Clear();
				    queryColumns.Add(Resources.MySQLTableColumn_MediaInfoHumanReadable, "@MediaInfoHumanReadable");
				    db.AddVariable(Resources.MySQLTableColumn_MediaInfoHumanReadable, mediaInfo.MediaInfoString);
				    j = db.ExecuteUpdateQuery(CurrentTableName, queryColumns, id) > 0 ? true : false;

				    if (j)
				    {
					Standard.StatusbarPrint(toolStripStatusLabel2, "Updated to new mediainfo on {0}...", filename);
					file_updated = true;
					what_changed_str = "Media Info";
				    }
				}
				mediaInfo.CloseFile();
			    }


			    if (oldsizel != sizel)
			    {
//				if (db.ExecuteQuery("UPDATE {0} SET filesize={1} WHERE id={2}", CurrentTableName, sizel, id) > 0)
				queryColumns.Clear();
				queryColumns.Add(Program.MySQLTableColumn_Filesize, sizel);
				if (db.ExecuteUpdateQuery(CurrentTableName, queryColumns, id) > 0)
				{
				    Standard.StatusbarPrint(toolStripStatusLabel2, "Updated filesize on {0} with {1}", filename, sizeStr);
				    file_updated = true;
				    if (what_changed_str.Length > 0)
					what_changed_str += MyString.comma;
				    what_changed_str += "File Size";
				    prev_value_str = MyString.FormatSizeString(oldsizel);
				    new_value_str = sizeStr;
				}
			    }

			    if (old_datetime != datetime)
			    {
//				if (db.ExecuteQuery("UPDATE {0} SET DateAndTime='{1}' WHERE id={2}", CurrentTableName, datetime, id) > 0)
				queryColumns.Clear();
				queryColumns.Add(Program.MySQLTableColumn_DateAndTime, datetime);
				if (db.ExecuteUpdateQuery(CurrentTableName, queryColumns, id) > 0)
				{
				    Standard.StatusbarPrint(toolStripStatusLabel2, "Updated date & time on {0} with {1}", filename, datetime);
				    file_updated = true;
				    if (what_changed_str.Length > 0)
				    {
					what_changed_str += MyString.comma;
					prev_value_str += MyString.comma;
					new_value_str += MyString.comma;
				    }
				    what_changed_str += "Date & Time";
				    prev_value_str += old_datetime;
				    new_value_str += datetime;
				}
			    }

			    if (old_url != url)
			    {
//				if (db.ExecuteQuery("UPDATE {0} SET url='{1}' WHERE id={2}", CurrentTableName, url, id) > 0)
				queryColumns.Clear();
				queryColumns.Add(Program.MySQLTableColumn_URL, url);
				if (db.ExecuteUpdateQuery(CurrentTableName, queryColumns, id) > 0)
				{
				    Standard.StatusbarPrint(toolStripStatusLabel2, "Updated URL on {0} with {1}", filename, url);
				    file_updated = true;
				    if (what_changed_str.Length > 0)
				    {
					what_changed_str += MyString.comma;
					prev_value_str += MyString.comma;
					new_value_str += MyString.comma;
				    }
				    what_changed_str += Program.MySQLTableColumn_URL;
				    prev_value_str += old_url;
				    new_value_str += url;
				}
			    }

			    if (old_webshare_url != webshare_url)
			    {
//				if (db.ExecuteQuery("UPDATE {0} SET WebShareURL='{1}' WHERE id={2}", CurrentTableName, webshare_url, id) > 0)
				queryColumns.Clear();
				queryColumns.Add(Program.MySQLTableColumn_WebShareURL, webshare_url);
				if (db.ExecuteUpdateQuery(CurrentTableName, queryColumns, id) > 0)
				{
				    Standard.StatusbarPrint(toolStripStatusLabel2, "Updated WebShareURL on {0} with {1}", filename, webshare_url);
				    file_updated = true;
				    if (what_changed_str.Length > 0)
				    {
					what_changed_str += MyString.comma;
					prev_value_str += MyString.comma;
					new_value_str += MyString.comma;
				    }
				    what_changed_str += Program.MySQLTableColumn_WebShareURL;
				    prev_value_str += old_webshare_url;
				    new_value_str += webshare_url;
				}
			    }

			    if (file_updated)
			    {
				li = UpdatedFilesListView.Items.Add(filename);
				li.SubItems.Add(what_changed_str);
				li.SubItems.Add(prev_value_str);
				li.SubItems.Add(new_value_str);
				li.SubItems.Add($"{id}");
				li.SubItems.Add(path);
				li.Tag = mediaInfo;
			    }

			    DirQR.Delete(i);
			    i--;
			    DirQR_c--;

			    file_found = true;
			    break;
			}
		    }

		    if (!file_found)
		    {   // File doesn't exist in database.. Add it

			TListOfStrings strs = new TListOfStrings(filename, " - ");
			c = strs.Count;

			if (c > 0)
			{
			    if (c > 2)
			    {
				title = strs[2];
				str = strs[1];
				artist = strs[0];
			    }
			    else
			    if (c > 1)
			    {
				artist = strs[0];
				title = strs[1];
				str = string.Empty;
			    }
			    else
			    {
				title = strs[0];
				str = MyString.EmptyStr;
				artist = MyString.EmptyStr;
			    }

			    if (str.Length > 0)
			    {
				char c2 = str[0];

				switch (c2)
				{
				    case 'V':
				    case 'v':
					if (MyString.mysscanf(str, "VOL%dE%d", ref list) > 0)
					{
					    SeasonID = (int)list[0];
					    SeasonEpisodeID = list.Count > 1 ? (int)list[1] : 0;
					}
					else
					{
					    SeasonID = 0;
					    SeasonEpisodeID = 0;
					}
					break;
				    case 'S':
				    case 's':
					if (MyString.mysscanf(str, "S%dE%d", ref list) > 0)
					{
					    SeasonID = (int)list[0];
					    SeasonEpisodeID = list.Count > 1 ? (int)list[1] : 0;
					}
					else
					{
					    SeasonID = 0;
					    SeasonEpisodeID = 0;
					}
					break;
				    case 'E':
				    case 'e':
					if (MyString.mysscanf(str, "E%d", ref list) > 0)
					{
					    SeasonEpisodeID = (int)list[0];
					}
					SeasonID = 0;
					break;
				}


//				if	(SeasonEpisodeID && c>2)
				if (c > 2)
				{
				    title += System.String.Format(" ({0})", str);
				}

			    }

			    mediaInfo = new TMediaInfo();

			    if (mediaInfo.ReadFromFile(parameter.FullName) == 0)
				break;
			    AddedFilesmediaInfosList.Add(mediaInfo);

			    filetype = mediaInfo.FileFormat;

			    if (filetype == "MPEG Audio")
			    {
				artist = mediaInfo.ID3Artist;
				title = mediaInfo.ID3Title;
			    }

			    db.AddVariable(Resources.MySQLTableColumn_MediaInfoRawData, mediaInfo.RawDataString);
			    db.AddVariable(Resources.MySQLTableColumn_MediaInfoHumanReadable, mediaInfo.MediaInfoString);

/*
			    if (db.ExecuteQuery("INSERT INTO {0} (filename,path,filesize,{1},title,filetype,URL,WebShareURL,DateAndTime,MediaInfoRawData,Duration,OverallBitRate,AudioSampleRate,AudioNumChannels,AudioBitRate,AudioCodec,AudioBitDepth) VALUES ('{2}','{3}',{4},'{5}','{6}','{7}','{8}','{9}','{10}',@MediaInfoRawData,{11},{12},{13},{14},{15},'{16}',{17})",
					    CurrentTableName, CurrentArtistDBColumnName, filename, path, sizel, artist, title, filetype, url, webshare_url,
					    datetime, mediaInfo.Duration, mediaInfo.OverallBitRate, mediaInfo.AudioSampleRate, mediaInfo.AudioChannelCount,
					    mediaInfo.AudioBitRate(0), mediaInfo.AudioCodec, mediaInfo.AudioBitDepth) > 0)
*/
			    queryColumns.Clear();
			    queryColumns.Add(Program.MySQLTableColumn_Filename, filename);
			    queryColumns.Add(Program.MySQLTableColumn_Path, path);
			    queryColumns.Add(Program.MySQLTableColumn_Filesize, sizel);
			    queryColumns.Add(CurrentArtistDBColumnName, artist);
			    queryColumns.Add(Program.MySQLTableColumn_Title, title);
			    queryColumns.Add(Program.MySQLTableColumn_Filetype, filetype);
			    queryColumns.Add(Program.MySQLTableColumn_URL, url);
			    queryColumns.Add(Program.MySQLTableColumn_WebShareURL, webshare_url);
			    queryColumns.Add(Program.MySQLTableColumn_DateAndTime, datetime);
			    queryColumns.Add(Resources.MySQLTableColumn_MediaInfoRawData, "@MediaInfoRawData");
			    queryColumns.Add(Program.MySQLTableColumn_Duration, mediaInfo.Duration);
			    queryColumns.Add(Program.MySQLTableColumn_OverallBitRate, mediaInfo.OverallBitRate);
			    queryColumns.Add(Program.MySQLTableColumn_AudioSampleRate, mediaInfo.AudioSampleRate);
			    queryColumns.Add(Program.MySQLTableColumn_AudioNumChannels, mediaInfo.AudioChannelCount);
			    queryColumns.Add(Program.MySQLTableColumn_AudioBitRate, mediaInfo.AudioBitRate(0));
			    queryColumns.Add(Program.MySQLTableColumn_AudioCodec, mediaInfo.AudioCodec);
			    queryColumns.Add(Program.MySQLTableColumn_AudioBitDepth, mediaInfo.AudioBitDepth);
			    queryColumns.Add(Resources.MySQLTableColumn_MediaInfoHumanReadable, "@MediaInfoHumanReadable");

			    if (db.ExecuteInsertQuery(CurrentTableName, queryColumns) > 0)
			    {
				id = db.LastInsertID;

				li = AddedFilesListView.Items.Add(title);
				li.Tag = mediaInfo;
				li.SubItems.Add(artist);
				li.SubItems.Add(filename);
				li.SubItems.Add(sizeStr);
				li.SubItems.Add(mediaInfo.DurationString);
				li.SubItems.Add(mediaInfo.OverallBitRateString);
				li.SubItems.Add(filetype);
				li.SubItems.Add(mediaInfo.VideoCodec);
				li.SubItems.Add(mediaInfo.VideoResolution);
				li.SubItems.Add(mediaInfo.VideoBitRateString(0));
				li.SubItems.Add(mediaInfo.VideoFrameRateString(0));
				li.SubItems.Add(mediaInfo.AspectRatioString(0));
				li.SubItems.Add(mediaInfo.AudioCodec);
				li.SubItems.Add(mediaInfo.AudioBitRateString(0));
				li.SubItems.Add(mediaInfo.AudioChannelCount.ToString());
				li.SubItems.Add(mediaInfo.AudioSampleRate.ToString());
				li.SubItems.Add(mediaInfo.AudioBitDepth.ToString());
				li.SubItems.Add(path);
				li.SubItems.Add(url);
				li.SubItems.Add(webshare_url);
				li.SubItems.Add(datetime);
				li.SubItems.Add(id.ToString());
				li.SubItems.Add(mediaInfo.VideoTracksCount.ToString());
				li.SubItems.Add(mediaInfo.AudioTracksCount.ToString());
				li.SubItems.Add(mediaInfo.SubtitleTracksCount.ToString());
				li.SubItems.Add(mediaInfo.VideoBitRateMode(0));
				li.SubItems.Add(mediaInfo.AudioBitRateMode(0));
				li.SubItems.Add(mediaInfo.AudioChannelLayout(0));
				li.SubItems.Add(mediaInfo.AudioChannelPositions(0));

				queryColumns.Clear();

				if (CurrentDBi == TDatabases.dbTVShows)
				{
//				    db.ExecuteQuery("UPDATE {0} SET SeasonID={1},SeasonEpisodeID={2} WHERE id={3}", CurrentTableName, SeasonID, SeasonEpisodeID, id);

				    queryColumns.Add("SeasonID", SeasonID);
				    queryColumns.Add("SeasonEpisodeID", SeasonEpisodeID);

				    li.SubItems.Add(SeasonID.ToString());
				    li.SubItems.Add(SeasonEpisodeID.ToString());
				}

				if (mediaInfo.VideoTracksCount > 0)
				{
//				    db.ExecuteQuery("UPDATE {0} SET Resolution='{1}',FrameRate={2},VideoBitRate={3},VideoCodec='{4}' WHERE id={5}", CurrentTableName, mediaInfo.VideoResolution,
//					       mediaInfo.VideoFrameRate(0), mediaInfo.VideoBitRate(0), mediaInfo.VideoCodec, id);

				    queryColumns.Add(Program.MySQLTableColumn_Resolution, mediaInfo.VideoResolution);
				    queryColumns.Add(Program.MySQLTableColumn_FrameRate, mediaInfo.VideoFrameRate(0));
				    queryColumns.Add(Program.MySQLTableColumn_VideoBitRate, mediaInfo.VideoBitRate(0));
				    queryColumns.Add(Program.MySQLTableColumn_VideoCodec, mediaInfo.VideoCodec);
				}

				db.ExecuteUpdateQuery(CurrentTableName, queryColumns, id);

				Standard.StatusbarPrint(toolStripStatusLabel2, "Added {0} to database..", filename);
				Standard.StatusbarPrint(toolStripStatusLabel1, "{0}", id);
			    }
			    mediaInfo.CloseFile();
			}
		    }
		    break;
		case FileSearchReason.Finished:
		    if (AbortScan)
		    {
			break;
		    }
		    c = DirQR.Count;

//		    Standard.SetupListView(DeletedFilesListView, c, Program.NumColumns);
		    DeletedFilesListView.Items.Clear();

		    DeletedFilesmediaInfosList.Clear();

		    for (i = 0; i < c; i++)
		    {
			dr = DirQR.Rows[i];
			id = dr.DWORDLONG(0);

			filename = dr.String(FileNameColumnIndex);

			li = DeletedFilesListView.Items.Add("");

			mediaInfo = new TMediaInfo();
			mediaInfo.RawDataString = dr.StringByColumnName(Resources.MySQLTableColumn_MediaInfoRawData);

			for (int ii = 0; ii < Program.NumColumns; ii++)
			{
			    li.SubItems.Add(string.Empty);
			}

			Program.GetFileInfoFromDatabase(dr, i, ref li, mediaInfo, CurrentArtistDBColumnName);

			Standard.StatusbarPrint(toolStripStatusLabel2, "Deleted {0} from database..", filename);
			Standard.StatusbarPrint(toolStripStatusLabel1, "{0}", id);

			db.ExecuteDeleteQuery(CurrentTableName, id);

			DeletedFilesmediaInfosList.Add(mediaInfo);
		    }
		    break;
	    }

	    Application.DoEvents();
	    return AbortScan ? FileSearchStatus.SearchAbort : FileSearchStatus.SearchContinue;
	}

	private void MainForm_Shown(object sender, EventArgs e)
	{
	    TMySQLDataRow dr;
	    int c, r;

	    r = MySQL.ConnectToMySQLServer(db, "server.wpnet.se", "stefan", "piU9Jfdj6W^*BfG", "multimediadatabase");

	    if (r < 0)
	    {
		Close();
		return;
	    }

	    db.ReadOptions("wnet.multimedia_config");
	    db.ReadFileTypes("wnet.multimediafiletypes", TMMFileTypeEn.All, Program.FileTypes);

//	    c = db.ExecuteQuery("SELECT * FROM dbs ORDER BY Title");

	    c = MultimediaDatabases.ReadFromDB(Resources.DBS_TableName);

/*
	    c = db.ExecuteSelectQuery(Resources.DBS_TableName, string.Empty, $"ORDER BY {Program.MySQLTableColumn_Title}");
	    multimediaDBs.Assign(MySQLQueryResult);
*/

	    MultimediaDatabases.BuildComboBox(CurrentDatabaseComboBox);

	    db.ExecuteSelectQuery("tv", string.Empty, "LIMIT 1");
	    FileSizeColumnIndex = MySQLQueryResult.ColumnHeaders.IndexOf(Program.MySQLTableColumn_Filesize); ;
	    FileNameColumnIndex = MySQLQueryResult.ColumnHeaders.IndexOf(Program.MySQLTableColumn_Filename);
	    FilePathColumnIndex = MySQLQueryResult.ColumnHeaders.IndexOf(Program.MySQLTableColumn_Path);

	    CurrentDatabaseComboBox.SelectedIndex = 0;

//	    db.ExecuteInsertQuery("videoclips",new Dictionary<string, object>() { { "filename", "dfd.mkv"}, { Program.ySQLColumnHeader_Filesize, 54898957 } });

//	    db.ExecuteSelectQuery("videoclips", string.Empty, null, "LIKE '%å%'", "filename");

	}

	private void TMainForm_FormClosed(object sender, FormClosedEventArgs e)
	{
	    db.Disconnect();
	}

	private void CurrentDatabaseComboBox_SelectedIndexChanged(object sender, EventArgs e)
	{
	    int i = CurrentDatabaseComboBox.SelectedIndex;

	    if (i >= 0)
	    {
		MultimediaDatabases.CurrentDatabaseIndex = i;
		currentDatabase = MultimediaDatabases.CurrentDatabase;

		CurrentTableName = currentDatabase.TableName;
		CurrentDatabaseName = currentDatabase.Name;

		CurrentArtistColumnName = currentDatabase.ArtistColumnName;
		CurrentArtistDBColumnName = currentDatabase.ArtistDBColumnName;
		CurrentModeString = currentDatabase.ModeString;

		FilesAddedArtistColumnHeader.Text = CurrentArtistColumnName;
		FilesDeletedArtistColumnHeader.Text = CurrentArtistColumnName;

		currentDatabase.BuildListView(DatabaseDirectoriesListView);

		CurrentDirs = currentDatabase.Directories;
		CurrentBaseURLs = currentDatabase.BaseURLs;
		CurrentBaseWebShareURLs = currentDatabase.BaseWebShareURLs;


		ClearDirectoriesButton.Enabled = currentDatabase.Directories.Count > 0 ? true : false;

		CurrentDBi = (TDatabases)i;
	    }
	}

	//---------------------------------------------------------------------------
	public void ClearFilesListViews()
	{
	    AddedFilesListView.Items.Clear();
	    //	    DeletedFilesListView.Items.Clear();
	    UpdatedFilesListView.Items.Clear();
	    //	    AddedFilesmediaInfosList.Clear();
	    //	    DeletedFilesmediaInfosList.Clear();
	}

	private void AddDirectoryButton_Click(object sender, EventArgs e)
	{
	    ListViewItem    li;

	    string dir = string.Empty, baseURL = string.Empty, baseWebShareURL = string.Empty;

	    if (Program.EditDatabaseDirectoryForm.AddDirectoryEntry(ref dir, ref baseURL, ref baseWebShareURL))
	    {
		currentDatabase.Directories.Add(dir);
		currentDatabase.BaseURLs.Add(baseURL);
		currentDatabase.BaseWebShareURLs.Add(baseWebShareURL);

		li = DatabaseDirectoriesListView.Items.Add(dir);

		li.SubItems.Add(baseURL);
		li.SubItems.Add(baseWebShareURL);

		UpdateDBDirOptions();
	    }

	}

	private void ViewDatabaseButton_Click(object sender, EventArgs e)
	{
	    TViewDatabaseForm viewDatabaseForm = new TViewDatabaseForm(db, CurrentTableName, CurrentDatabaseName);

	    viewDatabaseForm.Show();

	    Program.AddFormToWindowMenu(viewDatabaseForm);
	}

	private void ExitMenuItem_Click(object sender, EventArgs e)
	{
	    Close();
	}

	public void WindowMenu_Click(object sender, EventArgs e)
	{
	    ToolStripMenuItem mitem = (ToolStripMenuItem)sender;
	    Form form;
	    int form_i;

	    form_i = Program.VDBFormsMenuItemsList.IndexOf(mitem);
	    if (form_i >= 0)
	    {
		form = Program.VDBFormsList[form_i];
		form.BringToFront();
	    }

	}

	private void PlayFileButton_Click(object sender, EventArgs e)
	{
	    string fileName;
	    TabPage activeTabPage = FileReportPageControl.SelectedTab;

	    TTabPages index = (TTabPages)FileReportTabPageList.IndexOf(activeTabPage);

	    if (index >= 0)
	    {
		ListView listView = FileReportListViewList[(int)index];
		ListView.SelectedListViewItemCollection selectedListViewItems = listView.SelectedItems;

		foreach (ListViewItem item in selectedListViewItems)
		{
		    if (index == TTabPages.FilesUpdatedPage)
		    {
//			fileName = String.Format("{0}{1}", item.SubItems[5].Text, item.Text);
			fileName = item.SubItems[5].Text + item.Text;
		    }
		    else
			fileName = Program.GetFullFileNameFromListItem(item);

		    Exec.ShellExecute(fileName);
		}

	    }
	}

	private void ViewMediaInfoButton_Click(object sender, EventArgs e)
	{
	    TMediaInfo mediaInfo;
	    string fullfilename;
	    TabPage activeTabPage = FileReportPageControl.SelectedTab;

	    TTabPages index = (TTabPages)FileReportTabPageList.IndexOf(activeTabPage);

	    if (index >= 0)
	    {
		ListView listView = FileReportListViewList[(int)index];
		ListView.SelectedListViewItemCollection selectedListViewItems = listView.SelectedItems;

		foreach (ListViewItem item in selectedListViewItems)
		{
		    if (index == TTabPages.FilesUpdatedPage)
		    {
//			fullfilename = String.Format("{0}{1}", item.SubItems[5].Text, item.Text);
			fullfilename = item.SubItems[5].Text + item.Text;
		    }
		    else
			fullfilename = Program.GetFullFileNameFromListItem(item);

		    mediaInfo = (TMediaInfo)item.Tag;
		    if (mediaInfo.MediaInfoString.Length > 0)
			Program.ViewMediaInfo(fullfilename, mediaInfo.MediaInfoString);
		    else
			Program.ViewMediaInfo(fullfilename, mediaInfo.RawDataStrings);
		}

	    }

	}

	private void FilesListView_SelectedIndexChanged(object sender, EventArgs e)
	{
	    ListView listView = (ListView)sender;

	    int index = FileReportListViewList.IndexOf(listView);

	    if (index >= 0)
	    {
		ListView.SelectedListViewItemCollection selectedListViewItems = listView.SelectedItems;

		bool selected = selectedListViewItems.Count > 0 ? true : false;

		PlayFileButton.Enabled = selected;
		ViewMediaInfoButton.Enabled = selected;
	    }
	}

	private void FileReportPageControl_SelectedIndexChanged(object sender, EventArgs e)
	{
	    TabPage activeTabPage = FileReportPageControl.SelectedTab;

	    TTabPages index = (TTabPages)FileReportTabPageList.IndexOf(activeTabPage);

	    if (index >= 0)
	    {
		ListView listView = FileReportListViewList[(int)index];

		FilesListView_SelectedIndexChanged(listView, null);
	    }
	}

	private void FilesListView_DoubleClick(object sender, EventArgs e)
	{
	    ListView listView = (ListView)sender;

	    int index = FileReportListViewList.IndexOf(listView);

	    if (index >= 0)
	    {
		PlayFileButton.PerformClick();
	    }
	}

	private void EditDatabaseButton_Click(object sender, EventArgs e)
	{

	    if (Program.EditDatabaseSettings.Edit(currentDatabase))
	    {
		Dictionary<string, object> queryColumns = new Dictionary<string, object>();
		queryColumns.Add("Title", currentDatabase.Name);
		queryColumns.Add("DatabaseTableName", currentDatabase.TableName);
		queryColumns.Add("ArtistColumnName", currentDatabase.ArtistColumnName);
		queryColumns.Add("ArtistDBColumnName", currentDatabase.ArtistDBColumnName);

		db.ExecuteUpdateQuery(Resources.DBS_TableName, queryColumns, currentDatabase.ModeString, "mode");

		if (((string) CurrentDatabaseComboBox.SelectedItem) != currentDatabase.Name)
		{
		    CurrentDatabaseComboBox.Items[(int) CurrentDBi] = currentDatabase.Name;
		}
	    }
	}

	private void AddDatabaseButton_Click(object sender, EventArgs e)
	{
	    TMultimediaDatabase multimediaDatabaseObj = Program.EditDatabaseSettings.AddDatabase();

	    if (multimediaDatabaseObj != null)
	    {
		Dictionary<string, object> queryColumns = new Dictionary<string, object>();

		queryColumns.Add("Title", multimediaDatabaseObj.Name);
		queryColumns.Add("DatabaseTableName", multimediaDatabaseObj.TableName);
		queryColumns.Add("ArtistColumnName", multimediaDatabaseObj.ArtistColumnName);
		queryColumns.Add("ArtistDBColumnName", multimediaDatabaseObj.ArtistDBColumnName);
		queryColumns.Add("mode", multimediaDatabaseObj.ModeString);
		queryColumns.Add("FileTypeIndex", (int) multimediaDatabaseObj.FileType);

		db.ExecuteInsertQuery(Resources.DBS_TableName, queryColumns);
	    }
	}

	private void ClearDirectoriesButton_Click(object sender, EventArgs e)
	{
	    currentDatabase.ClearDirectories();

	    UpdateDBDirOptions();

	    DatabaseDirectoriesListView.Items.Clear();
	    ClearDirectoriesButton.Enabled = false;
	}

	private void DeleteSelectedDirectoryButton_Click(object sender, EventArgs e)
	{
	    int index = SelectedDatabaseDirectoryListViewItem.Index;

	    if (SelectedDatabaseDirectoryListViewItem != null &&
		Standard.QuestionMessage("Confirm Deletion..", "Are you sure you want to delete \n'{0}'", currentDatabase.Directories[index]) == DialogResult.Yes )
	    {
		currentDatabase.Directories.Delete(index);
		currentDatabase.BaseURLs.Delete(index);
		currentDatabase.BaseWebShareURLs.Delete(index);
		DatabaseDirectoriesListView.Items.Remove(SelectedDatabaseDirectoryListViewItem);
		UpdateDBDirOptions();

	    }
	}

	private void DatabaseDirectoriesListView_SelectedIndexChanged(object sender, EventArgs e)
	{
	    bool enabled = false;
	    if (DatabaseDirectoriesListView.SelectedItems.Count > 0)
	    {
		SelectedDatabaseDirectoryListViewItem = DatabaseDirectoriesListView.SelectedItems[0];
		enabled = true;
	    } else
		SelectedDatabaseDirectoryListViewItem = null;

	    DeleteSelectedDirectoryButton.Enabled = enabled;
	    EditSelectedDirectoryButton.Enabled = enabled;
	}

	private void EditSelectedDirectoryButton_Click(object sender, EventArgs e)
	{
	    string dir, baseURL, baseWebShareURL;
	    int index;

	    if (SelectedDatabaseDirectoryListViewItem != null)
	    {
		index = SelectedDatabaseDirectoryListViewItem.Index;

		dir = CurrentDirs[index];
		baseURL = CurrentBaseURLs[index];
		baseWebShareURL = CurrentBaseWebShareURLs[index];

		if (Program.EditDatabaseDirectoryForm.EditDirectoryEntry(ref dir, ref baseURL, ref baseWebShareURL))
		{
		    CurrentDirs[index] = dir;
		    CurrentBaseURLs[index] = baseURL;
		    CurrentBaseWebShareURLs[index] = baseWebShareURL;

		    SelectedDatabaseDirectoryListViewItem.Text = dir;
		    SelectedDatabaseDirectoryListViewItem.SubItems[1].Text = baseURL;
		    SelectedDatabaseDirectoryListViewItem.SubItems[2].Text = baseWebShareURL;
		    UpdateDBDirOptions();
		}

	    }
	}

	public void UpdateDBDirOptions()
	{
	    Dictionary<string, object> queryColumns = new Dictionary<string, object>();

	    queryColumns.Add("DiskDirectory", currentDatabase.Directories.Join(MyString.semicolon));
	    queryColumns.Add("BaseURL", currentDatabase.BaseURLs.Join(MyString.semicolon));
	    queryColumns.Add("BaseWebShareURL", currentDatabase.BaseWebShareURLs.Join(MyString.semicolon));
	    db.ExecuteUpdateQuery(Resources.DBS_TableName, queryColumns, currentDatabase.ModeString, "mode");
	}

	private void DatabaseDirectoriesListView_DoubleClick(object sender, EventArgs e)
	{
	    EditSelectedDirectoryButton.PerformClick();
	}

	private void AbortScanButton_Click(object sender, EventArgs e)
	{
	    AbortScan = true; 
	}

	private void DumpColumnSizeButton_Click(object sender, EventArgs e)
	{
	    TListOfStrings columnsizes = new TListOfStrings();
	    string listViewName;
	    ListView listView;

	    if (FileReportPageControl.SelectedTab == FilesAddedPage)
	    {
		listView = AddedFilesListView;
		listViewName = listView.Name;
	    }
	    else
	    if (FileReportPageControl.SelectedTab == FilesDeletedPage)
	    {
		listView = DeletedFilesListView;
		listViewName = listView.Name;
	    }
	    else
	    {
		listView = null;
		listViewName = string.Empty;
	    }

	    if (listView is not null)
	    {
		string filename = String.Format("{0}\\ListView{1}Columns.txt", Directory.GetCurrentDirectory(), listViewName);

		columnsizes.AddFormatted("ListView {0} Columns:", listViewName);

		ListView.ColumnHeaderCollection columns = listView.Columns;
		foreach (ColumnHeader item in columns)
		{
		    columnsizes.AddFormatted("Column {0}: Width={1}", item.Text, item.Width);
		}

		columnsizes.WriteToFile(filename);
	    }

		}
    }

    partial class Program
    {
	public static int AddFormToWindowMenu(Form aForm)
	{
	    ToolStripMenuItem mitem;

	    VDBFormsList.Add(aForm);

	    mitem = new ToolStripMenuItem();

	    mitem.Text = aForm.Text;
	    mitem.BackColor = System.Drawing.Color.DimGray;
	    mitem.ForeColor = System.Drawing.Color.White;
	    mitem.Click += new System.EventHandler(MainForm.WindowMenu_Click);

	    VDBFormsMenuItemsList.Add(mitem);
	    MainForm.WindowMenu.DropDownItems.Add(mitem);

	    return 0;
	}

//---------------------------------------------------------------------------
	public static int RemoveFormFromWindowMenu(Form aForm)
	{
	    ToolStripMenuItem mitem;

	    int formIndex = VDBFormsList.IndexOf(aForm);

	    if (formIndex >= 0)
	    {
		VDBFormsList.Remove(aForm);
		mitem = VDBFormsMenuItemsList[formIndex];
//		delete	mitem;

		MainForm.WindowMenu.DropDownItems.Remove(mitem);
		VDBFormsMenuItemsList.RemoveAt(formIndex);
	    }

	    return 0;
	}
    }
}
