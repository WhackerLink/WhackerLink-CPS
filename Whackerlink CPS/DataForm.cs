/*
* WhackerLink - WhackerLink-CPS
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
* 
* Copyright (C) 2024 Hanna Johnson (Elleran)
* 
*/

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Windows.Forms;
using Krypton.Toolkit;

namespace Whackerlink_CPS
{
    public partial class DataForm : Form
    {
        public event EventHandler<ChannelUpdatedEventArgs> ChannelUpdated;
        private TreeNode _selectedNode;
        private List<string> _systems;
        private List<string> _systemIds;

        public DataForm(TreeNode selectedNode, List<string> systems, List<string> systemIds)
        {
            InitializeComponent();
            _selectedNode = selectedNode;
            _systems = systems;
            _systemIds = systemIds;
            LoadSystems();
            LoadNodeData();
            EncryptionType.Items.Add("None");
            EncryptionType.Items.Add("AES-256");
            EncryptionType.SelectedIndex = 0; 
            EncryptionType.SelectedIndexChanged += EncryptionType_SelectedIndexChanged;
            EncryptionMode.Items.Add("Strapped");
            EncryptionMode.Items.Add("Selectable");
            EncryptionMode.SelectedIndex = 0; 
            EncryptionMode.SelectedIndexChanged += EncryptionType_SelectedIndexChanged;



            EncryptionKey.Enabled = false;
            btnGen.Enabled = false;
            kryptonCheckBox1.Enabled = false;



            EncryptionKey.UseSystemPasswordChar = true;
        }

        private void LoadSystems()
        {
            cmbSystems.DataSource = _systems;
        }

        public void SetTgid(string tgid)
        {
            txtTgid.Text = tgid;
        }
  


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedNode != null)
            {
                string originalChannelName = _selectedNode.Text;

                
                _selectedNode.Text = txtName.Text;

                
                var channelData = _selectedNode.Tag as Codeplug.Channel ?? new Codeplug.Channel();

                
                channelData.Name = txtName.Text;
                channelData.System = cmbSystems.SelectedItem?.ToString() ?? string.Empty;
                channelData.Tgid = txtTgid.Text;
                channelData.EncryptionKey = EncryptionKey.Text;
                channelData.EncryptionMode = EncryptionMode.SelectedItem?.ToString() ?? string.Empty;
                channelData.EncryptionType = EncryptionType.SelectedItem?.ToString() ?? string.Empty;

                
                _selectedNode.Tag = channelData;

                
                if (_selectedNode.Parent != null)
                {
                    txtZoneName.Text = _selectedNode.Parent.Text;
                }

                
                ChannelUpdated?.Invoke(this, new ChannelUpdatedEventArgs
                {
                    OriginalChannelName = originalChannelName,
                    ChannelName = channelData.Name,
                    SystemName = channelData.System,
                    Tgid = channelData.Tgid,
                    ZoneName = txtZoneName.Text,
                    EncryptionMode = channelData.EncryptionMode,
                    EncryptionType = channelData.EncryptionType,
                    EncryptionKey = channelData.EncryptionKey,
                });

                
                this.DialogResult = DialogResult.OK;
            }
        }


        private void LoadNodeData()
        {
            if (_selectedNode != null)
            {
                txtName.Text = _selectedNode.Text;
                if (_selectedNode.Tag is Codeplug.Channel channelData)
                {
                    cmbSystems.SelectedItem = channelData.System;
                    
                }
                txtTgid.Text = Properties.Settings.Default.Tgid;
                if (_selectedNode.Parent != null)
                {
                    txtZoneName.Text = _selectedNode.Parent.Text;
                }
            }
        }

        public void InvokeUpdateButton()
        {
            btnUpdate.PerformClick();

        }

        public class ChannelUpdatedEventArgs : EventArgs
        {
            public string OriginalChannelName { get; set; }
            public string ChannelName { get; set; }
            public string SystemName { get; set; }
            public string Tgid { get; set; }
            public string ZoneName { get; set; }
            public string EncryptionMode { get; set; }
            public string EncryptionType { get; set; }
            public string EncryptionKey { get; set; }
        }

        private void DataForm_Load(object sender, EventArgs e)
        {
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] key = new byte[32]; 
                rng.GetBytes(key);

                
                EncryptionKey.Text = BitConverter.ToString(key).Replace("-", "");
            }
        }

        private void EncryptionKey_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("AES-256 Key Updated: " + EncryptionKey.Text);
        }

        private void kryptonCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            EncryptionKey.UseSystemPasswordChar = !kryptonCheckBox1.Checked;
        }

     
      

        private void cmbSystems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSystems.SelectedItem != null)
            {
                string selectedSystem = cmbSystems.SelectedItem.ToString();
                Console.WriteLine("Selected System: " + selectedSystem);
            }
        }

        private void kryptonLabel1_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonLabel3_Click(object sender, EventArgs e)
        {

        }

        private void txtTgid_TextChanged(object sender, EventArgs e)
        {

        }

        private void EncryptionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EncryptionType.SelectedItem != null)
            {
                string selectedOption = EncryptionType.SelectedItem.ToString();

                if (selectedOption == "None")
                {
                    EncryptionKey.Text = string.Empty;
                    EncryptionKey.Enabled = false;
                    btnGen.Enabled = false;
                    kryptonCheckBox1.Enabled = false;
                    EncryptionMode.Enabled = false;
                    EncryptionMode.Items.Add("Clear");
                    EncryptionMode.SelectedItem = "Clear";
                   
                }
                else if (selectedOption == "AES-256")
                {
                    EncryptionKey.Enabled = true;
                    btnGen.Enabled = true;
                    kryptonCheckBox1.Enabled = true;
                    EncryptionMode.Enabled = true;
                    EncryptionMode.Items.Remove("Clear");
                    EncryptionMode.SelectedItem = "Strapped";





                }
            }
        }


        private void kryptonRichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
