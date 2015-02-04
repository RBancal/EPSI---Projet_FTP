using API_FTP.FTP_Client.Enums;
using API_FTP.FTP_Client.Interfaces;
using Limilabs.FTP.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace API_FTP.FTP_Client.Classes
{
    /// <summary>
    /// 
    /// </summary>
    public class ClientFtpProjectMultithreading : IClientFtp
    {
        private Configuration _maConfig;
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

        public bool Upload(ElementFolder localFolder, ElementFile localFile, ElementFolder distantFolder)
        {
            FtpResponse maReponseFtp;

            using (_monFtp = new Ftp())
            {
                _monFtp.Connect(_maConfig.Host, _maConfig.Port);
                _monFtp.Login(_maConfig.Login, _maConfig.MotDePass);
                string resteChemin = distantFolder.GetPath().Replace(_maConfig.GetUriChaine(), "").Replace(@"\", "/");

                if (!string.IsNullOrEmpty(resteChemin))
                {
                    _monFtp.ChangeFolder(resteChemin);
                }
                
                maReponseFtp = _monFtp.Upload(localFile.GetName(), localFile.GetPath());
                _monFtp.Close();
            }

            return true;
        }

        public List<ITransfer> ListFolder(string cheminFTPDossier)
        {
            List<FtpItem> lesFtpElements = new List<FtpItem>();
            List<ITransfer> lesElements = new List<ITransfer>();

            //StatusCommand lesStatuts = new StatusCommand(EStatusCommand);

            using (_monFtp = new Ftp())
            {
                VariablesGlobales._leLog.Log(new StatusCommand(EStatusCommand.DemandeConnexion));

                try
                {
                    _monFtp.Connect(_maConfig.Host, _maConfig.Port);  // or ConnectSSL for SSL
                    VariablesGlobales._leLog.Log(new StatusResponse(EStatusResponse.AReussieAjoindreHote));
                }
                catch (Exception)
                {
                    VariablesGlobales._leLog.Log(new StatusResponse(EStatusResponse.ImpossibleDAtteindreServeurFtp));
                }
                
                VariablesGlobales._leLog.Log(new StatusCommand(EStatusCommand.DemandeAuthentification));

                try
                {
                    _monFtp.Login(_maConfig.Login, _maConfig.MotDePass);
                    VariablesGlobales._leLog.Log(new StatusResponse(EStatusResponse.AuthentificationReussie));
                }
                catch (FtpResponseException e)
                {
                    VariablesGlobales._leLog.Log(new StatusResponse(EStatusResponse.AuthentificationReussie));
                }
                

                

                string resteChemin = cheminFTPDossier.Replace(_maConfig.GetUriChaine(), "").Replace(@"\","/");

                if (resteChemin.Equals(""))
                {
                    VariablesGlobales._leLog.Log(new StatusResponse(EStatusResponse.RepertoireInexistant));
                    VariablesGlobales._leLog.Log(new StatusResponse(EStatusResponse.RepertoireParDefautDefini));
                    VariablesGlobales._leLog.Log(new StatusCommand(EStatusCommand.DemandeListDossier));
                    VariablesGlobales._leLog.LogCustom(string.Format("Demande de la liste des dossiers de : {0}", _maConfig.GetUriChaine()), true);

                    lesFtpElements = _monFtp.GetList();

                    VariablesGlobales._leLog.Log(new StatusResponse(EStatusResponse.ListeTrouvee));
                }
                else
                {
                    List<string> larbo = resteChemin.Split(new char[]{'/'}).ToList();

                    VariablesGlobales._leLog.Log(new StatusCommand(EStatusCommand.DemandeChangementRepertoire));

                    if (larbo.Count > 0)
                    {
                        _monFtp.ChangeFolder(resteChemin);
                    }
                    else
                    {
                        _monFtp.ChangeFolder(resteChemin);
                    }

                    VariablesGlobales._leLog.Log(new StatusResponse(EStatusResponse.ChangementRepertoireEffectue));
                    VariablesGlobales._leLog.Log(new StatusCommand(EStatusCommand.DemandeListDossier));
                    VariablesGlobales._leLog.LogCustom(string.Format("Demande de la liste des dossiers de : {0}", resteChemin), true);

                    lesFtpElements = _monFtp.GetList();

                    VariablesGlobales._leLog.Log(new StatusResponse(EStatusResponse.ListeTrouvee));
                }

                VariablesGlobales._leLog.Log(new StatusCommand(EStatusCommand.DemandeFermetureFluxEchange));

                _monFtp.Close();

                VariablesGlobales._leLog.Log(new StatusResponse(EStatusResponse.FermetureDuFluxReussie));
            }

            VariablesGlobales._leLog.Log(new StatusResponse(EStatusResponse.GenerationElementTransferables));

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
            List<ITransfer> lesTranferables = ListFolder(_maConfig.GetUriChaine());
            lesTranferables.AddRange(ListFileFolder(_maConfig.GetUriChaine()));
            return new ElementFolder(_maConfig.GetUriChaine(), lesTranferables);
        }

        private List<ITransfer> ListFileFolder(string cheminDossierServeurFtp)
        {
            List<FtpItem> lesFtpElements = new List<FtpItem>();
            List<ITransfer> lesElements = new List<ITransfer>();

            using (Ftp monFtp = new Ftp())
            {
                monFtp.Connect(_maConfig.Host, _maConfig.Port);  // or ConnectSSL for SSL
                monFtp.Login(_maConfig.Login, _maConfig.MotDePass);

                string resteChemin = MethodesGlobales.GetCheminServerSansRacinne(cheminDossierServeurFtp, _maConfig.GetUriChaine());

                if (!string.IsNullOrEmpty(resteChemin))
                {
                    monFtp.ChangeFolder(resteChemin);
                }


                lesFtpElements = monFtp.GetList();


                monFtp.Close();
            }

            foreach (FtpItem unFtpItem in lesFtpElements)
            {
                if (unFtpItem.IsFile)
                {
                    lesElements.Add(new ElementFile(unFtpItem, Path.Combine(cheminDossierServeurFtp, unFtpItem.Name)));
                }
            }

            return lesElements;
        }

        public string GetPathRootString()
        {
            return _pathRoot;
        }

        List<ITransfer> IClientFtp.ListFileFolder(string unDossier)
        {
            List<FtpItem> lesFtpElements = new List<FtpItem>();
            List<ITransfer> lesElements = new List<ITransfer>();

            using (Ftp monFtp = new Ftp())
            {
                monFtp.Connect(_maConfig.Host, _maConfig.Port);  // or ConnectSSL for SSL
                monFtp.Login(_maConfig.Login, _maConfig.MotDePass);

                string resteChemin = MethodesGlobales.GetCheminServerSansRacinne(unDossier, _maConfig.GetUriChaine());

                if (!string.IsNullOrEmpty(resteChemin))
                {
                    monFtp.ChangeFolder(resteChemin);
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


        public void CreerDossier(string leNmDossierACreer, ElementFolder leDossierDistant)
        {
            using (_monFtp = new Ftp())
            {
                _monFtp.Connect(_maConfig.Host, _maConfig.Port);
                _monFtp.Login(_maConfig.Login, _maConfig.MotDePass);
                string resteChemin = MethodesGlobales.GetCheminServerSansRacinne(leDossierDistant.GetPath(), _maConfig.GetUriChaine());
                _monFtp.ChangeFolder(resteChemin);
                _monFtp.CreateFolder(leNmDossierACreer);
                _monFtp.Close();
            }
        }


        public void UploadDossier(ElementFolder dossierLocal, ElementFolder dossierDistant)
        {
            using (_monFtp = new Ftp())
            {
                _monFtp.Connect(_maConfig.Host, _maConfig.Port);
                _monFtp.Login(_maConfig.Login, _maConfig.MotDePass);
                string resteChemin = MethodesGlobales.GetCheminServerSansRacinne(dossierDistant.GetPath(), _maConfig.GetUriChaine());
                _monFtp.CreateFolder(MethodesGlobales.GetCheminDossierUploadSurServeur(resteChemin, dossierLocal.GetName()));
                LocalSearchOptions uneLocalSearchOption = new LocalSearchOptions("*", true);
                _monFtp.UploadFiles(MethodesGlobales.GetCheminDossierUploadSurServeur(resteChemin, dossierLocal.GetName()), dossierLocal.GetPath(), uneLocalSearchOption);
                _monFtp.Close();
            }
        }


        public Ftp GetModuleFtp()
        {
            return _monFtp;
        }


        public void DownloadDossier(ElementFolder dossierDistant, ElementFolder dossierLocal)
        {
            using (_monFtp = new Ftp())
            {
                _monFtp.Connect(_maConfig.Host, _maConfig.Port);
                _monFtp.Login(_maConfig.Login, _maConfig.MotDePass);

                string resteChemin = MethodesGlobales.GetCheminServerSansRacinne(dossierDistant.GetPath(), _maConfig.GetUriChaine());
                string cheminDossierADowloaded = MethodesGlobales.GetCheminDossierLocalDownload(dossierLocal.GetPath(), dossierDistant.GetName());

                Directory.CreateDirectory(cheminDossierADowloaded);

                _monFtp.DownloadFiles(resteChemin, cheminDossierADowloaded, new RemoteSearchOptions("*", true));

                _monFtp.Close();
            }
        }


        public void Supprimer(ITransfer transfer)
        {
            using (_monFtp = new Ftp())
            {
                _monFtp.Connect(_maConfig.Host, _maConfig.Port);
                _monFtp.Login(_maConfig.Login, _maConfig.MotDePass);

                string resteChemin = MethodesGlobales.GetCheminServerSansRacinne(transfer.GetPath(), _maConfig.GetUriChaine());

                if (string.IsNullOrEmpty(resteChemin))
                {
                    
                    MessageBox.Show("Vous ne pouvez supprimer le répertoire racinne !");
                }
                else
                {
                    if (transfer.EstUnDossier())
                    {
                        _monFtp.DeleteFolder(resteChemin);
                    }
                    else
                    {
                        _monFtp.DeleteFile(resteChemin);
                    }
                }

                _monFtp.Close();
            }
        }
    }
}
