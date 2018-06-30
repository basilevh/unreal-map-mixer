﻿namespace UnrealMapMixer
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtInputFiles = new System.Windows.Forms.TextBox();
            this.lblSolid = new System.Windows.Forms.Label();
            this.numSolid = new System.Windows.Forms.NumericUpDown();
            this.numLight = new System.Windows.Forms.NumericUpDown();
            this.lblLight = new System.Windows.Forms.Label();
            this.grpChances = new System.Windows.Forms.GroupBox();
            this.numNonSolid = new System.Windows.Forms.NumericUpDown();
            this.lblNonSolid = new System.Windows.Forms.Label();
            this.numSemiSolid = new System.Windows.Forms.NumericUpDown();
            this.lblSemiSolid = new System.Windows.Forms.Label();
            this.numMover = new System.Windows.Forms.NumericUpDown();
            this.lblMover = new System.Windows.Forms.Label();
            this.numSubtract = new System.Windows.Forms.NumericUpDown();
            this.lblSubtract = new System.Windows.Forms.Label();
            this.numOther = new System.Windows.Forms.NumericUpDown();
            this.lblOther = new System.Windows.Forms.Label();
            this.txtExActors = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.grpInputFiles = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlblAuthor = new System.Windows.Forms.ToolStripStatusLabel();
            this.chkExMore = new System.Windows.Forms.CheckBox();
            this.grpExActors = new System.Windows.Forms.GroupBox();
            this.chkExPortal = new System.Windows.Forms.CheckBox();
            this.chkExInvis = new System.Windows.Forms.CheckBox();
            this.chkExZoneInfo = new System.Windows.Forms.CheckBox();
            this.chkKeepEventTag = new System.Windows.Forms.CheckBox();
            this.lblKeepEventTag = new System.Windows.Forms.Label();
            this.chkKeepWorldCons = new System.Windows.Forms.CheckBox();
            this.lblKeepWorldCons = new System.Windows.Forms.Label();
            this.grpIntelligence = new System.Windows.Forms.GroupBox();
            this.lblExpandPortals = new System.Windows.Forms.Label();
            this.chkExpandPortals = new System.Windows.Forms.CheckBox();
            this.lblTranslateCOG = new System.Windows.Forms.Label();
            this.chkTranslateCOG = new System.Windows.Forms.CheckBox();
            this.chkRemTrapPlay = new System.Windows.Forms.CheckBox();
            this.radSmartOpen = new System.Windows.Forms.RadioButton();
            this.radSmartClosed = new System.Windows.Forms.RadioButton();
            this.radShuffled = new System.Windows.Forms.RadioButton();
            this.radOrdered = new System.Windows.Forms.RadioButton();
            this.lblMode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numSolid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLight)).BeginInit();
            this.grpChances.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNonSolid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSemiSolid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSubtract)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOther)).BeginInit();
            this.grpInputFiles.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.grpExActors.SuspendLayout();
            this.grpIntelligence.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInputFiles
            // 
            this.txtInputFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputFiles.Location = new System.Drawing.Point(6, 19);
            this.txtInputFiles.Multiline = true;
            this.txtInputFiles.Name = "txtInputFiles";
            this.txtInputFiles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInputFiles.Size = new System.Drawing.Size(548, 80);
            this.txtInputFiles.TabIndex = 1;
            // 
            // lblSolid
            // 
            this.lblSolid.AutoSize = true;
            this.lblSolid.Location = new System.Drawing.Point(6, 21);
            this.lblSolid.Name = "lblSolid";
            this.lblSolid.Size = new System.Drawing.Size(91, 13);
            this.lblSolid.TabIndex = 2;
            this.lblSolid.Text = "&Solid Brushes (%):";
            // 
            // numSolid
            // 
            this.numSolid.DecimalPlaces = 1;
            this.numSolid.Location = new System.Drawing.Point(134, 19);
            this.numSolid.Name = "numSolid";
            this.numSolid.Size = new System.Drawing.Size(60, 20);
            this.numSolid.TabIndex = 3;
            this.numSolid.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // numLight
            // 
            this.numLight.DecimalPlaces = 1;
            this.numLight.Location = new System.Drawing.Point(134, 149);
            this.numLight.Name = "numLight";
            this.numLight.Size = new System.Drawing.Size(60, 20);
            this.numLight.TabIndex = 5;
            this.numLight.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // lblLight
            // 
            this.lblLight.AutoSize = true;
            this.lblLight.Location = new System.Drawing.Point(6, 151);
            this.lblLight.Name = "lblLight";
            this.lblLight.Size = new System.Drawing.Size(55, 13);
            this.lblLight.TabIndex = 4;
            this.lblLight.Text = "&Lights (%):";
            // 
            // grpChances
            // 
            this.grpChances.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpChances.Controls.Add(this.numNonSolid);
            this.grpChances.Controls.Add(this.lblNonSolid);
            this.grpChances.Controls.Add(this.numSemiSolid);
            this.grpChances.Controls.Add(this.lblSemiSolid);
            this.grpChances.Controls.Add(this.numMover);
            this.grpChances.Controls.Add(this.lblMover);
            this.grpChances.Controls.Add(this.numSubtract);
            this.grpChances.Controls.Add(this.lblSubtract);
            this.grpChances.Controls.Add(this.numOther);
            this.grpChances.Controls.Add(this.lblOther);
            this.grpChances.Controls.Add(this.numLight);
            this.grpChances.Controls.Add(this.lblLight);
            this.grpChances.Controls.Add(this.numSolid);
            this.grpChances.Controls.Add(this.lblSolid);
            this.grpChances.Location = new System.Drawing.Point(372, 152);
            this.grpChances.Name = "grpChances";
            this.grpChances.Size = new System.Drawing.Size(200, 201);
            this.grpChances.TabIndex = 6;
            this.grpChances.TabStop = false;
            this.grpChances.Text = "Chances";
            // 
            // numNonSolid
            // 
            this.numNonSolid.DecimalPlaces = 1;
            this.numNonSolid.Location = new System.Drawing.Point(134, 71);
            this.numNonSolid.Name = "numNonSolid";
            this.numNonSolid.Size = new System.Drawing.Size(60, 20);
            this.numNonSolid.TabIndex = 15;
            this.numNonSolid.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // lblNonSolid
            // 
            this.lblNonSolid.AutoSize = true;
            this.lblNonSolid.Location = new System.Drawing.Point(6, 73);
            this.lblNonSolid.Name = "lblNonSolid";
            this.lblNonSolid.Size = new System.Drawing.Size(114, 13);
            this.lblNonSolid.TabIndex = 14;
            this.lblNonSolid.Text = "&Non-Solid Brushes (%):";
            // 
            // numSemiSolid
            // 
            this.numSemiSolid.DecimalPlaces = 1;
            this.numSemiSolid.Location = new System.Drawing.Point(134, 45);
            this.numSemiSolid.Name = "numSemiSolid";
            this.numSemiSolid.Size = new System.Drawing.Size(60, 20);
            this.numSemiSolid.TabIndex = 13;
            this.numSemiSolid.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // lblSemiSolid
            // 
            this.lblSemiSolid.AutoSize = true;
            this.lblSemiSolid.Location = new System.Drawing.Point(6, 47);
            this.lblSemiSolid.Name = "lblSemiSolid";
            this.lblSemiSolid.Size = new System.Drawing.Size(117, 13);
            this.lblSemiSolid.TabIndex = 12;
            this.lblSemiSolid.Text = "S&emi-Solid Brushes (%):";
            // 
            // numMover
            // 
            this.numMover.DecimalPlaces = 1;
            this.numMover.Location = new System.Drawing.Point(134, 123);
            this.numMover.Name = "numMover";
            this.numMover.Size = new System.Drawing.Size(60, 20);
            this.numMover.TabIndex = 11;
            this.numMover.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // lblMover
            // 
            this.lblMover.AutoSize = true;
            this.lblMover.Location = new System.Drawing.Point(6, 125);
            this.lblMover.Name = "lblMover";
            this.lblMover.Size = new System.Drawing.Size(98, 13);
            this.lblMover.TabIndex = 10;
            this.lblMover.Text = "&Mover Brushes (%):";
            // 
            // numSubtract
            // 
            this.numSubtract.DecimalPlaces = 1;
            this.numSubtract.Location = new System.Drawing.Point(134, 97);
            this.numSubtract.Name = "numSubtract";
            this.numSubtract.Size = new System.Drawing.Size(60, 20);
            this.numSubtract.TabIndex = 9;
            this.numSubtract.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // lblSubtract
            // 
            this.lblSubtract.AutoSize = true;
            this.lblSubtract.Location = new System.Drawing.Point(6, 99);
            this.lblSubtract.Name = "lblSubtract";
            this.lblSubtract.Size = new System.Drawing.Size(108, 13);
            this.lblSubtract.TabIndex = 8;
            this.lblSubtract.Text = "S&ubtract Brushes (%):";
            // 
            // numOther
            // 
            this.numOther.DecimalPlaces = 1;
            this.numOther.Location = new System.Drawing.Point(134, 175);
            this.numOther.Name = "numOther";
            this.numOther.Size = new System.Drawing.Size(60, 20);
            this.numOther.TabIndex = 7;
            this.numOther.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // lblOther
            // 
            this.lblOther.AutoSize = true;
            this.lblOther.Location = new System.Drawing.Point(6, 177);
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(98, 13);
            this.lblOther.TabIndex = 6;
            this.lblOther.Text = "&All other Actors (%):";
            // 
            // txtExActors
            // 
            this.txtExActors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExActors.Location = new System.Drawing.Point(6, 111);
            this.txtExActors.Multiline = true;
            this.txtExActors.Name = "txtExActors";
            this.txtExActors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExActors.Size = new System.Drawing.Size(188, 92);
            this.txtExActors.TabIndex = 0;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(372, 574);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(200, 23);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.Text = "&Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // grpInputFiles
            // 
            this.grpInputFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInputFiles.Controls.Add(this.btnBrowse);
            this.grpInputFiles.Controls.Add(this.txtInputFiles);
            this.grpInputFiles.Location = new System.Drawing.Point(12, 12);
            this.grpInputFiles.Name = "grpInputFiles";
            this.grpInputFiles.Size = new System.Drawing.Size(560, 134);
            this.grpInputFiles.TabIndex = 9;
            this.grpInputFiles.TabStop = false;
            this.grpInputFiles.Text = "Input Files";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(479, 105);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 600);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(584, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tlblAuthor
            // 
            this.tlblAuthor.ForeColor = System.Drawing.Color.Gray;
            this.tlblAuthor.Name = "tlblAuthor";
            this.tlblAuthor.Size = new System.Drawing.Size(569, 17);
            this.tlblAuthor.Spring = true;
            this.tlblAuthor.Text = "© 2018 Basile Van Hoorick";
            this.tlblAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkExMore
            // 
            this.chkExMore.AutoSize = true;
            this.chkExMore.Checked = true;
            this.chkExMore.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExMore.Location = new System.Drawing.Point(6, 88);
            this.chkExMore.Name = "chkExMore";
            this.chkExMore.Size = new System.Drawing.Size(154, 17);
            this.chkExMore.TabIndex = 3;
            this.chkExMore.Text = "More (specific &names only):";
            this.chkExMore.UseVisualStyleBackColor = true;
            // 
            // grpExActors
            // 
            this.grpExActors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpExActors.Controls.Add(this.chkExPortal);
            this.grpExActors.Controls.Add(this.chkExInvis);
            this.grpExActors.Controls.Add(this.chkExMore);
            this.grpExActors.Controls.Add(this.chkExZoneInfo);
            this.grpExActors.Controls.Add(this.txtExActors);
            this.grpExActors.Location = new System.Drawing.Point(372, 359);
            this.grpExActors.Name = "grpExActors";
            this.grpExActors.Size = new System.Drawing.Size(200, 209);
            this.grpExActors.TabIndex = 7;
            this.grpExActors.TabStop = false;
            this.grpExActors.Text = "Excluded Actors";
            // 
            // chkExPortal
            // 
            this.chkExPortal.AutoSize = true;
            this.chkExPortal.Checked = true;
            this.chkExPortal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExPortal.Location = new System.Drawing.Point(6, 42);
            this.chkExPortal.Name = "chkExPortal";
            this.chkExPortal.Size = new System.Drawing.Size(94, 17);
            this.chkExPortal.TabIndex = 5;
            this.chkExPortal.Text = "Por&tal Brushes";
            this.chkExPortal.UseVisualStyleBackColor = true;
            // 
            // chkExInvis
            // 
            this.chkExInvis.AutoSize = true;
            this.chkExInvis.Checked = true;
            this.chkExInvis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExInvis.Location = new System.Drawing.Point(6, 19);
            this.chkExInvis.Name = "chkExInvis";
            this.chkExInvis.Size = new System.Drawing.Size(105, 17);
            this.chkExInvis.TabIndex = 4;
            this.chkExInvis.Text = "&Invisible Brushes";
            this.chkExInvis.UseVisualStyleBackColor = true;
            // 
            // chkExZoneInfo
            // 
            this.chkExZoneInfo.AutoSize = true;
            this.chkExZoneInfo.Checked = true;
            this.chkExZoneInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExZoneInfo.Location = new System.Drawing.Point(6, 65);
            this.chkExZoneInfo.Name = "chkExZoneInfo";
            this.chkExZoneInfo.Size = new System.Drawing.Size(210, 17);
            this.chkExZoneInfo.TabIndex = 1;
            this.chkExZoneInfo.Text = "&ZoneInfo (and subclasses, except Sky)";
            this.chkExZoneInfo.UseVisualStyleBackColor = true;
            // 
            // chkKeepEventTag
            // 
            this.chkKeepEventTag.AutoSize = true;
            this.chkKeepEventTag.Checked = true;
            this.chkKeepEventTag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKeepEventTag.Enabled = false;
            this.chkKeepEventTag.Location = new System.Drawing.Point(6, 202);
            this.chkKeepEventTag.Name = "chkKeepEventTag";
            this.chkKeepEventTag.Size = new System.Drawing.Size(157, 17);
            this.chkKeepEventTag.TabIndex = 4;
            this.chkKeepEventTag.Text = "&Keep Event-Tag links intact";
            this.chkKeepEventTag.UseVisualStyleBackColor = true;
            // 
            // lblKeepEventTag
            // 
            this.lblKeepEventTag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeepEventTag.AutoEllipsis = true;
            this.lblKeepEventTag.Enabled = false;
            this.lblKeepEventTag.ForeColor = System.Drawing.Color.Gray;
            this.lblKeepEventTag.Location = new System.Drawing.Point(6, 222);
            this.lblKeepEventTag.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.lblKeepEventTag.Name = "lblKeepEventTag";
            this.lblKeepEventTag.Size = new System.Drawing.Size(342, 52);
            this.lblKeepEventTag.TabIndex = 4;
            this.lblKeepEventTag.Text = resources.GetString("lblKeepEventTag.Text");
            // 
            // chkKeepWorldCons
            // 
            this.chkKeepWorldCons.AutoSize = true;
            this.chkKeepWorldCons.Checked = true;
            this.chkKeepWorldCons.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKeepWorldCons.Enabled = false;
            this.chkKeepWorldCons.Location = new System.Drawing.Point(6, 283);
            this.chkKeepWorldCons.Name = "chkKeepWorldCons";
            this.chkKeepWorldCons.Size = new System.Drawing.Size(169, 17);
            this.chkKeepWorldCons.TabIndex = 4;
            this.chkKeepWorldCons.Text = "Keep &world connections intact";
            this.chkKeepWorldCons.UseVisualStyleBackColor = true;
            // 
            // lblKeepWorldCons
            // 
            this.lblKeepWorldCons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeepWorldCons.AutoEllipsis = true;
            this.lblKeepWorldCons.Enabled = false;
            this.lblKeepWorldCons.ForeColor = System.Drawing.Color.Gray;
            this.lblKeepWorldCons.Location = new System.Drawing.Point(6, 303);
            this.lblKeepWorldCons.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.lblKeepWorldCons.Name = "lblKeepWorldCons";
            this.lblKeepWorldCons.Size = new System.Drawing.Size(342, 52);
            this.lblKeepWorldCons.TabIndex = 8;
            this.lblKeepWorldCons.Text = resources.GetString("lblKeepWorldCons.Text");
            // 
            // grpIntelligence
            // 
            this.grpIntelligence.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpIntelligence.Controls.Add(this.lblExpandPortals);
            this.grpIntelligence.Controls.Add(this.chkExpandPortals);
            this.grpIntelligence.Controls.Add(this.lblTranslateCOG);
            this.grpIntelligence.Controls.Add(this.chkTranslateCOG);
            this.grpIntelligence.Controls.Add(this.chkRemTrapPlay);
            this.grpIntelligence.Controls.Add(this.radSmartOpen);
            this.grpIntelligence.Controls.Add(this.radSmartClosed);
            this.grpIntelligence.Controls.Add(this.radShuffled);
            this.grpIntelligence.Controls.Add(this.radOrdered);
            this.grpIntelligence.Controls.Add(this.lblMode);
            this.grpIntelligence.Controls.Add(this.lblKeepWorldCons);
            this.grpIntelligence.Controls.Add(this.chkKeepEventTag);
            this.grpIntelligence.Controls.Add(this.chkKeepWorldCons);
            this.grpIntelligence.Controls.Add(this.lblKeepEventTag);
            this.grpIntelligence.Location = new System.Drawing.Point(12, 152);
            this.grpIntelligence.Name = "grpIntelligence";
            this.grpIntelligence.Size = new System.Drawing.Size(354, 445);
            this.grpIntelligence.TabIndex = 9;
            this.grpIntelligence.TabStop = false;
            this.grpIntelligence.Text = "Intelligence";
            // 
            // lblExpandPortals
            // 
            this.lblExpandPortals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExpandPortals.AutoEllipsis = true;
            this.lblExpandPortals.Enabled = false;
            this.lblExpandPortals.ForeColor = System.Drawing.Color.Gray;
            this.lblExpandPortals.Location = new System.Drawing.Point(6, 384);
            this.lblExpandPortals.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.lblExpandPortals.Name = "lblExpandPortals";
            this.lblExpandPortals.Size = new System.Drawing.Size(342, 52);
            this.lblExpandPortals.TabIndex = 16;
            this.lblExpandPortals.Text = resources.GetString("lblExpandPortals.Text");
            // 
            // chkExpandPortals
            // 
            this.chkExpandPortals.AutoSize = true;
            this.chkExpandPortals.Checked = true;
            this.chkExpandPortals.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExpandPortals.Enabled = false;
            this.chkExpandPortals.Location = new System.Drawing.Point(6, 364);
            this.chkExpandPortals.Name = "chkExpandPortals";
            this.chkExpandPortals.Size = new System.Drawing.Size(97, 17);
            this.chkExpandPortals.TabIndex = 15;
            this.chkExpandPortals.Text = "E&xpand Portals";
            this.chkExpandPortals.UseVisualStyleBackColor = true;
            // 
            // lblTranslateCOG
            // 
            this.lblTranslateCOG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTranslateCOG.AutoEllipsis = true;
            this.lblTranslateCOG.Enabled = false;
            this.lblTranslateCOG.ForeColor = System.Drawing.Color.Gray;
            this.lblTranslateCOG.Location = new System.Drawing.Point(6, 154);
            this.lblTranslateCOG.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.lblTranslateCOG.Name = "lblTranslateCOG";
            this.lblTranslateCOG.Size = new System.Drawing.Size(342, 39);
            this.lblTranslateCOG.TabIndex = 14;
            this.lblTranslateCOG.Text = "If checked, all input maps will first be \'moved to the origin\' by steps of 64, to" +
    " prevent that the mixed map content would become too disjunct due to differently" +
    " located original maps.";
            // 
            // chkTranslateCOG
            // 
            this.chkTranslateCOG.AutoSize = true;
            this.chkTranslateCOG.Checked = true;
            this.chkTranslateCOG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTranslateCOG.Enabled = false;
            this.chkTranslateCOG.Location = new System.Drawing.Point(6, 134);
            this.chkTranslateCOG.Name = "chkTranslateCOG";
            this.chkTranslateCOG.Size = new System.Drawing.Size(204, 17);
            this.chkTranslateCOG.TabIndex = 13;
            this.chkTranslateCOG.Text = "Translate to common center of gra&vity";
            this.chkTranslateCOG.UseVisualStyleBackColor = true;
            // 
            // chkRemTrapPlay
            // 
            this.chkRemTrapPlay.AutoSize = true;
            this.chkRemTrapPlay.Checked = true;
            this.chkRemTrapPlay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemTrapPlay.Enabled = false;
            this.chkRemTrapPlay.Location = new System.Drawing.Point(6, 111);
            this.chkRemTrapPlay.Name = "chkRemTrapPlay";
            this.chkRemTrapPlay.Size = new System.Drawing.Size(164, 17);
            this.chkRemTrapPlay.TabIndex = 12;
            this.chkRemTrapPlay.Text = "&Remove trapped PlayerStarts";
            this.chkRemTrapPlay.UseVisualStyleBackColor = true;
            // 
            // radSmartOpen
            // 
            this.radSmartOpen.AutoSize = true;
            this.radSmartOpen.Enabled = false;
            this.radSmartOpen.Location = new System.Drawing.Point(49, 88);
            this.radSmartOpen.Name = "radSmartOpen";
            this.radSmartOpen.Size = new System.Drawing.Size(124, 17);
            this.radSmartOpen.TabIndex = 11;
            this.radSmartOpen.Text = "Smart O&pen-Map Mix";
            this.radSmartOpen.UseVisualStyleBackColor = true;
            // 
            // radSmartClosed
            // 
            this.radSmartClosed.AutoSize = true;
            this.radSmartClosed.Enabled = false;
            this.radSmartClosed.Location = new System.Drawing.Point(49, 65);
            this.radSmartClosed.Name = "radSmartClosed";
            this.radSmartClosed.Size = new System.Drawing.Size(130, 17);
            this.radSmartClosed.TabIndex = 10;
            this.radSmartClosed.Text = "Smart &Closed-Map Mix";
            this.radSmartClosed.UseVisualStyleBackColor = true;
            // 
            // radShuffled
            // 
            this.radShuffled.AutoSize = true;
            this.radShuffled.Location = new System.Drawing.Point(49, 42);
            this.radShuffled.Name = "radShuffled";
            this.radShuffled.Size = new System.Drawing.Size(83, 17);
            this.radShuffled.TabIndex = 9;
            this.radShuffled.Text = "S&huffled Mix";
            this.radShuffled.UseVisualStyleBackColor = true;
            // 
            // radOrdered
            // 
            this.radOrdered.AutoSize = true;
            this.radOrdered.Checked = true;
            this.radOrdered.Location = new System.Drawing.Point(49, 19);
            this.radOrdered.Name = "radOrdered";
            this.radOrdered.Size = new System.Drawing.Size(82, 17);
            this.radOrdered.TabIndex = 8;
            this.radOrdered.TabStop = true;
            this.radOrdered.Text = "&Ordered Mix";
            this.radOrdered.UseVisualStyleBackColor = true;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(6, 21);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(37, 13);
            this.lblMode.TabIndex = 8;
            this.lblMode.Text = "Mode:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 622);
            this.Controls.Add(this.grpIntelligence);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpInputFiles);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.grpChances);
            this.Controls.Add(this.grpExActors);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 661);
            this.Name = "frmMain";
            this.Text = "Unreal Tournament Map Mixer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numSolid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLight)).EndInit();
            this.grpChances.ResumeLayout(false);
            this.grpChances.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNonSolid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSemiSolid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSubtract)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOther)).EndInit();
            this.grpInputFiles.ResumeLayout(false);
            this.grpInputFiles.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grpExActors.ResumeLayout(false);
            this.grpExActors.PerformLayout();
            this.grpIntelligence.ResumeLayout(false);
            this.grpIntelligence.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtInputFiles;
        private System.Windows.Forms.Label lblSolid;
        private System.Windows.Forms.NumericUpDown numSolid;
        private System.Windows.Forms.NumericUpDown numLight;
        private System.Windows.Forms.Label lblLight;
        private System.Windows.Forms.GroupBox grpChances;
        private System.Windows.Forms.NumericUpDown numOther;
        private System.Windows.Forms.Label lblOther;
        private System.Windows.Forms.TextBox txtExActors;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.GroupBox grpInputFiles;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tlblAuthor;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.CheckBox chkExMore;
        private System.Windows.Forms.GroupBox grpExActors;
        private System.Windows.Forms.Label lblKeepEventTag;
        private System.Windows.Forms.CheckBox chkKeepEventTag;
        private System.Windows.Forms.CheckBox chkKeepWorldCons;
        private System.Windows.Forms.Label lblKeepWorldCons;
        private System.Windows.Forms.GroupBox grpIntelligence;
        private System.Windows.Forms.RadioButton radSmartOpen;
        private System.Windows.Forms.RadioButton radSmartClosed;
        private System.Windows.Forms.RadioButton radShuffled;
        private System.Windows.Forms.RadioButton radOrdered;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.NumericUpDown numMover;
        private System.Windows.Forms.Label lblMover;
        private System.Windows.Forms.NumericUpDown numSubtract;
        private System.Windows.Forms.Label lblSubtract;
        private System.Windows.Forms.CheckBox chkRemTrapPlay;
        private System.Windows.Forms.NumericUpDown numNonSolid;
        private System.Windows.Forms.Label lblNonSolid;
        private System.Windows.Forms.NumericUpDown numSemiSolid;
        private System.Windows.Forms.Label lblSemiSolid;
        private System.Windows.Forms.CheckBox chkExZoneInfo;
        private System.Windows.Forms.CheckBox chkExPortal;
        private System.Windows.Forms.CheckBox chkExInvis;
        private System.Windows.Forms.Label lblTranslateCOG;
        private System.Windows.Forms.CheckBox chkTranslateCOG;
        private System.Windows.Forms.CheckBox chkExpandPortals;
        private System.Windows.Forms.Label lblExpandPortals;
    }
}

