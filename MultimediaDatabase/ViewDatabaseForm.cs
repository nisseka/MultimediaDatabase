using MySql.Extended;
using Strings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Stndrd;
using System.Diagnostics;
using Posts;
using MultimediaDatabase.Properties;

namespace MultimediaDatabase
{
    public partial class TViewDatabaseForm : Form
    {
	TMySQLDatabase db;
	TMySQLQueryResult queryResult;

	public string CurrentTableName;
	public string CurrentArtistDBColumnName;
	public string CurrentArtistListViewColumnName;

	ListViewItem SelectedArtistListItem;
	ListViewItem SelectedFileListItem;
	ListView.SelectedListViewItemCollection SelectedFileListItems;

	ListViewItem AllFilesListItem;

	TListOfObjectsTIndex	ArtistDetailsMediaInfos;
	private string CurrentArtist;

	public TViewDatabaseForm(TMySQLDatabase aDb, string currentTableName, string databaseName)
	{
	    InitializeComponent();

	    ArtistDetailsMediaInfos = new TListOfObjectsTIndex();
	    db = aDb;
	    queryResult = db.QueryResult;

	    CurrentTableName = currentTableName;
	    Text = $"Viewing database {databaseName}";

	    ArtistsListViewArtistColumnHeader.Text = Program.MainForm.CurrentArtistColumnName;
	    FilesListViewArtistColumnHeader.Text = Program.MainForm.CurrentArtistColumnName;
	    CurrentArtistDBColumnName = Program.MainForm.CurrentArtistDBColumnName;
	    CurrentArtistListViewColumnName = Program.MainForm.CurrentArtistColumnName;

	    SelectedArtistListItem = null;
	    SelectedFileListItem = null;

	    SelectedFileListItems = FilesListView.SelectedItems;
	}

	private void RefreshButton_Click(object sender, EventArgs e)
	{
	    ListViewItem li;
	    TMySQLDataRow dr;
	    int i, count,totalCount=0, listViewCount;
	    string str;

//	    List<string> selectColumns = new List<string>();

	    Application.DoEvents();

//	    selectColumns.Add(CurrentArtistDBColumnName);
//	    selectColumns.Add("COUNT(*) as count");
	    count = db.ExecuteSelectQuery(CurrentTableName, $"{CurrentArtistDBColumnName}, COUNT(*) as count",
					  $"GROUP BY {CurrentArtistDBColumnName} ORDER BY {CurrentArtistDBColumnName}");

	    //	    ArtistsListView.Items.Clear();
	    listViewCount = ArtistsListView.Items.Count;

	    //		FilesListView.Items.Clear();
	    if (count < (listViewCount - 0))
	    {
		Standard.SetupListView(ArtistsListView, count, 2);
		listViewCount = count;
	    }

	    Application.DoEvents();

	    for (i = 0; i < count; i++)
	    {
		dr = queryResult.Rows[i];

		str = dr.String(0);
		/*
				if (i == 0)
				{
				    str = $"(Empty)";
				}
		*/
		if (i < listViewCount)
		{
		    li = ArtistsListView.Items[i];
		    li.Text = str;
		    li.SubItems[1].Text = dr.String(1);
		}
		else
		{
		    li = ArtistsListView.Items.Add(str);
		    li.SubItems.Add(dr.String(1));
		}

		//		li = ArtistsListView.Items.Add(str);


		totalCount += dr.Integer(1);
	    }

	    li = ArtistsListView.Items.Add("(All)");
	    li.SubItems.Add(totalCount.ToString());

	    AllFilesListItem = li;

	    Application.DoEvents();

	    ArtistsListView_SelectedIndexChanged(null, null);
	}

