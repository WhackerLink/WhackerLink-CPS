using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using System.Windows.Forms;
using static Whackerlink_CPS.Codeplug;
using static Whackerlink_CPS.Data;
using YamlDotNet.Serialization.NamingConventions;

namespace Whackerlink_CPS
{
    public partial class Form1 : Form
    {
        private Codeplug _currentCodeplug;
        private string _currentFilePath;
        public Form1()
        {
            InitializeComponent();
            treeView1.AfterSelect += treeView1_AfterSelect_1; // Ensure the event handler is attached
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowForm2OnPanel2();
            loadthemes();
        }

        private void loadthemes()
        {
            Theme th = new Theme();
            if (Properties.Settings.Default.Themes == "Light")
            {
                th.krypton2007White();
            }
            else if (Properties.Settings.Default.Themes == "Blue")
            {
                th.krypton2007Blue();
            }
            else if (Properties.Settings.Default.Themes == "Dark")
            {
                th.krypton2007Dark();
            }
            else if (Properties.Settings.Default.Themes == "Sparkle")
            {
                th.krypton2007Sparkle();
            }
        }

        private void LoadYamlFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "YAML files (*.yaml)|*.yaml|All files (*.*)|*.*",
                Title = "Open YAML File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string yamlContent = File.ReadAllText(filePath);

                var deserializer = new DeserializerBuilder().Build();
                Codeplug codeplug = deserializer.Deserialize<Codeplug>(yamlContent);

                PopulateTreeView(codeplug);
                ShowSystemForm(codeplug);
            }
        }
        private void ShowSystemForm(Codeplug codeplug)
        {
            Systems systemForm = new Systems();
            systemForm.SetRadioWideData(codeplug.radioWide);
            //systemForm.SetSystemsData(codeplug.systems);

            systemForm.TopLevel = false;
            systemForm.FormBorderStyle = FormBorderStyle.None;
            systemForm.Dock = DockStyle.Fill;

            MenuPanel.Controls.Clear();
            MenuPanel.Controls.Add(systemForm);
            systemForm.Show();
        }
        private void PopulateTreeView(Codeplug codeplug)
        {
            treeView1.Nodes.Clear();

            // RadioWide Configuration (root node only)
            TreeNode radioWideNode = new TreeNode("RadioWide Configuration");
            treeView1.Nodes.Add(radioWideNode);

            // Systems (root node only)
            TreeNode systemsNode = new TreeNode("Systems");
            treeView1.Nodes.Add(systemsNode);

            // Zones (root node with first sub-nodes)
            TreeNode zonesNode = new TreeNode("Zones");
            foreach (var zone in codeplug.zones)
            {
                TreeNode zoneNode = new TreeNode(zone.name);
                zonesNode.Nodes.Add(zoneNode);

                // Add only the first level of channels as sub-nodes
                foreach (var channel in zone.channels)
                {
                    TreeNode channelNode = new TreeNode(channel.name)
                    {
                        Tag = channel  // Store the channel object in the Tag property
                    };
                    zoneNode.Nodes.Add(channelNode);
                }
            }
            treeView1.Nodes.Add(zonesNode);

            treeView1.ExpandAll();
        }

        private void RibbonCodeplugFileRead_Click(object sender, EventArgs e)
        {
            LoadYamlFile();
        }

        private void DataForm_ChannelUpdated(object sender, ChannelUpdatedEventArgs e)
        {
            // Save updated data to YAML file
            var serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            string yamlContent = serializer.Serialize(_currentCodeplug);
            File.WriteAllText(_currentFilePath, yamlContent);

            // Optionally, refresh the TreeView
            PopulateTreeView(_currentCodeplug);
        }

        private void ShowForm2OnPanel2()
        {
            // Create a new instance of Form2
            Home form2 = new Home();

            // Set the TopLevel property to false
            form2.TopLevel = false;

            // Set the FormBorderStyle to None
            form2.FormBorderStyle = FormBorderStyle.None;

            // Add Form2 to Panel2
            this.MenuPanel.Controls.Add(form2);

            // Dock Form2 to fill Panel2
            form2.Dock = DockStyle.Fill;

            // Show Form2
            form2.Show();
        }

        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is Codeplug.Channel selectedChannel)
            {
                Data dataForm = new Data();
                dataForm.SetChannelData(selectedChannel.name, selectedChannel.system, selectedChannel.tgid);
                dataForm.TopLevel = false;
                dataForm.FormBorderStyle = FormBorderStyle.None;
                dataForm.ChannelUpdated += DataForm_ChannelUpdated;
                dataForm.Dock = DockStyle.Fill;
                MenuPanel.Controls.Clear();
                MenuPanel.Controls.Add(dataForm);
                dataForm.Show();
            }
            else if (e.Node.Tag is Codeplug.System selectedSystem)
            {
                Systems systemForm = new Systems();
                systemForm.SetSystemData(selectedSystem); // Pass a single System object

                systemForm.TopLevel = false;
                systemForm.FormBorderStyle = FormBorderStyle.None;
                systemForm.Dock = DockStyle.Fill;
                MenuPanel.Controls.Clear();
                MenuPanel.Controls.Add(systemForm);
                systemForm.Show();
            }
            else if (e.Node.Text == "RadioWide Configuration" || e.Node.Parent?.Text == "RadioWide Configuration")
            {
                //ShowSystemForm(codeplug); // Make sure to store the deserialized Codeplug instance in a class-level variable
            }
        }

        private void RibbonSettingsThemeLight_Click(object sender, EventArgs e)
        {
            Theme theme = new Theme();
            theme.krypton2007White();
        }

        private void RibbonSettingsThemeDark_Click(object sender, EventArgs e)
        {
            Theme theme = new Theme();
            theme.krypton2007Dark();
        }

        private void RibbonSettingsThemeBlue_Click(object sender, EventArgs e)
        {
            Theme theme = new Theme();
            theme.krypton2007Blue();
        }

        private void RibbonSettingThemeSparkle_Click(object sender, EventArgs e)
        {
            Theme theme = new Theme();
            theme.krypton2007Sparkle();
        }

        private void KryptonCodeplugFileRead_Click(object sender, EventArgs e)
        {
            LoadYamlFile();
        }
    }
}