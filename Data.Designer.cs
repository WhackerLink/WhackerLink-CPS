namespace Whackerlink_CPS
{
    partial class Data
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
            this.txtChannelName = new Krypton.Toolkit.KryptonTextBox();
            this.txtSystem = new Krypton.Toolkit.KryptonTextBox();
            this.txtTgid = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.BtnOkay = new Krypton.Toolkit.KryptonButton();
            this.BtnCancel = new Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // txtChannelName
            // 
            this.txtChannelName.Location = new System.Drawing.Point(748, 67);
            this.txtChannelName.Name = "txtChannelName";
            this.txtChannelName.Size = new System.Drawing.Size(226, 39);
            this.txtChannelName.TabIndex = 0;
            this.txtChannelName.Text = "kryptonTextBox1";
            this.txtChannelName.TextChanged += new System.EventHandler(this.kryptonTextBox1_TextChanged);
            // 
            // txtSystem
            // 
            this.txtSystem.Location = new System.Drawing.Point(748, 112);
            this.txtSystem.Name = "txtSystem";
            this.txtSystem.Size = new System.Drawing.Size(226, 39);
            this.txtSystem.TabIndex = 1;
            this.txtSystem.Text = "kryptonTextBox2";
            this.txtSystem.TextChanged += new System.EventHandler(this.kryptonTextBox2_TextChanged);
            // 
            // txtTgid
            // 
            this.txtTgid.Location = new System.Drawing.Point(748, 157);
            this.txtTgid.Name = "txtTgid";
            this.txtTgid.Size = new System.Drawing.Size(226, 39);
            this.txtTgid.TabIndex = 2;
            this.txtTgid.Text = "kryptonTextBox3";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(537, 67);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(181, 37);
            this.kryptonLabel1.TabIndex = 3;
            this.kryptonLabel1.Values.Text = "Channel Name:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(589, 114);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(129, 37);
            this.kryptonLabel2.TabIndex = 4;
            this.kryptonLabel2.Values.Text = "System ID:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(638, 157);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(80, 37);
            this.kryptonLabel3.TabIndex = 5;
            this.kryptonLabel3.Values.Text = "TG ID: ";
            // 
            // BtnOkay
            // 
            this.BtnOkay.Location = new System.Drawing.Point(243, 476);
            this.BtnOkay.Name = "BtnOkay";
            this.BtnOkay.Size = new System.Drawing.Size(272, 93);
            this.BtnOkay.TabIndex = 6;
            this.BtnOkay.Values.Text = "Okay";
            this.BtnOkay.Click += new System.EventHandler(this.BtnOkay_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(674, 476);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(272, 93);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Values.Text = "Cancel";
            // 
            // Data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1174, 748);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOkay);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.txtTgid);
            this.Controls.Add(this.txtSystem);
            this.Controls.Add(this.txtChannelName);
            this.Name = "Data";
            this.Text = "Data";
            this.Load += new System.EventHandler(this.Data_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonTextBox txtChannelName;
        private Krypton.Toolkit.KryptonTextBox txtSystem;
        private Krypton.Toolkit.KryptonTextBox txtTgid;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonButton BtnOkay;
        private Krypton.Toolkit.KryptonButton BtnCancel;
    }
}