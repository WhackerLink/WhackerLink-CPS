namespace Whackerlink_CPS
{
    partial class SystemForm
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
            this.txtAddress = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.txtPort = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.txtRid = new Krypton.Toolkit.KryptonTextBox();
            this.btnUpdate = new Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(299, 72);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(212, 39);
            this.txtName.TabIndex = 0;
            this.txtName.Text = "kryptonTextBox1";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(195, 74);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(85, 37);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Name:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(145, 130);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(135, 37);
            this.kryptonLabel2.TabIndex = 3;
            this.kryptonLabel2.Values.Text = "IP Address:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(299, 130);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(212, 39);
            this.txtAddress.TabIndex = 1;
            this.txtAddress.Text = "kryptonTextBox1";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(215, 192);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(65, 37);
            this.kryptonLabel3.TabIndex = 5;
            this.kryptonLabel3.Values.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(299, 192);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(212, 39);
            this.txtPort.TabIndex = 2;
            this.txtPort.Text = "kryptonTextBox1";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(200, 258);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(80, 37);
            this.kryptonLabel4.TabIndex = 7;
            this.kryptonLabel4.Values.Text = "TG ID:";
            // 
            // txtRid
            // 
            this.txtRid.Location = new System.Drawing.Point(299, 256);
            this.txtRid.Name = "txtRid";
            this.txtRid.Size = new System.Drawing.Size(212, 39);
            this.txtRid.TabIndex = 3;
            this.txtRid.Text = "kryptonTextBox1";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(321, 338);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(198, 59);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Values.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // SystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.txtRid);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.txtName);
            this.Name = "SystemForm";
            this.Text = "SystemForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonTextBox txtName;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonTextBox txtAddress;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonTextBox txtPort;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonTextBox txtRid;
        private Krypton.Toolkit.KryptonButton btnUpdate;
    }
}