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
    public interface ILogable
    {
        /// <summary>
        /// Ajout une message de log à l'élément
        /// </summary>
        void AddLog(string message);

        /// <summary>
        /// Ajout du message personnalisé de log à l'élément
        /// </summary>
        /// <param name="message">le statut à logguer</param>
        /// <param name="estUneCommande">définit si c'est une commande personnalisée ou une réponse. True pour une commande et false pour pour réponse. Par défaut c'est une réponse.</param>
        void AddLogCustom(string message, bool estUneCommande = false);
    }
}
