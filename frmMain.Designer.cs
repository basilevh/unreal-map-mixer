namespace UnrealMapMixer
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
            this.lblSolid = new System.Windows.Forms.Label();
            this.numSolid = new System.Windows.Forms.NumericUpDown();
            this.numLight = new System.Windows.Forms.NumericUpDown();
            this.lblLight = new System.Windows.Forms.Label();
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
            this.txtExcludeActors = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.grpInputFiles = new System.Windows.Forms.GroupBox();
            this.btnView = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lvwSourceFiles = new System.Windows.Forms.ListView();
            this.clmPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAdd = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlblAuthor = new System.Windows.Forms.ToolStripStatusLabel();
            this.chkExMore = new System.Windows.Forms.CheckBox();
            this.chkExPortal = new System.Windows.Forms.CheckBox();
            this.chkExInvis = new System.Windows.Forms.CheckBox();
            this.chkExZoneInfo = new System.Windows.Forms.CheckBox();
            this.chkKeepEventTag = new System.Windows.Forms.CheckBox();
            this.lblKeepEventTag = new System.Windows.Forms.Label();
            this.chkKeepWorldCons = new System.Windows.Forms.CheckBox();
            this.lblKeepWorldCons = new System.Windows.Forms.Label();
            this.lblExpandPortals = new System.Windows.Forms.Label();
            this.chkExpandPortals = new System.Windows.Forms.CheckBox();
            this.lblTranslateCOG = new System.Windows.Forms.Label();
            this.chkTranslateCOG = new System.Windows.Forms.CheckBox();
            this.chkRemTrapPlay = new System.Windows.Forms.CheckBox();
            this.radSmartAdd = new System.Windows.Forms.RadioButton();
            this.radSmartSubtract = new System.Windows.Forms.RadioButton();
            this.radShuffled = new System.Windows.Forms.RadioButton();
            this.radOrdered = new System.Windows.Forms.RadioButton();
            this.lblMode = new System.Windows.Forms.Label();
            this.tbcParameters = new System.Windows.Forms.TabControl();
            this.tabIntelligence = new System.Windows.Forms.TabPage();
            this.tabProbabilities = new System.Windows.Forms.TabPage();
            this.lblProbs = new System.Windows.Forms.Label();
            this.tabExcluded = new System.Windows.Forms.TabPage();
            this.lblExclusions = new System.Windows.Forms.Label();
            this.tabExtras = new System.Windows.Forms.TabPage();
            this.chkSwapTex = new System.Windows.Forms.CheckBox();
            this.chkSwapAct = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numSolid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNonSolid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSemiSolid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSubtract)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOther)).BeginInit();
            this.grpInputFiles.SuspendLayout();
            this.tbcParameters.SuspendLayout();
            this.tabIntelligence.SuspendLayout();
            this.tabProbabilities.SuspendLayout();
            this.tabExcluded.SuspendLayout();
            this.tabExtras.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSolid
            // 
            this.lblSolid.AutoSize = true;
            this.lblSolid.Location = new System.Drawing.Point(6, 42);
            this.lblSolid.Name = "lblSolid";
            this.lblSolid.Size = new System.Drawing.Size(91, 13);
            this.lblSolid.TabIndex = 2;
            this.lblSolid.Text = "&Solid Brushes (%):";
            // 
            // numSolid
            // 
            this.numSolid.DecimalPlaces = 1;
            this.numSolid.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numSolid.Location = new System.Drawing.Point(129, 40);
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
            this.numLight.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numLight.Location = new System.Drawing.Point(129, 170);
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
            this.lblLight.Location = new System.Drawing.Point(6, 172);
            this.lblLight.Name = "lblLight";
            this.lblLight.Size = new System.Drawing.Size(55, 13);
            this.lblLight.TabIndex = 4;
            this.lblLight.Text = "&Lights (%):";
            // 
            // numNonSolid
            // 
            this.numNonSolid.DecimalPlaces = 1;
            this.numNonSolid.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numNonSolid.Location = new System.Drawing.Point(129, 92);
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
            this.lblNonSolid.Location = new System.Drawing.Point(6, 94);
            this.lblNonSolid.Name = "lblNonSolid";
            this.lblNonSolid.Size = new System.Drawing.Size(114, 13);
            this.lblNonSolid.TabIndex = 14;
            this.lblNonSolid.Text = "&Non-Solid Brushes (%):";
            // 
            // numSemiSolid
            // 
            this.numSemiSolid.DecimalPlaces = 1;
            this.numSemiSolid.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numSemiSolid.Location = new System.Drawing.Point(129, 66);
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
            this.lblSemiSolid.Location = new System.Drawing.Point(6, 68);
            this.lblSemiSolid.Name = "lblSemiSolid";
            this.lblSemiSolid.Size = new System.Drawing.Size(117, 13);
            this.lblSemiSolid.TabIndex = 12;
            this.lblSemiSolid.Text = "S&emi-Solid Brushes (%):";
            // 
            // numMover
            // 
            this.numMover.DecimalPlaces = 1;
            this.numMover.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numMover.Location = new System.Drawing.Point(129, 144);
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
            this.lblMover.Location = new System.Drawing.Point(6, 146);
            this.lblMover.Name = "lblMover";
            this.lblMover.Size = new System.Drawing.Size(98, 13);
            this.lblMover.TabIndex = 10;
            this.lblMover.Text = "&Mover Brushes (%):";
            // 
            // numSubtract
            // 
            this.numSubtract.DecimalPlaces = 1;
            this.numSubtract.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numSubtract.Location = new System.Drawing.Point(129, 118);
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
            this.lblSubtract.Location = new System.Drawing.Point(6, 120);
            this.lblSubtract.Name = "lblSubtract";
            this.lblSubtract.Size = new System.Drawing.Size(108, 13);
            this.lblSubtract.TabIndex = 8;
            this.lblSubtract.Text = "S&ubtract Brushes (%):";
            // 
            // numOther
            // 
            this.numOther.DecimalPlaces = 1;
            this.numOther.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numOther.Location = new System.Drawing.Point(129, 196);
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
            this.lblOther.Location = new System.Drawing.Point(6, 198);
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(98, 13);
            this.lblOther.TabIndex = 6;
            this.lblOther.Text = "All &other Actors (%):";
            // 
            // txtExcludeActors
            // 
            this.txtExcludeActors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExcludeActors.Location = new System.Drawing.Point(6, 130);
            this.txtExcludeActors.Multiline = true;
            this.txtExcludeActors.Name = "txtExcludeActors";
            this.txtExcludeActors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExcludeActors.Size = new System.Drawing.Size(640, 273);
            this.txtExcludeActors.TabIndex = 0;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(12, 613);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(660, 23);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.Text = "&Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // grpInputFiles
            // 
            this.grpInputFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInputFiles.Controls.Add(this.btnView);
            this.grpInputFiles.Controls.Add(this.btnRemove);
            this.grpInputFiles.Controls.Add(this.lvwSourceFiles);
            this.grpInputFiles.Controls.Add(this.btnAdd);
            this.grpInputFiles.Location = new System.Drawing.Point(12, 12);
            this.grpInputFiles.Name = "grpInputFiles";
            this.grpInputFiles.Size = new System.Drawing.Size(660, 154);
            this.grpInputFiles.TabIndex = 9;
            this.grpInputFiles.TabStop = false;
            this.grpInputFiles.Text = "Source Files";
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Location = new System.Drawing.Point(579, 77);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 5;
            this.btnView.Text = "&View Layout";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(579, 48);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "&Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lvwSourceFiles
            // 
            this.lvwSourceFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwSourceFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmPath,
            this.clmTitle,
            this.clmAuthor,
            this.clmType});
            this.lvwSourceFiles.FullRowSelect = true;
            this.lvwSourceFiles.GridLines = true;
            this.lvwSourceFiles.HideSelection = false;
            this.lvwSourceFiles.Location = new System.Drawing.Point(6, 19);
            this.lvwSourceFiles.Name = "lvwSourceFiles";
            this.lvwSourceFiles.Size = new System.Drawing.Size(567, 129);
            this.lvwSourceFiles.TabIndex = 3;
            this.lvwSourceFiles.UseCompatibleStateImageBehavior = false;
            this.lvwSourceFiles.View = System.Windows.Forms.View.Details;
            this.lvwSourceFiles.DoubleClick += new System.EventHandler(this.lvwSourceFiles_DoubleClick);
            // 
            // clmPath
            // 
            this.clmPath.Text = "Path";
            this.clmPath.Width = 270;
            // 
            // clmTitle
            // 
            this.clmTitle.Text = "Title";
            this.clmTitle.Width = 100;
            // 
            // clmAuthor
            // 
            this.clmAuthor.Text = "Author";
            this.clmAuthor.Width = 90;
            // 
            // clmType
            // 
            this.clmType.Text = "Type";
            this.clmType.Width = 80;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(579, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "&Add...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 639);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(684, 22);
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
            this.chkExMore.Location = new System.Drawing.Point(6, 107);
            this.chkExMore.Name = "chkExMore";
            this.chkExMore.Size = new System.Drawing.Size(181, 17);
            this.chkExMore.TabIndex = 3;
            this.chkExMore.Text = "&More (specific class names only):";
            this.chkExMore.UseVisualStyleBackColor = true;
            // 
            // chkExPortal
            // 
            this.chkExPortal.AutoSize = true;
            this.chkExPortal.Checked = true;
            this.chkExPortal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExPortal.Location = new System.Drawing.Point(6, 61);
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
            this.chkExInvis.Location = new System.Drawing.Point(6, 38);
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
            this.chkExZoneInfo.Location = new System.Drawing.Point(6, 84);
            this.chkExZoneInfo.Name = "chkExZoneInfo";
            this.chkExZoneInfo.Size = new System.Drawing.Size(253, 17);
            this.chkExZoneInfo.TabIndex = 1;
            this.chkExZoneInfo.Text = "&ZoneInfo (and subclasses, except SkyZoneInfo)\r\n";
            this.chkExZoneInfo.UseVisualStyleBackColor = true;
            // 
            // chkKeepEventTag
            // 
            this.chkKeepEventTag.AutoSize = true;
            this.chkKeepEventTag.Enabled = false;
            this.chkKeepEventTag.Location = new System.Drawing.Point(6, 176);
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
            this.lblKeepEventTag.Location = new System.Drawing.Point(6, 196);
            this.lblKeepEventTag.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.lblKeepEventTag.Name = "lblKeepEventTag";
            this.lblKeepEventTag.Size = new System.Drawing.Size(634, 39);
            this.lblKeepEventTag.TabIndex = 4;
            this.lblKeepEventTag.Text = resources.GetString("lblKeepEventTag.Text");
            // 
            // chkKeepWorldCons
            // 
            this.chkKeepWorldCons.AutoSize = true;
            this.chkKeepWorldCons.Enabled = false;
            this.chkKeepWorldCons.Location = new System.Drawing.Point(6, 244);
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
            this.lblKeepWorldCons.Location = new System.Drawing.Point(6, 264);
            this.lblKeepWorldCons.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.lblKeepWorldCons.Name = "lblKeepWorldCons";
            this.lblKeepWorldCons.Size = new System.Drawing.Size(634, 26);
            this.lblKeepWorldCons.TabIndex = 8;
            this.lblKeepWorldCons.Text = resources.GetString("lblKeepWorldCons.Text");
            // 
            // lblExpandPortals
            // 
            this.lblExpandPortals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExpandPortals.AutoEllipsis = true;
            this.lblExpandPortals.Enabled = false;
            this.lblExpandPortals.ForeColor = System.Drawing.Color.Gray;
            this.lblExpandPortals.Location = new System.Drawing.Point(6, 319);
            this.lblExpandPortals.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.lblExpandPortals.Name = "lblExpandPortals";
            this.lblExpandPortals.Size = new System.Drawing.Size(634, 26);
            this.lblExpandPortals.TabIndex = 16;
            this.lblExpandPortals.Text = "If checked, Portal sheets will be expanded to prevent any sheet from not filling " +
    "a gap completely. This expansion happens in the order that the Brushes were adde" +
    "d to the mixed map.";
            // 
            // chkExpandPortals
            // 
            this.chkExpandPortals.AutoSize = true;
            this.chkExpandPortals.Enabled = false;
            this.chkExpandPortals.Location = new System.Drawing.Point(6, 299);
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
            this.lblTranslateCOG.ForeColor = System.Drawing.Color.Gray;
            this.lblTranslateCOG.Location = new System.Drawing.Point(6, 141);
            this.lblTranslateCOG.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.lblTranslateCOG.Name = "lblTranslateCOG";
            this.lblTranslateCOG.Size = new System.Drawing.Size(634, 26);
            this.lblTranslateCOG.TabIndex = 14;
            this.lblTranslateCOG.Text = "If checked, all input maps will first be \'moved to the origin\' by steps of 64, to" +
    " prevent that the mixed map content would become too disjunct due to differently" +
    " located source maps.";
            // 
            // chkTranslateCOG
            // 
            this.chkTranslateCOG.AutoSize = true;
            this.chkTranslateCOG.Location = new System.Drawing.Point(6, 121);
            this.chkTranslateCOG.Name = "chkTranslateCOG";
            this.chkTranslateCOG.Size = new System.Drawing.Size(204, 17);
            this.chkTranslateCOG.TabIndex = 13;
            this.chkTranslateCOG.Text = "&Translate to common center of gravity";
            this.chkTranslateCOG.UseVisualStyleBackColor = true;
            // 
            // chkRemTrapPlay
            // 
            this.chkRemTrapPlay.AutoSize = true;
            this.chkRemTrapPlay.Enabled = false;
            this.chkRemTrapPlay.Location = new System.Drawing.Point(6, 98);
            this.chkRemTrapPlay.Name = "chkRemTrapPlay";
            this.chkRemTrapPlay.Size = new System.Drawing.Size(164, 17);
            this.chkRemTrapPlay.TabIndex = 12;
            this.chkRemTrapPlay.Text = "R&emove trapped PlayerStarts";
            this.chkRemTrapPlay.UseVisualStyleBackColor = true;
            // 
            // radSmartAdd
            // 
            this.radSmartAdd.AutoSize = true;
            this.radSmartAdd.Enabled = false;
            this.radSmartAdd.Location = new System.Drawing.Point(49, 75);
            this.radSmartAdd.Name = "radSmartAdd";
            this.radSmartAdd.Size = new System.Drawing.Size(136, 17);
            this.radSmartAdd.TabIndex = 11;
            this.radSmartAdd.Text = "Smart A&dditive-Map Mix";
            this.radSmartAdd.UseVisualStyleBackColor = true;
            // 
            // radSmartSubtract
            // 
            this.radSmartSubtract.AutoSize = true;
            this.radSmartSubtract.Enabled = false;
            this.radSmartSubtract.Location = new System.Drawing.Point(49, 52);
            this.radSmartSubtract.Name = "radSmartSubtract";
            this.radSmartSubtract.Size = new System.Drawing.Size(152, 17);
            this.radSmartSubtract.TabIndex = 10;
            this.radSmartSubtract.Text = "Smart S&ubtractive Map Mix";
            this.radSmartSubtract.UseVisualStyleBackColor = true;
            // 
            // radShuffled
            // 
            this.radShuffled.AutoSize = true;
            this.radShuffled.Location = new System.Drawing.Point(49, 29);
            this.radShuffled.Name = "radShuffled";
            this.radShuffled.Size = new System.Drawing.Size(83, 17);
            this.radShuffled.TabIndex = 9;
            this.radShuffled.Text = "&Shuffled Mix";
            this.radShuffled.UseVisualStyleBackColor = true;
            // 
            // radOrdered
            // 
            this.radOrdered.AutoSize = true;
            this.radOrdered.Checked = true;
            this.radOrdered.Location = new System.Drawing.Point(49, 6);
            this.radOrdered.Name = "radOrdered";
            this.radOrdered.Size = new System.Drawing.Size(158, 17);
            this.radOrdered.TabIndex = 8;
            this.radOrdered.TabStop = true;
            this.radOrdered.Text = "&Ordered Mix (recommended)";
            this.radOrdered.UseVisualStyleBackColor = true;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(6, 8);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(37, 13);
            this.lblMode.TabIndex = 8;
            this.lblMode.Text = "Mode:";
            // 
            // tbcParameters
            // 
            this.tbcParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcParameters.Controls.Add(this.tabIntelligence);
            this.tbcParameters.Controls.Add(this.tabProbabilities);
            this.tbcParameters.Controls.Add(this.tabExcluded);
            this.tbcParameters.Controls.Add(this.tabExtras);
            this.tbcParameters.Location = new System.Drawing.Point(12, 172);
            this.tbcParameters.Name = "tbcParameters";
            this.tbcParameters.SelectedIndex = 0;
            this.tbcParameters.Size = new System.Drawing.Size(660, 435);
            this.tbcParameters.TabIndex = 11;
            // 
            // tabIntelligence
            // 
            this.tabIntelligence.Controls.Add(this.lblExpandPortals);
            this.tabIntelligence.Controls.Add(this.lblMode);
            this.tabIntelligence.Controls.Add(this.chkExpandPortals);
            this.tabIntelligence.Controls.Add(this.lblKeepEventTag);
            this.tabIntelligence.Controls.Add(this.lblTranslateCOG);
            this.tabIntelligence.Controls.Add(this.chkKeepWorldCons);
            this.tabIntelligence.Controls.Add(this.chkTranslateCOG);
            this.tabIntelligence.Controls.Add(this.chkKeepEventTag);
            this.tabIntelligence.Controls.Add(this.chkRemTrapPlay);
            this.tabIntelligence.Controls.Add(this.lblKeepWorldCons);
            this.tabIntelligence.Controls.Add(this.radSmartAdd);
            this.tabIntelligence.Controls.Add(this.radOrdered);
            this.tabIntelligence.Controls.Add(this.radSmartSubtract);
            this.tabIntelligence.Controls.Add(this.radShuffled);
            this.tabIntelligence.Location = new System.Drawing.Point(4, 22);
            this.tabIntelligence.Name = "tabIntelligence";
            this.tabIntelligence.Padding = new System.Windows.Forms.Padding(3);
            this.tabIntelligence.Size = new System.Drawing.Size(652, 409);
            this.tabIntelligence.TabIndex = 0;
            this.tabIntelligence.Text = "Intelligence";
            this.tabIntelligence.UseVisualStyleBackColor = true;
            // 
            // tabProbabilities
            // 
            this.tabProbabilities.Controls.Add(this.lblProbs);
            this.tabProbabilities.Controls.Add(this.numNonSolid);
            this.tabProbabilities.Controls.Add(this.numSolid);
            this.tabProbabilities.Controls.Add(this.lblNonSolid);
            this.tabProbabilities.Controls.Add(this.lblSolid);
            this.tabProbabilities.Controls.Add(this.numSemiSolid);
            this.tabProbabilities.Controls.Add(this.lblLight);
            this.tabProbabilities.Controls.Add(this.lblSemiSolid);
            this.tabProbabilities.Controls.Add(this.numLight);
            this.tabProbabilities.Controls.Add(this.numMover);
            this.tabProbabilities.Controls.Add(this.lblOther);
            this.tabProbabilities.Controls.Add(this.lblMover);
            this.tabProbabilities.Controls.Add(this.numOther);
            this.tabProbabilities.Controls.Add(this.numSubtract);
            this.tabProbabilities.Controls.Add(this.lblSubtract);
            this.tabProbabilities.Location = new System.Drawing.Point(4, 22);
            this.tabProbabilities.Name = "tabProbabilities";
            this.tabProbabilities.Padding = new System.Windows.Forms.Padding(3);
            this.tabProbabilities.Size = new System.Drawing.Size(652, 409);
            this.tabProbabilities.TabIndex = 1;
            this.tabProbabilities.Text = "Probabilities";
            this.tabProbabilities.UseVisualStyleBackColor = true;
            // 
            // lblProbs
            // 
            this.lblProbs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProbs.Location = new System.Drawing.Point(6, 8);
            this.lblProbs.Margin = new System.Windows.Forms.Padding(3);
            this.lblProbs.Name = "lblProbs";
            this.lblProbs.Size = new System.Drawing.Size(640, 26);
            this.lblProbs.TabIndex = 16;
            this.lblProbs.Text = "These values specify the probabilities that a particular actor will be copied fro" +
    "m a source map to the mixed map, depending on its type.";
            // 
            // tabExcluded
            // 
            this.tabExcluded.Controls.Add(this.lblExclusions);
            this.tabExcluded.Controls.Add(this.chkExPortal);
            this.tabExcluded.Controls.Add(this.chkExInvis);
            this.tabExcluded.Controls.Add(this.txtExcludeActors);
            this.tabExcluded.Controls.Add(this.chkExMore);
            this.tabExcluded.Controls.Add(this.chkExZoneInfo);
            this.tabExcluded.Location = new System.Drawing.Point(4, 22);
            this.tabExcluded.Name = "tabExcluded";
            this.tabExcluded.Padding = new System.Windows.Forms.Padding(3);
            this.tabExcluded.Size = new System.Drawing.Size(652, 409);
            this.tabExcluded.TabIndex = 2;
            this.tabExcluded.Text = "Exclusions";
            this.tabExcluded.UseVisualStyleBackColor = true;
            // 
            // lblExclusions
            // 
            this.lblExclusions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExclusions.Location = new System.Drawing.Point(6, 6);
            this.lblExclusions.Margin = new System.Windows.Forms.Padding(3);
            this.lblExclusions.Name = "lblExclusions";
            this.lblExclusions.Size = new System.Drawing.Size(640, 26);
            this.lblExclusions.TabIndex = 17;
            this.lblExclusions.Text = "If checked, the following objects will not be copied from the source maps. If you" +
    " are mixing subtractive maps with high brush copy probabilities, then feel free " +
    "to turn these off.";
            // 
            // tabExtras
            // 
            this.tabExtras.Controls.Add(this.chkSwapTex);
            this.tabExtras.Controls.Add(this.chkSwapAct);
            this.tabExtras.Location = new System.Drawing.Point(4, 22);
            this.tabExtras.Name = "tabExtras";
            this.tabExtras.Padding = new System.Windows.Forms.Padding(3);
            this.tabExtras.Size = new System.Drawing.Size(652, 409);
            this.tabExtras.TabIndex = 3;
            this.tabExtras.Text = "Extras";
            this.tabExtras.UseVisualStyleBackColor = true;
            // 
            // chkSwapTex
            // 
            this.chkSwapTex.AutoSize = true;
            this.chkSwapTex.Enabled = false;
            this.chkSwapTex.Location = new System.Drawing.Point(6, 6);
            this.chkSwapTex.Name = "chkSwapTex";
            this.chkSwapTex.Size = new System.Drawing.Size(97, 17);
            this.chkSwapTex.TabIndex = 1;
            this.chkSwapTex.Text = "Swap &Textures";
            this.chkSwapTex.UseVisualStyleBackColor = true;
            // 
            // chkSwapAct
            // 
            this.chkSwapAct.AutoSize = true;
            this.chkSwapAct.Enabled = false;
            this.chkSwapAct.Location = new System.Drawing.Point(6, 29);
            this.chkSwapAct.Name = "chkSwapAct";
            this.chkSwapAct.Size = new System.Drawing.Size(86, 17);
            this.chkSwapAct.TabIndex = 0;
            this.chkSwapAct.Text = "Swap &Actors";
            this.chkSwapAct.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 661);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.tbcParameters);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpInputFiles);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 640);
            this.Name = "frmMain";
            this.Text = "Unreal Tournament Map Mixer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numSolid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNonSolid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSemiSolid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSubtract)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOther)).EndInit();
            this.grpInputFiles.ResumeLayout(false);
            this.tbcParameters.ResumeLayout(false);
            this.tabIntelligence.ResumeLayout(false);
            this.tabIntelligence.PerformLayout();
            this.tabProbabilities.ResumeLayout(false);
            this.tabProbabilities.PerformLayout();
            this.tabExcluded.ResumeLayout(false);
            this.tabExcluded.PerformLayout();
            this.tabExtras.ResumeLayout(false);
            this.tabExtras.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSolid;
        private System.Windows.Forms.NumericUpDown numSolid;
        private System.Windows.Forms.NumericUpDown numLight;
        private System.Windows.Forms.Label lblLight;
        private System.Windows.Forms.NumericUpDown numOther;
        private System.Windows.Forms.Label lblOther;
        private System.Windows.Forms.TextBox txtExcludeActors;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.GroupBox grpInputFiles;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tlblAuthor;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.CheckBox chkExMore;
        private System.Windows.Forms.Label lblKeepEventTag;
        private System.Windows.Forms.CheckBox chkKeepEventTag;
        private System.Windows.Forms.CheckBox chkKeepWorldCons;
        private System.Windows.Forms.Label lblKeepWorldCons;
        private System.Windows.Forms.RadioButton radSmartAdd;
        private System.Windows.Forms.RadioButton radSmartSubtract;
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
        private System.Windows.Forms.ListView lvwSourceFiles;
        private System.Windows.Forms.ColumnHeader clmPath;
        private System.Windows.Forms.ColumnHeader clmTitle;
        private System.Windows.Forms.ColumnHeader clmAuthor;
        private System.Windows.Forms.ColumnHeader clmType;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.TabControl tbcParameters;
        private System.Windows.Forms.TabPage tabIntelligence;
        private System.Windows.Forms.TabPage tabProbabilities;
        private System.Windows.Forms.TabPage tabExcluded;
        private System.Windows.Forms.TabPage tabExtras;
        private System.Windows.Forms.CheckBox chkSwapTex;
        private System.Windows.Forms.CheckBox chkSwapAct;
        private System.Windows.Forms.Label lblProbs;
        private System.Windows.Forms.Label lblExclusions;
    }
}

