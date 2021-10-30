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
    public partial class EditDatabaseDirectoryForm : Form
    {
	public EditDatabaseDirectoryForm()
	{
	    InitializeComponent();
	}

	private void TEditDatabaseDirectoryForm_Load(object sender, EventArgs e)
	{

	}

	private void SelectDirButton_Click(object sender, EventArgs e)
	{
	    string dir = DiskPathTextBox.Text;

	    FolderBrowserDialog.SelectedPath = dir;

	    if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
	    {
		DiskPathTextBox.Text = FolderBrowserDialog.SelectedPath;
	    }

	}

	public bool EditDirectoryEntry(ref string aDirectory, ref string aURL, ref string aWebShareURL)
	{
	    bool r = false;

	    Text = "Edit Directory..";
	    DiskPathTextBox.Text = aDirectory;
	    URLTextBox.Text = aURL;
	    WebShareURLTextBox.Text = aWebShareURL;

	    if (ShowDialog() == DialogResult.OK)
	    {
		aDirectory = DiskPathTextBox.Text;
		aURL = URLTextBox.Text;
		aWebShareURL = WebShareURLTextBox.Text;
		r = true;
	    }

	    return r;
	}

	public bool AddDirectoryEntry(ref string    aDirectory, ref string  aURL, ref string	aWebShareURL)
	{
	    bool r = false;

	    Text = "Add Directory..";
	    URLTextBox.Text = aURL;
	    WebShareURLTextBox.Text = aWebShareURL;

	    SelectDirButton_Click(SelectDirButton,null);

	    if (ShowDialog() == DialogResult.OK)
	    {
		aDirectory = DiskPathTextBox.Text;
		aURL = URLTextBox.Text;
		aWebShareURL = WebShareURLTextBox.Text;
		r = true;
	    }

	    return r;
	}

	private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
	{
	    bool en = DiskPathTextBox.Text.Length > 0 && URLTextBox.Text.Length > 0 && WebShareURLTextBox.Text.Length > 0 ? true : false;

	    OKButton.Enabled = en;
	}
    }

    public partial class Program
    {

    }
}
