using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Whackerlink_CPS.Properties;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using static Whackerlink_CPS.Codeplug;

namespace Whackerlink_CPS
{
    public partial class Form1 : Form
    {
        private Root _yamlRoot;

        public Form1()
        {
            InitializeComponent();
            treeView1.AfterSelect += TreeView1_AfterSelect;
            KryptonCodeplugFileSave.Enabled = false; // Initially disable the save button
            QATSave.Enabled = false; // Initially disable the save button
            ButtonSave.Enabled = false; // Initially disable the save button
            LoadThemes(); //load default theme
            loadHome();
        }

        private void LoadThemes()
        {
            Theme th = new Theme();
            switch (Properties.Settings.Default.Themes)
            {
                case "Light":
                    th.krypton2007White();
                    break;
                case "Blue":
                    th.krypton2007Blue();
                    break;
                case "Dark":
                    th.krypton2007Dark();
                    break;
                case "Sparkle":
                    th.krypton2007Sparkle();
                    break;
                case "SilverDark":
                    th.krypton2007SilverDark();
                    break;
                case "SilverLight":
                    th.krypton2007SilverLight();
                    break;

                default:
                    break;
            }
        }

        private void loadHome()
        {
            HomeForm hf = new HomeForm();

            hf.TopLevel = false;
            hf.FormBorderStyle = FormBorderStyle.None;
            hf.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(hf);
            hf.Show();
        }

        private void LoadYamlIntoTreeView(string yamlContent)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            _yamlRoot = deserializer.Deserialize<Root>(yamlContent);

            treeView1.Nodes.Clear();

            // RadioWide node
            TreeNode radioWideNode = new TreeNode("RadioWide");
            radioWideNode.Nodes.Add(new TreeNode($"HostVersion: {_yamlRoot.RadioWide.hostVersion}"));
            radioWideNode.Nodes.Add(new TreeNode($"CodeplugVersion: {_yamlRoot.RadioWide.codeplugVersion}"));
            radioWideNode.Nodes.Add(new TreeNode($"RadioAlias: {_yamlRoot.RadioWide.radioAlias}"));
            radioWideNode.Nodes.Add(new TreeNode($"SerialNumber: {_yamlRoot.RadioWide.serialNumber}"));
            radioWideNode.Nodes.Add(new TreeNode($"Model: {_yamlRoot.RadioWide.model}"));
            treeView1.Nodes.Add(radioWideNode);

            // Systems node
            TreeNode systemsNode = new TreeNode("Systems");
            foreach (var systemData in _yamlRoot.Systems)
            {
                TreeNode systemNode = new TreeNode(systemData.name)
                {
                    Name = systemData.name,
                    Tag = new SystemData
                    {
                        Name = systemData.name,
                        Address = systemData.address,
                        Port = systemData.port,
                        Rid = systemData.rid
                    }
                };
                systemsNode.Nodes.Add(systemNode);
            }
            treeView1.Nodes.Add(systemsNode);

            // Zones node
            TreeNode zonesNode = new TreeNode("Zones");
            foreach (var zone in _yamlRoot.Zones)
            {
                TreeNode zoneNode = new TreeNode(zone.name)
                {
                    Name = zone.name
                };
                foreach (var channel in zone.channels)
                {
                    TreeNode channelNode = new TreeNode(channel.name)
                    {
                        Name = channel.name,
                        Tag = new ChannelData
                        {
                            Name = channel.name,
                            System = channel.system,
                            Tgid = channel.tgid.ToString()
                        }
                    };
                    zoneNode.Nodes.Add(channelNode);
                }
                zonesNode.Nodes.Add(zoneNode);
            }
            treeView1.Nodes.Add(zonesNode);

            treeView1.ExpandAll();
        }

