using API_FTP.FTP_Client.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace API_FTP.FTP_Client
{
    /// <summary>
    /// Class fournissant l'enesemble des methodes globales du client FTP
    /// </summary>
    public static class MethodesGlobales
    {
        /// <summary>
        /// Affiche un message à l'utilisateur
        /// </summary>
        /// <param name="message">le message</param>
        /// <param name="titre">le titre du message</param>
        public static void AfficherMessage(string message, string titre)
        {
            MessageBox.Show(message, titre);
        }

        /// <summary>
        /// Affiche un message d'erreur correspondant à une erreur de chargement du ILog
        /// </summary>
        public static void AfficherMessageErreurInitialisationILog()
        {
            AfficherMessage(VariablesGlobales.GetContenuMessageErreurInitialisationILog, VariablesGlobales.GetTitreMessageErreurInitialisationILog);
        }

        /// <summary>
        /// Affiche un message d'erreur correspondant à une erreur de chargement du ILogable
        /// </summary>
        public static void AfficherMessageErreurInitialisationILogable()
        {
            AfficherMessage(VariablesGlobales.GetContenuMessageErreurInitialisationILogable, VariablesGlobales.GetTitreMessageErreurInitialisationILogable);
        }

        internal static string GetCheminServerSansRacinne(string unDossier, string UriRacinneSrvFtp)
        {
            return unDossier.Replace(UriRacinneSrvFtp, "").Replace(@"\", "/");
        }

        internal static string GetCheminDossierUploadSurServeur(string cheminDossierServeurSansRacinne, string nomDossierUlploaded)
        {
            return string.Format(@"{0}/{1}", cheminDossierServeurSansRacinne, nomDossierUlploaded);
        }

        internal static string GetCheminDossierLocalDownload(string cheminCompletDossierLocal, string nomDossierDistantATelecharger)
        {
            return Path.Combine(cheminCompletDossierLocal, nomDossierDistantATelecharger);
        }
    }
}
