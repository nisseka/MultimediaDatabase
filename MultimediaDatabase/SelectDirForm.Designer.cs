
namespace MultimediaDatabase
{
    partial class SelectDirForm
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
	    this.SuspendLayout();
	    // 
	    // CancelButton
	    // 
	    this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
	    this.CancelButton.BackColor = System.Drawing.Color.DimGray;
	    this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
	    this.CancelButton.Image = global::MultimediaDatabase.Properties.Resources.Red_Cross;
	    this.CancelButton.Location = new System.Drawing.Point(372, 371);
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
	    this.OKButton.Image = global::MultimediaDatabase.Properties.Resources.Green_Check;
	    this.OKButton.Location = new System.Drawing.Point(238, 371);
	    this.OKButton.Name = "OKButton";
	    this.OKButton.Size = new System.Drawing.Size(113, 28);
	    this.OKButton.TabIndex = 28;
	    this.OKButton.Text = "OK";
	    this.OKButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
	    this.OKButton.UseVisualStyleBackColor = false;
	    // 
	    // SelectDirForm
	    // 
	    this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
	    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	    this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
	    this.CancelButton = this.CancelButton;
	    this.ClientSize = new System.Drawing.Size(728, 411);
	    this.Controls.Add(this.CancelButton);
	    this.Controls.Add(this.OKButton);
	    this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
	    this.ForeColor = System.Drawing.Color.White;
	    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
	    this.Name = "SelectDirForm";
	    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	    this.Text = "Select Directory...";
	    this.ResumeLayout(false);

	}

	#endregion

	private System.Windows.Forms.Button CancelButton;
	private System.Windows.Forms.Button OKButton;
    }
}