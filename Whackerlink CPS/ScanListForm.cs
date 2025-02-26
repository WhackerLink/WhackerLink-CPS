using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Whackerlink_CPS
{
    public partial class ScanListForm : Form
    {
        private Codeplug.ScanList _scanList;

        public event EventHandler<ScanListUpdatedEventArgs> ScanListUpdated;

        public ScanListForm(Codeplug.ScanList scanList)
        {
            InitializeComponent();
            _scanList = scanList;
            LoadScanList();
        }

        private void LoadScanList()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(LoadScanList));
                return;
            }
            scanListNameTextBox.Text = _scanList.Name;
            RefreshChannelList();
        }

        private void RefreshChannelList()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(RefreshChannelList));
                return;
            }
            scanListChannelsGridView.DataSource = null;
            scanListChannelsGridView.DataSource = _scanList.Channels.Select(c => new { c.Zone, c.Channel }).ToList();
        }

        private void scanListChannelsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle grid cell clicks if needed later on
        }

        private void addChannelButton_Click(object sender, EventArgs e)
        {
            _scanList.Channels.Add(new Codeplug.ScanListChannel { Zone = "New Zone", Channel = "New Channel" });
            RefreshChannelList();
        }

        private void removeChannelButton_Click(object sender, EventArgs e)
        {
            if (scanListChannelsGridView.SelectedRows.Count > 0)
            {
                var selectedIndex = scanListChannelsGridView.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < _scanList.Channels.Count)
                {
                    _scanList.Channels.RemoveAt(selectedIndex);
                    RefreshChannelList();
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            _scanList.Name = scanListNameTextBox.Text;
            ScanListUpdated?.Invoke(this, new ScanListUpdatedEventArgs(_scanList.Name, _scanList.Channels));
            this.Close();
        }

        public void ScanListForm_ScanListUpdated(object sender, ScanListUpdatedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    _scanList.Name = e.ScanListName;
                    _scanList.Channels = e.Channels;
                    RefreshChannelList();
                }));
            }
            else
            {
                _scanList.Name = e.ScanListName;
                _scanList.Channels = e.Channels;
                RefreshChannelList();
            }
        }

        public class ScanListUpdatedEventArgs : EventArgs
        {
            public string ScanListName { get; }
            public List<Codeplug.ScanListChannel> Channels { get; }

            public ScanListUpdatedEventArgs(string scanListName, List<Codeplug.ScanListChannel> channels)
            {
                ScanListName = scanListName;
                Channels = channels;
            }
        }
    }
}
