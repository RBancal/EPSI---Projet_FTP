using API_FTP.FTP_Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace API_FTP.FTP_Client.Classes
{
    abstract class LogFtp : ILog
    {
        protected ILogable _monLogueur;

        public void Log(IStatus leStatut)
        {
            if (_monLogueur == null)
            {
                MethodesGlobales.AfficherMessageErreurInitialisationILog();
            }
            else
            {
                _monLogueur.AddLog(leStatut.GetStatusDetail());
            }
        }

        public void LogCustom(string message, bool estUneCommande = false)
        {
            if (_monLogueur == null)
            {
                MethodesGlobales.AfficherMessageErreurInitialisationILog();
            }
            else
            {
                if (estUneCommande)
                {
                    StatusCommand laCommande = new StatusCommand(message);
                    _monLogueur.AddLogCustom(laCommande.GetStatusDetail());
                }
                else
                {
                    StatusResponse laReponse = new StatusResponse(message);
                    _monLogueur.AddLogCustom(laReponse.GetStatusDetail());
                }
            }
        }


        public void DefinirElementLogable(ILogable lElementLogable)
        {
            if (lElementLogable == null)
            {
                MethodesGlobales.AfficherMessageErreurInitialisationILog();
            }
            else
            {
                _monLogueur = lElementLogable;
            }
        }
    }
}
