namespace Whackerlink_CPS
{
    partial class ScanListForm
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
            this.scanListChannelsGridView = new Krypton.Toolkit.KryptonDataGridView();
            this.scanListNameTextBox = new Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.scanListChannelsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // scanListChannelsGridView
            // 
            this.scanListChannelsGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.scanListChannelsGridView.Location = new System.Drawing.Point(47, 177);
            this.scanListChannelsGridView.Name = "scanListChannelsGridView";
            this.scanListChannelsGridView.Size = new System.Drawing.Size(708, 248);
            this.scanListChannelsGridView.TabIndex = 0;
            this.scanListChannelsGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.scanListChannelsGridView_CellContentClick);
            // 
            // scanListNameTextBox
            // 
            this.scanListNameTextBox.Location = new System.Drawing.Point(250, 48);
            this.scanListNameTextBox.Name = "scanListNameTextBox";
            this.scanListNameTextBox.Size = new System.Drawing.Size(100, 23);
            this.scanListNameTextBox.TabIndex = 1;
            this.scanListNameTextBox.Text = "scanListNameTextBox";
            // 
            // ScanListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.scanListNameTextBox);
            this.Controls.Add(this.scanListChannelsGridView);
            this.Name = "ScanListForm";
            this.Text = "ScanListForm";
            ((System.ComponentModel.ISupportInitialize)(this.scanListChannelsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonDataGridView scanListChannelsGridView;
        private Krypton.Toolkit.KryptonTextBox scanListNameTextBox;
    }
}