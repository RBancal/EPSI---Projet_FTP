using API_FTP.FTP_Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace API_FTP.FTP_Client.Classes
{
    class LocalManager : Manager
    {
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="pathRoot">chemin du répertoire local</param>
        /// <param name="unLogueur">logueur de messages</param>
        public LocalManager(string pathRoot, ILog unLogueur)
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

                ChargerLogueur(unLogueur);
            }
        }

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="aFolderRoot">dossier local</param>
        /// <param name="unLogueur">logueur de messages</param>
        public LocalManager(ElementFolder aFolderRoot, ILog unLogueur)
        {
            base._pathRoot = aFolderRoot.GetPath();
            base._lesDossiers = new List<ITransfer>();
            base._lesDossiers.Add((ElementFolder) aFolderRoot.Clone());
            ChargerLogueur(unLogueur);
        }

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="theFolder">élement de transfer de type dossier (ElementFolder)</param>
        /// <param name="unLogueur">logueur de messages</param>
        public LocalManager(ITransfer theFolder, ILog unLogueur)
        {
            if (theFolder.EstUnDossier())
            {
                base._pathRoot = theFolder.GetPath();
                base._lesDossiers = new List<ITransfer>();
                base._lesDossiers.Add((ElementFolder)theFolder.Clone());

                ChargerLogueur(unLogueur);
                _monLogueur.LogCustom("Dossiers local chargé");
            }
            else
            {
                throw new DirectoryNotFoundException(string.Format("{0} n'existe pas !", theFolder.GetPath()));
            }
        }

        /// <summary>
        /// Liste les élément contenu dans le répertoire fourni. Cette liste n'inclus pas le contenu des sous repertoires
        /// </summary>
        /// <param name="leDossier">le réertoire</param>
        /// <returns>liste des ITransfert à la racine du répertoire</returns>
        public new List<ITransfer> ListerContenu(ElementFolder leDossier)
        {
            List<ITransfer> lesElementsDuDossier = new List<ITransfer>();

            lesElementsDuDossier.AddRange(leDossier.ListerContenu());

            return lesElementsDuDossier;
        }

    }
}
