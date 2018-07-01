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
            this.grpProbabilities = new System.Windows.Forms.GroupBox();
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
            this.grpExcludeActors = new System.Windows.Forms.GroupBox();
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
            this.grpProbabilities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNonSolid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSemiSolid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSubtract)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOther)).BeginInit();
            this.grpInputFiles.SuspendLayout();
            this.grpExcludeActors.SuspendLayout();
            this.grpIntelligence.SuspendLayout();
            this.SuspendLayout();
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
            this.numSolid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numSolid.DecimalPlaces = 1;
            this.numSolid.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numSolid.Location = new System.Drawing.Point(194, 19);
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
            this.numLight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numLight.DecimalPlaces = 1;
            this.numLight.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numLight.Location = new System.Drawing.Point(194, 149);
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
            // grpProbabilities
            // 
            this.grpProbabilities.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpProbabilities.Controls.Add(this.numNonSolid);
            this.grpProbabilities.Controls.Add(this.lblNonSolid);
            this.grpProbabilities.Controls.Add(this.numSemiSolid);
            this.grpProbabilities.Controls.Add(this.lblSemiSolid);
            this.grpProbabilities.Controls.Add(this.numMover);
            this.grpProbabilities.Controls.Add(this.lblMover);
            this.grpProbabilities.Controls.Add(this.numSubtract);
            this.grpProbabilities.Controls.Add(this.lblSubtract);
            this.grpProbabilities.Controls.Add(this.numOther);
            this.grpProbabilities.Controls.Add(this.lblOther);
            this.grpProbabilities.Controls.Add(this.numLight);
            this.grpProbabilities.Controls.Add(this.lblLight);
            this.grpProbabilities.Controls.Add(this.numSolid);
            this.grpProbabilities.Controls.Add(this.lblSolid);
            this.grpProbabilities.Location = new System.Drawing.Point(392, 172);
            this.grpProbabilities.Name = "grpProbabilities";
            this.grpProbabilities.Size = new System.Drawing.Size(260, 201);
            this.grpProbabilities.TabIndex = 6;
            this.grpProbabilities.TabStop = false;
            this.grpProbabilities.Text = "Probabilities";
            // 
            // numNonSolid
            // 
            this.numNonSolid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numNonSolid.DecimalPlaces = 1;
            this.numNonSolid.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numNonSolid.Location = new System.Drawing.Point(194, 71);
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
            this.numSemiSolid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numSemiSolid.DecimalPlaces = 1;
            this.numSemiSolid.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numSemiSolid.Location = new System.Drawing.Point(194, 45);
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
            this.numMover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numMover.DecimalPlaces = 1;
            this.numMover.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numMover.Location = new System.Drawing.Point(194, 123);
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
            this.numSubtract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numSubtract.DecimalPlaces = 1;
            this.numSubtract.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numSubtract.Location = new System.Drawing.Point(194, 97);
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
            this.numOther.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numOther.DecimalPlaces = 1;
            this.numOther.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numOther.Location = new System.Drawing.Point(194, 175);
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
            // txtExcludeActors
            // 
            this.txtExcludeActors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExcludeActors.Location = new System.Drawing.Point(6, 111);
            this.txtExcludeActors.Multiline = true;
            this.txtExcludeActors.Name = "txtExcludeActors";
            this.txtExcludeActors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExcludeActors.Size = new System.Drawing.Size(248, 91);
            this.txtExcludeActors.TabIndex = 0;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(392, 593);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(260, 23);
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
            this.grpInputFiles.Size = new System.Drawing.Size(640, 154);
            this.grpInputFiles.TabIndex = 9;
            this.grpInputFiles.TabStop = false;
            this.grpInputFiles.Text = "Source Files";
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Location = new System.Drawing.Point(559, 77);
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
            this.btnRemove.Location = new System.Drawing.Point(559, 48);
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
            this.lvwSourceFiles.Size = new System.Drawing.Size(547, 129);
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
            this.btnAdd.Location = new System.Drawing.Point(559, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "&Add...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 619);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(664, 22);
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
            // grpExcludeActors
            // 
            this.grpExcludeActors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpExcludeActors.Controls.Add(this.chkExPortal);
            this.grpExcludeActors.Controls.Add(this.chkExInvis);
            this.grpExcludeActors.Controls.Add(this.chkExMore);
            this.grpExcludeActors.Controls.Add(this.chkExZoneInfo);
            this.grpExcludeActors.Controls.Add(this.txtExcludeActors);
            this.grpExcludeActors.Location = new System.Drawing.Point(392, 379);
            this.grpExcludeActors.Name = "grpExcludeActors";
            this.grpExcludeActors.Size = new System.Drawing.Size(260, 208);
            this.grpExcludeActors.TabIndex = 7;
            this.grpExcludeActors.TabStop = false;
            this.grpExcludeActors.Text = "Excluded Actors";
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
            this.chkExZoneInfo.Size = new System.Drawing.Size(253, 17);
            this.chkExZoneInfo.TabIndex = 1;
            this.chkExZoneInfo.Text = "&ZoneInfo (and subclasses, except SkyZoneInfo)\r\n";
            this.chkExZoneInfo.UseVisualStyleBackColor = true;
            // 
            // chkKeepEventTag
            // 
            this.chkKeepEventTag.AutoSize = true;
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
            this.lblKeepEventTag.Size = new System.Drawing.Size(362, 52);
            this.lblKeepEventTag.TabIndex = 4;
            this.lblKeepEventTag.Text = resources.GetString("lblKeepEventTag.Text");
            // 
            // chkKeepWorldCons
            // 
            this.chkKeepWorldCons.AutoSize = true;
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
            this.lblKeepWorldCons.Size = new System.Drawing.Size(362, 52);
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
            this.grpIntelligence.Location = new System.Drawing.Point(12, 172);
            this.grpIntelligence.Name = "grpIntelligence";
            this.grpIntelligence.Size = new System.Drawing.Size(374, 444);
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
            this.lblExpandPortals.Size = new System.Drawing.Size(362, 52);
            this.lblExpandPortals.TabIndex = 16;
            this.lblExpandPortals.Text = resources.GetString("lblExpandPortals.Text");
            // 
            // chkExpandPortals
            // 
            this.chkExpandPortals.AutoSize = true;
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
            this.lblTranslateCOG.Size = new System.Drawing.Size(362, 39);
            this.lblTranslateCOG.TabIndex = 14;
            this.lblTranslateCOG.Text = "If checked, all input maps will first be \'moved to the origin\' by steps of 64, to" +
    " prevent that the mixed map content would become too disjunct due to differently" +
    " located source maps.";
            // 
            // chkTranslateCOG
            // 
            this.chkTranslateCOG.AutoSize = true;
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
            this.ClientSize = new System.Drawing.Size(664, 641);
            this.Controls.Add(this.grpIntelligence);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpInputFiles);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.grpProbabilities);
            this.Controls.Add(this.grpExcludeActors);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(680, 680);
            this.Name = "frmMain";
            this.Text = "Unreal Tournament Map Mixer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numSolid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLight)).EndInit();
            this.grpProbabilities.ResumeLayout(false);
            this.grpProbabilities.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNonSolid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSemiSolid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSubtract)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOther)).EndInit();
            this.grpInputFiles.ResumeLayout(false);
            this.grpExcludeActors.ResumeLayout(false);
            this.grpExcludeActors.PerformLayout();
            this.grpIntelligence.ResumeLayout(false);
            this.grpIntelligence.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSolid;
        private System.Windows.Forms.NumericUpDown numSolid;
        private System.Windows.Forms.NumericUpDown numLight;
        private System.Windows.Forms.Label lblLight;
        private System.Windows.Forms.GroupBox grpProbabilities;
        private System.Windows.Forms.NumericUpDown numOther;
        private System.Windows.Forms.Label lblOther;
        private System.Windows.Forms.TextBox txtExcludeActors;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.GroupBox grpInputFiles;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tlblAuthor;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.CheckBox chkExMore;
        private System.Windows.Forms.GroupBox grpExcludeActors;
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
        private System.Windows.Forms.ListView lvwSourceFiles;
        private System.Windows.Forms.ColumnHeader clmPath;
        private System.Windows.Forms.ColumnHeader clmTitle;
        private System.Windows.Forms.ColumnHeader clmAuthor;
        private System.Windows.Forms.ColumnHeader clmType;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnView;
    }
}

