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
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Whackerlink_CPS
{
    public partial class HelpForm : Form
    {
        private XmlDocument xmlDoc = new XmlDocument();

        public HelpForm()
        {
            InitializeComponent();
            LoadXml();
            PopulateTreeView();
        }

        private void LoadXml()
        {
            xmlDoc.Load("Help.xml");
        }

        private void PopulateTreeView()
        {
            XmlNodeList sectionList = xmlDoc.SelectNodes("//Section");
            foreach (XmlNode section in sectionList)
            {
                TreeNode sectionNode = new TreeNode(GetNodeText(section, "Title"));
                sectionNode.Tag = GetNodeText(section, "Content");
                kryptonTreeView1.Nodes.Add(sectionNode);

                XmlNodeList subSectionList = section.SelectNodes("SubSection");
                foreach (XmlNode subSection in subSectionList)
                {
                    TreeNode subSectionNode = new TreeNode(GetNodeText(subSection, "Title"));
                    subSectionNode.Tag = GetNodeText(subSection, "Content");
                    sectionNode.Nodes.Add(subSectionNode);
                }
            }
        }

        private string GetNodeText(XmlNode node, string tagName)
        {
            XmlNode childNode = node.SelectSingleNode(tagName);
            return childNode != null ? childNode.InnerText : string.Empty;
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            displayPage.Text = e.Node.Tag.ToString();
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchBar.Text.ToLower();
            kryptonTreeView1.Nodes.Clear();
            XmlNodeList sectionList = xmlDoc.SelectNodes("//Section");
            foreach (XmlNode section in sectionList)
            {
                string sectionTitle = GetNodeText(section, "Title").ToLower();
                if (sectionTitle.Contains(searchText))
                {
                    TreeNode sectionNode = new TreeNode(GetNodeText(section, "Title"));
                    sectionNode.Tag = GetNodeText(section, "Content");
                    kryptonTreeView1.Nodes.Add(sectionNode);
                }
                else
                {
                    TreeNode sectionNode = new TreeNode(GetNodeText(section, "Title"));
                    sectionNode.Tag = GetNodeText(section, "Content");

                    bool subSectionAdded = false;
                    XmlNodeList subSectionList = section.SelectNodes("SubSection");
                    foreach (XmlNode subSection in subSectionList)
                    {
                        string subSectionTitle = GetNodeText(subSection, "Title").ToLower();
                        if (subSectionTitle.Contains(searchText))
                        {
                            TreeNode subSectionNode = new TreeNode(GetNodeText(subSection, "Title"));
                            subSectionNode.Tag = GetNodeText(subSection, "Content");
                            sectionNode.Nodes.Add(subSectionNode);
                            subSectionAdded = true;
                        }
                    }

                    if (subSectionAdded)
                    {
                        kryptonTreeView1.Nodes.Add(sectionNode);
                    }
                }
            }
        }
    


private void kryptonPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void searchBar_MouseClick(object sender, MouseEventArgs e)
        {
            searchBar.Text = "";
        }
    }
}