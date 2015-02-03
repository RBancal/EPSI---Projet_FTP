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
    public class ClientFtpProjectMultithreading : IClientFtp
    {
        private Configuration _maConfig;
        private FtpWebRequest _monWebRequestFtp;
        private FtpWebResponse _monWebReponseFtp;
        private Stream _monFluxReponse;
        private StreamReader _monFluxLecture;
        private string _pathRoot;
        private Ftp _monFtp;

        bool repConnect = false;

        public ClientFtpProjectMultithreading(Configuration _maConfig) : base()
        {
            this._maConfig = (Configuration)_maConfig.Clone();
        }

        public bool Connect()
        {
            
            return repConnect;
        }

        public bool Disconnect()
        {
            bool repDeconnect = false;

            //try
            //{
            //    Close();
            //    repDeconnect = true;
            //}
            //catch (Exception)
            //{
            //    MethodesGlobales.AfficherMessage("Impossible de se déconnecté !", "Erreur de déconnexion");
            //    repDeconnect = false;
            //}
            //finally
            //{
            //    _monFluxLecture.Close();
            //    _monFluxReponse.Close();
            //}


            return true;
        }

        public bool Download(ElementFolder remoteFolder, ElementFile remoteFile, ElementFolder localFolder)
        {
                using (_monFtp = new Ftp())
                {
                    _monFtp.Connect(_maConfig.Host, _maConfig.Port);  // or ConnectSSL for SSL
                    _monFtp.Login(_maConfig.Login, _maConfig.MotDePass);
                    string resteCheminFolder = remoteFolder.GetPath().Replace(_maConfig.GetUriChaine(), "").Replace(@"\", "/");
                    string resteCheminFichier = remoteFile.GetPath().Replace(_maConfig.GetUriChaine(), "").Replace(@"\", "/");
                    _monFtp.ChangeFolder(resteCheminFolder);

                    _monFtp.Download(remoteFile.GetName(), Path.Combine(localFolder.GetPath(), remoteFile.GetName()));

                    _monFtp.Close();
                }

            return true;
        }

        public bool Upload(ElementFolder remoteFolder, ElementFile remoteFile, ElementFolder localFolder)
        {
            FtpResponse maReponseFtp;

            using (_monFtp = new Ftp())
            {
                _monFtp.Connect(_maConfig.Host, _maConfig.Port);
                _monFtp.Login(_maConfig.Login, _maConfig.MotDePass);
                _monFtp.ChangeFolder(remoteFolder.GetPath());
                maReponseFtp = _monFtp.Upload(remoteFile.GetName(), Path.Combine(localFolder.GetPath(), remoteFile.GetName()));
                _monFtp.Close();
            }

            return true;
        }

        public List<ITransfer> ListFolder(string cheminFTPDossier)
        {
            List<FtpItem> lesFtpElements = new List<FtpItem>();
            List<ITransfer> lesElements = new List<ITransfer>();

            using (Ftp monFtp = new Ftp())
            {
                monFtp.Connect(_maConfig.Host, _maConfig.Port);  // or ConnectSSL for SSL
                monFtp.Login(_maConfig.Login, _maConfig.MotDePass);
                string resteChemin = cheminFTPDossier.Replace(_maConfig.GetUriChaine(), "").Replace(@"\","/");

                if (resteChemin.Equals(""))
                {
                    lesFtpElements = monFtp.GetList();
                }
                else
                {
                    List<string> larbo = resteChemin.Split(new char[]{'/'}).ToList();

                    if (larbo.Count > 0)
                    {
                        monFtp.ChangeFolder(resteChemin);
                    }
                    else
                    {
                        monFtp.ChangeFolder(resteChemin);
                    }
                    
                }

                lesFtpElements = monFtp.GetList();
                

                monFtp.Close();
            }

            foreach (FtpItem unFtpItem in lesFtpElements)
            {
                if (unFtpItem.IsFolder)
                {
                     lesElements.Add(new ElementFolder(unFtpItem, Path.Combine(cheminFTPDossier, unFtpItem.Name)));
                }
            }

            return lesElements;
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
            _pathRoot = chemnComplet;
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
            List<FtpItem> lesFtpElements = new List<FtpItem>();
            List<ITransfer> lesElements = new List<ITransfer>();

            using (Ftp monFtp = new Ftp())
            {
                monFtp.Connect(_maConfig.Host, _maConfig.Port);  // or ConnectSSL for SSL
                monFtp.Login(_maConfig.Login, _maConfig.MotDePass);
                string resteChemin = unDossier.Replace(_maConfig.GetUriChaine(), "").Replace(@"\","/");

                if (resteChemin.Equals(""))
                {
                    lesFtpElements = monFtp.GetList();
                }
                else
                {
                    List<string> larbo = resteChemin.Split(new char[] { '/' }).ToList();

                    if (larbo.Count > 0)
                    {
                        monFtp.ChangeFolder(resteChemin);
                    }
                    else
                    {
                        monFtp.ChangeFolder(resteChemin);
                    }

                }

                lesFtpElements = monFtp.GetList();


                monFtp.Close();
            }

            foreach (FtpItem unFtpItem in lesFtpElements)
            {
                if (unFtpItem.IsFile)
                {
                    lesElements.Add(new ElementFile(unFtpItem, Path.Combine(unDossier, unFtpItem.Name)));
                }
            }

            return lesElements;
        }
    }
}
