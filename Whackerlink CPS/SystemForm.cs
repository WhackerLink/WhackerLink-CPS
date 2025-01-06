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
* Copyright (C) 2024 Caleb, K4PHP
* 
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Whackerlink_CPS
{
    public partial class SystemForm : Form
    {
        private TreeNode _selectedNode;
        private List<string> _systemNames;
        private List<string> _systemIds;
        private BindingList<Site> sites = new BindingList<Site>();

        public event EventHandler<SystemUpdateEventArgs> SystemUpdated;

        public void InvokeUpdateButton()
        {
            btnUpdate.PerformClick();
        }
        public SystemForm(TreeNode selectedNode, List<string> systemNames, List<string> systemIds)
        {
            InitializeComponent();
            _selectedNode = selectedNode;
            _systemNames = systemNames;
            _systemIds = systemIds;

            LoadData();
        }

        private void LoadData()
        {
            if (_selectedNode.Tag is Codeplug.System systemData)
            {
                txtName.Text = systemData.Name;
                txtAddress.Text = systemData.Address;
                txtPort.Text = systemData.Port.ToString();
                txtRid.Text = systemData.Rid;

                if (Form1.SelectedCodeplug.RadioWide.BaseMode == ModelMode.CONSOLE || Form1.SelectedCodeplug.RadioWide.BaseMode == ModelMode.DESKTOPRADIO)
                {
                    sitesView.Visible = true;

                    SetupSiteGridView();
                    sites.Clear();

                    if (systemData.Site != null)
                    {
                        sites.Add(systemData.Site);
                    }
                    else
                    {
                        MessageBox.Show("The site data is missing or null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else
                {
                    sitesView.Visible = false;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedNode.Tag is Codeplug.System systemData)
            {
                var originalSystemName = systemData.Name;

                systemData.Name = txtName.Text;
                systemData.Address = txtAddress.Text;
                systemData.Port = Int32.Parse(txtPort.Text);
                systemData.Rid = txtRid.Text;

                SystemUpdated?.Invoke(this, new SystemUpdateEventArgs
                {
                    OriginalSystemName = originalSystemName,
                    SystemName = systemData.Name,
                    Address = systemData.Address,
                    Port = systemData.Port.ToString(),
                    Rid = systemData.Rid,
                    Site = systemData.Site
                });

                _selectedNode.Text = systemData.Name;
            }
        }

        private void SetupSiteGridView()
        {
            var dataGridView = sitesView;

            dataGridView.Columns.Clear();

            dataGridView.AutoGenerateColumns = false;
            dataGridView.AllowUserToAddRows = false; // TODO: If and when we want multiple in the codeplug, handle it
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeColumns = true;

            var nameColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                DataPropertyName = "Name"
            };
            dataGridView.Columns.Add(nameColumn);

            var controlChannelColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Control Channel",
                DataPropertyName = "ControlChannel"
            };
            dataGridView.Columns.Add(controlChannelColumn);

/*            var voiceChannelsColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Voice Channels",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            };
            dataGridView.Columns.Add(voiceChannelsColumn);*/

/*            var locationColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Location",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            };
            dataGridView.Columns.Add(locationColumn);*/

            var siteIdColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Site ID",
                DataPropertyName = "SiteID"
            };
            dataGridView.Columns.Add(siteIdColumn);

            var systemIdColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "System ID",
                DataPropertyName = "SystemID"
            };
            dataGridView.Columns.Add(systemIdColumn);

/*
            var rangeColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Range",
                DataPropertyName = "Range"
            };
            dataGridView.Columns.Add(rangeColumn);*/

            dataGridView.DataSource = sites;

            dataGridView.Refresh();
        }

        public class SystemUpdateEventArgs : EventArgs
        {
            public string OriginalSystemName { get; set; }
            public string SystemName { get; set; }
            public string Address { get; set; }
            public string Port { get; set; }
            public string Rid { get; set; }
            public Site Site { get; set; }
        }

        private void txtRid_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonLabel4_Click(object sender, EventArgs e)
        {

        }
    }
}
    



