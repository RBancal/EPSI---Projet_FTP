using API_FTP.FTP_Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_FTP.FTP_Client.Classes
{
    /// <summary>
    /// Classe 
    /// </summary>
    public class DistantManager : Manager
    {
        protected Configuration _maConfig;
        protected IClientFtp _monClientFtp;

        public DistantManager(Configuration laConfig, ILog unLogueur)
        {
            _maConfig = (Configuration)laConfig.Clone();
            base._pathRoot = _maConfig.GetUriChaine();
            base._lesDossiers = new List<ITransfer>();
            _monClientFtp = new ClientFtpProjectMultithreading(_maConfig);
            ChargerLogueur(unLogueur);
        }

        public override List<ITransfer> ListerContenu(ITransfer leDossier, bool avecSousRepertoire = false)
        {
            List<ITransfer> lesElementsContenus = new List<ITransfer>();
            _monClientFtp.DefinePathRoot(base._pathRoot);
            _monClientFtp.Connect();

            if (avecSousRepertoire)
            {

            }
            else
            {
                lesElementsContenus.AddRange(_monClientFtp.ListFolder((ElementFolder)leDossier));
                lesElementsContenus.AddRange(_monClientFtp.ListFileFolder((ElementFolder)leDossier));
            }

            
            return lesElementsContenus;
        }

        public List<ITransfer> ListerContenu(bool avecSousRepertoire = false)
        {
            List<ITransfer> lesElementsContenus = new List<ITransfer>();
            _monClientFtp.DefinePathRoot(base._pathRoot);
            _monClientFtp.Connect();

            if (avecSousRepertoire)
            {

            }
            else
            {
                lesElementsContenus.AddRange(_monClientFtp.ListFolder(base._pathRoot));
                lesElementsContenus.AddRange(_monClientFtp.ListFileFolder(base._pathRoot));
            }


            return lesElementsContenus;
        }

        public override List<ITransfer> ListerContenu(Interfaces.ITransfer leDossier)
        {
            throw new NotImplementedException();
        }
    }
}
