using MySql.Extended;
using Posts;
using Strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static Strings.MyString;
using ListViewItem = System.Windows.Forms.ListViewItem;

namespace MultimediaDatabase
{
    partial class Program
    {
	static public TMainForm MainForm;
	static public TEditDatabaseSettings EditDatabaseSettings;
	static public EditDatabaseDirectoryForm EditDatabaseDirectoryForm;
	static public TMMFileTypes FileTypes;
	static public int NumColumns;
	static public List<Form> VDBFormsList;
	static public List<ToolStripMenuItem> VDBFormsMenuItemsList;

	public static string MySQLTableColumn_MediaInfoRawData = "MediaInfoRawData";
	public static string MySQLTableColumn_OverallBitRate = "OverallBitRate";
	public static string MySQLTableColumn_Filename = "filename";
	public static string MySQLTableColumn_Filesize = "filesize";
	public static string MySQLTableColumn_Filetype = "filetype";
	public static string MySQLTableColumn_Path = "path";
	public static string MySQLTableColumn_Title = "title";
	public static string MySQLTableColumn_URL = "URL";
	public static string MySQLTableColumn_WebShareURL = "WebShareURL";
	public static string MySQLTableColumn_DateAndTime = "DateAndTime";
	public static string MySQLTableColumn_Duration = "Duration";
	public static string MySQLTableColumn_AudioSampleRate = "AudioSampleRate";
	public static string MySQLTableColumn_AudioNumChannels = "AudioNumChannels";
	public static string MySQLTableColumn_AudioBitRate = "AudioBitRate";
	public static string MySQLTableColumn_AudioCodec = "AudioCodec";
	public static string MySQLTableColumn_AudioBitDepth = "AudioBitDepth";
	public static string MySQLTableColumn_Resolution = "Resolution";
	public static string MySQLTableColumn_FrameRate = "FrameRate";
	public static string MySQLTableColumn_VideoBitRate = "VideoBitRate";
	public static string MySQLTableColumn_VideoCodec = "VideoCodec";

