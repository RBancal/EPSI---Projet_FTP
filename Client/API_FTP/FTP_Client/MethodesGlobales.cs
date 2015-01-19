using System;
using System.Collections.Generic;
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
    }
}
