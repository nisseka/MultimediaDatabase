
namespace MultimediaDatabase
{
    partial class TViewDatabaseForm
    {
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	/// Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing)
	{
	    if (disposing && (components != null))
	    {
		components.Dispose();
	    }
	    base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
	    this.FilesListView = new System.Windows.Forms.ListView();
	    this.FilesListViewTitleColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.FilesListViewArtistColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.FilesListViewFilenameColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.FilesListViewSizeColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.FilesListViewDurationColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.FilesListViewOverallBitrateColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.FilesListViewTypeColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.FilesListViewVideoFormatColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.FilesListViewResolutionColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.FilesListViewVideoBitRateColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.FilesListViewFrameRateColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.FilesListViewAspectRatioColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.FilesListViewAudioFormatColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.FilesListViewAudioBitRateColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.FilesListViewAudioChannelsColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.FilesListViewAudioSampleRateColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.FilesListViewAudioBitDepthColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.FilesListViewPathColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.FilesListViewURLColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.FilesListViewWebshareURLColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.FilesListViewDateTimeColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.FilesListViewIDColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.FilesListViewNbVideoTracksColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.FilesListViewNbAudioTracksColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.FilesListViewNbSubTitleTracksColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.FilesListViewVideoBitRateModeColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.FilesListViewAudioBitRateModeColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.FilesListViewVideoChannelLayoutColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.FilesListViewAudioChannelPositionsColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.RefreshButton = new System.Windows.Forms.Button();
	    this.DumpColumnSizeButton = new System.Windows.Forms.Button();
	    this.FileCountTextBox = new System.Windows.Forms.TextBox();
	    this.FileCountTitleLabel = new System.Windows.Forms.Label();
	    this.ArtistsListView = new System.Windows.Forms.ListView();
	    this.ArtistsListViewArtistColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.ArtistsListViewCountColumnHeader = new System.Windows.Forms.ColumnHeader();
	    this.RefreshArtistDetailsButton = new System.Windows.Forms.Button();
	    this.ViewMediaInfoButton = new System.Windows.Forms.Button();
	    this.PlayFileButton = new System.Windows.Forms.Button();
	    this.DeleteFileItemButton = new System.Windows.Forms.Button();
	    this.ClearArtistDetailsButton = new System.Windows.Forms.Button();
	    this.ArtistDetailsGroupBox = new System.Windows.Forms.GroupBox();
	    this.ArtistsGroupBox = new System.Windows.Forms.GroupBox();
	    this.ArtistDetailsGroupBox.SuspendLayout();
	    this.ArtistsGroupBox.SuspendLayout();
	    this.SuspendLayout();
	    // 
	    // FilesListView
	    // 
	    this.FilesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
	    this.FilesListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
	    this.FilesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FilesListViewTitleColumnHeader,
            this.FilesListViewArtistColumnHeader,
            this.FilesListViewFilenameColumnHeader,
            this.FilesListViewSizeColumnHeader,
            this.FilesListViewDurationColumnHeader,
            this.FilesListViewOverallBitrateColumnHeader,
            this.FilesListViewTypeColumnHeader,
            this.FilesListViewVideoFormatColumnHeader,
            this.FilesListViewResolutionColumnHeader,
            this.FilesListViewVideoBitRateColumnHeader,
            this.FilesListViewFrameRateColumnHeader,
            this.FilesListViewAspectRatioColumnHeader,
            this.FilesListViewAudioFormatColumnHeader,
            this.FilesListViewAudioBitRateColumnHeader,
            this.FilesListViewAudioChannelsColumnHeader,
            this.FilesListViewAudioSampleRateColumnHeader,
            this.FilesListViewAudioBitDepthColumnHeader,
            this.FilesListViewPathColumnHeader,
            this.FilesListViewURLColumnHeader,
            this.FilesListViewWebshareURLColumnHeader,
            this.FilesListViewDateTimeColumnHeader,
            this.FilesListViewIDColumnHeader,
            this.FilesListViewNbVideoTracksColumnHeader,
            this.FilesListViewNbAudioTracksColumnHeader,
            this.FilesListViewNbSubTitleTracksColumnHeader,
            this.FilesListViewVideoBitRateModeColumnHeader,
            this.FilesListViewAudioBitRateModeColumnHeader,
            this.FilesListViewVideoChannelLayoutColumnHeader,
            this.FilesListViewAudioChannelPositionsColumnHeader});
	    this.FilesListView.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
	    this.FilesListView.ForeColor = System.Drawing.Color.White;
	    this.FilesListView.FullRowSelect = true;
	    this.FilesListView.GridLines = true;
	    this.FilesListView.HideSelection = false;
	    this.FilesListView.Location = new System.Drawing.Point(7, 20);
	    this.FilesListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
	    this.FilesListView.Name = "FilesListView";
	    this.FilesListView.Size = new System.Drawing.Size(1117, 755);
	    this.FilesListView.TabIndex = 3;
	    this.FilesListView.UseCompatibleStateImageBehavior = false;
	    this.FilesListView.View = System.Windows.Forms.View.Details;
	    this.FilesListView.SelectedIndexChanged += new System.EventHandler(this.FilesListView_SelectedIndexChanged);
	    this.FilesListView.DoubleClick += new System.EventHandler(this.FilesListView_DoubleClick);
	    this.FilesListView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FilesListView_KeyUp);
	    // 
	    // FilesListViewTitleColumnHeader
	    // 
	    this.FilesListViewTitleColumnHeader.Text = "Title";
	    this.FilesListViewTitleColumnHeader.Width = 300;
	    // 
	    // FilesListViewArtistColumnHeader
	    // 
	    this.FilesListViewArtistColumnHeader.Text = "Artist";
	    this.FilesListViewArtistColumnHeader.Width = 234;
	    // 
	    // FilesListViewFilenameColumnHeader
	    // 
	    this.FilesListViewFilenameColumnHeader.Text = "Filename";
	    this.FilesListViewFilenameColumnHeader.Width = 451;
	    // 
	    // FilesListViewSizeColumnHeader
	    // 
	    this.FilesListViewSizeColumnHeader.Text = "Size";
	    this.FilesListViewSizeColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	    this.FilesListViewSizeColumnHeader.Width = 120;
	    // 
	    // FilesListViewDurationColumnHeader
	    // 
	    this.FilesListViewDurationColumnHeader.Text = "Duration";
	    this.FilesListViewDurationColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	    this.FilesListViewDurationColumnHeader.Width = 147;
	    // 
	    // FilesListViewOverallBitrateColumnHeader
	    // 
	    this.FilesListViewOverallBitrateColumnHeader.Text = "Overall BitRate";
	    this.FilesListViewOverallBitrateColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	    this.FilesListViewOverallBitrateColumnHeader.Width = 142;
	    // 
	    // FilesListViewTypeColumnHeader
	    // 
	    this.FilesListViewTypeColumnHeader.Text = "Type";
	    this.FilesListViewTypeColumnHeader.Width = 110;
	    // 
	    // FilesListViewVideoFormatColumnHeader
	    // 
	    this.FilesListViewVideoFormatColumnHeader.Text = "Video Format";
	    this.FilesListViewVideoFormatColumnHeader.Width = 200;
	    // 
	    // FilesListViewResolutionColumnHeader
	    // 
	    this.FilesListViewResolutionColumnHeader.Text = "Resolution";
	    this.FilesListViewResolutionColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	    this.FilesListViewResolutionColumnHeader.Width = 122;
	    // 
	    // FilesListViewVideoBitRateColumnHeader
	    // 
	    this.FilesListViewVideoBitRateColumnHeader.Text = "Video BitRate";
	    this.FilesListViewVideoBitRateColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	    this.FilesListViewVideoBitRateColumnHeader.Width = 162;
	    // 
	    // FilesListViewFrameRateColumnHeader
	    // 
	    this.FilesListViewFrameRateColumnHeader.Text = "FrameRate";
	    this.FilesListViewFrameRateColumnHeader.Width = 105;
	    // 
	    // FilesListViewAspectRatioColumnHeader
	    // 
	    this.FilesListViewAspectRatioColumnHeader.Text = "Aspect Ratio";
	    this.FilesListViewAspectRatioColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	    this.FilesListViewAspectRatioColumnHeader.Width = 131;
	    // 
	    // FilesListViewAudioFormatColumnHeader
	    // 
	    this.FilesListViewAudioFormatColumnHeader.Text = "Audio Format";
	    this.FilesListViewAudioFormatColumnHeader.Width = 187;
	    // 
	    // FilesListViewAudioBitRateColumnHeader
	    // 
	    this.FilesListViewAudioBitRateColumnHeader.Text = "Audio Bitrate";
	    this.FilesListViewAudioBitRateColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	    this.FilesListViewAudioBitRateColumnHeader.Width = 135;
	    // 
	    // FilesListViewAudioChannelsColumnHeader
	    // 
	    this.FilesListViewAudioChannelsColumnHeader.Text = "Audio Channels";
	    this.FilesListViewAudioChannelsColumnHeader.Width = 143;
	    // 
	    // FilesListViewAudioSampleRateColumnHeader
	    // 
	    this.FilesListViewAudioSampleRateColumnHeader.Text = "Audio SampleRate";
	    this.FilesListViewAudioSampleRateColumnHeader.Width = 157;
	    // 
	    // FilesListViewAudioBitDepthColumnHeader
	    // 
	    this.FilesListViewAudioBitDepthColumnHeader.Text = "Audio Bit Depth";
	    this.FilesListViewAudioBitDepthColumnHeader.Width = 152;
	    // 
	    // FilesListViewPathColumnHeader
	    // 
	    this.FilesListViewPathColumnHeader.Text = "Path";
	    this.FilesListViewPathColumnHeader.Width = 380;
	    // 
	    // FilesListViewURLColumnHeader
	    // 
	    this.FilesListViewURLColumnHeader.Text = "URL";
	    this.FilesListViewURLColumnHeader.Width = 430;
	    // 
	    // FilesListViewWebshareURLColumnHeader
	    // 
	    this.FilesListViewWebshareURLColumnHeader.Text = "WebShareURL";
	    this.FilesListViewWebshareURLColumnHeader.Width = 430;
	    // 
	    // FilesListViewDateTimeColumnHeader
	    // 
	    this.FilesListViewDateTimeColumnHeader.Text = "Date & Time";
	    this.FilesListViewDateTimeColumnHeader.Width = 192;
	    // 
	    // FilesListViewIDColumnHeader
	    // 
	    this.FilesListViewIDColumnHeader.Text = "ID";
	    // 
	    // FilesListViewNbVideoTracksColumnHeader
	    // 
	    this.FilesListViewNbVideoTracksColumnHeader.Text = "# Video Tracks";
	    this.FilesListViewNbVideoTracksColumnHeader.Width = 145;
	    // 
	    // FilesListViewNbAudioTracksColumnHeader
	    // 
	    this.FilesListViewNbAudioTracksColumnHeader.Text = "# Audio Tracks";
	    this.FilesListViewNbAudioTracksColumnHeader.Width = 145;
	    // 
	    // FilesListViewNbSubTitleTracksColumnHeader
	    // 
	    this.FilesListViewNbSubTitleTracksColumnHeader.Text = "# Subtitle Tracks";
	    this.FilesListViewNbSubTitleTracksColumnHeader.Width = 180;
	    // 
	    // FilesListViewVideoBitRateModeColumnHeader
	    // 
	    this.FilesListViewVideoBitRateModeColumnHeader.Text = "Video BitRate Mode";
	    this.FilesListViewVideoBitRateModeColumnHeader.Width = 170;
	    // 
	    // FilesListViewAudioBitRateModeColumnHeader
	    // 
	    this.FilesListViewAudioBitRateModeColumnHeader.Text = "Audio BitRate Mode";
	    this.FilesListViewAudioBitRateModeColumnHeader.Width = 170;
	    // 
	    // FilesListViewVideoChannelLayoutColumnHeader
	    // 
	    this.FilesListViewVideoChannelLayoutColumnHeader.Text = "Audio Channel Layout";
	    this.FilesListViewVideoChannelLayoutColumnHeader.Width = 182;
	    // 
	    // FilesListViewAudioChannelPositionsColumnHeader
	    // 
	    this.FilesListViewAudioChannelPositionsColumnHeader.Text = "Audio Channel Positions";
	    this.FilesListViewAudioChannelPositionsColumnHeader.Width = 224;
	    // 
	    // RefreshButton
	    // 
	    this.RefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
	    this.RefreshButton.BackColor = System.Drawing.Color.DimGray;
	    this.RefreshButton.ForeColor = System.Drawing.SystemColors.Control;
	    this.RefreshButton.Image = global::MultimediaDatabase.Properties.Resources.retry;
	    this.RefreshButton.Location = new System.Drawing.Point(14, 806);
	    this.RefreshButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
	    this.RefreshButton.Name = "RefreshButton";
	    this.RefreshButton.Size = new System.Drawing.Size(133, 34);
	    this.RefreshButton.TabIndex = 4;
	    this.RefreshButton.Text = "Refresh";
	    this.RefreshButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
	    this.RefreshButton.UseVisualStyleBackColor = false;
	    this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
	    // 
	    // DumpColumnSizeButton
	    // 
	    this.DumpColumnSizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
	    this.DumpColumnSizeButton.BackColor = System.Drawing.Color.DimGray;
	    this.DumpColumnSizeButton.ForeColor = System.Drawing.SystemColors.Control;
	    this.DumpColumnSizeButton.Location = new System.Drawing.Point(168, 806);
	    this.DumpColumnSizeButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
	    this.DumpColumnSizeButton.Name = "DumpColumnSizeButton";
	    this.DumpColumnSizeButton.Size = new System.Drawing.Size(34, 34);
	    this.DumpColumnSizeButton.TabIndex = 5;
	    this.DumpColumnSizeButton.Text = "d";
	    this.DumpColumnSizeButton.UseVisualStyleBackColor = false;
	    this.DumpColumnSizeButton.Click += new System.EventHandler(this.DumpColumnSizeButton_Click);
	    // 
	    // FileCountTextBox
	    // 
	    this.FileCountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
	    this.FileCountTextBox.BackColor = System.Drawing.Color.DimGray;
	    this.FileCountTextBox.ForeColor = System.Drawing.SystemColors.Control;
	    this.FileCountTextBox.Location = new System.Drawing.Point(1428, 811);
	    this.FileCountTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
	    this.FileCountTextBox.Name = "FileCountTextBox";
	    this.FileCountTextBox.ReadOnly = true;
	    this.FileCountTextBox.Size = new System.Drawing.Size(76, 25);
	    this.FileCountTextBox.TabIndex = 6;
	    this.FileCountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	    // 
	    // FileCountTitleLabel
	    // 
	    this.FileCountTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
	    this.FileCountTitleLabel.AutoSize = true;
	    this.FileCountTitleLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
	    this.FileCountTitleLabel.Location = new System.Drawing.Point(1324, 814);
	    this.FileCountTitleLabel.Name = "FileCountTitleLabel";
	    this.FileCountTitleLabel.Size = new System.Drawing.Size(96, 18);
	    this.FileCountTitleLabel.TabIndex = 7;
	    this.FileCountTitleLabel.Text = "# of Files:";
	    this.FileCountTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
	    // 
	    // ArtistsListView
	    // 
	    this.ArtistsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
	    this.ArtistsListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
	    this.ArtistsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ArtistsListViewArtistColumnHeader,
            this.ArtistsListViewCountColumnHeader});
	    this.ArtistsListView.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
	    this.ArtistsListView.ForeColor = System.Drawing.Color.White;
	    this.ArtistsListView.FullRowSelect = true;
	    this.ArtistsListView.GridLines = true;
	    this.ArtistsListView.HideSelection = false;
	    this.ArtistsListView.Location = new System.Drawing.Point(7, 17);
	    this.ArtistsListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
	    this.ArtistsListView.MultiSelect = false;
	    this.ArtistsListView.Name = "ArtistsListView";
	    this.ArtistsListView.Size = new System.Drawing.Size(351, 759);
	    this.ArtistsListView.TabIndex = 8;
	    this.ArtistsListView.UseCompatibleStateImageBehavior = false;
	    this.ArtistsListView.View = System.Windows.Forms.View.Details;
	    this.ArtistsListView.SelectedIndexChanged += new System.EventHandler(this.ArtistsListView_SelectedIndexChanged);
	    this.ArtistsListView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ArtistsListView_KeyUp);
	    // 
	    // ArtistsListViewArtistColumnHeader
	    // 
	    this.ArtistsListViewArtistColumnHeader.Text = "Artist";
	    this.ArtistsListViewArtistColumnHeader.Width = 250;
	    // 
	    // ArtistsListViewCountColumnHeader
	    // 
	    this.ArtistsListViewCountColumnHeader.Text = "Count";
	    this.ArtistsListViewCountColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	    this.ArtistsListViewCountColumnHeader.Width = 70;
	    // 
	    // RefreshArtistDetailsButton
	    // 
	    this.RefreshArtistDetailsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
	    this.RefreshArtistDetailsButton.BackColor = System.Drawing.Color.DimGray;
	    this.RefreshArtistDetailsButton.Enabled = false;
	    this.RefreshArtistDetailsButton.ForeColor = System.Drawing.SystemColors.Control;
	    this.RefreshArtistDetailsButton.Image = global::MultimediaDatabase.Properties.Resources.retry;
	    this.RefreshArtistDetailsButton.Location = new System.Drawing.Point(1173, 806);
	    this.RefreshArtistDetailsButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
	    this.RefreshArtistDetailsButton.Name = "RefreshArtistDetailsButton";
	    this.RefreshArtistDetailsButton.Size = new System.Drawing.Size(133, 34);
	    this.RefreshArtistDetailsButton.TabIndex = 9;
	    this.RefreshArtistDetailsButton.Text = "Refresh";
	    this.RefreshArtistDetailsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
	    this.RefreshArtistDetailsButton.UseVisualStyleBackColor = false;
	    this.RefreshArtistDetailsButton.Click += new System.EventHandler(this.RefreshArtistDetailsButton_Click);
	    // 
	    // ViewMediaInfoButton
	    // 
	    this.ViewMediaInfoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
	    this.ViewMediaInfoButton.BackColor = System.Drawing.Color.DimGray;
	    this.ViewMediaInfoButton.Enabled = false;
	    this.ViewMediaInfoButton.ForeColor = System.Drawing.SystemColors.Control;
	    this.ViewMediaInfoButton.Image = global::MultimediaDatabase.Properties.Resources.fileopen;
	    this.ViewMediaInfoButton.Location = new System.Drawing.Point(474, 806);
	    this.ViewMediaInfoButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
	    this.ViewMediaInfoButton.Name = "ViewMediaInfoButton";
	    this.ViewMediaInfoButton.Size = new System.Drawing.Size(191, 34);
	    this.ViewMediaInfoButton.TabIndex = 10;
	    this.ViewMediaInfoButton.Text = "View MediaInfo";
	    this.ViewMediaInfoButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
	    this.ViewMediaInfoButton.UseVisualStyleBackColor = false;
	    this.ViewMediaInfoButton.Click += new System.EventHandler(this.ViewMediaInfoButton_Click);
	    // 
	    // PlayFileButton
	    // 
	    this.PlayFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
	    this.PlayFileButton.BackColor = System.Drawing.Color.DimGray;
	    this.PlayFileButton.Enabled = false;
	    this.PlayFileButton.ForeColor = System.Drawing.SystemColors.Control;
	    this.PlayFileButton.Image = global::MultimediaDatabase.Properties.Resources.play_button;
	    this.PlayFileButton.Location = new System.Drawing.Point(344, 806);
	    this.PlayFileButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
	    this.PlayFileButton.Name = "PlayFileButton";
	    this.PlayFileButton.Size = new System.Drawing.Size(123, 34);
	    this.PlayFileButton.TabIndex = 11;
	    this.PlayFileButton.Text = "Play";
	    this.PlayFileButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
	    this.PlayFileButton.UseVisualStyleBackColor = false;
	    this.PlayFileButton.Click += new System.EventHandler(this.PlayFileButton_Click);
	    // 
	    // DeleteFileItemButton
	    // 
	    this.DeleteFileItemButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
	    this.DeleteFileItemButton.BackColor = System.Drawing.Color.DimGray;
	    this.DeleteFileItemButton.Enabled = false;
	    this.DeleteFileItemButton.ForeColor = System.Drawing.SystemColors.Control;
	    this.DeleteFileItemButton.Image = global::MultimediaDatabase.Properties.Resources.Remove_Item;
	    this.DeleteFileItemButton.Location = new System.Drawing.Point(671, 806);
	    this.DeleteFileItemButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
	    this.DeleteFileItemButton.Name = "DeleteFileItemButton";
	    this.DeleteFileItemButton.Size = new System.Drawing.Size(119, 34);
	    this.DeleteFileItemButton.TabIndex = 12;
	    this.DeleteFileItemButton.Text = "Delete";
	    this.DeleteFileItemButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
	    this.DeleteFileItemButton.UseVisualStyleBackColor = false;
	    this.DeleteFileItemButton.Click += new System.EventHandler(this.DeleteFileItemButton_Click);
	    // 
	    // ClearArtistDetailsButton
	    // 
	    this.ClearArtistDetailsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
	    this.ClearArtistDetailsButton.BackColor = System.Drawing.Color.DimGray;
	    this.ClearArtistDetailsButton.Enabled = false;
	    this.ClearArtistDetailsButton.ForeColor = System.Drawing.SystemColors.Control;
	    this.ClearArtistDetailsButton.Image = global::MultimediaDatabase.Properties.Resources.clear;
	    this.ClearArtistDetailsButton.Location = new System.Drawing.Point(1044, 806);
	    this.ClearArtistDetailsButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
	    this.ClearArtistDetailsButton.Name = "ClearArtistDetailsButton";
	    this.ClearArtistDetailsButton.Size = new System.Drawing.Size(122, 34);
	    this.ClearArtistDetailsButton.TabIndex = 13;
	    this.ClearArtistDetailsButton.Text = "Clear";
	    this.ClearArtistDetailsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
	    this.ClearArtistDetailsButton.UseVisualStyleBackColor = false;
	    this.ClearArtistDetailsButton.Click += new System.EventHandler(this.ClearArtistDetailsButton_Click);
	    // 
	    // ArtistDetailsGroupBox
	    // 
	    this.ArtistDetailsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
	    this.ArtistDetailsGroupBox.Controls.Add(this.FilesListView);
	    this.ArtistDetailsGroupBox.ForeColor = System.Drawing.Color.White;
	    this.ArtistDetailsGroupBox.Location = new System.Drawing.Point(373, 14);
	    this.ArtistDetailsGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
	    this.ArtistDetailsGroupBox.Name = "ArtistDetailsGroupBox";
	    this.ArtistDetailsGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
	    this.ArtistDetailsGroupBox.Size = new System.Drawing.Size(1131, 784);
	    this.ArtistDetailsGroupBox.TabIndex = 14;
	    this.ArtistDetailsGroupBox.TabStop = false;
	    this.ArtistDetailsGroupBox.Text = "Artist";
	    // 
	    // ArtistsGroupBox
	    // 
	    this.ArtistsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
	    this.ArtistsGroupBox.Controls.Add(this.ArtistsListView);
	    this.ArtistsGroupBox.ForeColor = System.Drawing.Color.White;
	    this.ArtistsGroupBox.Location = new System.Drawing.Point(2, 14);
	    this.ArtistsGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
	    this.ArtistsGroupBox.Name = "ArtistsGroupBox";
	    this.ArtistsGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
	    this.ArtistsGroupBox.Size = new System.Drawing.Size(365, 784);
	    this.ArtistsGroupBox.TabIndex = 15;
	    this.ArtistsGroupBox.TabStop = false;
	    // 
	    // TViewDatabaseForm
	    // 
	    this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
	    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	    this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
	    this.ClientSize = new System.Drawing.Size(1514, 847);
	    this.Controls.Add(this.ArtistsGroupBox);
	    this.Controls.Add(this.ArtistDetailsGroupBox);
	    this.Controls.Add(this.ClearArtistDetailsButton);
	    this.Controls.Add(this.DeleteFileItemButton);
	    this.Controls.Add(this.PlayFileButton);
	    this.Controls.Add(this.ViewMediaInfoButton);
	    this.Controls.Add(this.RefreshArtistDetailsButton);
	    this.Controls.Add(this.FileCountTitleLabel);
	    this.Controls.Add(this.FileCountTextBox);
	    this.Controls.Add(this.DumpColumnSizeButton);
	    this.Controls.Add(this.RefreshButton);
	    this.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
	    this.ForeColor = System.Drawing.SystemColors.Control;
	    this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
	    this.MinimumSize = new System.Drawing.Size(1530, 886);
	    this.Name = "TViewDatabaseForm";
	    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	    this.Text = "View Database...";
	    this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TViewDatabaseForm_FormClosed);
	    this.Shown += new System.EventHandler(this.ViewDatabaseFormcs_Shown);
	    this.ArtistDetailsGroupBox.ResumeLayout(false);
	    this.ArtistsGroupBox.ResumeLayout(false);
	    this.ResumeLayout(false);
	    this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.ListView FilesListView;
	private System.Windows.Forms.ColumnHeader FilesListViewTitleColumnHeader;
	private System.Windows.Forms.ColumnHeader FilesListViewArtistColumnHeader;
	private System.Windows.Forms.ColumnHeader FilesListViewFilenameColumnHeader;
	private System.Windows.Forms.ColumnHeader FilesListViewSizeColumnHeader;
	private System.Windows.Forms.ColumnHeader FilesListViewDurationColumnHeader;
	private System.Windows.Forms.ColumnHeader FilesListViewOverallBitrateColumnHeader;
	private System.Windows.Forms.ColumnHeader FilesListViewTypeColumnHeader;
	private System.Windows.Forms.ColumnHeader FilesListViewVideoFormatColumnHeader;
	private System.Windows.Forms.ColumnHeader FilesListViewResolutionColumnHeader;
	private System.Windows.Forms.ColumnHeader FilesListViewVideoBitRateColumnHeader;
	private System.Windows.Forms.ColumnHeader FilesListViewFrameRateColumnHeader;
	private System.Windows.Forms.ColumnHeader FilesListViewAspectRatioColumnHeader;
	private System.Windows.Forms.ColumnHeader FilesListViewAudioFormatColumnHeader;
	private System.Windows.Forms.ColumnHeader FilesListViewAudioBitRateColumnHeader;
	private System.Windows.Forms.ColumnHeader FilesListViewAudioChannelsColumnHeader;
	private System.Windows.Forms.ColumnHeader FilesListViewAudioSampleRateColumnHeader;
	private System.Windows.Forms.ColumnHeader FilesListViewAudioBitDepthColumnHeader;
	private System.Windows.Forms.ColumnHeader FilesListViewPathColumnHeader;
	private System.Windows.Forms.ColumnHeader FilesListViewURLColumnHeader;
	private System.Windows.Forms.ColumnHeader FilesListViewWebshareURLColumnHeader;
	private System.Windows.Forms.ColumnHeader FilesListViewDateTimeColumnHeader;
	private System.Windows.Forms.ColumnHeader FilesListViewIDColumnHeader;
	private System.Windows.Forms.ColumnHeader FilesListViewNbVideoTracksColumnHeader;
	private System.Windows.Forms.ColumnHeader FilesListViewNbAudioTracksColumnHeader;
	private System.Windows.Forms.ColumnHeader FilesListViewNbSubTitleTracksColumnHeader;
	private System.Windows.Forms.ColumnHeader FilesListViewVideoBitRateModeColumnHeader;
	private System.Windows.Forms.ColumnHeader FilesListViewAudioBitRateModeColumnHeader;
	private System.Windows.Forms.ColumnHeader FilesListViewVideoChannelLayoutColumnHeader;
	private System.Windows.Forms.ColumnHeader FilesListViewAudioChannelPositionsColumnHeader;
	private System.Windows.Forms.Button RefreshButton;
	private System.Windows.Forms.Button DumpColumnSizeButton;
	private System.Windows.Forms.TextBox FileCountTextBox;
	private System.Windows.Forms.Label FileCountTitleLabel;
	private System.Windows.Forms.ListView ArtistsListView;
	private System.Windows.Forms.ColumnHeader ArtistsListViewArtistColumnHeader;
	private System.Windows.Forms.ColumnHeader ArtistsListViewCountColumnHeader;
	private System.Windows.Forms.Button RefreshArtistDetailsButton;
	private System.Windows.Forms.Button ViewMediaInfoButton;
	private System.Windows.Forms.Button PlayFileButton;
	private System.Windows.Forms.Button DeleteFileItemButton;
	private System.Windows.Forms.Button ClearArtistDetailsButton;
	private System.Windows.Forms.GroupBox ArtistDetailsGroupBox;
	private System.Windows.Forms.GroupBox ArtistsGroupBox;
    }
}