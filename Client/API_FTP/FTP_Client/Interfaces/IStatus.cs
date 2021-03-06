﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_FTP.FTP_Client.Interfaces
{
    /// <summary>
    /// Interface des objets fournissant des status
    /// </summary>
    public interface IStatus
    {
        /// <summary>
        /// Obtient le code statut
        /// </summary>
        /// <returns>nombre entier</returns>
        int GetStatusCode();

        /// <summary>
        /// Obtient le commentaire du statut
        /// </summary>
        /// <returns>chaine (string)</returns>
        string GetStatusDetail();

        /// <summary>
        /// Dit si c'est un statut de type StatutCommand
        /// </summary>
        /// <returns>true pour est un statutCommand</returns>
        bool EstUnStatutCommand();
    }
}
