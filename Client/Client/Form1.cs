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

            connexionButton.Hide();
        }
    }
}
