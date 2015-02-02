using API_FTP.FTP_Client;
using API_FTP.FTP_Client.Classes;
using API_FTP.FTP_Client.Factory;
using API_FTP.FTP_Client.Interfaces;
using Limilabs.FTP.Client;
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
        private IDictionary<string, IManager> _mesGestionnaires;

        public Form1()
        {
            InitializeComponent();
            PopulateTreeView(treeViewLocal, @"C:\");
            _mesGestionnaires.Add("$LocalManager", ManagerFactory.Fabriquer("$LocalManager", ));
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
            //FileInfo infoF = new FileInfo("toto");
            //int size = (int) infoF.Length;
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



            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(string.Format("ftp://{0}:{1}/", address, port));
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential(login, password);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.KeepAlive = true;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();



            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            Console.WriteLine(reader.ReadToEnd());

            Console.WriteLine("Directory List Complete, status {0}", response.StatusDescription);

            reader.Close();
            response.Close();


            connexionButton.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /* private void deconnexionButton_Click(object sender, EventArgs e)
        {
            connexionButton.Show();
        } */
    }
}
