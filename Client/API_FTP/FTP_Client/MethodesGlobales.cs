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
        public static void AfficherMessager(string message, string titre)
        {
            MessageBox.Show(message, titre);
        }

        public static void AfficherMessageErreurInitialisationILog()
        {
            AfficherMessager(VariablesGlobales.GetContenuMessageErreurInitialisationILog, VariablesGlobales.GetTitreMessageErreurInitialisationILog);
        }
    }
}
