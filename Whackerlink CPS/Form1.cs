﻿/*
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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Whackerlink_CPS.Properties;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using static Whackerlink_CPS.Codeplug;

namespace Whackerlink_CPS
{
    public partial class Form1 : Form
    {
        public static Codeplug SelectedCodeplug { get; set; }

        private Codeplug _yamlRoot;

        public Form1()
        {
            InitializeComponent();
            Icon = Resources.whackerlink1;
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

        internal void LoadYamlIntoTreeView(string yamlContent = null, Codeplug codeplug = null)
        {
            if (yamlContent != null)
            {
                var deserializer = new DeserializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .IgnoreUnmatchedProperties()
                    .Build();

                _yamlRoot = deserializer.Deserialize<Codeplug>(yamlContent);

                SelectedCodeplug = _yamlRoot;
            }

            if (codeplug != null)
            {
                SelectedCodeplug = codeplug;
                _yamlRoot = codeplug;
            }

            treeView1.Nodes.Clear();

            // RadioWide node
            TreeNode radioWideNode = new TreeNode("RadioWide");
            radioWideNode.Nodes.Add(new TreeNode($"HostVersion: {_yamlRoot.RadioWide.HostVersion}"));
            radioWideNode.Nodes.Add(new TreeNode($"CodeplugVersion: {_yamlRoot.RadioWide.CodeplugVersion}"));
            radioWideNode.Nodes.Add(new TreeNode($"RadioAlias: {_yamlRoot.RadioWide.RadioAlias}"));
            radioWideNode.Nodes.Add(new TreeNode($"SerialNumber: {_yamlRoot.RadioWide.SerialNumber}"));
            radioWideNode.Nodes.Add(new TreeNode($"Model: {_yamlRoot.RadioWide.Model}"));
            treeView1.Nodes.Add(radioWideNode);

            // Systems node
            TreeNode systemsNode = new TreeNode("Systems");
            foreach (var systemData in _yamlRoot.Systems)
            {
                TreeNode systemNode = new TreeNode(systemData.Name)
                {
                    Name = systemData.Name,
                    Tag = new Codeplug.System
                    {
                        Name = systemData.Name,
                        Address = systemData.Address,
                        Port = systemData.Port,
                        Rid = systemData.Rid,
                        Site = systemData.Site
                    }
                };
                systemsNode.Nodes.Add(systemNode);
            }
            treeView1.Nodes.Add(systemsNode);

            // Zones node
            TreeNode zonesNode = new TreeNode("Zones");
            foreach (var zone in _yamlRoot.Zones)
            {
                TreeNode zoneNode = new TreeNode(zone.Name)
                {
                    Name = zone.Name
                };
                foreach (var channel in zone.Channels)
                {
                    TreeNode channelNode = new TreeNode(channel.Name)
                    {
                        Name = channel.Name,
                        Tag = new Codeplug.Channel
                        {
                            Name = channel.Name,
                            System = channel.System,
                            Tgid = channel.Tgid.ToString(),
                            
                        }
                    };
                    zoneNode.Nodes.Add(channelNode);
                }
                zonesNode.Nodes.Add(zoneNode);
            }
            treeView1.Nodes.Add(zonesNode);

            if (_yamlRoot.scanLists != null)
            {
                // Scan lists
                TreeNode scanListsNode = new TreeNode("Scan Lists");
                foreach (var scanList in _yamlRoot.scanLists)
                {
                    TreeNode scanListNode = new TreeNode(scanList.Name)
                    {
                        Name = scanList.Name,
                        Tag = scanList
                    };
                    scanListsNode.Nodes.Add(scanListNode);
                }
                treeView1.Nodes.Add(scanListsNode);
            }

            treeView1.ExpandAll();
        }

        private void ShowDataForm(TreeNode selectedNode)
        {
            var systemNames = _yamlRoot.Systems.Select(s => s.Name).ToList();
            var systemIds = _yamlRoot.Systems.Select(s => s.Rid).ToList();

            if (selectedNode.Parent != null)
            {
                if (selectedNode.Parent.Parent != null && selectedNode.Parent.Parent.Text == "Zones" && selectedNode.Tag is Codeplug.Channel)
                {
                    Console.WriteLine("Opening DataForm...");
                    var dataForm = new DataForm(selectedNode, systemNames, systemIds);
                    var channelData = (Codeplug.Channel)selectedNode.Tag;
                    dataForm.SetTgid(channelData.Tgid);
                    dataForm.TopLevel = false;
                    dataForm.FormBorderStyle = FormBorderStyle.None;
                    dataForm.Dock = DockStyle.Fill;
                    panel2.Controls.Clear();
                    panel2.Controls.Add(dataForm);
                    dataForm.ChannelUpdated += DataForm_ChannelUpdated;
                    dataForm.Show();
                }
                else if (selectedNode.Parent.Text == "Systems" && selectedNode.Tag is Codeplug.System)
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
                else if (selectedNode.Parent.Text == "Scan Lists" && selectedNode.Tag is Codeplug.ScanList scanList)
                {
                    Console.WriteLine("Opening ScanListForm...");
                    var scanListForm = new ScanListForm(scanList);
                    scanListForm.TopLevel = false;
                    scanListForm.FormBorderStyle = FormBorderStyle.None;
                    scanListForm.Dock = DockStyle.Fill;

                    // Subscribe to event BEFORE adding to the panel
                    scanListForm.ScanListUpdated += (sender, e) =>
                    {
                        if (InvokeRequired)
                        {
                            Invoke(new Action(() => ScanListForm_ScanListUpdated(sender, e)));
                        }
                        else
                        {
                            ScanListForm_ScanListUpdated(sender, e);
                        }
                    };

                    panel2.Controls.Clear();
                    panel2.Controls.Add(scanListForm);
                    scanListForm.Show();
                }

                else
                {
                    Console.WriteLine("No matching form to open.");
                }
            }
        }

        private void ScanListForm_ScanListUpdated(object sender, ScanListForm.ScanListUpdatedEventArgs e)
        {
            var scanList = _yamlRoot.scanLists.FirstOrDefault(s => s.Name == e.ScanListName);
            if (scanList != null)
            {
                scanList.Channels = e.Channels;

                // Update the tree view node
                var scanListNode = treeView1.Nodes.Find(e.ScanListName, true).FirstOrDefault();
                if (scanListNode != null)
                {
                    scanListNode.Text = e.ScanListName;
                    scanListNode.Tag = scanList;
                }
            }
        }


        private void DataForm_ChannelUpdated(object sender, DataForm.ChannelUpdatedEventArgs e)
        {
            var zone = _yamlRoot.Zones.FirstOrDefault(z => z.Name == e.ZoneName);
            if (zone != null)
            {
                var channel = zone.Channels.FirstOrDefault(c => c.Name == e.OriginalChannelName);
                if (channel != null)
                {
                    channel.Name = e.ChannelName;
                    channel.System = e.SystemName;
                    channel.Tgid = e.Tgid;

                    // Update the tree view node
                    var zoneNode = treeView1.Nodes.Find(zone.Name, true).FirstOrDefault();
                    var channelNode = zoneNode?.Nodes.Find(e.OriginalChannelName, true).FirstOrDefault();

                    if (channelNode != null)
                    {
                        channelNode.Name = e.ChannelName;
                        channelNode.Text = e.ChannelName;
                        channelNode.Tag = new Codeplug.Channel
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
            var system = _yamlRoot.Systems.FirstOrDefault(s => s.Name == e.OriginalSystemName);
            if (system != null)
            {
                system.Name = e.SystemName;
                system.Address = e.Address;
                system.Port = Int32.Parse(e.Port);
                system.Rid = e.Rid;
                system.Site = e.Site;

                // Update the tree view node
                var systemNode = treeView1.Nodes.Find(e.OriginalSystemName, true).FirstOrDefault();

                if (systemNode != null)
                {
                    systemNode.Name = e.SystemName;
                    systemNode.Text = e.SystemName;
                    systemNode.Tag = new Codeplug.System
                    {
                        Name = e.SystemName,
                        Address = e.Address,
                        Port = Int32.Parse(e.Port),
                        Rid = e.Rid,
                        Site = e.Site
                    };
                }
            }
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selectedNode = e.Node;
            ShowDataForm(selectedNode);

            // Save TGID in settings when a channel is selected
            if (selectedNode.Parent != null && selectedNode.Parent.Parent != null && selectedNode.Parent.Parent.Text == "Zones" && selectedNode.Tag is Codeplug.Channel)
            {
                var channelData = (Codeplug.Channel)selectedNode.Tag;
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
                openFileDialog.Filter = "WhackerLink Codeplug files (*.yml)|*.yml|All files (*.*)|*.*";
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

            _yamlRoot.RadioWide.CodeplugVersion = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? "R01.00.00";

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Codeplug files (*.yml)|*.yml|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var serializer = new SerializerBuilder()
                        .WithNamingConvention(CamelCaseNamingConvention.Instance)
                        .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull)
                        .WithIndentedSequences()
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
                        Name = "New Zone",
                        Channels = new List<Channel>()
                    };
                    _yamlRoot.Zones.Add(newZone);

                    var zoneNode = new TreeNode(newZone.Name)
                    {
                        Name = newZone.Name
                    };
                    treeView1.SelectedNode.Nodes.Add(zoneNode);
                    treeView1.SelectedNode.Expand();
                }
                else if (treeView1.SelectedNode.Parent != null && treeView1.SelectedNode.Parent.Text == "Zones")
                {
                    var selectedZone = _yamlRoot.Zones.Find(z => z.Name == treeView1.SelectedNode.Text);
                    var newChannel = new Channel
                    {
                        Name = "New Channel",
                        System = _yamlRoot.Systems[0].Name,
                        Tgid = "1001"
                    };
                    selectedZone.Channels.Add(newChannel);

                    var channelNode = new TreeNode(newChannel.Name)
                    {
                        Name = newChannel.Name,
                        Tag = new Codeplug.Channel
                        {
                            Name = newChannel.Name,
                            System = newChannel.System,
                            Tgid = newChannel.Tgid
                        }
                    };
                    treeView1.SelectedNode.Nodes.Add(channelNode);
                    treeView1.SelectedNode.Expand();
                }
                else if (treeView1.SelectedNode.Text == "Systems")
                {
                    var newSystemData = new Codeplug.System
                    {
                        Name = "System",
                        Address = "127.0.0.1",
                        Port = 3000,
                        Rid = "123456"
                    };
                    _yamlRoot.Systems.Add(new Codeplug.System
                    {
                        Name = newSystemData.Name,
                        Address = newSystemData.Address,
                        Port = newSystemData.Port,
                        Rid = newSystemData.Rid
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
                if (treeView1.SelectedNode.Parent != null && treeView1.SelectedNode.Parent.Parent != null && treeView1.SelectedNode.Parent.Parent.Text == "Zones" && treeView1.SelectedNode.Tag is Codeplug.Channel)
                {
                    var zoneName = treeView1.SelectedNode.Parent.Text;
                    var channelName = treeView1.SelectedNode.Name;
                    var zone = _yamlRoot.Zones.FirstOrDefault(z => z.Name == zoneName);

                    if (zone != null)
                    {
                        var channel = zone.Channels.FirstOrDefault(c => c.Name == channelName);
                        if (channel != null)
                        {
                            zone.Channels.Remove(channel);
                            treeView1.SelectedNode.Remove();
                        }
                    }
                }
                // Deleting a system
                else if (treeView1.SelectedNode.Parent != null && treeView1.SelectedNode.Parent.Text == "Systems" && treeView1.SelectedNode.Tag is Codeplug.System)
                {
                    var systemName = treeView1.SelectedNode.Name;
                    var system = _yamlRoot.Systems.FirstOrDefault(s => s.Name == systemName);

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
                    var zone = _yamlRoot.Zones.FirstOrDefault(z => z.Name == zoneName);

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
                    var zone = _yamlRoot.Zones.FirstOrDefault(z => z.Name == zoneName);

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
                    var system = _yamlRoot.Systems.FirstOrDefault(s => s.Name == systemName);

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

        private void kryptonRibbon1_SelectedTabChanged(object sender, EventArgs e)
        {

        }

        private void createCodeplugBtn_Click(object sender, EventArgs e)
        {
            CreateCodeplugForm createForm = new CreateCodeplugForm(this);

            createForm.ShowDialog();
        }
    }
}