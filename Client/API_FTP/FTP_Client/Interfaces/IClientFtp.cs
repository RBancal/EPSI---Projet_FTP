using API_FTP.FTP_Client.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_FTP.FTP_Client.Interfaces
{
    /// <summary>
    /// Interface permettant d'interagir avec le serveur FTP
    /// </summary>
    public interface IClientFtp
    {
        /// <summary>
        /// Permet de se connecter
        /// </summary>
        /// <returns>true si la connexion s'est bien passé</returns>
        bool Connect();

        /// <summary>
        /// Permet de se déconnecter
        /// </summary>
        /// <returns>true si la déconnexion s'est bien passé</returns>
        bool Disconnect();

        /// <summary>
        /// Permet de télécharger des éléments
        /// </summary>
        /// <param name="remoteFolder">le dossier serveur</param>
        /// <param name="remoteFile">le fichier à télécharger</param>
        /// <param name="localFolder">le dossier local</param>
        /// <returns>true si le téléchargement s'es bien passé</returns>
        bool Download(ElementFolder remoteFolder, ElementFile remoteFile, ElementFolder localFolder);

        /// <summary>
        /// Permet d'envoyer des éléments au server FTP
        /// </summary>
        /// <param name="remoteFolder">le dossier racine serveur</param>
        /// <param name="remoteFile">le fichier serveur à upload</param>
        /// <param name="localFolder">le dossier local</param>
        /// <returns>true si l'envoie s'est bien passé</returns>
        bool Upload(ElementFolder remoteFolder, ElementFile remoteFile, ElementFolder localFolder);

        /// <summary>
        /// Obtient la liste les dossiers sur le serveur
        /// </summary>
        /// <returns>list des ElementFolder</returns>
        List<ITransfer> ListFolder(string cheminFTPDossier);

        /// <summary>
        /// Obtient la liste les dossiers sur le serveur
        /// </summary>
        /// <returns>list des ElementFolder</returns>
        List<ITransfer> ListFolder(ElementFolder unDossier);

        /// <summary>
        /// Obtient la liste des Fchiers d'un dossier
        /// </summary>
        /// <returns>liste d'ElementFile</returns>
        List<ITransfer> ListFileFolder(ElementFolder unDossier);

        /// <summary>
        /// Obtient la liste des Fchiers d'un dossier
        /// </summary>
        /// <returns>liste d'ElementFile</returns>
        List<ITransfer> ListFileFolder(string unDossier);

        /// <summary>
        /// Définit le répertoire root du serveur pour le client
        /// </summary>
        /// <param name="chemnComplet">chemin d'accès au dossier sur le serveur ftp</param>
        void DefinePathRoot(string chemnComplet);

        /// <summary>
        /// Permet de suivre la valeur d'avancement
        /// </summary>
        /// <returns>un entier</returns>
        int FollowProgress();

        /// <summary>
        /// Obtient le dossier root du serveur FTP pour l'utilisateur
        /// </summary>
        /// <returns>ElementFolder</returns>
        ElementFolder GetPathRootFolder();

        /// <summary>
        /// Obtient le dossier root du serveur FTP pour l'utilisateur
        /// </summary>
        /// <returns>chemin coomplet du dossier root sur le serveur pour l'utilisateur</returns>
        string GetPathRootString();

        void CreerDossier(string leNmDossierACreer, ElementFolder leDossierDistant);

        void UploadDossier(ElementFolder dossierLocal, ElementFolder dossierDistant);

        Limilabs.FTP.Client.Ftp GetModuleFtp();
    }
}
