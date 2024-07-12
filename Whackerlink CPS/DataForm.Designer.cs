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
            ((System.ComponentModel.ISupportInitialize)(this.cmbSystems)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(386, 102);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(216, 39);
            this.txtName.TabIndex = 2;
            this.txtName.Text = "kryptonTextBox1";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(197, 104);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(170, 37);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "System Name:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(197, 170);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(164, 37);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "System Select";
            // 
            // txtTgid
            // 
            this.txtTgid.Location = new System.Drawing.Point(386, 236);
            this.txtTgid.Name = "txtTgid";
            this.txtTgid.Size = new System.Drawing.Size(216, 39);
            this.txtTgid.TabIndex = 4;
            this.txtTgid.Text = "kryptonTextBox1";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(197, 238);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(124, 37);
            this.kryptonLabel3.TabIndex = 4;
            this.kryptonLabel3.Values.Text = "Talkgroup";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(269, 300);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(232, 53);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Values.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(220, 44);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(147, 37);
            this.kryptonLabel4.TabIndex = 8;
            this.kryptonLabel4.Values.Text = "Zone Name:";
            // 
            // txtZoneName
            // 
            this.txtZoneName.Location = new System.Drawing.Point(386, 42);
            this.txtZoneName.Name = "txtZoneName";
            this.txtZoneName.Size = new System.Drawing.Size(216, 39);
            this.txtZoneName.TabIndex = 1;
            this.txtZoneName.Text = "kryptonTextBox1";
            // 
            // cmbSystems
            // 
            this.cmbSystems.DropDownWidth = 216;
            this.cmbSystems.IntegralHeight = false;
            this.cmbSystems.Location = new System.Drawing.Point(386, 169);
            this.cmbSystems.Name = "cmbSystems";
            this.cmbSystems.Size = new System.Drawing.Size(216, 38);
            this.cmbSystems.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.cmbSystems.TabIndex = 3;
            this.cmbSystems.Text = "kryptonComboBox1";
            // 
            // DataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbSystems);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.txtZoneName);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtTgid);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.txtName);
            this.Name = "DataForm";
            this.Text = "DataForm";
            ((System.ComponentModel.ISupportInitialize)(this.cmbSystems)).EndInit();
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
    }
}