	/// <summary>
	///  The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main()
	{
	    Application.SetHighDpiMode(HighDpiMode.SystemAware);
	    Application.EnableVisualStyles();
	    Application.SetCompatibleTextRenderingDefault(false);

	    MainForm = new TMainForm();
	    FileTypes = new TMMFileTypes();
	    VDBFormsList = new List<Form>();
	    VDBFormsMenuItemsList = new List<ToolStripMenuItem>();
	    EditDatabaseSettings = new TEditDatabaseSettings(MainForm.db);
	    EditDatabaseDirectoryForm = new EditDatabaseDirectoryForm();

	    Application.Run(MainForm);
	}
	//---------------------------------------------------------------------------
	public static void GetFileInfoFromDatabase(TMySQLDataRow DataRow, int Index, ref ListViewItem ListItem, MediaInfo MediaInfo, string ArtistDBColumnName)
	{
	    ulong id;
	    ulong size;
	    double duration;
	    string artist, title, sizestr, duration_str, audio_bitrate_str;
	    string filename, datetime, audio_samplerate_str, video_bitrate_str, overall_bitrate_str;
	    string path, filetype, URL, WebShareURL;
	    TTimePrintModes tpm;
	    uint audio_bitrate, video_bitrate, audio_samplerate, overall_bitrate;

	    tpm = TTimePrintModes.Hours | TTimePrintModes.Minutes | TTimePrintModes.Seconds | TTimePrintModes.Milliseconds;

	    artist = DataRow.StringByColumnName(ArtistDBColumnName);
	    title = DataRow.StringByColumnName("title");
	    filename = DataRow.StringByColumnName("filename");
	    path = DataRow.StringByColumnName("path");
	    URL = DataRow.StringByColumnName("URL");
	    WebShareURL = DataRow.StringByColumnName("WebShareURL");
	    filetype = DataRow.StringByColumnName("filetype");
	    size = DataRow.DWORDLONGByColumnName("filesize");
	    datetime = DataRow.StringByColumnName("DateAndTime");
	    duration = DataRow.DoubleByColumnName("Duration");
	    audio_samplerate = DataRow.DWORDByColumnName("AudioSampleRate");
	    audio_bitrate = DataRow.DWORDByColumnName("AudioBitRate");
	    video_bitrate = DataRow.DWORDByColumnName("VideoBitRate");
	    overall_bitrate = DataRow.DWORDByColumnName("OverallBitRate");

	    /*
		    if	(ArtistDBColumnName==TVDBColumnName)
		    {
			    int	SeasonID=DataRow.DWORDByColumnName("SeasonID");
			    int	SeasonEpisodeID=DataRow.DWORDByColumnName("SeasonEpisodeID");

			    if	(SeasonEpisodeID)
			    {
				    if	(SeasonID)
					    title+=printf_ansistring(" (S%02dE%02d)",SeasonID,SeasonEpisodeID);
				    else
					    title+=printf_ansistring(" (E%02d)",SeasonEpisodeID);
			    }
		    }
	    */

	    id = DataRow.DWORDLONG(0);

	    sizestr = MyString.FormatSizeString(size);
	    duration_str = MyString.printf_time(duration, tpm);
	    audio_bitrate_str = MyString.FormatBitRateString(audio_bitrate);
	    video_bitrate_str = MyString.FormatBitRateString(video_bitrate);
	    overall_bitrate_str = MyString.FormatBitRateString(overall_bitrate);
	    audio_samplerate_str = MyString.FormatString("{0} Hz", audio_samplerate);

	    ListItem.Tag = MediaInfo;
	    ListItem.Text = title;
	    //	    ListItem.SubItems[0].Text = title;
	    ListItem.SubItems[1].Text = artist;
	    ListItem.SubItems[2].Text = filename;
	    ListItem.SubItems[3].Text = sizestr;
	    ListItem.SubItems[4].Text = duration_str;
	    ListItem.SubItems[5].Text = overall_bitrate_str;
	    ListItem.SubItems[6].Text = filetype;
	    ListItem.SubItems[7].Text = DataRow.StringByColumnName("VideoCodec");
	    ListItem.SubItems[8].Text = DataRow.StringByColumnName("Resolution");
	    ListItem.SubItems[9].Text = video_bitrate_str;
	    ListItem.SubItems[10].Text = DataRow.StringByColumnName("FrameRate");
	    ListItem.SubItems[11].Text = MediaInfo.AspectRatioString(0);
	    ListItem.SubItems[12].Text = DataRow.StringByColumnName("AudioCodec");
	    ListItem.SubItems[13].Text = audio_bitrate_str;
	    ListItem.SubItems[14].Text = DataRow.StringByColumnName("AudioNumChannels");
	    ListItem.SubItems[15].Text = audio_samplerate_str;
	    ListItem.SubItems[16].Text = DataRow.StringByColumnName("AudioBitDepth");
	    ListItem.SubItems[17].Text = path;
	    ListItem.SubItems[18].Text = URL;
	    ListItem.SubItems[19].Text = WebShareURL;
	    ListItem.SubItems[20].Text = datetime;
	    ListItem.SubItems[21].Text = id.ToString();
	    ListItem.SubItems[22].Text = MediaInfo.VideoTracksCount.ToString();
	    ListItem.SubItems[23].Text = MediaInfo.AudioTracksCount.ToString();
	    ListItem.SubItems[24].Text = MediaInfo.SubtitleTracksCount.ToString();
	    ListItem.SubItems[25].Text = MediaInfo.VideoBitRateMode(0);
	    ListItem.SubItems[26].Text = MediaInfo.AudioBitRateMode(0);
	    ListItem.SubItems[27].Text = MediaInfo.AudioChannelLayout(0);
	    ListItem.SubItems[28].Text = MediaInfo.AudioChannelPositions(0);

	}

	public static string GetFullFileNameFromListItem(ListViewItem aListItem)
	{
	    return aListItem.SubItems[17].Text + aListItem.SubItems[2].Text;
	}
    }
}
