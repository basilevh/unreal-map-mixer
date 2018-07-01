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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMapLayout));
            this.picLayout = new System.Windows.Forms.PictureBox();
            this.lblWarning = new System.Windows.Forms.Label();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.pnlControls = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picLayout)).BeginInit();
            this.pnlControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLayout
            // 
            this.picLayout.BackColor = System.Drawing.Color.Black;
            this.picLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLayout.Location = new System.Drawing.Point(0, 0);
            this.picLayout.Name = "picLayout";
            this.picLayout.Size = new System.Drawing.Size(784, 525);
            this.picLayout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLayout.TabIndex = 0;
            this.picLayout.TabStop = false;
            // 
            // lblWarning
            // 
            this.lblWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWarning.ForeColor = System.Drawing.Color.White;
            this.lblWarning.Location = new System.Drawing.Point(0, 0);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(624, 36);
            this.lblWarning.TabIndex = 1;
            this.lblWarning.Text = "Warning: this layout might be inaccurate because there is MainScale / PostScale /" +
    " Rotation information present, which is not yet fully supported by the applicati" +
    "on.";
            this.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWarning.Visible = false;
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlControls.Controls.Add(this.lblWarning);
            this.pnlControls.Controls.Add(this.btnRedo);
            this.pnlControls.Controls.Add(this.btnSave);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControls.ForeColor = System.Drawing.Color.White;
            this.pnlControls.Location = new System.Drawing.Point(0, 525);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(784, 36);
            this.pnlControls.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSave.Location = new System.Drawing.Point(704, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 36);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRedo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRedo.Location = new System.Drawing.Point(624, 0);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(80, 36);
            this.btnRedo.TabIndex = 3;
            this.btnRedo.Text = "&Redo";
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // frmMapLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.picLayout);
            this.Controls.Add(this.pnlControls);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMapLayout";
            this.Text = "Map Layout";
            this.ResizeEnd += new System.EventHandler(this.frmMapLayout_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.frmMapLayout_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.picLayout)).EndInit();
            this.pnlControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picLayout;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.Button btnSave;
    }
}