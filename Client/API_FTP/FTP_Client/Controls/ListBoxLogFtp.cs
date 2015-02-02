using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API_FTP.FTP_Client.Interfaces;

namespace API_FTP.FTP_Client.Controls
{
    public partial class ListBoxLogFtp : UserControl, ILogable
    {
        public ListBoxLogFtp()
        {
            InitializeComponent();
        }

        public void AddLog(string message)
        {
            lst_messagesLog.Items.Add(message);
        }

        public void AddLogCustom(string message, bool estUneCommande = false)
        {
            lst_messagesLog.Items.Add(message);
        }
    }
}