        private void ShowDataForm(TreeNode selectedNode)
        {
            var systemNames = _yamlRoot.Systems.Select(s => s.name).ToList();
            var systemIds = _yamlRoot.Systems.Select(s => s.rid).ToList();

            if (selectedNode.Parent != null)
            {
                if (selectedNode.Parent.Parent != null && selectedNode.Parent.Parent.Text == "Zones" && selectedNode.Tag is ChannelData)
                {
                    Console.WriteLine("Opening DataForm...");
                    var dataForm = new DataForm(selectedNode, systemNames, systemIds);
                    var channelData = (ChannelData)selectedNode.Tag;
                    dataForm.SetTgid(channelData.Tgid);
                    dataForm.TopLevel = false;
                    dataForm.FormBorderStyle = FormBorderStyle.None;
                    dataForm.Dock = DockStyle.Fill;
                    panel2.Controls.Clear();
                    panel2.Controls.Add(dataForm);
                    dataForm.ChannelUpdated += DataForm_ChannelUpdated;
                    dataForm.Show();
                }
                else if (selectedNode.Parent.Text == "Systems" && selectedNode.Tag is SystemData)
                {
                    Console.WriteLine("Opening SystemForm...");
                    var systemForm = new SystemForm(selectedNode, systemNames, systemIds);
                    systemForm.TopLevel = false;
                    systemForm.FormBorderStyle = FormBorderStyle.None;
                    systemForm.Dock = DockStyle.Fill;
                    panel2.Controls.Clear();
                    panel2.Controls.Add(systemForm);
                    systemForm.SystemUpdated += SystemForm_SystemUpdated;
                    systemForm.Show();
                }
                else
                {
                    Console.WriteLine("No matching form to open.");
                }
            }
        }

        private void DataForm_ChannelUpdated(object sender, DataForm.ChannelUpdatedEventArgs e)
        {
            var zone = _yamlRoot.Zones.FirstOrDefault(z => z.name == e.ZoneName);
            if (zone != null)
            {
                var channel = zone.channels.FirstOrDefault(c => c.name == e.OriginalChannelName);
                if (channel != null)
                {
                    channel.name = e.ChannelName;
                    channel.system = e.SystemName;
                    channel.tgid = e.Tgid;

                    // Update the tree view node
                    var zoneNode = treeView1.Nodes.Find(zone.name, true).FirstOrDefault();
                    var channelNode = zoneNode?.Nodes.Find(e.OriginalChannelName, true).FirstOrDefault();

                    if (channelNode != null)
                    {
                        channelNode.Name = e.ChannelName;
                        channelNode.Text = e.ChannelName;
                        channelNode.Tag = new ChannelData
                        {
                            Name = e.ChannelName,
                            System = e.SystemName,
                            Tgid = e.Tgid
                        };
                    }
                }
            }
        }

        private void SystemForm_SystemUpdated(object sender, SystemForm.SystemUpdateEventArgs e)
        {
            var system = _yamlRoot.Systems.FirstOrDefault(s => s.name == e.OriginalSystemName);
            if (system != null)
            {
                system.name = e.SystemName;
                system.address = e.Address;
                system.port = e.Port;
                system.rid = e.Rid;

                // Update the tree view node
                var systemNode = treeView1.Nodes.Find(e.OriginalSystemName, true).FirstOrDefault();

                if (systemNode != null)
                {
                    systemNode.Name = e.SystemName;
                    systemNode.Text = e.SystemName;
                    systemNode.Tag = new SystemData
                    {
                        Name = e.SystemName,
                        Address = e.Address,
                        Port = e.Port,
                        Rid = e.Rid
                    };
                }
            }
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selectedNode = e.Node;
            ShowDataForm(selectedNode);

            // Save TGID in settings when a channel is selected
            if (selectedNode.Parent != null && selectedNode.Parent.Parent != null && selectedNode.Parent.Parent.Text == "Zones" && selectedNode.Tag is ChannelData)
            {
                var channelData = (ChannelData)selectedNode.Tag;
                Properties.Settings.Default.Tgid = channelData.Tgid;
                Properties.Settings.Default.Save();
            }
        }

        private void KryptonCodeplugFileSave_Click(object sender, EventArgs e)
        {
            SaveYamlFile();
        }

        private void RibbonCodeplugFileRead_Click(object sender, EventArgs e)
        {
            LoadYamlFile();
        }

        private void LoadYamlFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "YAML files (*.yaml)|*.yaml|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string yamlContent = File.ReadAllText(openFileDialog.FileName);
                    LoadYamlIntoTreeView(yamlContent);

