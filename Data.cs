using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whackerlink_CPS
{
    public partial class Data : Form
    {
        public event EventHandler<ChannelUpdatedEventArgs> ChannelUpdated;
        private Codeplug.Channel _channel;
        public Data()
        {
            InitializeComponent();
        }

        public void SetChannelData(string channelName, string system, string tgid)
        {
            txtChannelName.Text = channelName;
            txtSystem.Text = system;
            txtTgid.Text = tgid;
        }
        private void kryptonTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Data_Load(object sender, EventArgs e)
        {

        }
        public void SetChannelData(Codeplug.Channel channel)
        {
            _channel = channel;
            txtChannelName.Text = channel.name;
            txtSystem.Text = channel.system;
            txtTgid.Text = channel.tgid;
        }

        private void BtnOkay_Click(object sender, EventArgs e)
        {
            _channel.name = txtChannelName.Text;
            _channel.system = txtSystem.Text;
            _channel.tgid = txtTgid.Text;

            ChannelUpdated?.Invoke(this, new ChannelUpdatedEventArgs(_channel));
            this.Close();
        }

        public class ChannelUpdatedEventArgs : EventArgs
        {
            public Codeplug.Channel Channel { get; }

            public ChannelUpdatedEventArgs(Codeplug.Channel channel)
            {
                Channel = channel;
            }
        }
    }
}
