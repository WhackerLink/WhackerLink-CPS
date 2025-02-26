namespace Whackerlink_CPS
{
    partial class CreateCodeplugForm
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
            this.model = new Krypton.Toolkit.KryptonComboBox();
            this.serialNumber = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.inCarModel = new Krypton.Toolkit.KryptonComboBox();
            this.fiveMbox = new Krypton.Toolkit.KryptonCheckBox();
            this.createBtn = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.model)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inCarModel)).BeginInit();
            this.SuspendLayout();
            // 
            // model
            // 
            this.model.DropDownWidth = 162;
            this.model.IntegralHeight = false;
            this.model.Location = new System.Drawing.Point(224, 51);
            this.model.Name = "model";
            this.model.Size = new System.Drawing.Size(162, 22);
            this.model.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.model.TabIndex = 0;
            this.model.Text = "N/A";
            // 
            // serialNumber
            // 
            this.serialNumber.Location = new System.Drawing.Point(224, 109);
            this.serialNumber.Name = "serialNumber";
            this.serialNumber.Size = new System.Drawing.Size(162, 23);
            this.serialNumber.TabIndex = 1;
            this.serialNumber.Text = "123ABC1234";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(147, 51);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(48, 20);
            this.kryptonLabel1.TabIndex = 2;
            this.kryptonLabel1.Values.Text = "Model:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(152, 109);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(43, 20);
            this.kryptonLabel2.TabIndex = 3;
            this.kryptonLabel2.Values.Text = "Serial:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(150, 77);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(45, 20);
            this.kryptonLabel3.TabIndex = 4;
            this.kryptonLabel3.Values.Text = "In Car:";
            // 
            // inCarModel
            // 
            this.inCarModel.DropDownWidth = 162;
            this.inCarModel.IntegralHeight = false;
            this.inCarModel.Location = new System.Drawing.Point(224, 81);
            this.inCarModel.Name = "inCarModel";
            this.inCarModel.Size = new System.Drawing.Size(162, 22);
            this.inCarModel.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.inCarModel.TabIndex = 5;
            this.inCarModel.Text = "N/A";
            // 
            // fiveMbox
            // 
            this.fiveMbox.Location = new System.Drawing.Point(224, 150);
            this.fiveMbox.Name = "fiveMbox";
            this.fiveMbox.Size = new System.Drawing.Size(56, 20);
            this.fiveMbox.TabIndex = 6;
            this.fiveMbox.Values.Text = "FiveM";
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(199, 218);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(90, 25);
            this.createBtn.TabIndex = 7;
            this.createBtn.Values.Text = "Create";
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // CreateCodeplugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 356);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.fiveMbox);
            this.Controls.Add(this.inCarModel);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.serialNumber);
            this.Controls.Add(this.model);
            this.Name = "CreateCodeplugForm";
            this.Text = "CreateCodeplugForm";
            ((System.ComponentModel.ISupportInitialize)(this.model)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inCarModel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonComboBox model;
        private Krypton.Toolkit.KryptonTextBox serialNumber;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonComboBox inCarModel;
        private Krypton.Toolkit.KryptonCheckBox fiveMbox;
        private Krypton.Toolkit.KryptonButton createBtn;
    }
}