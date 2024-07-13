using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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