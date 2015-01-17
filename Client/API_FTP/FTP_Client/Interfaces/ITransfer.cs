using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_FTP.FTP_Client.Interfaces
{
    /// <summary>
    /// Interface des éléments transferable
    /// </summary>
    interface ITransfer : ICloneable
    {
        /// <summary>
        /// Obtient le chemin complet de l'élément transferable
        /// </summary>
        /// <returns></returns>
        string GetPath();

        /// <summary>
        /// Obtient le nom de l'élément transferable
        /// </summary>
        /// <returns></returns>
        string GetName();
        /// <summary>
        /// Obtien la taille de l'élément transferable
        /// </summary>
        /// <returns>taille en long</returns>
        long GetSize();

        /// <summary>
        /// Dit si l'élément transferable est un ElementFolder(dossier)
        /// </summary>
        /// <returns>true si c'est un élémentFolder(dossier)</returns>
        Boolean EstUnDossier();
    }
}
