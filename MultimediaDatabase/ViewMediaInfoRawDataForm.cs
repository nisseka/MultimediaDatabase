using Strings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultimediaDatabase
{
    public partial class TViewMediaInfoRawDataForm : Form
    {
	public TViewMediaInfoRawDataForm()
	{
	    InitializeComponent();
	}

	//---------------------------------------------------------------------------
	public int Execute(string Filename, TListOfStrings mediaInfoStrings)
	{
	    int r = 1;

	    MediaInfoContentGroupBox.Text = Filename;
	    Text = String.Format("View MediaInfo Raw Data for {0}...", Path.GetFileName(Filename));

	    MediaInfoContentRichTextBox.Lines = mediaInfoStrings.ToArray();

	    Show();

	    MediaInfoContentRichTextBox.SelectionLength = 0;
	    return r;
	}

	private void TViewMediaInfoRawDataForm_FormClosed(object sender, FormClosedEventArgs e)
	{
	    Program.RemoveFormFromWindowMenu(this);
	}
    }

    partial class Program
    {
	public static int ViewMediaInfo(string Filename, TListOfStrings mediaInfoStrings)
	{
	    int r;
	    TViewMediaInfoRawDataForm vmiform = new TViewMediaInfoRawDataForm();

	    r = vmiform.Execute(Filename, mediaInfoStrings);

	    AddFormToWindowMenu(vmiform);

	    return r;
	}

	public static int ViewMediaInfo(string Filename, string mediaInfoString)
	{
	    TListOfStrings mediaInfoStrings = new TListOfStrings(mediaInfoString,"\r\n");

	    return ViewMediaInfo(Filename, mediaInfoStrings);
	}
    }
}
