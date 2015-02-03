using Limilabs.FTP.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_FTP.FTP_Client.Classes
{
    public class ElementFile : Element
    {
        public bool EstUnFichier()
        {
            return true;
        }

        public new bool EstUnDossier()
        {
            return false;
        }

        public new long GetSize()
        {
            return new FileInfo(Path).Length;
        }

        public ElementFile(string chemin)
        {
            if (!File.Exists(chemin))
            {
                throw new FileNotFoundException(string.Format("{0} n'existe pas !", chemin));
            }
            else
            {
                _path = chemin;
                Name = new FileInfo(chemin).Name;
            }
        }

        public ElementFile(FtpItem unFtpItem, string cheminCompletFichierSurServeur)
        {
            if (unFtpItem.IsFolder)
            {
                _path = cheminCompletFichierSurServeur;
                Name = unFtpItem.Name;
            }
            else
            {
                _path = cheminCompletFichierSurServeur;
                Name = unFtpItem.Name;
            }
        }
    }
}
