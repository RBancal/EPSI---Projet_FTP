using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopulateTreeView(treeViewLocal, "C:\\");
        }

        private void PopulateTreeView(TreeView treeView ,string path)
        {
            TreeNode rootNode;

            DirectoryInfo info = new DirectoryInfo(path);
            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                GetDirectories(info.GetDirectories(), rootNode);
                treeView.Nodes.Add(rootNode);
            }
        }

        private void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs)
            {
                try
                {
                    aNode = new TreeNode(subDir.Name, 0, 0);
                    aNode.Tag = subDir;
                    aNode.ImageKey = "folder";
                    nodeToAddTo.Nodes.Add(aNode);
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
                catch (InvalidOperationException)
                {
                    continue;
                }
                catch (NullReferenceException)
                {
                    continue;
                }
            }
        }

        private void connexionButton_Click(object sender, EventArgs e)
        {
            string login = loginTextBox.Text;
            string password = passwordTextBox.Text;
            string address = serverTextBox.Text;
            int port = 0;

            if (! int.TryParse(portTextBox.Text, out port))
            {
                MessageBox.Show("Veuillez rentrer un port valide", "Port invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FtpWebRequest request = (FtpWebRequest) FtpWebRequest.Create(new Uri("ftp://" + address + ":" + port + "/"));
            request.Credentials = new NetworkCredential(login, password);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.KeepAlive = true;

            FtpWebResponse response = (FtpWebResponse) request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            //Console.WriteLine("Directory List Complete, status {0}", response.StatusDescription);

            reader.Close();
            response.Close();

            // PopulateTreeView(treeViewDistant, string response);

            connexionButton.Hide();
        }

        /* private void deconnexionButton_Click(object sender, EventArgs e)
        {
            connexionButton.Show();
        } */
    }
}
