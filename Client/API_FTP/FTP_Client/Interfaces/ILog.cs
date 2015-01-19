using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_FTP.FTP_Client.Interfaces
{
    /// <summary>
    /// Interface des éléments pouvant loguer des informations
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// Ajout une message de log à l'élément
        /// </summary>
        /// <param name="leStatut">le statut à logguer</param>
        void Log(IStatus leStatut);

        /// <summary>
        /// Ajout du message personnalisé de log à l'élément
        /// </summary>
        /// <param name="message">le statut à logguer</param>
        /// <param name="estUneCommande">définit si c'est une commande personnalisée ou une réponse. True pour une commande et false pour pour réponse. Par défaut c'est une réponse.</param>
        void LogCustom(string message, bool estUneCommande = false);

        /// <summary>
        /// Définit l'élement qui affichera tous les messages
        /// </summary>
        /// <param name="lElementLogable">l'objet logable</param>
        void DefinirElementLogable(ILogable lElementLogable);
    }
}
