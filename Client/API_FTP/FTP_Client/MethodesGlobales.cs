using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace API_FTP.FTP_Client
{
    public static abstract class MethodesGlobales
    {
        public static void AfficherMessage(string message, string titre)
        {
            MessageBox.Show(message, titre);
        }

        public static void AfficherMessageErreurInitialisationILog()
        {
            AfficherMessage(VariablesGlobales.GetContenuMessageErreurInitialisationILog, VariablesGlobales.GetTitreMessageErreurInitialisationILog);
        }

        public static void AfficherMessageErreurInitialisationILogable()
        {
            AfficherMessage(VariablesGlobales.GetContenuMessageErreurInitialisationILogable, VariablesGlobales.GetTitreMessageErreurInitialisationILogable);
        }
    }
}
