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
        /// <summary>
        /// variable renseignant sur le loggeueur de message
        /// </summary>
        protected ILogable _monLogueur;

        public LocalManager(string pathRoot, ILogable unLogueur)
        {
            if (!Directory.Exists(pathRoot))
            {
                throw new DirectoryNotFoundException(string.Format("{0} n'existe pas !", pathRoot));
            }
            else
            {
                base._pathRoot = pathRoot;
                base._lesDossiers = new List<ITransfer>();
                base._lesDossiers.Add(new ElementFolder(pathRoot));
                _monLogueur = unLogueur;
            }
        }

        public LocalManager(ElementFolder aFolderRoot, ILogable unLogueur)
        {
            base._pathRoot = aFolderRoot.GetPath();
            base._lesDossiers = new List<ITransfer>();
            base._lesDossiers.Add((ElementFolder) aFolderRoot.Clone());
            _monLogueur = unLogueur;
        }

        public LocalManager(ITransfer theFolder, ILogable unLogueur)
        {
            if (theFolder.EstUnDossier())
            {
                base._pathRoot = theFolder.GetPath();
                base._lesDossiers = new List<ITransfer>();
                base._lesDossiers.Add((ElementFolder)theFolder.Clone());
                _monLogueur = unLogueur;
            }
            else
            {
                throw new DirectoryNotFoundException(string.Format("{0} n'existe pas !", theFolder.GetPath()));
            }
        }

        public new List<ITransfer> Parcourrir(ElementFolder leDossier)
        {
            List<ITransfer> lesElementsDuDossier = new List<ITransfer>();

            lesElementsDuDossier.AddRange(leDossier.ListerContenu());

            return lesElementsDuDossier;
        }

    }
}
