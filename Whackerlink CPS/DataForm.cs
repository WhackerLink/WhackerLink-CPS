using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
        }

        private void LoadSystems()
        {
            cmbSystems.DataSource = _systems;
            // You might want to use _systemIds for another control or logic
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
                var channelData = _selectedNode.Tag as ChannelData ?? new ChannelData();
                channelData.System = cmbSystems.SelectedItem.ToString();
                channelData.Tgid = txtTgid.Text;

                _selectedNode.Tag = channelData;
                _selectedNode.Parent.Text = txtZoneName.Text;

                ChannelUpdated?.Invoke(this, new ChannelUpdatedEventArgs
                {
                    OriginalChannelName = originalChannelName,
                    ChannelName = txtName.Text,
                    SystemName = channelData.System,
                    Tgid = channelData.Tgid,
                    ZoneName = txtZoneName.Text
                });

                this.DialogResult = DialogResult.OK;
            }
        }
        private void LoadNodeData()
        {
            if (_selectedNode != null)
            {
                txtName.Text = _selectedNode.Text;
                if (_selectedNode.Tag is ChannelData channelData)
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
        }

        private void DataForm_Load(object sender, EventArgs e)
        {

        }
    }
}