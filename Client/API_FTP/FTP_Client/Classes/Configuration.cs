using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace API_FTP.FTP_Client.Classes
{
    public class Configuration : ICloneable
    {
        protected string _login;
        protected string _password;
        protected string _host;
        protected int _port;

        public string Login { get { return _login; } set { _login = value; } }
        public string MotDePass { get { return _password; } set { _password = value; } }
        public string Host { get { return _host; } set { _host = value; } }
        
        public int Port { get { return _port; } 
            set 
            {
                if (value < 0)
                {
                    MethodesGlobales.AfficherMessage("Un port ne peut avoir de valeur négative", "Erreur - port");
                }
                else
                {
                    _port = value;
                }
            } 
        }

        public bool FermeeConnexionApresTraitement { get; set; }

        public string GetUriChaine()
        {
            return string.Format("ftp://{0}:{1}/", _host, _port, _login, _password);
        }

        public Uri GetObjetUri()
        {
            return new Uri(GetUriChaine());
        }

        public NetworkCredential GetNetworkCredential(bool connexionAFermeApresEchange = false)
        {
            return new NetworkCredential(_login, _password);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
