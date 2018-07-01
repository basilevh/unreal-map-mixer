namespace UnrealMapMixer
{
    partial class frmMapLayout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMapLayout));
            this.picLayout = new System.Windows.Forms.PictureBox();
            this.lblWarning = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLayout)).BeginInit();
            this.SuspendLayout();
            // 
            // picLayout
            // 
            this.picLayout.BackColor = System.Drawing.Color.Gray;
            this.picLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLayout.Location = new System.Drawing.Point(0, 0);
            this.picLayout.Name = "picLayout";
            this.picLayout.Size = new System.Drawing.Size(784, 561);
            this.picLayout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLayout.TabIndex = 0;
            this.picLayout.TabStop = false;
            // 
            // lblWarning
            // 
            this.lblWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWarning.AutoSize = true;
            this.lblWarning.BackColor = System.Drawing.Color.Black;
            this.lblWarning.ForeColor = System.Drawing.Color.Gray;
            this.lblWarning.Location = new System.Drawing.Point(12, 539);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(782, 13);
            this.lblWarning.TabIndex = 1;
            this.lblWarning.Text = "Warning: this layout might not be accurate because there is MainScale / PostScale" +
    " / Rotation information present, which is not yet fully supported by this applic" +
    "ation.";
            this.lblWarning.Visible = false;
            // 
            // frmMapLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.picLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMapLayout";
            this.Text = "Map Layout";
            this.ResizeEnd += new System.EventHandler(this.frmMapLayout_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.picLayout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picLayout;
        private System.Windows.Forms.Label lblWarning;
    }
}