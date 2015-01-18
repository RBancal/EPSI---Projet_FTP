using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_FTP.FTP_Client
{
    static abstract class VariablesGlobales
    {
        protected const string ERREUR_INITIALISATION_MESSAGE = "Ce logueur n'est pas initialisé. Merci de l'initialisé";
        protected const string ERREUR_INITIALISATION_TITRE = "Erreur - Logueur";

        public static string GetContenuMessageErreurInitialisationILog { get { return ERREUR_INITIALISATION_MESSAGE; } }
        public static string GetTitreMessageErreurInitialisationILog { get { return ERREUR_INITIALISATION_TITRE;  } }
    }
}
