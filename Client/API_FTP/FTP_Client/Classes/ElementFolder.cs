using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using API_FTP.FTP_Client.Interfaces;

namespace API_FTP.FTP_Client.Classes
{
    /// <summary>
    /// Classe définissant la structure d'un dossier
    /// </summary>
    class ElementFolder : Element
    {
        /// <summary>
        /// variable renseignant sur la liste des élements de ce dossier
        /// </summary>
        protected List<ITransfer> _mesElements;

        /// <summary>
        /// Obtient la valeur disant si c'est un dossier
        /// </summary>
        /// <returns>true pour dire que c'est un dossier</returns>
        public new bool EstUnDossier()
        {
            return true;
        }

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="path">chemin complet du dossier</param>
        public ElementFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException(String.Format("{0} n'existe pas !", path));
            }
            else
            {
                _path = path;
                Name = new DirectoryInfo(path).Name;
                _mesElements = new List<ITransfer>();

                ChargerLesDossiersALaRacine(_path);
                ChargerLesFichiersALaRacine(_path);

            }
        }

        public void Rafraichir()
        {
            Name = new DirectoryInfo(_path).Name;
            _mesElements = new List<ITransfer>();

            ChargerLesDossiersALaRacine(_path);
            ChargerLesFichiersALaRacine(_path);
        }

        private void ChargerLesDossiersALaRacine(string path)
        {
            List<String> lesDossiersALaRacine = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly).ToList();

            foreach (string cheminComplet in lesDossiersALaRacine)
            {
                _mesElements.Add(new ElementFolder(cheminComplet));
            }
        }

        private void ChargerLesFichiersALaRacine(string path)
        {
            List<String> lesFichiersALaRacine = Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly).ToList();

            foreach (string cheminComplet in lesFichiersALaRacine)
            {
                _mesElements.Add(new ElementFile(cheminComplet));
            }
        }

        /// <summary>
        /// Obtient la taille du dossier (sous dossiers compris)
        /// </summary>
        /// <returns>un long comme valeur de taille du dossier</returns>
        public new long GetSize()
        {
            long size = 0;
            DirectoryInfo directoryInfo = new DirectoryInfo(Path);
            IEnumerable<FileInfo> files = directoryInfo.GetFiles("*", SearchOption.AllDirectories);

            foreach (FileInfo file in files)
            {
                size += file.Length;
            }

            return size;
        }

        /// <summary>
        /// Obtient la taille du dossier (sous dossier non compris)
        /// </summary>
        /// <returns>taille du dossier en long</returns>
        public long GetSizeRacine()
        {
            long size = 0;
            DirectoryInfo directoryInfo = new DirectoryInfo(Path);
            IEnumerable<FileInfo> files = directoryInfo.GetFiles("*", SearchOption.TopDirectoryOnly);

            foreach (FileInfo file in files)
            {
                size += file.Length;
            }

            return size;
        }

        /// <summary>
        /// Obtient la liste des fichiers du dossier (les sous dossiers ne sont pas compris)
        /// </summary>
        public List<ITransfer> GetFilesRacine { 
            get {
                List<ITransfer> lesFichiersRacineDuDossier = new List<ITransfer>();

                foreach (ITransfer unElement in _mesElements)
                {
                    if (!unElement.EstUnDossier())
                    {
                        ElementFile unFichierTemp = (ElementFile)unElement;

                        if (unFichierTemp.EstUnFichier())
                        {
                            lesFichiersRacineDuDossier.Add(new ElementFile(unElement.GetPath()));
                        }
                    }
                }

                return lesFichiersRacineDuDossier;
            }
        }

        /// <summary>
        /// Obtient la liste des fichiers (sous dossiers compris)
        /// </summary>
        public List<ITransfer> GetFiles {

            get
            {
                List<ITransfer> tousLesFichiers = new List<ITransfer>();

                foreach (ITransfer unElement in _mesElements)
                {
                    if (unElement.EstUnDossier())
                    {
                        ElementFolder tempFolder = (ElementFolder)unElement;

                        tousLesFichiers.AddRange(tempFolder.GetFiles);
                    }
                    else
                    {
                        ElementFile unFichierTemp = (ElementFile) unElement;

                        if (unFichierTemp.EstUnFichier())
                        {
                            tousLesFichiers.Add(new ElementFile(unElement.GetPath()));
                        }
                    }
                }

                return tousLesFichiers;
            }
        
        }

        /// <summary>
        /// Obtient le nombre de fichiers présent dans le dossier racine
        /// </summary>
        /// <returns>nombre entier int</returns>
        public int GetNbrFichiersRacine()
        {
            int nbrFichierRacine = 0;

            foreach (ITransfer unElement in _mesElements)
            {
                if (!unElement.EstUnDossier())
                {
                    ElementFile unFichierTempTraitement = (ElementFile)unElement;

                    if (unFichierTempTraitement.EstUnFichier())
                    {
                        nbrFichierRacine = nbrFichierRacine + 1;
                    }
                }
            }

            return nbrFichierRacine;
        }

        /// <summary>
        /// Obtient le nombre de fichiers présent dans le dossier (sous dossiers compris)
        /// </summary>
        /// <returns>un entier int</returns>
        public int GetNbrFichiers()
        {
            int nbrFichiers = 0;

            foreach (ITransfer unElement in _mesElements)
            {
                if (unElement.EstUnDossier())
                {
                    ElementFolder unDossierTempTraitement = (ElementFolder)unElement;
                    nbrFichiers = nbrFichiers + unDossierTempTraitement.GetNbrFichiers();
                }
                else
                {
                    ElementFile unFichierTempTraitement = (ElementFile)unElement;

                    if (unFichierTempTraitement.EstUnFichier())
                    {
                        nbrFichiers = nbrFichiers + 1;
                    }
                }
            }

            return nbrFichiers;
        }

        /// <summary>
        /// Obtient la liste des dossiers et fichiers à la racinne
        /// </summary>
        /// <returns></returns>
        public List<ITransfer> ListerContenu()
        {
            List<ITransfer> mesElements = new List<ITransfer>();

            mesElements.AddRange(_mesElements);

            return mesElements;
        }
    }
}
