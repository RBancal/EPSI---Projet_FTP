using API_FTP.FTP_Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_FTP.FTP_Client.Classes
{
    /// <summary>
    /// Classe abstraite qui renseigne sur les status
    /// </summary>
    abstract class Status : IStatus
    {
        protected string _comment;

        public int GetStatusCode()
        {
            return 0;
        }

        public string GetStatusDetail()
        {
            return "";
        }
    }
}
