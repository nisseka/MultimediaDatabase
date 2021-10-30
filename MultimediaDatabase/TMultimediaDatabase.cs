using MySql.Extended;
using Posts;
using Strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultimediaDatabase
{
    public class TMultimediaDatabase : TIndex
    {
	private TMMFileTypeEn fileType;

	public string Name;
	public string TableName;
	public string ModeString;
	public string ArtistColumnName;
	public string ArtistDBColumnName;
	public TMMFileTypeEn FileType
	{
	    get => fileType;
	    set
	    {
		if (value != fileType || SearchForFileTypes.Count == 0)
		{
		    Program.FileTypes.AssignTo(value, SearchForFileTypes);

		    fileType = value;
		}
	    }
	}

	public string FileTypeString
	{
	    get
	    {
		return fileType == TMMFileTypeEn.All ? "All" : MySQL.MultimediaFileTypeStrings[(int) fileType];
	    }

	    set
	    {
		int count = MySQL.MultimediaFileTypeStrings.Length;

		for (int i = 0; i < count; i++)
		{
		    if (MySQL.MultimediaFileTypeStrings[i] == value)
		    {
			fileType = (TMMFileTypeEn) i;
		    }
		}
	    }
	}

	public readonly TListOfStrings Directories;
	public readonly TListOfStrings BaseURLs;
	public readonly TListOfStrings BaseWebShareURLs;
	public readonly TListOfStrings SearchForFileTypes;
	public readonly TMultimediaDatabases Parent;

	public TMultimediaDatabase(TMultimediaDatabases aParent = null)
	{
	    Directories = new();
	    BaseURLs = new();
	    BaseWebShareURLs = new();
	    SearchForFileTypes = new();
	    Parent = aParent;
	}

	public void BuildListView(ListView listView)
	{
	    int i, count = Directories.Count;
	    string str;
	    ListViewItem li;

	    listView.Items.Clear();

	    for (i = 0; i < count; i++)
	    {
		str = Directories[i];

		li = listView.Items.Add(str);

		str = BaseURLs[i];
		li.SubItems.Add(str);

		str = BaseWebShareURLs[i];
		li.SubItems.Add(str);
	    }

	}

	public override string ToString()
	{
	    return String.Format("Name = {0}, TableName = {1}, ModeString = {2}, ArtistColumnName = {3}, ModeString = {4}", 
				 Name, TableName, ModeString, ArtistColumnName);
	}

	public void ClearDirectories()
	{
	    Directories.Clear();
	    BaseURLs.Clear();
	    BaseWebShareURLs.Clear();
	}

	public void Clear()
	{
	    Name = string.Empty;
	    TableName = string.Empty;
	    ModeString = string.Empty;
	    ArtistColumnName = string.Empty;
	    ArtistDBColumnName = string.Empty;

	    ClearDirectories();
	    SearchForFileTypes.Clear();
	}
    }


    public class TMultimediaDatabases : TListOfObjectsTIndex
    {
	private TMySQLDatabase db;
	private TMySQLQueryResult MySQLQueryResult;
	private TMultimediaDatabase currentDatabase;
	private int currentDatabaseIndex;

//	public TMySQLDatabase MySQLDB { get => db; }

	public TMultimediaDatabase CurrentDatabase
	{
	    get => currentDatabase;
	    set
	    {
		int i = IndexOf(value);

		if (value != currentDatabase && i >= 0)
		{
		    currentDatabase = value;
		    currentDatabaseIndex = i;
		}
	    }
	}

	public int CurrentDatabaseIndex
	{
	    get => currentDatabaseIndex;
	    set
	    {
		if (value >= 0 && value < Count)
		{
		    currentDatabaseIndex = value;
		    currentDatabase = this[value];
		}
	    }
	}

	public new TMultimediaDatabase this[int index]
	{
	    get
	    {
		return (TMultimediaDatabase) objectList[index];
	    }
	}

	public TMultimediaDatabases(TMySQLDatabase aDB)
	{
	    db = aDB;
	    MySQLQueryResult = db.QueryResult;

	    currentDatabaseIndex = -1;
	}

	public TMultimediaDatabase Add(string aTitle, string aDatabaseTableName, string aArtistColumnName, string aArtistDBColumnName,
					string aModeString, string aDirString, string aBaseURLsString, string aBaseWebShareURLsString,
					TMMFileTypeEn fileType)
	{
	    TMultimediaDatabase multimediaDatabaseObj = new TMultimediaDatabase(this);

	    multimediaDatabaseObj.Name = aTitle;
	    multimediaDatabaseObj.TableName = aDatabaseTableName;
	    multimediaDatabaseObj.ArtistColumnName = aArtistColumnName;
	    multimediaDatabaseObj.ArtistDBColumnName = aArtistDBColumnName;
	    multimediaDatabaseObj.ModeString = aModeString;
	    multimediaDatabaseObj.Directories.Split(aDirString, MyString.semicolon);
	    multimediaDatabaseObj.BaseURLs.Split(aBaseURLsString, MyString.semicolon);
	    multimediaDatabaseObj.BaseWebShareURLs.Split(aBaseWebShareURLsString, MyString.semicolon);
	    multimediaDatabaseObj.FileType = fileType;

	    Add(multimediaDatabaseObj);
	    return multimediaDatabaseObj;
	}

	public int ReadFromDB(string databaseTableName)
	{
	    TMultimediaDatabase multimediaDatabaseObj;
	    TMySQLDataRow dr;
	    TMMFileTypeEn fileType;
	    string TableName, DatabaseName, DirectoriesString, BaseURLs, WebShareBaseURLs;
	    string ArtistColumnName, ArtistDBColumnName, ModeString;
	    int tableNameColumnIndex;
	    int i, count;

	    count = db.ExecuteSelectQuery(databaseTableName, string.Empty, $"ORDER BY {Program.MySQLTableColumn_Title}");

	    tableNameColumnIndex = MySQLQueryResult.ColumnHeaders.IndexOf("DatabaseTableName");

	    for (i = 0; i < count; i++)
	    {
		dr = MySQLQueryResult.Rows[i];
		TableName = dr.String(tableNameColumnIndex);
		DatabaseName = dr.StringByColumnName("Title");
		DirectoriesString = dr.StringByColumnName("DiskDirectory");
		BaseURLs = dr.StringByColumnName("BaseURL");
		WebShareBaseURLs = dr.StringByColumnName("BaseWebShareURL");
		ArtistColumnName = dr.StringByColumnName("ArtistColumnName");
		ArtistDBColumnName = dr.StringByColumnName("ArtistDBColumnName");
		ModeString = dr.StringByColumnName("mode");
		fileType = (TMMFileTypeEn) dr.IntegerByColumnName("FileTypeIndex");

		multimediaDatabaseObj = Add(DatabaseName,TableName, ArtistColumnName, ArtistDBColumnName, ModeString, 
					    DirectoriesString, BaseURLs, WebShareBaseURLs,fileType);
	    }

	    return count;
	}

	public void BuildComboBox(ComboBox comboBox)
	{
	    int i, count = Count;
	    string str;
	    comboBox.Items.Clear();

	    for (i = 0;	i < count; i++)
	    {
		str = this[i].Name;
		comboBox.Items.Add(str);
	    }

	}

	public override string ToString()
	{
	    StringBuilder sb = new StringBuilder($"Count = {Count}, Multimedia Databases: ");
	    TMultimediaDatabase mDbObj;
	    int i, c = Count;

	    string str;

	    for (i = 0; i < c; i++)
	    {
		mDbObj = this[i];

		sb.Append(mDbObj.ToString());
		sb.Append(", ");
	    }
	    str = sb.ToString();
	    return str;
	}

    }

}
