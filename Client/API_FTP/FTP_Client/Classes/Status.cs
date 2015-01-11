using API_FTP.FTP_Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_FTP.FTP_Client.Classes
{
    /// <summary>
    /// Classe abstraite qui renseigne sur les status
    /// </summary>
    abstract class Status : IStatus
    {
        /// <summary>
        /// Renseigne sur le commentaire du statut
        /// </summary>
        protected string _comment;

        /// <summary>
        /// Obtient le code statut converti en int
        /// </summary>
        /// <returns>int</returns>
        public int GetStatusCode()
        {
            return 0;
        }

        /// <summary>
        /// Obtient le statut détaillé sous forme de chaine de texte
        /// </summary>
        /// <returns>string</returns>
        public string GetStatusDetail()
        {
            return "";
        }
    }
}
