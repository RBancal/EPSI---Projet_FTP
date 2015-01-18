using API_FTP.FTP_Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_FTP.FTP_Client.Classes
{
    /// <summary>
    /// 
    /// </summary>
    abstract class Manager
    {
        // List<> folders
        protected string _pathRoot;
        protected List<ITransfer> _lesDossiers;

        abstract public List<ElementFolder> GetFolders();

        abstract public void Parcourir(ITransfer theFolders);
    }
}
