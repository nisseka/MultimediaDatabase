
namespace MultimediaDatabase
{
    partial class EditDatabaseDirectoryForm
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
	    this.CancelButton = new System.Windows.Forms.Button();
	    this.OKButton = new System.Windows.Forms.Button();
	    this.WebShareURLTextBox = new System.Windows.Forms.TextBox();
	    this.WebShareURLTitleLabel = new System.Windows.Forms.Label();
	    this.URLTextBox = new System.Windows.Forms.TextBox();
	    this.URLTitleLabel = new System.Windows.Forms.Label();
	    this.DiskPathTextBox = new System.Windows.Forms.TextBox();
	    this.DiskPathTitleLabel = new System.Windows.Forms.Label();
	    this.SelectDirButton = new System.Windows.Forms.Button();
	    this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
	    this.SuspendLayout();
	    // 
	    // CancelButton
	    // 
	    this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
	    this.CancelButton.BackColor = System.Drawing.Color.DimGray;
	    this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
	    this.CancelButton.Image = global::MultimediaDatabase.Properties.Resources.Red_Cross;
	    this.CancelButton.Location = new System.Drawing.Point(290, 153);
	    this.CancelButton.Name = "CancelButton";
	    this.CancelButton.Size = new System.Drawing.Size(113, 28);
	    this.CancelButton.TabIndex = 29;
	    this.CancelButton.Text = "Cancel";
	    this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
	    this.CancelButton.UseVisualStyleBackColor = false;
	    // 
	    // OKButton
	    // 
	    this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
	    this.OKButton.BackColor = System.Drawing.Color.DimGray;
	    this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
	    this.OKButton.Enabled = false;
	    this.OKButton.Image = global::MultimediaDatabase.Properties.Resources.Green_Check;
	    this.OKButton.Location = new System.Drawing.Point(156, 153);
	    this.OKButton.Name = "OKButton";
	    this.OKButton.Size = new System.Drawing.Size(113, 28);
	    this.OKButton.TabIndex = 28;
	    this.OKButton.Text = "OK";
	    this.OKButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
	    this.OKButton.UseVisualStyleBackColor = false;
	    // 
	    // WebShareURLTextBox
	    // 
	    this.WebShareURLTextBox.BackColor = System.Drawing.Color.DimGray;
	    this.WebShareURLTextBox.ForeColor = System.Drawing.Color.White;
	    this.WebShareURLTextBox.Location = new System.Drawing.Point(162, 109);
	    this.WebShareURLTextBox.Name = "WebShareURLTextBox";
	    this.WebShareURLTextBox.Size = new System.Drawing.Size(304, 25);
	    this.WebShareURLTextBox.TabIndex = 35;
	    this.WebShareURLTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
	    // 
	    // WebShareURLTitleLabel
	    // 
	    this.WebShareURLTitleLabel.AutoSize = true;
	    this.WebShareURLTitleLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
	    this.WebShareURLTitleLabel.Location = new System.Drawing.Point(55, 112);
	    this.WebShareURLTitleLabel.Name = "WebShareURLTitleLabel";
	    this.WebShareURLTitleLabel.Size = new System.Drawing.Size(97, 17);
	    this.WebShareURLTitleLabel.TabIndex = 34;
	    this.WebShareURLTitleLabel.Text = "WebShare URL:";
	    // 
	    // URLTextBox
	    // 
	    this.URLTextBox.BackColor = System.Drawing.Color.DimGray;
	    this.URLTextBox.ForeColor = System.Drawing.Color.White;
	    this.URLTextBox.Location = new System.Drawing.Point(162, 69);
	    this.URLTextBox.Name = "URLTextBox";
	    this.URLTextBox.Size = new System.Drawing.Size(304, 25);
	    this.URLTextBox.TabIndex = 33;
	    this.URLTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
	    // 
	    // URLTitleLabel
	    // 
	    this.URLTitleLabel.AutoSize = true;
	    this.URLTitleLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
	    this.URLTitleLabel.Location = new System.Drawing.Point(118, 72);
	    this.URLTitleLabel.Name = "URLTitleLabel";
	    this.URLTitleLabel.Size = new System.Drawing.Size(34, 17);
	    this.URLTitleLabel.TabIndex = 32;
	    this.URLTitleLabel.Text = "URL:";
	    // 
	    // DiskPathTextBox
	    // 
	    this.DiskPathTextBox.BackColor = System.Drawing.Color.DimGray;
	    this.DiskPathTextBox.ForeColor = System.Drawing.Color.White;
	    this.DiskPathTextBox.Location = new System.Drawing.Point(162, 31);
	    this.DiskPathTextBox.Name = "DiskPathTextBox";
	    this.DiskPathTextBox.Size = new System.Drawing.Size(304, 25);
	    this.DiskPathTextBox.TabIndex = 31;
	    this.DiskPathTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
	    // 
	    // DiskPathTitleLabel
	    // 
	    this.DiskPathTitleLabel.AutoSize = true;
	    this.DiskPathTitleLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
	    this.DiskPathTitleLabel.Location = new System.Drawing.Point(88, 34);
	    this.DiskPathTitleLabel.Name = "DiskPathTitleLabel";
	    this.DiskPathTitleLabel.Size = new System.Drawing.Size(64, 17);
	    this.DiskPathTitleLabel.TabIndex = 30;
	    this.DiskPathTitleLabel.Text = "Disk Path:";
	    // 
	    // SelectDirButton
	    // 
	    this.SelectDirButton.BackColor = System.Drawing.Color.DimGray;
	    this.SelectDirButton.Image = global::MultimediaDatabase.Properties.Resources.Directory;
	    this.SelectDirButton.Location = new System.Drawing.Point(482, 31);
	    this.SelectDirButton.Name = "SelectDirButton";
	    this.SelectDirButton.Size = new System.Drawing.Size(27, 25);
	    this.SelectDirButton.TabIndex = 36;
	    this.SelectDirButton.UseVisualStyleBackColor = false;
	    this.SelectDirButton.Click += new System.EventHandler(this.SelectDirButton_Click);
	    // 
	    // FolderBrowserDialog
	    // 
	    this.FolderBrowserDialog.Description = "Select Directory..";
	    this.FolderBrowserDialog.UseDescriptionForTitle = true;
	    // 
	    // EditDatabaseDirectoryForm
	    // 
	    this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
	    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	    this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
	    this.ClientSize = new System.Drawing.Size(535, 193);
	    this.Controls.Add(this.SelectDirButton);
	    this.Controls.Add(this.WebShareURLTextBox);
	    this.Controls.Add(this.WebShareURLTitleLabel);
	    this.Controls.Add(this.URLTextBox);
	    this.Controls.Add(this.URLTitleLabel);
	    this.Controls.Add(this.DiskPathTextBox);
	    this.Controls.Add(this.DiskPathTitleLabel);
	    this.Controls.Add(this.CancelButton);
	    this.Controls.Add(this.OKButton);
	    this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
	    this.ForeColor = System.Drawing.Color.White;
	    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
	    this.Name = "EditDatabaseDirectoryForm";
	    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	    this.Text = "Edit Database Directory...";
	    this.Load += new System.EventHandler(this.TEditDatabaseDirectoryForm_Load);
	    this.ResumeLayout(false);
	    this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.Button CancelButton;
	private System.Windows.Forms.Button OKButton;
	private System.Windows.Forms.TextBox WebShareURLTextBox;
	private System.Windows.Forms.Label WebShareURLTitleLabel;
	private System.Windows.Forms.TextBox URLTextBox;
	private System.Windows.Forms.Label URLTitleLabel;
	private System.Windows.Forms.TextBox DiskPathTextBox;
	private System.Windows.Forms.Label DiskPathTitleLabel;
	private System.Windows.Forms.Button SelectDirButton;
	private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
    }
}