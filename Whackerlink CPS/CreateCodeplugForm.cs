using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whackerlink_CPS
{
    public partial class CreateCodeplugForm : Form
    {
        private Codeplug codeplug = new Codeplug();
        private Form1 form1 = null;

        public CreateCodeplugForm(Form1 form1)
        {
            InitializeComponent();

            this.form1 = form1;

            createBtn.Text = "Create";
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            codeplug.RadioWide = new Codeplug.RadioWideConfiguration();

            codeplug.RadioWide.CodeplugVersion = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? "R01.00.00";
            codeplug.RadioWide.HostVersion = "UNKOWN";
            codeplug.RadioWide.SerialNumber = serialNumber.Text;
            codeplug.RadioWide.Model = model.SelectedText.ToString();
            codeplug.RadioWide.InCarMode = inCarModel.SelectedText.ToString();

            // create default scan list
            List<Codeplug.ScanListChannel> scanChannels = new List<Codeplug.ScanListChannel>();

            scanChannels.Add(new Codeplug.ScanListChannel
            {
                Channel = "Channel 1",
                Zone = "Zone 1"
            });

            Codeplug.ScanList scanList = new Codeplug.ScanList {
                Name = "List 1",
                Channels = scanChannels
            };

            codeplug.scanLists = new List<Codeplug.ScanList>();            

            // create default zones
            List<Codeplug.Zone> zones = new List<Codeplug.Zone>();
            List<Codeplug.Channel> channels = new List<Codeplug.Channel>();

            channels.Add(new Codeplug.Channel
            {
                Name = "Channel 1",
                Tgid = "1",
                System = "System 1",
                ScanList = "List 1"
            });

            zones.Add(new Codeplug.Zone
            {
                Name = "Zone 1",
                Channels = channels
            });

            // create default system
            List<Codeplug.System> systems = new List<Codeplug.System>();

            systems.Add(new Codeplug.System
            {
                Name = "System 1",
                Address = "127.0.0.1",
                Port = 3000,
                // TODO: Site and RID for non FiveM
            });

            codeplug.Systems = systems;
            codeplug.Zones = zones;
            codeplug.scanLists.Add(scanList);

            form1.LoadYamlIntoTreeView(null, codeplug);

            Close();
        }
    }
}
