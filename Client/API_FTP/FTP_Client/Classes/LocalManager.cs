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
        /// est le logueur de messages
        /// </summary>
        protected ILogable _monLogueur;

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="pathRoot">chemin du répertoire local</param>
        /// <param name="unLogueur">logueur de messages</param>
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

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="aFolderRoot">dossier local</param>
        /// <param name="unLogueur">logueur de messages</param>
        public LocalManager(ElementFolder aFolderRoot, ILogable unLogueur)
        {
            base._pathRoot = aFolderRoot.GetPath();
            base._lesDossiers = new List<ITransfer>();
            base._lesDossiers.Add((ElementFolder) aFolderRoot.Clone());
            _monLogueur = unLogueur;
        }

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="theFolder">élement de transfer de type dossier (ElementFolder)</param>
        /// <param name="unLogueur">logueur de messages</param>
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
