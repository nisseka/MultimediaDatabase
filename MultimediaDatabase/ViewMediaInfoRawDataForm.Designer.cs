
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
	    this.MediaInfoContentTextBox = new System.Windows.Forms.TextBox();
	    this.MediaInfoContentGroupBox.SuspendLayout();
	    this.SuspendLayout();
	    // 
	    // MediaInfoContentGroupBox
	    // 
	    this.MediaInfoContentGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
	    this.MediaInfoContentGroupBox.Controls.Add(this.MediaInfoContentTextBox);
	    this.MediaInfoContentGroupBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
	    this.MediaInfoContentGroupBox.ForeColor = System.Drawing.Color.White;
	    this.MediaInfoContentGroupBox.Location = new System.Drawing.Point(8, 8);
	    this.MediaInfoContentGroupBox.Name = "MediaInfoContentGroupBox";
	    this.MediaInfoContentGroupBox.Size = new System.Drawing.Size(699, 918);
	    this.MediaInfoContentGroupBox.TabIndex = 0;
	    this.MediaInfoContentGroupBox.TabStop = false;
	    // 
	    // MediaInfoContentTextBox
	    // 
	    this.MediaInfoContentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
	    this.MediaInfoContentTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
	    this.MediaInfoContentTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
	    this.MediaInfoContentTextBox.ForeColor = System.Drawing.SystemColors.Window;
	    this.MediaInfoContentTextBox.Location = new System.Drawing.Point(8, 16);
	    this.MediaInfoContentTextBox.Multiline = true;
	    this.MediaInfoContentTextBox.Name = "MediaInfoContentTextBox";
	    this.MediaInfoContentTextBox.ReadOnly = true;
	    this.MediaInfoContentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
	    this.MediaInfoContentTextBox.Size = new System.Drawing.Size(683, 894);
	    this.MediaInfoContentTextBox.TabIndex = 0;
	    // 
	    // TViewMediaInfoRawDataForm
	    // 
	    this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
	    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	    this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
	    this.ClientSize = new System.Drawing.Size(714, 937);
	    this.Controls.Add(this.MediaInfoContentGroupBox);
	    this.ForeColor = System.Drawing.SystemColors.Control;
	    this.MinimumSize = new System.Drawing.Size(730, 976);
	    this.Name = "TViewMediaInfoRawDataForm";
	    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	    this.Text = "View MediaInfo Raw Data...";
	    this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TViewMediaInfoRawDataForm_FormClosed);
	    this.MediaInfoContentGroupBox.ResumeLayout(false);
	    this.MediaInfoContentGroupBox.PerformLayout();
	    this.ResumeLayout(false);

	}

	#endregion

	private System.Windows.Forms.GroupBox MediaInfoContentGroupBox;
	private System.Windows.Forms.TextBox MediaInfoContentTextBox;
    }
}