using API_FTP.FTP_Client.Interfaces;
using Limilabs.FTP.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace API_FTP.FTP_Client.Classes
{
    /// <summary>
    /// 
    /// </summary>
    public class ClientFtpProjectMultithreading : Ftp, IClientFtp
    {
        private Configuration _maConfig;
        private FtpWebRequest _monWebRequestFtp;
        private FtpWebResponse _monWebReponseFtp;
        private Stream _monFluxReponse;
        private StreamReader _monFluxLecture;

        bool repConnect = false;

        public ClientFtpProjectMultithreading(Configuration _maConfig) : base()
        {
            this._maConfig = (Configuration)_maConfig.Clone();
        }

        public bool Connect()
        {
            
            try
            {
                Connect(_maConfig.Host, _maConfig.Port);
                Login(_maConfig.Login, _maConfig.MotDePass);
                repConnect = true;
            }
            catch (Exception)
            {
                this.Close();
                repConnect = false;
            }
            
            return repConnect;
        }

        public bool Disconnect()
        {
            bool repDeconnect = false;

            try
            {
                Close();
                repDeconnect = true;
            }
            catch (Exception)
            {
                MethodesGlobales.AfficherMessage("Impossible de se déconnecté !", "Erreur de déconnexion");
                repDeconnect = false;
            }
            finally
            {
                _monFluxLecture.Close();
                _monFluxReponse.Close();
            }


            return true;
        }

        public bool Download(ElementFolder remoteFolder, ElementFile remoteFile, ElementFolder localFolder)
        {
            if (repConnect)
            {
                ChangeFolder(remoteFolder.GetPath());
                Download(remoteFile.GetName(), Path.Combine(localFolder.GetPath(), remoteFile.GetName()));
            }
            else
            {
                Connect();

                ChangeFolder(remoteFolder.GetPath());
                Download(remoteFile.GetName(), Path.Combine(localFolder.GetPath(), remoteFile.GetName()));
            }
        }

        public bool Upload(ElementFolder remoteFolder, ElementFile remoteFile, ElementFolder localFolder)
        {
            if (repConnect)
            {
                ChangeFolder(remoteFolder.GetPath());
                Upload(remoteFile.GetName(), Path.Combine(localFolder.GetPath(), remoteFile.GetName()));
            }
            else
            {
                Connect();

                ChangeFolder(remoteFolder.GetPath());
                Upload(remoteFile.GetName(), Path.Combine(localFolder.GetPath(), remoteFile.GetName()));
            }
        }

        public List<ITransfer> ListFolder(string cheminFTPDossier)
        {
            List<FtpItem> lesFtpElements = new List<FtpItem>();
            List<ITransfer> lesElements = new List<ITransfer>();

            using (Ftp monFtp = new Ftp())
            {
                monFtp.Connect(_maConfig.Host, _maConfig.Port);  // or ConnectSSL for SSL
                monFtp.Login(_maConfig.Login, _maConfig.MotDePass);
                lesFtpElements = monFtp.GetList();

                monFtp.Close();
            }

            foreach (FtpItem unFtpItem in lesFtpElements)
            {
                if (unFtpItem.IsFolder)
                {
                    lesElements.Add(new ElementFolder(unFtpItem.SymlinkPath));
                }
                else
                {
                    lesElements.Add(new ElementFile(unFtpItem.SymlinkPath));
                }
            }

            return new List<ITransfer>();
        }

        public List<ITransfer> ListFolder(ElementFolder unDossier)
        {
            List<ITransfer> lesElements = new List<ITransfer>();



            return lesElements;
        }

        public List<ITransfer> ListFileFolder(ElementFolder unDossier)
        {
            throw new NotImplementedException();
        }

        public void DefinePathRoot(string chemnComplet)
        {
            throw new NotImplementedException();
        }

        public int FollowProgress()
        {
            throw new NotImplementedException();
        }

        public ElementFolder GetPathRootFolder()
        {
            throw new NotImplementedException();
        }

        public string GetPathRootString()
        {
            throw new NotImplementedException();
        }


        List<ITransfer> IClientFtp.ListFileFolder(string unDossier)
        {
            return new List<ITransfer>();
        }
    }
}
