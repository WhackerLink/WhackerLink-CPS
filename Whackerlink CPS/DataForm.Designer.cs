namespace Whackerlink_CPS
{
    partial class DataForm
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
            this.txtName = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.txtTgid = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.btnUpdate = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.txtZoneName = new Krypton.Toolkit.KryptonTextBox();
            this.cmbSystems = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            this.EncryptionKey = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonCheckBox1 = new Krypton.Toolkit.KryptonCheckBox();
            this.btnGen = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel7 = new Krypton.Toolkit.KryptonLabel();
            this.EncryptionMode = new Krypton.Toolkit.KryptonComboBox();
            this.EncryptionType = new Krypton.Toolkit.KryptonComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSystems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EncryptionMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EncryptionType)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(193, 53);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(108, 23);
            this.txtName.TabIndex = 2;
            this.txtName.Text = "kryptonTextBox1";
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(98, 54);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(88, 20);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "System Name:";
            this.kryptonLabel1.Click += new System.EventHandler(this.kryptonLabel1_Click);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(98, 88);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(85, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "System Select";
            // 
            // txtTgid
            // 
            this.txtTgid.Location = new System.Drawing.Point(193, 123);
            this.txtTgid.Margin = new System.Windows.Forms.Padding(2);
            this.txtTgid.Name = "txtTgid";
            this.txtTgid.Size = new System.Drawing.Size(108, 23);
            this.txtTgid.TabIndex = 4;
            this.txtTgid.Text = "kryptonTextBox1";
            this.txtTgid.TextChanged += new System.EventHandler(this.txtTgid_TextChanged);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(108, 123);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(65, 20);
            this.kryptonLabel3.TabIndex = 4;
            this.kryptonLabel3.Values.Text = "Talkgroup";
            this.kryptonLabel3.Click += new System.EventHandler(this.kryptonLabel3_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(165, 306);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(116, 28);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Values.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(110, 23);
            this.kryptonLabel4.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(77, 20);
            this.kryptonLabel4.TabIndex = 8;
            this.kryptonLabel4.Values.Text = "Zone Name:";
            // 
            // txtZoneName
            // 
            this.txtZoneName.Location = new System.Drawing.Point(193, 22);
            this.txtZoneName.Margin = new System.Windows.Forms.Padding(2);
            this.txtZoneName.Name = "txtZoneName";
            this.txtZoneName.Size = new System.Drawing.Size(108, 23);
            this.txtZoneName.TabIndex = 1;
            this.txtZoneName.Text = "kryptonTextBox1";
            // 
            // cmbSystems
            // 
            this.cmbSystems.DropDownWidth = 216;
            this.cmbSystems.IntegralHeight = false;
            this.cmbSystems.Location = new System.Drawing.Point(193, 88);
            this.cmbSystems.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSystems.Name = "cmbSystems";
            this.cmbSystems.Size = new System.Drawing.Size(108, 22);
            this.cmbSystems.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.cmbSystems.TabIndex = 3;
            this.cmbSystems.Text = "kryptonComboBox1";
            this.cmbSystems.SelectedIndexChanged += new System.EventHandler(this.cmbSystems_SelectedIndexChanged);
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(82, 240);
            this.kryptonLabel6.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(91, 20);
            this.kryptonLabel6.TabIndex = 10;
            this.kryptonLabel6.Values.Text = "Encryption Key";
            // 
            // EncryptionKey
            // 
            this.EncryptionKey.Location = new System.Drawing.Point(187, 240);
            this.EncryptionKey.Margin = new System.Windows.Forms.Padding(2);
            this.EncryptionKey.Name = "EncryptionKey";
            this.EncryptionKey.PaletteMode = Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.EncryptionKey.Size = new System.Drawing.Size(465, 23);
            this.EncryptionKey.TabIndex = 17;
            this.EncryptionKey.Text = " EncryptionKey";
            this.EncryptionKey.TextChanged += new System.EventHandler(this.EncryptionKey_TextChanged);
            // 
            // kryptonCheckBox1
            // 
            this.kryptonCheckBox1.Location = new System.Drawing.Point(193, 268);
            this.kryptonCheckBox1.Name = "kryptonCheckBox1";
            this.kryptonCheckBox1.Size = new System.Drawing.Size(53, 20);
            this.kryptonCheckBox1.TabIndex = 13;
            this.kryptonCheckBox1.Values.Text = "Show";
            this.kryptonCheckBox1.CheckedChanged += new System.EventHandler(this.kryptonCheckBox1_CheckedChanged);
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(657, 240);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(90, 25);
            this.btnGen.TabIndex = 14;
            this.btnGen.Values.Text = "Generate Key";
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(79, 161);
            this.kryptonLabel5.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(104, 20);
            this.kryptonLabel5.TabIndex = 18;
            this.kryptonLabel5.Values.Text = "Encryption Mode";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(85, 200);
            this.kryptonLabel7.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(98, 20);
            this.kryptonLabel7.TabIndex = 19;
            this.kryptonLabel7.Values.Text = "Encryption Type";
            // 
            // EncryptionMode
            // 
            this.EncryptionMode.DropDownWidth = 216;
            this.EncryptionMode.IntegralHeight = false;
            this.EncryptionMode.Location = new System.Drawing.Point(187, 161);
            this.EncryptionMode.Margin = new System.Windows.Forms.Padding(2);
            this.EncryptionMode.Name = "EncryptionMode";
            this.EncryptionMode.Size = new System.Drawing.Size(108, 22);
            this.EncryptionMode.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.EncryptionMode.TabIndex = 20;
            this.EncryptionMode.Text = "EncryptionMode";
            // 
            // EncryptionType
            // 
            this.EncryptionType.DropDownWidth = 216;
            this.EncryptionType.IntegralHeight = false;
            this.EncryptionType.Location = new System.Drawing.Point(187, 200);
            this.EncryptionType.Margin = new System.Windows.Forms.Padding(2);
            this.EncryptionType.Name = "EncryptionType";
            this.EncryptionType.Size = new System.Drawing.Size(108, 22);
            this.EncryptionType.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.EncryptionType.TabIndex = 21;
            this.EncryptionType.Text = "EncryptionType";
            this.EncryptionType.SelectedIndexChanged += new System.EventHandler(this.EncryptionType_SelectedIndexChanged);
            // 
            // DataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 409);
            this.Controls.Add(this.EncryptionType);
            this.Controls.Add(this.EncryptionMode);
            this.Controls.Add(this.kryptonLabel7);
            this.Controls.Add(this.kryptonLabel5);
            this.Controls.Add(this.btnGen);
            this.Controls.Add(this.kryptonCheckBox1);
            this.Controls.Add(this.EncryptionKey);
            this.Controls.Add(this.kryptonLabel6);
            this.Controls.Add(this.cmbSystems);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.txtZoneName);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtTgid);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.txtName);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DataForm";
            this.Text = "DataForm";
            ((System.ComponentModel.ISupportInitialize)(this.cmbSystems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EncryptionMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EncryptionType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonTextBox txtName;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonTextBox txtTgid;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonButton btnUpdate;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonTextBox txtZoneName;
        private Krypton.Toolkit.KryptonComboBox cmbSystems;
        private Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private Krypton.Toolkit.KryptonTextBox EncryptionKey;
        private Krypton.Toolkit.KryptonCheckBox kryptonCheckBox1;
        private Krypton.Toolkit.KryptonButton btnGen;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private Krypton.Toolkit.KryptonComboBox EncryptionMode;
        private Krypton.Toolkit.KryptonComboBox EncryptionType;
    }
}