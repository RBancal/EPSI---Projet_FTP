using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_FTP.FTP_Client.Interfaces
{
    public interface IManager
    {
        /// <summary>
        /// Liste le contenu d'un dossier sans prendre en compte le contenu des sous-dossiers
        /// </summary>
        /// <param name="leDossier">le dossier à lister</param>
        /// <returns>retourn la liste des ITranfert contenu dans ce dossier</returns>
        List<ITransfer> ListerContenu(ITransfer leDossier);

        /// <summary>
        /// Liste le contenu d'un dossier
        /// </summary>
        /// <param name="leDossier">le dossier à lister</param>
        /// <param name="avecSousRepertoire">true pour les sous répertoire et false pour ne pas lister les éléments des sous-répertoires. Par défaut ne liste pas les éléments des sous-répertoires</param>
        /// <returns>retourn la liste des ITranfert contenu dans ce dossier</returns>
        List<ITransfer> ListerContenu(ITransfer leDossier, bool avecSousRepertoire = false);

        void Supprimer(ITransfer transfer);
    }
}