                    // Enable the save button after loading a file
                    KryptonCodeplugFileSave.Enabled = true;
                    QATSave.Enabled = true;
                    ButtonSave.Enabled = true;
                }
            }
        }

        private void SaveYamlFile()
        {
            if (_yamlRoot == null)
            {
                MessageBox.Show("File is not loaded. Please load a YAML file first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "YAML files (*.yaml)|*.yaml|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var serializer = new SerializerBuilder()
                        .WithNamingConvention(CamelCaseNamingConvention.Instance)
                        .Build();
                    string yamlContent = serializer.Serialize(_yamlRoot);
                    File.WriteAllText(saveFileDialog.FileName, yamlContent);
                    MessageBox.Show("File saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void RibbonCodeplugNodeAdd_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Text == "Zones")
                {
                    var newZone = new Zone
                    {
                        name = "New Zone",
                        channels = new List<Channel>()
                    };
                    _yamlRoot.Zones.Add(newZone);

                    var zoneNode = new TreeNode(newZone.name)
                    {
                        Name = newZone.name
                    };
                    treeView1.SelectedNode.Nodes.Add(zoneNode);
                    treeView1.SelectedNode.Expand();
                }
                else if (treeView1.SelectedNode.Parent != null && treeView1.SelectedNode.Parent.Text == "Zones")
                {
                    var selectedZone = _yamlRoot.Zones.Find(z => z.name == treeView1.SelectedNode.Text);
                    var newChannel = new Channel
                    {
                        name = "New Channel",
                        system = _yamlRoot.Systems[0].name,
                        tgid = "1001"
                    };
                    selectedZone.channels.Add(newChannel);

                    var channelNode = new TreeNode(newChannel.name)
                    {
                        Name = newChannel.name,
                        Tag = new ChannelData
                        {
                            Name = newChannel.name,
                            System = newChannel.system,
                            Tgid = newChannel.tgid
                        }
                    };
                    treeView1.SelectedNode.Nodes.Add(channelNode);
                    treeView1.SelectedNode.Expand();
                }
                else if (treeView1.SelectedNode.Text == "Systems")
                {
                    var newSystemData = new SystemData
                    {
                        Name = "System",
                        Address = "127.0.0.1",
                        Port = "3009",
                        Rid = "123456"
                    };
                    _yamlRoot.Systems.Add(new Codeplug.System
                    {
                        name = newSystemData.Name,
                        address = newSystemData.Address,
                        port = newSystemData.Port,
                        rid = newSystemData.Rid
                    });

                    var systemNode = new TreeNode(newSystemData.Name)
                    {
                        Name = newSystemData.Name,
                        Tag = newSystemData
                    };
                    treeView1.SelectedNode.Nodes.Add(systemNode);
                    treeView1.SelectedNode.Expand();
                }
                else
                {
                    MessageBox.Show("Please select the 'Zones' node or a specific zone to add a new channel, or the 'Systems' node to add a new system.");
                }
            }
            else
            {
                MessageBox.Show("Please select the 'Zones' node or a specific zone to add a new channel, or the 'Systems' node to add a new system.");
            }
        }

        private void RibbonCodeplugNodeUpdate_Click(object sender, EventArgs e)
        {
            foreach (Control control in panel2.Controls)
            {
                if (control is SystemForm systemForm)
                {
                    if (systemForm != null)
                    {
                        systemForm.InvokeUpdateButton();
                    }
                    else
                    {
                        MessageBox.Show("SystemForm is not active.");
                    }
                    return;
                }
                else if (control is DataForm dataForm)
                {
                    if (dataForm != null)
                    {
                        dataForm.InvokeUpdateButton();
                    }
                    else
                    {
                        MessageBox.Show("DataForm is not active.");
                    }
                    return;
                }
            }
            MessageBox.Show("No form is currently active for updating.");
        }

        private void RibbonCodeplugNodeDelete_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                // Deleting a channel
                if (treeView1.SelectedNode.Parent != null && treeView1.SelectedNode.Parent.Parent != null && treeView1.SelectedNode.Parent.Parent.Text == "Zones" && treeView1.SelectedNode.Tag is ChannelData)
                {
                    var zoneName = treeView1.SelectedNode.Parent.Text;
                    var channelName = treeView1.SelectedNode.Name;
                    var zone = _yamlRoot.Zones.FirstOrDefault(z => z.name == zoneName);

                    if (zone != null)
                    {
                        var channel = zone.channels.FirstOrDefault(c => c.name == channelName);
                        if (channel != null)
                        {
                            zone.channels.Remove(channel);
                            treeView1.SelectedNode.Remove();
                        }
                    }
                }
                // Deleting a system
                else if (treeView1.SelectedNode.Parent != null && treeView1.SelectedNode.Parent.Text == "Systems" && treeView1.SelectedNode.Tag is SystemData)
                {
                    var systemName = treeView1.SelectedNode.Name;
                    var system = _yamlRoot.Systems.FirstOrDefault(s => s.name == systemName);

                    if (system != null)
                    {
                        _yamlRoot.Systems.Remove(system);
                        treeView1.SelectedNode.Remove();
                    }
                }
                // Deleting a zone
                else if (treeView1.SelectedNode.Parent != null && treeView1.SelectedNode.Parent.Text == "Zones")
                {
                    var zoneName = treeView1.SelectedNode.Name;
                    var zone = _yamlRoot.Zones.FirstOrDefault(z => z.name == zoneName);

                    if (zone != null)
                    {
                        _yamlRoot.Zones.Remove(zone);
                        treeView1.SelectedNode.Remove();
                    }
                }
                // Deleting a top-level zone
                else if (treeView1.SelectedNode.Text == "Zones" && treeView1.SelectedNode.Nodes.Count > 0)
                {
                    var zoneName = treeView1.SelectedNode.Nodes[0].Name;
                    var zone = _yamlRoot.Zones.FirstOrDefault(z => z.name == zoneName);

                    if (zone != null)
                    {
                        _yamlRoot.Zones.Remove(zone);
                        treeView1.SelectedNode.Nodes[0].Remove();
                    }
                }
                // Deleting a top-level system
                else if (treeView1.SelectedNode.Text == "Systems" && treeView1.SelectedNode.Nodes.Count > 0)
                {
                    var systemName = treeView1.SelectedNode.Nodes[0].Name;
                    var system = _yamlRoot.Systems.FirstOrDefault(s => s.name == systemName);

                    if (system != null)
                    {
                        _yamlRoot.Systems.Remove(system);
                        treeView1.SelectedNode.Nodes[0].Remove();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a node to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QATRead_Click(object sender, EventArgs e)
        {
            LoadYamlFile();
        }

        private void QATSave_Click(object sender, EventArgs e)
        {
            SaveYamlFile();
        }

        private void ButtonRead_Click(object sender, EventArgs e)
        {
            LoadYamlFile();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            SaveYamlFile();
        }

        private void RibbonSettingsThemeLight_Click(object sender, EventArgs e)
        {
            Theme theme = new Theme();
            theme.krypton2007White();
        }

        private void RibbonSettingsThemeBlue_Click(object sender, EventArgs e)
        {
            Theme theme = new Theme();
            theme.krypton2007Blue();
        }

        private void RibbonSettingsThemeDark_Click(object sender, EventArgs e)
        {
            Theme theme = new Theme();
            theme.krypton2007Dark();
        }

        private void RibbonSettingsThemeSilverL_Click(object sender, EventArgs e)
        {
            Theme theme = new Theme();
            theme.krypton2007SilverLight();
        }

        private void RibbonSettingsThemeSparkle_Click(object sender, EventArgs e)
        {
            Theme theme = new Theme();
            theme.krypton2007Sparkle();
        }

        private void RibbonSettingThemeSilverD_Click(object sender, EventArgs e)
        {
            Theme theme = new Theme();
            theme.krypton2007SilverDark();
        }

        private void kryptonRibbonGroupButton1_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }

        private void RibbonHelpHelpHelpTopics_Click(object sender, EventArgs e)
        {
            HelpForm help = new HelpForm();
            help.ShowDialog();
        }
    }
}