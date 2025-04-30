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
* Copyright (C) 2025 Caleb, K4PHP
* 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static Whackerlink_CPS.Codeplug;

namespace Whackerlink_CPS
{
    public partial class DataForm : Form
    {
        public event EventHandler<ChannelUpdatedEventArgs> ChannelUpdated;
        private TreeNode _selectedNode;
        private List<string> _systems;
        private List<string> _systemIds;
        private List<string> _scanLists;

        public DataForm(TreeNode selectedNode, List<string> systems, List<string> systemIds, List<string> scanLists)
        {
            InitializeComponent();
            _selectedNode = selectedNode;
            _systems = systems;
            _systemIds = systemIds;
            _scanLists = scanLists;
            LoadSystems();
            LoadNodeData();
        }

        private void LoadSystems()
        {
            cmbSystems.DataSource = _systems;
            cmbScanLists.DataSource = _scanLists;
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
                channelData.System = cmbSystems.SelectedItem.ToString();
                channelData.ScanList = cmbScanLists.SelectedItem.ToString();
                channelData.Tgid = txtTgid.Text;

                _selectedNode.Tag = channelData;
                _selectedNode.Parent.Text = txtZoneName.Text;

                ChannelUpdated?.Invoke(this, new ChannelUpdatedEventArgs
                {
                    OriginalChannelName = originalChannelName,
                    ChannelName = txtName.Text,
                    SystemName = channelData.System,
                    Tgid = channelData.Tgid,
                    ZoneName = txtZoneName.Text,
                    ScanList = channelData.ScanList
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
                    var matched = _scanLists.FirstOrDefault(s => s.Equals(channelData.ScanList?.Trim(), StringComparison.OrdinalIgnoreCase));
                    if (matched != null)
                        cmbScanLists.SelectedItem = matched;
                    txtTgid.Text = Properties.Settings.Default.Tgid;
                }
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
            public string ScanList { get; set; }
        }

        private void DataForm_Load(object sender, EventArgs e)
        {

        }

        private void kryptonLabel5_Click(object sender, EventArgs e)
        {

        }

        private void kryptonLabel3_Click(object sender, EventArgs e)
        {

        }

        private void kryptonLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}