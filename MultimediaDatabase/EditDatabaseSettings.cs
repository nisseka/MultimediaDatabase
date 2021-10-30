using MultimediaDatabase.Properties;
using MySql.Extended;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultimediaDatabase
{
    public partial class TEditDatabaseSettings : Form
    {
	private TMySQLDatabase db;
	private TMySQLQueryResult MySQLQueryResult;

	public TEditDatabaseSettings(TMySQLDatabase aDB)
	{
	    InitializeComponent();

	    db = aDB;
	    MySQLQueryResult = db.QueryResult;

	    DatabaseFileTypesComboBox.Items.AddRange(MySQL.MultimediaFileTypeStrings);
	}

	public bool Edit(TMultimediaDatabase aDatabase)
	{
	    bool changed = false;

	    DatabaseTitleTextBox.Text = aDatabase.Name;
	    DatabaseTableNameComboBox.Text = aDatabase.TableName;
	    DatabaseModeNameTextBox.Text = aDatabase.ModeString;
	    DatabaseArtistColumnNameTextBox.Text = aDatabase.ArtistColumnName;
	    DatabaseArtistDBColumnNameTextBox.Text = aDatabase.ArtistDBColumnName;
	    DatabaseFileTypesComboBox.SelectedIndex = (int) aDatabase.FileType;

	    DatabaseModeNameTextBox.ReadOnly = true;
	    Text = String.Format("Edit Database '{0}' Settings...",aDatabase.Name);

	    if (ShowDialog() == DialogResult.OK)
	    {
		if (DatabaseTitleTextBox.Text != aDatabase.Name)
		{
		    aDatabase.Name = DatabaseTitleTextBox.Text;
		    changed = true;
		} 
		if (DatabaseTableNameComboBox.Text != aDatabase.TableName)
		{
		    aDatabase.TableName = DatabaseTableNameComboBox.Text;
		    changed = true;
		}
/*
		if (DatabaseModeNameTextBox.Text != aDatabase.ModeString)
		{
		    aDatabase.ModeString = DatabaseModeNameTextBox.Text;
		    changed = true;
		}
*/
		if (DatabaseArtistColumnNameTextBox.Text != aDatabase.ArtistColumnName)
		{
		    aDatabase.ArtistColumnName = DatabaseArtistColumnNameTextBox.Text;
		    changed = true;
		}
		if (DatabaseArtistDBColumnNameTextBox.Text != aDatabase.ArtistDBColumnName)
		{
		    aDatabase.ArtistDBColumnName = DatabaseArtistDBColumnNameTextBox.Text;
		    changed = true;
		}
		if (DatabaseFileTypesComboBox.Text != aDatabase.FileTypeString)
		{
		    aDatabase.FileType = (TMMFileTypeEn)DatabaseFileTypesComboBox.SelectedIndex;
		    changed = true;
		}
	    }
	    return changed;
	}

	public TMultimediaDatabase AddDatabase()
	{
	    TMultimediaDatabase multimediaDatabaseObj = null;

	    DatabaseTitleTextBox.Text = string.Empty;
	    DatabaseTableNameComboBox.Text = string.Empty;
	    DatabaseModeNameTextBox.Text = string.Empty;
	    DatabaseArtistColumnNameTextBox.Text = string.Empty;
	    DatabaseArtistDBColumnNameTextBox.Text = string.Empty;
	    DatabaseFileTypesComboBox.SelectedIndex = 0;

	    DatabaseModeNameTextBox.ReadOnly = false;

	    if (ShowDialog() == DialogResult.OK)
	    {
		multimediaDatabaseObj = new TMultimediaDatabase();

		multimediaDatabaseObj.Name = DatabaseTitleTextBox.Text;
		multimediaDatabaseObj.TableName = DatabaseTableNameComboBox.Text;
		multimediaDatabaseObj.ArtistColumnName = DatabaseArtistColumnNameTextBox.Text;
		multimediaDatabaseObj.ArtistDBColumnName = DatabaseArtistDBColumnNameTextBox.Text;
		multimediaDatabaseObj.ModeString = DatabaseModeNameTextBox.Text;
		multimediaDatabaseObj.FileType = (TMMFileTypeEn) DatabaseFileTypesComboBox.SelectedIndex;
	    }

	    return multimediaDatabaseObj;
	}

	private void TEditDatabaseSettings_Shown(object sender, EventArgs e)
	{
	    int i, c;
	    TMySQLDataRow dr;
	    string str;
	    int tableNameColumnIndex = 0;

	    c = db.ExecuteSelectQuery(Resources.DBS_TableName, string.Empty, $"ORDER BY {Program.MySQLTableColumn_Title}");

	    tableNameColumnIndex = MySQLQueryResult.ColumnHeaders.IndexOf("DatabaseTableName");

	    DatabaseTableNameComboBox.Items.Clear();

	    for (i = 0; i < c; i++)
	    {
		dr = MySQLQueryResult.Rows[i];
		str = dr.String(tableNameColumnIndex);

		DatabaseTableNameComboBox.Items.Add(str);
	    }
	}
    }
}
