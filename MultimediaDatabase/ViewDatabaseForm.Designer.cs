
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
	    this.components = new System.ComponentModel.Container();
	    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TViewDatabaseForm));
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
	    this.ButtonsImageList = new System.Windows.Forms.ImageList(this.components);
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
	    this.FilesListView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
	    this.FilesListView.ForeColor = System.Drawing.Color.White;
	    this.FilesListView.FullRowSelect = true;
	    this.FilesListView.GridLines = true;
	    this.FilesListView.HideSelection = false;
	    this.FilesListView.Location = new System.Drawing.Point(6, 17);
	    this.FilesListView.Name = "FilesListView";
	    this.FilesListView.Size = new System.Drawing.Size(939, 630);
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
	    this.FilesListViewArtistColumnHeader.Width = 160;
	    // 
	    // FilesListViewFilenameColumnHeader
	    // 
	    this.FilesListViewFilenameColumnHeader.Text = "Filename";
	    this.FilesListViewFilenameColumnHeader.Width = 360;
	    // 
	    // FilesListViewSizeColumnHeader
	    // 
	    this.FilesListViewSizeColumnHeader.Text = "Size";
	    this.FilesListViewSizeColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	    this.FilesListViewSizeColumnHeader.Width = 80;
	    // 
	    // FilesListViewDurationColumnHeader
	    // 
	    this.FilesListViewDurationColumnHeader.Text = "Duration";
	    this.FilesListViewDurationColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	    this.FilesListViewDurationColumnHeader.Width = 110;
	    // 
	    // FilesListViewOverallBitrateColumnHeader
	    // 
	    this.FilesListViewOverallBitrateColumnHeader.Text = "Overall BitRate";
	    this.FilesListViewOverallBitrateColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	    this.FilesListViewOverallBitrateColumnHeader.Width = 90;
	    // 
	    // FilesListViewTypeColumnHeader
	    // 
	    this.FilesListViewTypeColumnHeader.Text = "Type";
	    this.FilesListViewTypeColumnHeader.Width = 100;
	    // 
	    // FilesListViewVideoFormatColumnHeader
	    // 
	    this.FilesListViewVideoFormatColumnHeader.Text = "Video Format";
	    this.FilesListViewVideoFormatColumnHeader.Width = 160;
	    // 
	    // FilesListViewResolutionColumnHeader
	    // 
	    this.FilesListViewResolutionColumnHeader.Text = "Resolution";
	    this.FilesListViewResolutionColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	    this.FilesListViewResolutionColumnHeader.Width = 80;
	    // 
	    // FilesListViewVideoBitRateColumnHeader
	    // 
	    this.FilesListViewVideoBitRateColumnHeader.Text = "Video BitRate";
	    this.FilesListViewVideoBitRateColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	    this.FilesListViewVideoBitRateColumnHeader.Width = 95;
	    // 
	    // FilesListViewFrameRateColumnHeader
	    // 
	    this.FilesListViewFrameRateColumnHeader.Text = "FrameRate";
	    this.FilesListViewFrameRateColumnHeader.Width = 80;
	    // 
	    // FilesListViewAspectRatioColumnHeader
	    // 
	    this.FilesListViewAspectRatioColumnHeader.Text = "Aspect Ratio";
	    this.FilesListViewAspectRatioColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	    this.FilesListViewAspectRatioColumnHeader.Width = 91;
	    // 
	    // FilesListViewAudioFormatColumnHeader
	    // 
	    this.FilesListViewAudioFormatColumnHeader.Text = "Audio Format";
	    this.FilesListViewAudioFormatColumnHeader.Width = 146;
	    // 
	    // FilesListViewAudioBitRateColumnHeader
	    // 
	    this.FilesListViewAudioBitRateColumnHeader.Text = "Audio Bitrate";
	    this.FilesListViewAudioBitRateColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	    this.FilesListViewAudioBitRateColumnHeader.Width = 105;
	    // 
	    // FilesListViewAudioChannelsColumnHeader
	    // 
	    this.FilesListViewAudioChannelsColumnHeader.Text = "Audio Channels";
	    this.FilesListViewAudioChannelsColumnHeader.Width = 110;
	    // 
	    // FilesListViewAudioSampleRateColumnHeader
	    // 
	    this.FilesListViewAudioSampleRateColumnHeader.Text = "Audio SampleRate";
	    this.FilesListViewAudioSampleRateColumnHeader.Width = 110;
	    // 
	    // FilesListViewAudioBitDepthColumnHeader
	    // 
	    this.FilesListViewAudioBitDepthColumnHeader.Text = "Audio Bit Depth";
	    this.FilesListViewAudioBitDepthColumnHeader.Width = 118;
	    // 
	    // FilesListViewPathColumnHeader
	    // 
	    this.FilesListViewPathColumnHeader.Text = "Path";
	    this.FilesListViewPathColumnHeader.Width = 220;
	    // 
	    // FilesListViewURLColumnHeader
	    // 
	    this.FilesListViewURLColumnHeader.Text = "URL";
	    this.FilesListViewURLColumnHeader.Width = 244;
	    // 
	    // FilesListViewWebshareURLColumnHeader
	    // 
	    this.FilesListViewWebshareURLColumnHeader.Text = "WebShareURL";
	    this.FilesListViewWebshareURLColumnHeader.Width = 244;
	    // 
	    // FilesListViewDateTimeColumnHeader
	    // 
	    this.FilesListViewDateTimeColumnHeader.Text = "Date & Time";
	    this.FilesListViewDateTimeColumnHeader.Width = 126;
	    // 
	    // FilesListViewIDColumnHeader
	    // 
	    this.FilesListViewIDColumnHeader.Text = "ID";
	    // 
	    // FilesListViewNbVideoTracksColumnHeader
	    // 
	    this.FilesListViewNbVideoTracksColumnHeader.Text = "# Video Tracks";
	    this.FilesListViewNbVideoTracksColumnHeader.Width = 90;
	    // 
	    // FilesListViewNbAudioTracksColumnHeader
	    // 
	    this.FilesListViewNbAudioTracksColumnHeader.Text = "# Audio Tracks";
	    this.FilesListViewNbAudioTracksColumnHeader.Width = 90;
	    // 
	    // FilesListViewNbSubTitleTracksColumnHeader
	    // 
	    this.FilesListViewNbSubTitleTracksColumnHeader.Text = "# Subititle Tracks";
	    this.FilesListViewNbSubTitleTracksColumnHeader.Width = 107;
	    // 
	    // FilesListViewVideoBitRateModeColumnHeader
	    // 
	    this.FilesListViewVideoBitRateModeColumnHeader.Text = "Video BitRate Mode";
	    this.FilesListViewVideoBitRateModeColumnHeader.Width = 125;
	    // 
	    // FilesListViewAudioBitRateModeColumnHeader
	    // 
	    this.FilesListViewAudioBitRateModeColumnHeader.Text = "Audio BitRate Mode";
	    this.FilesListViewAudioBitRateModeColumnHeader.Width = 133;
	    // 
	    // FilesListViewVideoChannelLayoutColumnHeader
	    // 
	    this.FilesListViewVideoChannelLayoutColumnHeader.Text = "Audio Channel Layout";
	    this.FilesListViewVideoChannelLayoutColumnHeader.Width = 140;
	    // 
	    // FilesListViewAudioChannelPositionsColumnHeader
	    // 
	    this.FilesListViewAudioChannelPositionsColumnHeader.Text = "Audio Channel Positions";
	    this.FilesListViewAudioChannelPositionsColumnHeader.Width = 160;
	    // 
	    // RefreshButton
	    // 
	    this.RefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
	    this.RefreshButton.BackColor = System.Drawing.Color.DimGray;
	    this.RefreshButton.ForeColor = System.Drawing.SystemColors.Control;
	    this.RefreshButton.Image = global::MultimediaDatabase.Properties.Resources.retry;
	    this.RefreshButton.Location = new System.Drawing.Point(12, 672);
	    this.RefreshButton.Name = "RefreshButton";
	    this.RefreshButton.Size = new System.Drawing.Size(116, 28);
	    this.RefreshButton.TabIndex = 4;
	    this.RefreshButton.Text = "Refresh";
	    this.RefreshButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
	    this.RefreshButton.UseVisualStyleBackColor = false;
	    this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
	    // 
	    // ButtonsImageList
	    // 
	    this.ButtonsImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
	    this.ButtonsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ButtonsImageList.ImageStream")));
	    this.ButtonsImageList.TransparentColor = System.Drawing.Color.Transparent;
	    this.ButtonsImageList.Images.SetKeyName(0, "clear.bmp");
	    this.ButtonsImageList.Images.SetKeyName(1, "fileopen.bmp");
	    this.ButtonsImageList.Images.SetKeyName(2, "play button.bmp");
	    this.ButtonsImageList.Images.SetKeyName(3, "Remove Item.bmp");
	    this.ButtonsImageList.Images.SetKeyName(4, "retry.bmp");
	    // 
	    // DumpColumnSizeButton
	    // 
	    this.DumpColumnSizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
	    this.DumpColumnSizeButton.BackColor = System.Drawing.Color.DimGray;
	    this.DumpColumnSizeButton.ForeColor = System.Drawing.SystemColors.Control;
	    this.DumpColumnSizeButton.Location = new System.Drawing.Point(147, 672);
	    this.DumpColumnSizeButton.Name = "DumpColumnSizeButton";
	    this.DumpColumnSizeButton.Size = new System.Drawing.Size(30, 28);
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
	    this.FileCountTextBox.Location = new System.Drawing.Point(1175, 672);
	    this.FileCountTextBox.Name = "FileCountTextBox";
	    this.FileCountTextBox.ReadOnly = true;
	    this.FileCountTextBox.Size = new System.Drawing.Size(67, 23);
	    this.FileCountTextBox.TabIndex = 6;
	    this.FileCountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	    // 
	    // FileCountTitleLabel
	    // 
	    this.FileCountTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
	    this.FileCountTitleLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
	    this.FileCountTitleLabel.Location = new System.Drawing.Point(1101, 672);
	    this.FileCountTitleLabel.Name = "FileCountTitleLabel";
	    this.FileCountTitleLabel.Size = new System.Drawing.Size(68, 23);
	    this.FileCountTitleLabel.TabIndex = 7;
	    this.FileCountTitleLabel.Text = "# of Files:";
	    this.FileCountTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
	    this.ArtistsListView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
	    this.ArtistsListView.ForeColor = System.Drawing.Color.White;
	    this.ArtistsListView.FullRowSelect = true;
	    this.ArtistsListView.GridLines = true;
	    this.ArtistsListView.HideSelection = false;
	    this.ArtistsListView.Location = new System.Drawing.Point(6, 14);
	    this.ArtistsListView.MultiSelect = false;
	    this.ArtistsListView.Name = "ArtistsListView";
	    this.ArtistsListView.Size = new System.Drawing.Size(281, 633);
	    this.ArtistsListView.TabIndex = 8;
	    this.ArtistsListView.UseCompatibleStateImageBehavior = false;
	    this.ArtistsListView.View = System.Windows.Forms.View.Details;
	    this.ArtistsListView.SelectedIndexChanged += new System.EventHandler(this.ArtistsListView_SelectedIndexChanged);
	    this.ArtistsListView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ArtistsListView_KeyUp);
	    // 
	    // ArtistsListViewArtistColumnHeader
	    // 
	    this.ArtistsListViewArtistColumnHeader.Text = "Artist";
	    this.ArtistsListViewArtistColumnHeader.Width = 200;
	    // 
	    // ArtistsListViewCountColumnHeader
	    // 
	    this.ArtistsListViewCountColumnHeader.Text = "Count";
	    this.ArtistsListViewCountColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	    this.ArtistsListViewCountColumnHeader.Width = 50;
	    // 
	    // RefreshArtistDetailsButton
	    // 
	    this.RefreshArtistDetailsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
	    this.RefreshArtistDetailsButton.BackColor = System.Drawing.Color.DimGray;
	    this.RefreshArtistDetailsButton.Enabled = false;
	    this.RefreshArtistDetailsButton.ForeColor = System.Drawing.SystemColors.Control;
	    this.RefreshArtistDetailsButton.Image = global::MultimediaDatabase.Properties.Resources.retry;
	    this.RefreshArtistDetailsButton.Location = new System.Drawing.Point(989, 671);
	    this.RefreshArtistDetailsButton.Name = "RefreshArtistDetailsButton";
	    this.RefreshArtistDetailsButton.Size = new System.Drawing.Size(116, 28);
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
	    this.ViewMediaInfoButton.Location = new System.Drawing.Point(415, 672);
	    this.ViewMediaInfoButton.Name = "ViewMediaInfoButton";
	    this.ViewMediaInfoButton.Size = new System.Drawing.Size(170, 28);
	    this.ViewMediaInfoButton.TabIndex = 10;
	    this.ViewMediaInfoButton.Text = "View MediaInfo Raw Data";
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
	    this.PlayFileButton.Location = new System.Drawing.Point(301, 672);
	    this.PlayFileButton.Name = "PlayFileButton";
	    this.PlayFileButton.Size = new System.Drawing.Size(108, 28);
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
	    this.DeleteFileItemButton.Location = new System.Drawing.Point(591, 672);
	    this.DeleteFileItemButton.Name = "DeleteFileItemButton";
	    this.DeleteFileItemButton.Size = new System.Drawing.Size(104, 28);
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
	    this.ClearArtistDetailsButton.Location = new System.Drawing.Point(876, 671);
	    this.ClearArtistDetailsButton.Name = "ClearArtistDetailsButton";
	    this.ClearArtistDetailsButton.Size = new System.Drawing.Size(107, 28);
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
	    this.ArtistDetailsGroupBox.Location = new System.Drawing.Point(301, 12);
	    this.ArtistDetailsGroupBox.Name = "ArtistDetailsGroupBox";
	    this.ArtistDetailsGroupBox.Size = new System.Drawing.Size(951, 653);
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
	    this.ArtistsGroupBox.Location = new System.Drawing.Point(2, 12);
	    this.ArtistsGroupBox.Name = "ArtistsGroupBox";
	    this.ArtistsGroupBox.Size = new System.Drawing.Size(293, 653);
	    this.ArtistsGroupBox.TabIndex = 15;
	    this.ArtistsGroupBox.TabStop = false;
	    // 
	    // TViewDatabaseForm
	    // 
	    this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
	    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	    this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
	    this.ClientSize = new System.Drawing.Size(1255, 706);
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
	    this.ForeColor = System.Drawing.SystemColors.Control;
	    this.MinimumSize = new System.Drawing.Size(1271, 745);
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
	private System.Windows.Forms.ImageList ButtonsImageList;
    }
}