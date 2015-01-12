using API_FTP.FTP_Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace API_FTP.FTP_Client.Classes
{
    class LocalManager : Manager
    {
        public LocalManager(string pathRoot)
        {
            if (!Directory.Exists(pathRoot))
            {
                throw new DirectoryNotFoundException(string.Format("{0} n'existe pas !", pathRoot));
            }
            else
            {
                base._pathRoot = pathRoot;
                base._theFolders = new List<ITransfer>();
                base._theFolders.Add(new ElementFolder(pathRoot));
            }
        }

        public LocalManager(ElementFolder aFolderRoot)
        {
            base._pathRoot = aFolderRoot.GetPath();
            base._theFolders = new List<ITransfer>();
            base._theFolders.Add((ElementFolder) aFolderRoot.Clone());
        }
    }
}
