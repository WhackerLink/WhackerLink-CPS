namespace Whackerlink_CPS
{
    partial class Form1
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
            this.kryptonRibbon1 = new Krypton.Ribbon.KryptonRibbon();
            this.QATRead = new Krypton.Ribbon.KryptonRibbonQATButton();
            this.QATSave = new Krypton.Ribbon.KryptonRibbonQATButton();
            this.ButtonRead = new Krypton.Toolkit.KryptonContextMenuItem();
            this.ButtonSave = new Krypton.Toolkit.KryptonContextMenuItem();
            this.kryptonRibbonTab1 = new Krypton.Ribbon.KryptonRibbonTab();
            this.kryptonRibbonGroup1 = new Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple1 = new Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.RibbonCodeplugFileRead = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.KryptonCodeplugFileSave = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupButton3 = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroup2 = new Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple2 = new Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.RibbonCodeplugNodeAdd = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.RibbonCodeplugNodeUpdate = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.RibbonCodeplugNodeDelete = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonTab2 = new Krypton.Ribbon.KryptonRibbonTab();
            this.kryptonRibbonGroup3 = new Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple3 = new Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.RibbonSettingsThemeLight = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.RibbonSettingsThemeBlue = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.RibbonSettingsThemeDark = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupTriple4 = new Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.RibbonSettingsThemeSilverL = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.RibbonSettingsThemeSparkle = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.RibbonSettingThemeSilverD = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonTab3 = new Krypton.Ribbon.KryptonRibbonTab();
            this.kryptonRibbonGroup4 = new Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple5 = new Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.RibbonHelpHelpAbout = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.RibbonHelpHelpHelpTopics = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupButton4 = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.treeView1 = new Krypton.Toolkit.KryptonTreeView();
            this.panel2 = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonRibbon1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonRibbon1
            // 
            this.kryptonRibbon1.AllowFormIntegrate = true;
            this.kryptonRibbon1.InDesignHelperMode = true;
            this.kryptonRibbon1.Name = "kryptonRibbon1";
            this.kryptonRibbon1.QATButtons.AddRange(new System.ComponentModel.Component[] {
            this.QATRead,
            this.QATSave});
            this.kryptonRibbon1.QATUserChange = false;
            this.kryptonRibbon1.RibbonAppButton.AppButtonMenuItems.AddRange(new Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.ButtonRead,
            this.ButtonSave});
            this.kryptonRibbon1.RibbonTabs.AddRange(new Krypton.Ribbon.KryptonRibbonTab[] {
            this.kryptonRibbonTab1,
            this.kryptonRibbonTab2,
            this.kryptonRibbonTab3});
            this.kryptonRibbon1.SelectedContext = null;
            this.kryptonRibbon1.SelectedTab = this.kryptonRibbonTab1;
            this.kryptonRibbon1.Size = new System.Drawing.Size(2002, 259);
            this.kryptonRibbon1.TabIndex = 0;
            // 
            // QATRead
            // 
            this.QATRead.Image = global::Whackerlink_CPS.Properties.Resources.Read_16x16;
            this.QATRead.Click += new System.EventHandler(this.QATRead_Click);
            // 
            // QATSave
            // 
            this.QATSave.Image = global::Whackerlink_CPS.Properties.Resources.Save_16x16;
            this.QATSave.Click += new System.EventHandler(this.QATSave_Click);
            // 
            // ButtonRead
            // 
            this.ButtonRead.Text = "Read Codeplug";
            this.ButtonRead.Click += new System.EventHandler(this.ButtonRead_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Text = "Save Codeplug";
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // kryptonRibbonTab1
            // 
            this.kryptonRibbonTab1.Groups.AddRange(new Krypton.Ribbon.KryptonRibbonGroup[] {
            this.kryptonRibbonGroup1,
            this.kryptonRibbonGroup2});
            this.kryptonRibbonTab1.Text = "Codeplug";
            // 
            // kryptonRibbonGroup1
            // 
            this.kryptonRibbonGroup1.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple1});
            this.kryptonRibbonGroup1.TextLine1 = "File Menu";
            // 
            // kryptonRibbonGroupTriple1
            // 
            this.kryptonRibbonGroupTriple1.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.RibbonCodeplugFileRead,
            this.KryptonCodeplugFileSave,
            this.kryptonRibbonGroupButton3});
            // 
            // RibbonCodeplugFileRead
            // 
            this.RibbonCodeplugFileRead.ImageLarge = global::Whackerlink_CPS.Properties.Resources.Read_64x64;
            this.RibbonCodeplugFileRead.TextLine1 = "Read";
            this.RibbonCodeplugFileRead.TextLine2 = "Codeplug";
            this.RibbonCodeplugFileRead.Click += new System.EventHandler(this.RibbonCodeplugFileRead_Click);
            // 
            // KryptonCodeplugFileSave
            // 
            this.KryptonCodeplugFileSave.ImageLarge = global::Whackerlink_CPS.Properties.Resources.Save_64x64;
            this.KryptonCodeplugFileSave.TextLine1 = "Save";
            this.KryptonCodeplugFileSave.TextLine2 = "Codeplug";
            this.KryptonCodeplugFileSave.Click += new System.EventHandler(this.KryptonCodeplugFileSave_Click);
            // 
            // kryptonRibbonGroupButton3
            // 
            this.kryptonRibbonGroupButton3.Visible = false;
            // 
            // kryptonRibbonGroup2
            // 
            this.kryptonRibbonGroup2.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple2});
            this.kryptonRibbonGroup2.TextLine1 = "Node Menu";
            // 
            // kryptonRibbonGroupTriple2
            // 
            this.kryptonRibbonGroupTriple2.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.RibbonCodeplugNodeAdd,
            this.RibbonCodeplugNodeUpdate,
            this.RibbonCodeplugNodeDelete});
            // 
            // RibbonCodeplugNodeAdd
            // 
            this.RibbonCodeplugNodeAdd.ImageLarge = global::Whackerlink_CPS.Properties.Resources.Add;
            this.RibbonCodeplugNodeAdd.TextLine1 = "Add";
            this.RibbonCodeplugNodeAdd.Click += new System.EventHandler(this.RibbonCodeplugNodeAdd_Click);
            // 
            // RibbonCodeplugNodeUpdate
            // 
            this.RibbonCodeplugNodeUpdate.ImageLarge = global::Whackerlink_CPS.Properties.Resources.update;
            this.RibbonCodeplugNodeUpdate.TextLine1 = "Update";
            this.RibbonCodeplugNodeUpdate.Click += new System.EventHandler(this.RibbonCodeplugNodeUpdate_Click);
            // 
            // RibbonCodeplugNodeDelete
            // 
            this.RibbonCodeplugNodeDelete.ImageLarge = global::Whackerlink_CPS.Properties.Resources.Delete;
            this.RibbonCodeplugNodeDelete.TextLine1 = "Delete";
            this.RibbonCodeplugNodeDelete.Click += new System.EventHandler(this.RibbonCodeplugNodeDelete_Click);
            // 
            // kryptonRibbonTab2
            // 
            this.kryptonRibbonTab2.Groups.AddRange(new Krypton.Ribbon.KryptonRibbonGroup[] {
            this.kryptonRibbonGroup3});
            this.kryptonRibbonTab2.Text = "Settings";
            // 
            // kryptonRibbonGroup3
            // 
            this.kryptonRibbonGroup3.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple3,
            this.kryptonRibbonGroupTriple4});
            this.kryptonRibbonGroup3.TextLine1 = "Theme";
            // 
            // kryptonRibbonGroupTriple3
            // 
            this.kryptonRibbonGroupTriple3.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.RibbonSettingsThemeLight,
            this.RibbonSettingsThemeBlue,
            this.RibbonSettingsThemeDark});
            // 
            // RibbonSettingsThemeLight
            // 
            this.RibbonSettingsThemeLight.ImageLarge = global::Whackerlink_CPS.Properties.Resources.Theme;
            this.RibbonSettingsThemeLight.TextLine1 = "Light";
            this.RibbonSettingsThemeLight.Click += new System.EventHandler(this.RibbonSettingsThemeLight_Click);
            // 
            // RibbonSettingsThemeBlue
            // 
            this.RibbonSettingsThemeBlue.ImageLarge = global::Whackerlink_CPS.Properties.Resources.Theme;
            this.RibbonSettingsThemeBlue.TextLine1 = "Blue";
            this.RibbonSettingsThemeBlue.Click += new System.EventHandler(this.RibbonSettingsThemeBlue_Click);
            // 
            // RibbonSettingsThemeDark
            // 
            this.RibbonSettingsThemeDark.ImageLarge = global::Whackerlink_CPS.Properties.Resources.Theme;
            this.RibbonSettingsThemeDark.TextLine1 = "Dark";
            this.RibbonSettingsThemeDark.Click += new System.EventHandler(this.RibbonSettingsThemeDark_Click);
            // 
            // kryptonRibbonGroupTriple4
            // 
            this.kryptonRibbonGroupTriple4.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.RibbonSettingsThemeSilverL,
            this.RibbonSettingsThemeSparkle,
            this.RibbonSettingThemeSilverD});
            // 
            // RibbonSettingsThemeSilverL
            // 
            this.RibbonSettingsThemeSilverL.ImageLarge = global::Whackerlink_CPS.Properties.Resources.Theme;
            this.RibbonSettingsThemeSilverL.TextLine1 = "Silver";
            this.RibbonSettingsThemeSilverL.TextLine2 = "Light";
            this.RibbonSettingsThemeSilverL.Click += new System.EventHandler(this.RibbonSettingsThemeSilverL_Click);
            // 
            // RibbonSettingsThemeSparkle
            // 
            this.RibbonSettingsThemeSparkle.ImageLarge = global::Whackerlink_CPS.Properties.Resources.Theme;
            this.RibbonSettingsThemeSparkle.TextLine1 = "Sparkle";
            this.RibbonSettingsThemeSparkle.Click += new System.EventHandler(this.RibbonSettingsThemeSparkle_Click);
            // 
            // RibbonSettingThemeSilverD
            // 
            this.RibbonSettingThemeSilverD.ImageLarge = global::Whackerlink_CPS.Properties.Resources.Theme;
            this.RibbonSettingThemeSilverD.TextLine1 = "Silver";
            this.RibbonSettingThemeSilverD.TextLine2 = "Dark";
            this.RibbonSettingThemeSilverD.Click += new System.EventHandler(this.RibbonSettingThemeSilverD_Click);
            // 
            // kryptonRibbonTab3
            // 
            this.kryptonRibbonTab3.Groups.AddRange(new Krypton.Ribbon.KryptonRibbonGroup[] {
            this.kryptonRibbonGroup4});
            this.kryptonRibbonTab3.Text = "Help";
            // 
            // kryptonRibbonGroup4
            // 
            this.kryptonRibbonGroup4.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple5});
            this.kryptonRibbonGroup4.TextLine1 = "Help";
            // 
            // kryptonRibbonGroupTriple5
            // 
            this.kryptonRibbonGroupTriple5.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.RibbonHelpHelpAbout,
            this.RibbonHelpHelpHelpTopics,
            this.kryptonRibbonGroupButton4});
            // 
            // RibbonHelpHelpAbout
            // 
            this.RibbonHelpHelpAbout.ImageLarge = global::Whackerlink_CPS.Properties.Resources.Help;
            this.RibbonHelpHelpAbout.TextLine1 = "About";
            this.RibbonHelpHelpAbout.Click += new System.EventHandler(this.kryptonRibbonGroupButton1_Click);
            // 
            // RibbonHelpHelpHelpTopics
            // 
            this.RibbonHelpHelpHelpTopics.ImageLarge = global::Whackerlink_CPS.Properties.Resources.Search;
            this.RibbonHelpHelpHelpTopics.Click += new System.EventHandler(this.RibbonHelpHelpHelpTopics_Click);
            // 
            // kryptonRibbonGroupButton4
            // 
            this.kryptonRibbonGroupButton4.Visible = false;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.treeView1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 259);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(464, 679);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(464, 679);
            this.treeView1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(464, 259);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1538, 679);
            this.panel2.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2002, 938);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.kryptonRibbon1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonRibbon1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Ribbon.KryptonRibbon kryptonRibbon1;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonPanel panel2;
        private Krypton.Toolkit.KryptonTreeView treeView1;
        private Krypton.Ribbon.KryptonRibbonTab kryptonRibbonTab1;
        private Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup1;
        private Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple1;
        private Krypton.Ribbon.KryptonRibbonGroupButton RibbonCodeplugFileRead;
        private Krypton.Ribbon.KryptonRibbonGroupButton KryptonCodeplugFileSave;
        private Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton3;
        private Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup2;
        private Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple2;
        private Krypton.Ribbon.KryptonRibbonGroupButton RibbonCodeplugNodeAdd;
        private Krypton.Ribbon.KryptonRibbonGroupButton RibbonCodeplugNodeUpdate;
        private Krypton.Ribbon.KryptonRibbonGroupButton RibbonCodeplugNodeDelete;
        private Krypton.Ribbon.KryptonRibbonQATButton QATRead;
        private Krypton.Ribbon.KryptonRibbonQATButton QATSave;
        private Krypton.Toolkit.KryptonContextMenuItem ButtonRead;
        private Krypton.Toolkit.KryptonContextMenuItem ButtonSave;
        private Krypton.Ribbon.KryptonRibbonTab kryptonRibbonTab2;
        private Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup3;
        private Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple3;
        private Krypton.Ribbon.KryptonRibbonGroupButton RibbonSettingsThemeLight;
        private Krypton.Ribbon.KryptonRibbonGroupButton RibbonSettingsThemeBlue;
        private Krypton.Ribbon.KryptonRibbonGroupButton RibbonSettingsThemeDark;
        private Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple4;
        private Krypton.Ribbon.KryptonRibbonGroupButton RibbonSettingsThemeSilverL;
        private Krypton.Ribbon.KryptonRibbonGroupButton RibbonSettingsThemeSparkle;
        private Krypton.Ribbon.KryptonRibbonGroupButton RibbonSettingThemeSilverD;
        private Krypton.Ribbon.KryptonRibbonTab kryptonRibbonTab3;
        private Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup4;
        private Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple5;
        private Krypton.Ribbon.KryptonRibbonGroupButton RibbonHelpHelpAbout;
        private Krypton.Ribbon.KryptonRibbonGroupButton RibbonHelpHelpHelpTopics;
        private Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton4;
    }
}

