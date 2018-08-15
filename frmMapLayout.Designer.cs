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
            this.pnlWarning = new System.Windows.Forms.Panel();
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlMixOnly = new System.Windows.Forms.Panel();
            this.numZ = new System.Windows.Forms.NumericUpDown();
            this.lblZ = new System.Windows.Forms.Label();
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.lblY = new System.Windows.Forms.Label();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.lblX = new System.Windows.Forms.Label();
            this.cmbSourceMap = new System.Windows.Forms.ComboBox();
            this.lblSourceMap = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLayout)).BeginInit();
            this.pnlWarning.SuspendLayout();
            this.pnlMixOnly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            this.SuspendLayout();
            // 
            // picLayout
            // 
            this.picLayout.BackColor = System.Drawing.Color.Black;
            this.picLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLayout.Location = new System.Drawing.Point(0, 0);
            this.picLayout.Name = "picLayout";
            this.picLayout.Size = new System.Drawing.Size(784, 489);
            this.picLayout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLayout.TabIndex = 0;
            this.picLayout.TabStop = false;
            this.picLayout.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picLayout_MouseMove);
            // 
            // lblWarning
            // 
            this.lblWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWarning.ForeColor = System.Drawing.Color.White;
            this.lblWarning.Location = new System.Drawing.Point(0, 0);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(784, 36);
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
            // pnlWarning
            // 
            this.pnlWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlWarning.Controls.Add(this.lblWarning);
            this.pnlWarning.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlWarning.ForeColor = System.Drawing.Color.White;
            this.pnlWarning.Location = new System.Drawing.Point(0, 489);
            this.pnlWarning.Name = "pnlWarning";
            this.pnlWarning.Size = new System.Drawing.Size(784, 36);
            this.pnlWarning.TabIndex = 2;
            // 
            // btnRedo
            // 
            this.btnRedo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRedo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRedo.Location = new System.Drawing.Point(616, 6);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(80, 27);
            this.btnRedo.TabIndex = 3;
            this.btnRedo.Text = "&Remix";
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSave.Location = new System.Drawing.Point(701, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 27);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlMixOnly
            // 
            this.pnlMixOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlMixOnly.Controls.Add(this.numZ);
            this.pnlMixOnly.Controls.Add(this.lblZ);
            this.pnlMixOnly.Controls.Add(this.numY);
            this.pnlMixOnly.Controls.Add(this.lblY);
            this.pnlMixOnly.Controls.Add(this.numX);
            this.pnlMixOnly.Controls.Add(this.lblX);
            this.pnlMixOnly.Controls.Add(this.cmbSourceMap);
            this.pnlMixOnly.Controls.Add(this.lblSourceMap);
            this.pnlMixOnly.Controls.Add(this.btnRedo);
            this.pnlMixOnly.Controls.Add(this.btnSave);
            this.pnlMixOnly.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMixOnly.ForeColor = System.Drawing.Color.White;
            this.pnlMixOnly.Location = new System.Drawing.Point(0, 525);
            this.pnlMixOnly.Name = "pnlMixOnly";
            this.pnlMixOnly.Size = new System.Drawing.Size(784, 36);
            this.pnlMixOnly.TabIndex = 4;
            // 
            // numZ
            // 
            this.numZ.Increment = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numZ.Location = new System.Drawing.Point(512, 11);
            this.numZ.Maximum = new decimal(new int[] {
            16384,
            0,
            0,
            0});
            this.numZ.Minimum = new decimal(new int[] {
            16384,
            0,
            0,
            -2147483648});
            this.numZ.Name = "numZ";
            this.numZ.Size = new System.Drawing.Size(60, 20);
            this.numZ.TabIndex = 11;
            this.numZ.ValueChanged += new System.EventHandler(this.numZ_ValueChanged);
            // 
            // lblZ
            // 
            this.lblZ.AutoSize = true;
            this.lblZ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblZ.ForeColor = System.Drawing.Color.White;
            this.lblZ.Location = new System.Drawing.Point(489, 13);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(17, 13);
            this.lblZ.TabIndex = 10;
            this.lblZ.Text = "&Z:";
            this.lblZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblZ.Visible = false;
            // 
            // numY
            // 
            this.numY.Increment = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numY.Location = new System.Drawing.Point(423, 11);
            this.numY.Maximum = new decimal(new int[] {
            16384,
            0,
            0,
            0});
            this.numY.Minimum = new decimal(new int[] {
            16384,
            0,
            0,
            -2147483648});
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(60, 20);
            this.numY.TabIndex = 9;
            this.numY.ValueChanged += new System.EventHandler(this.numY_ValueChanged);
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblY.ForeColor = System.Drawing.Color.White;
            this.lblY.Location = new System.Drawing.Point(400, 13);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(17, 13);
            this.lblY.TabIndex = 8;
            this.lblY.Text = "&Y:";
            this.lblY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblY.Visible = false;
            // 
            // numX
            // 
            this.numX.Increment = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numX.Location = new System.Drawing.Point(334, 11);
            this.numX.Maximum = new decimal(new int[] {
            16384,
            0,
            0,
            0});
            this.numX.Minimum = new decimal(new int[] {
            16384,
            0,
            0,
            -2147483648});
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(60, 20);
            this.numX.TabIndex = 7;
            this.numX.ValueChanged += new System.EventHandler(this.numX_ValueChanged);
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblX.ForeColor = System.Drawing.Color.White;
            this.lblX.Location = new System.Drawing.Point(280, 13);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(48, 13);
            this.lblX.TabIndex = 6;
            this.lblX.Text = "Offset &X:";
            this.lblX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblX.Visible = false;
            // 
            // cmbSourceMap
            // 
            this.cmbSourceMap.FormattingEnabled = true;
            this.cmbSourceMap.Location = new System.Drawing.Point(114, 10);
            this.cmbSourceMap.Name = "cmbSourceMap";
            this.cmbSourceMap.Size = new System.Drawing.Size(160, 21);
            this.cmbSourceMap.TabIndex = 5;
            this.cmbSourceMap.SelectedIndexChanged += new System.EventHandler(this.cmbSourceMap_SelectedIndexChanged);
            // 
            // lblSourceMap
            // 
            this.lblSourceMap.AutoSize = true;
            this.lblSourceMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSourceMap.ForeColor = System.Drawing.Color.White;
            this.lblSourceMap.Location = new System.Drawing.Point(6, 13);
            this.lblSourceMap.Name = "lblSourceMap";
            this.lblSourceMap.Size = new System.Drawing.Size(102, 13);
            this.lblSourceMap.TabIndex = 4;
            this.lblSourceMap.Text = "&Modify Source Map:";
            this.lblSourceMap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMapLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.picLayout);
            this.Controls.Add(this.pnlWarning);
            this.Controls.Add(this.pnlMixOnly);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMapLayout";
            this.Text = "Map Layout";
            this.ResizeEnd += new System.EventHandler(this.frmMapLayout_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.frmMapLayout_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.picLayout)).EndInit();
            this.pnlWarning.ResumeLayout(false);
            this.pnlMixOnly.ResumeLayout(false);
            this.pnlMixOnly.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picLayout;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.Panel pnlWarning;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlMixOnly;
        private System.Windows.Forms.ComboBox cmbSourceMap;
        private System.Windows.Forms.Label lblSourceMap;
        private System.Windows.Forms.NumericUpDown numZ;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.NumericUpDown numY;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.NumericUpDown numX;
        private System.Windows.Forms.Label lblX;
    }
}