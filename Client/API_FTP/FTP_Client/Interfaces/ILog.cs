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
    interface ILog
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
        void LogCustom(string message);
    }
}