	private void RefreshArtistDetailsButton_Click(object sender, EventArgs e)
	{
	    ListViewItem li;
	    TMySQLDataRow dr;
	    TMediaInfo mediaInfo;
	    string whereData = null, whereColumnnName = null;

	    int i, count, listViewCount;

	    //	    if (SelectedArtistListItem is not null)
	    if (true)
	    {
		Application.DoEvents();

		if (SelectedArtistListItem != AllFilesListItem)
		{
		    whereData = SelectedArtistListItem.Text;
		    whereColumnnName = CurrentArtistDBColumnName;
		}
		//	    count = db.ExecuteQuery("SELECT * FROM {0}", CurrentTableName);
		count = db.ExecuteSelectQuery(CurrentTableName, string.Empty, $"ORDER BY {Program.MySQLTableColumn_Filename}", whereData, whereColumnnName);
		listViewCount = FilesListView.Items.Count;

		//		FilesListView.Items.Clear();
		if (count < listViewCount)
		{
		    Standard.SetupListView(FilesListView, count, Program.NumColumns);
		    listViewCount = count;
		}

		FileCountTextBox.Text = count.ToString();
		Application.DoEvents();

		int MySQLTableColumn_MediaInfoRawDataColumnIndex = queryResult.ColumnHeaders.IndexOf(Resources.MySQLTableColumn_MediaInfoRawData);
		int MySQLTableColumn_MediaInfoHumanReadableColumnIndex = queryResult.ColumnHeaders.IndexOf(Resources.MySQLTableColumn_MediaInfoHumanReadable);

		for (i = 0; i < count; i++)
		{
		    dr = queryResult.Rows[i];

		    if (i < listViewCount)
		    {
			li = FilesListView.Items[i];
		    }
		    else
		    {
			li = FilesListView.Items.Add("");

			for (int j = 0; j < Program.NumColumns; j++)
			{
			    li.SubItems.Add(string.Empty);
			}
		    }

		    mediaInfo = new TMediaInfo();
		    mediaInfo.RawDataString = dr.String(MySQLTableColumn_MediaInfoRawDataColumnIndex);
		    mediaInfo.MediaInfoString = dr.String(MySQLTableColumn_MediaInfoHumanReadableColumnIndex);

		    ArtistDetailsMediaInfos.Add(mediaInfo);

		    Program.GetFileInfoFromDatabase(dr, i, ref li, mediaInfo, CurrentArtistDBColumnName);
		}
		Application.DoEvents();
	    }
	}

	private void ViewDatabaseFormcs_Shown(object sender, EventArgs e)
	{
	    RefreshButton.PerformClick();
	}

	private void DumpColumnSizeButton_Click(object sender, EventArgs e)
	{
	    TListOfStrings columnsizes = new TListOfStrings();
	    string filename = String.Format("{0}\\ListView{1}Columns.txt", Directory.GetCurrentDirectory(), FilesListView.Name);

	    columnsizes.AddFormatted("ListView {0} Columns:",FilesListView.Name);

	    foreach (ColumnHeader item in FilesListView.Columns)
	    {
		columnsizes.AddFormatted("Column {0}: Width={1}",item.Text,item.Width);
	    }

	    columnsizes.WriteToFile(filename);
	}

	private void ArtistsListView_SelectedIndexChanged(object sender, EventArgs e)
	{
	    bool selected;
	    ListView.SelectedListViewItemCollection selectedItems = ArtistsListView.SelectedItems;

	    if (selectedItems.Count > 0)
	    {
		SelectedArtistListItem = selectedItems[0];

		selected = true;
		ClearArtistDetailsButton.Enabled = selected;
		CurrentArtist = SelectedArtistListItem.Text;
		ArtistDetailsGroupBox.Text = String.Format("{0} '{1}'", CurrentArtistListViewColumnName, CurrentArtist);

		RefreshArtistDetailsButton.Enabled = true;
		RefreshArtistDetailsButton.PerformClick();
	    }
	    else
	    {
		selected = false;
		SelectedArtistListItem = null;
		RefreshArtistDetailsButton.Enabled = selected;
	    }

	}

