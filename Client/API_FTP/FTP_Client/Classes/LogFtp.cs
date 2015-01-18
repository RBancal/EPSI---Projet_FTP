using API_FTP.FTP_Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace API_FTP.FTP_Client.Classes
{
    /// <summary>
    /// Classe définissant la structure du logFTP
    /// </summary>
    abstract class LogFtp : ILog
    {
        /// <summary>
        /// est l'attribut définissant le ILogable
        /// </summary>
        protected ILogable _monLogable;

        /// <summary>
        /// Charge le logable en testant si il n'est pas null. S'il est null il affiche un message à l'utilisateur
        /// </summary>
        /// <param name="unLogable">le Ilogable</param>
        protected void ChargerLogable(ILogable unLogable)
        {
            if (unLogable == null)
            {
                MethodesGlobales.AfficherMessageErreurInitialisationILogable();
            }
            else
            {
                _monLogable = unLogable;
            }
        }

        /// <summary>
        /// Envoie un Statut que doit afficher le ILogable sous forme de message
        /// </summary>
        /// <param name="leStatut">le statut</param>
        public void Log(IStatus leStatut)
        {
            if (_monLogable == null)
            {
                MethodesGlobales.AfficherMessageErreurInitialisationILogable();
            }
            else
            {
                _monLogable.AddLog(leStatut.GetStatusDetail());
            }
        }

        /// <summary>
        /// Envoie un message personnalisé que doit afficher le ILogable
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="estUneCommande">définit si c'est une commande ou une réponse. True pour commande</param>
        public void LogCustom(string message, bool estUneCommande = false)
        {
            if (_monLogable == null)
            {
                MethodesGlobales.AfficherMessageErreurInitialisationILogable();
            }
            else
            {
                if (estUneCommande)
                {
                    StatusCommand laCommande = new StatusCommand(message);
                    _monLogable.AddLogCustom(laCommande.GetStatusDetail());
                }
                else
                {
                    StatusResponse laReponse = new StatusResponse(message);
                    _monLogable.AddLogCustom(laReponse.GetStatusDetail());
                }
            }
        }

        /// <summary>
        /// Définit le Ilogable à utiliser
        /// </summary>
        /// <param name="lElementLogable">le ILogable</param>
        public void DefinirElementLogable(ILogable lElementLogable)
        {
            ChargerLogable(lElementLogable);
        }
    }
}
