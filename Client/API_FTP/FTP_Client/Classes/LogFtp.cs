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

        protected const string ERREUR_INITIALISATION_MESSAGE = "Ce logueur n'est pas initialisé. Merci de l'initialisé";
        protected const string ERREUR_INITIALISATION_TITRE = "Erreur - Logueur";

        public void Log(IStatus leStatut)
        {
            if (_monLogueur == null)
            {
                MessageBox.Show(ERREUR_INITIALISATION_MESSAGE, ERREUR_INITIALISATION_TITRE);
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
                MessageBox.Show(ERREUR_INITIALISATION_MESSAGE, ERREUR_INITIALISATION_TITRE);
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
                MessageBox.Show(ERREUR_INITIALISATION_MESSAGE, ERREUR_INITIALISATION_TITRE);
            }
            else
            {
                _monLogueur = lElementLogable;
            }
        }
    }
}