	private void FilesListView_SelectedIndexChanged(object sender, EventArgs e)
	{
	    bool selected;
	    
	    if (SelectedFileListItems.Count > 0)
	    {
		SelectedFileListItem = SelectedFileListItems[0];

		selected = true;
	    }
	    else
	    {
		selected = false;
		SelectedFileListItem = null;
	    }

	    ViewMediaInfoButton.Enabled = selected;
	    PlayFileButton.Enabled = selected;
	    DeleteFileItemButton.Enabled = selected;

	}

	private void ViewMediaInfoButton_Click(object sender, EventArgs e)
	{
	    TMediaInfo mediaInfo;
	    string fullfilename;

//	    if (SelectedFileListItem is not null)
	    foreach (ListViewItem item in SelectedFileListItems)
	    {
		mediaInfo = (TMediaInfo ) item.Tag;
		fullfilename = Program.GetFullFileNameFromListItem(item);

		if (mediaInfo.MediaInfoString.Length > 0)
		    Program.ViewMediaInfo(fullfilename, mediaInfo.MediaInfoString);
		else
		    Program.ViewMediaInfo(fullfilename, mediaInfo.RawDataStrings);

	    }

	}

	private void PlayFileButton_Click(object sender, EventArgs e)
	{
//	    if (SelectedFileListItem is not null)
	    foreach (ListViewItem item in SelectedFileListItems)
	    {
		string fileName = Program.GetFullFileNameFromListItem(item);

		Exec.ShellExecute(fileName);
	    }
	}

	private void DeleteFileItemButton_Click(object sender, EventArgs e)
	{
	    int i, count = SelectedFileListItems.Count;

	    if (count > 0)
	    {
		foreach (ListViewItem item in SelectedFileListItems)
		{
		    i = item.Index;

		    db.ExecuteDeleteQuery(CurrentTableName, Convert.ToUInt32(item.SubItems[21].Text));

		    ArtistDetailsMediaInfos.Remove((TMediaInfo)item.Tag);
		    FilesListView.Items.Remove(SelectedFileListItem);
		}
		FilesListView_SelectedIndexChanged(null, null);
		RefreshButton.PerformClick();
	    }
	}

	private void ClearArtistDetailsButton_Click(object sender, EventArgs e)
	{
	    if (CurrentArtist is not null && Standard.QuestionMessage("Confirm Deletion...", "Delete all {0} file(s) of {1} '{2}'?", FilesListView.Items.Count,
								      CurrentArtistListViewColumnName, CurrentArtist) == DialogResult.Yes)
	    {
		FilesListView.Items.Clear();
		ArtistDetailsMediaInfos.Clear();
		db.ExecuteDeleteQuery(CurrentTableName, CurrentArtist, CurrentArtistDBColumnName);

		CurrentArtist = null;
		ClearArtistDetailsButton.Enabled = false;
		RefreshArtistDetailsButton.Enabled = false;

		RefreshButton.PerformClick();
	    }
	}

	private void FilesListView_DoubleClick(object sender, EventArgs e)
	{
	    PlayFileButton.PerformClick();
	}

	private void FilesListView_KeyUp(object sender, KeyEventArgs e)
	{
	    string fullfilename;

	    switch (e.KeyData)
	    {
		case Keys.Delete:
		    if (e.Shift)
		    {
			foreach (ListViewItem item in SelectedFileListItems)
			{
			    fullfilename = Program.GetFullFileNameFromListItem(item);

			    if (Standard.QuestionMessage("Confirm Deletion...", "Really delete file '{0}'?", item.SubItems[2]) == DialogResult.Yes)
			    {
				File.Delete(fullfilename);
			    }
			}
		    }

		    DeleteFileItemButton.PerformClick();
		    break;
		default:
		    break;
	    }
	}

	private void TViewDatabaseForm_FormClosed(object sender, FormClosedEventArgs e)
	{
	    Program.RemoveFormFromWindowMenu(this);
	}

	private void ArtistsListView_KeyUp(object sender, KeyEventArgs e)
	{
	    switch (e.KeyData)
	    {
		case Keys.Delete:
		    ClearArtistDetailsButton.PerformClick();
		    break;
		default:
		    break;
	    }

	}
    }


}
