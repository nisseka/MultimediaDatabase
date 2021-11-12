
namespace MultimediaDatabase
{
    partial class TViewMediaInfoRawDataForm
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
	    this.MediaInfoContentGroupBox = new System.Windows.Forms.GroupBox();
	    this.MediaInfoContentRichTextBox = new System.Windows.Forms.RichTextBox();
	    this.MediaInfoContentGroupBox.SuspendLayout();
	    this.SuspendLayout();
	    // 
	    // MediaInfoContentGroupBox
	    // 
	    this.MediaInfoContentGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
	    this.MediaInfoContentGroupBox.Controls.Add(this.MediaInfoContentRichTextBox);
	    this.MediaInfoContentGroupBox.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
	    this.MediaInfoContentGroupBox.ForeColor = System.Drawing.Color.White;
	    this.MediaInfoContentGroupBox.Location = new System.Drawing.Point(9, 10);
	    this.MediaInfoContentGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
	    this.MediaInfoContentGroupBox.Name = "MediaInfoContentGroupBox";
	    this.MediaInfoContentGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
	    this.MediaInfoContentGroupBox.Size = new System.Drawing.Size(799, 839);
	    this.MediaInfoContentGroupBox.TabIndex = 0;
	    this.MediaInfoContentGroupBox.TabStop = false;
	    // 
	    // MediaInfoContentRichTextBox
	    // 
	    this.MediaInfoContentRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
	    this.MediaInfoContentRichTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
	    this.MediaInfoContentRichTextBox.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
	    this.MediaInfoContentRichTextBox.ForeColor = System.Drawing.Color.White;
	    this.MediaInfoContentRichTextBox.Location = new System.Drawing.Point(7, 29);
	    this.MediaInfoContentRichTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
	    this.MediaInfoContentRichTextBox.Name = "MediaInfoContentRichTextBox";
	    this.MediaInfoContentRichTextBox.Size = new System.Drawing.Size(785, 802);
	    this.MediaInfoContentRichTextBox.TabIndex = 1;
	    this.MediaInfoContentRichTextBox.Text = "";
	    this.MediaInfoContentRichTextBox.WordWrap = false;
	    // 
	    // TViewMediaInfoRawDataForm
	    // 
	    this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
	    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	    this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
	    this.ClientSize = new System.Drawing.Size(816, 861);
	    this.Controls.Add(this.MediaInfoContentGroupBox);
	    this.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
	    this.ForeColor = System.Drawing.SystemColors.Control;
	    this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
	    this.MinimumSize = new System.Drawing.Size(832, 900);
	    this.Name = "TViewMediaInfoRawDataForm";
	    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	    this.Text = "View MediaInfo Raw Data...";
	    this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TViewMediaInfoRawDataForm_FormClosed);
	    this.MediaInfoContentGroupBox.ResumeLayout(false);
	    this.ResumeLayout(false);

	}

	#endregion

	private System.Windows.Forms.GroupBox MediaInfoContentGroupBox;
	private System.Windows.Forms.RichTextBox MediaInfoContentRichTextBox;
    }
}