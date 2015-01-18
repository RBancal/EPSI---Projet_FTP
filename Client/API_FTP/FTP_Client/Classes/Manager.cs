using API_FTP.FTP_Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_FTP.FTP_Client.Classes
{
    /// <summary>
    /// 
    /// </summary>
    abstract class Manager
    {
        /// <summary>
        /// Chemin du répertoire racine de démarrage 
        /// </summary>
        protected string _pathRoot;
        
        /// <summary>
        /// est la variable fournissant la liste des répertoires à la racine du réêrtoire root
        /// </summary>
        protected List<ITransfer> _lesDossiers;

        /// <summary>
        /// Obtient tous les dossiers
        /// </summary>
        /// <returns></returns>
        abstract public List<ElementFolder> GetFolders();

        abstract public List<ITransfer> ListerContenu(ITransfer leDossier);
    }
}
