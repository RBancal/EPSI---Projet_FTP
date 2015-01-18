using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_FTP.FTP_Client
{
    static abstract class VariablesGlobales
    {
        protected const string ERREUR_INITIALISATION_MESSAGE = "Ce {0} N'est pas initialisé. Merci de l'initialisé";
        protected const string ERREUR_INITIALISATION_TITRE = "Erreur - {0}";

        public static string GetContenuMessageErreurInitialisationILog { get { return string.Format(ERREUR_INITIALISATION_MESSAGE, "ILog"); } }
        public static string GetTitreMessageErreurInitialisationILog { get { return string.Format(ERREUR_INITIALISATION_TITRE, "ILog");  } }
        public static string GetContenuMessageErreurInitialisationILogable { get { return string.Format(ERREUR_INITIALISATION_MESSAGE, "ILogable"); } }
        public static string GetTitreMessageErreurInitialisationILogable { get { return string.Format(ERREUR_INITIALISATION_TITRE, "ILogable"); } }
    }
}
