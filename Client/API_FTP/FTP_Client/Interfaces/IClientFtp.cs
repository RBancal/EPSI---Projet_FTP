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
    interface IClientFtp
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
        /// <returns>true si le téléchargement s'es bien passé</returns>
        bool Download();

        /// <summary>
        /// Permet d'envoyer des éléments au server FTP
        /// </summary>
        /// <returns>true si l'envoie s'est bien passé</returns>
        bool Upload();

        /// <summary>
        /// Obtient la liste les dossiers sur le serveur
        /// </summary>
        /// <returns>list des ElementFolder</returns>
        List<ElementFolder> ListFolder(string cheminFTPDossier);

        /// <summary>
        /// Obtient la liste les dossiers sur le serveur
        /// </summary>
        /// <returns>list des ElementFolder</returns>
        List<ElementFolder> ListFolder(ElementFolder unDossier);

        /// <summary>
        /// Obtient la liste des Fchiers d'un dossier
        /// </summary>
        /// <returns></returns>
        List<ElementFile> ListFileFolder(ElementFolder unDossier);

        /// <summary>
        /// Obtient la liste des Fchiers d'un dossier
        /// </summary>
        /// <returns></returns>
        List<ElementFile> ListFileFolder(string unDossier);

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
    }
}
