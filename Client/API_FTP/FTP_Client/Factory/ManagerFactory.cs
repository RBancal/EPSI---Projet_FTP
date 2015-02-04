using API_FTP.FTP_Client.Classes;
using API_FTP.FTP_Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_FTP.FTP_Client.Factory
{
    public static class ManagerFactory
    {
        public static Manager Fabriquer(string gestionnaire, Configuration laConfig = null)
        {
            Manager unManager = null;

            if (gestionnaire == "$LocalManager")
            {
                
                unManager = new LocalManager(new ElementFolder(@"d:\"));
            }
            else
            {
                unManager = new DistantManager(laConfig);
            }

            return unManager;
        }
    }
}
