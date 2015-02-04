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
    public class LocalManager : Manager
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

        public override List<ITransfer> ListerContenu(ITransfer leDossier)
        {
            List<ITransfer> lesElementContenus = new List<ITransfer>();

            if (leDossier.EstUnDossier())
            {
                ElementFolder unElementFolder = (ElementFolder)leDossier;

                lesElementContenus.AddRange(ListerContenu(unElementFolder));
            }
            else
            {
                MethodesGlobales.AfficherMessage(string.Format("{0} N'est pas un dossier ! Il est impossible de le lister", leDossier.GetPath()), "Erreur de listage de contenu");
            }

            return lesElementContenus;
        }

        /// <summary>
        /// Liste le contenu du répertoire
        /// </summary>
        /// <param name="leDossier">le dossier</param>
        /// <param name="avecSousRepertoire">true pour lister les sous repertoire et false pour ne pas lister. Par défaut, il liste les sous répertoire</param>
        /// <returns>la liste des ITranfers trouves dans le repertoire (sous-répertoires compris)</returns>
        public override List<ITransfer> ListerContenu(ITransfer leDossier, bool avecSousRepertoire = false)
        {
            List<ITransfer> lesElementContenus = new List<ITransfer>();

            if (leDossier.EstUnDossier())
            {
                if (avecSousRepertoire)
                {
                    ListerTousLesITransfertAvecSousRepertoire(leDossier, ref lesElementContenus);
                }
                else
                {
                    ElementFolder unELementFolder = (ElementFolder) leDossier;
                    lesElementContenus.AddRange(ListerContenu(unELementFolder));
                }
            }
            else
            {
                MethodesGlobales.AfficherMessage(string.Format("{0} N'est pas un dossier ! Il est impossible de le lister", leDossier.GetPath()), "Erreur de listage de contenu");
            }

            return lesElementContenus;
        }

        protected void ListerTousLesITransfertAvecSousRepertoire(ITransfer leDossier, ref List<ITransfer> lesElementContenus)
        {
            ElementFolder unElementFolder = (ElementFolder)leDossier;

            foreach (ITransfer unElement in unElementFolder.ListerContenu())
            {
                if (unElementFolder.EstUnDossier())
                {
                    lesElementContenus.AddRange(ListerContenu(unElement));
                }
                else
                {
                    lesElementContenus.Add(unElement);
                }
            }
        }

        public override void Supprimer(ITransfer transfer)
        {
            if (transfer.EstUnDossier())
            {
                Directory.Delete(transfer.GetPath());
            }
            else
            {
                File.Delete(transfer.GetPath());
            }
        }
    }
}
