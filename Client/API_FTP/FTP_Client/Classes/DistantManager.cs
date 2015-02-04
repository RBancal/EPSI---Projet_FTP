using API_FTP.FTP_Client.Interfaces;
using Limilabs.FTP.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_FTP.FTP_Client.Classes
{
    /// <summary>
    /// Classe 
    /// </summary>
    public class DistantManager : Manager
    {
        protected Configuration _maConfig;
        protected IClientFtp _monClientFtp;

        public DistantManager(Configuration laConfig)
        {
            _maConfig = (Configuration)laConfig.Clone();
            base._pathRoot = _maConfig.GetUriChaine();
            base._lesDossiers = new List<ITransfer>();
            _monClientFtp = new ClientFtpProjectMultithreading(_maConfig);
        }

        public override List<ITransfer> ListerContenu(ITransfer leDossier, bool avecSousRepertoire = false)
        {
            List<ITransfer> lesElementsContenus = new List<ITransfer>();
            _monClientFtp.DefinePathRoot(base._pathRoot);

            if (avecSousRepertoire)
            {

            }
            else
            {
                lesElementsContenus.AddRange(_monClientFtp.ListFolder((ElementFolder)leDossier));
                lesElementsContenus.AddRange(_monClientFtp.ListFileFolder((ElementFolder)leDossier));
            }

            
            return lesElementsContenus;
        }

        public List<ITransfer> ListerContenu(bool avecSousRepertoire = false)
        {
            List<ITransfer> lesElementsContenus = new List<ITransfer>();
            _monClientFtp.DefinePathRoot(base._pathRoot);

            if (avecSousRepertoire)
            {

            }
            else
            {
                
                lesElementsContenus.AddRange(_monClientFtp.ListFolder(base._pathRoot));
                lesElementsContenus.AddRange(_monClientFtp.ListFileFolder(base._pathRoot));
            }


            return lesElementsContenus;
        }

        public override List<ITransfer> ListerContenu(Interfaces.ITransfer leDossier)
        {
            List<ITransfer> lesElementsContenus = new List<ITransfer>();
            lesElementsContenus.AddRange(_monClientFtp.ListFolder(leDossier.GetPath()));
            lesElementsContenus.AddRange(_monClientFtp.ListFileFolder(leDossier.GetPath()));


            return lesElementsContenus;
        }

        public void Download(ElementFolder remoteFolder, ElementFile remoteFile, ElementFolder localFolder)
        {
            _monClientFtp.Download(remoteFolder, remoteFile, localFolder);
        }

        public void Upload(ElementFolder elementFolder1, ElementFile elementFile, ElementFolder elementFolder2)
        {
            _monClientFtp.Upload(elementFolder1, elementFile, elementFolder2);
        }

        public void CreerDossier(string leNmDossierACreer, ElementFolder leDossierDistant)
        {
            _monClientFtp.CreerDossier(leNmDossierACreer, leDossierDistant);
        }

        public void UploadDossier(ElementFolder dossierLocal, ElementFolder dossierDistant)
        {
            _monClientFtp.UploadDossier(dossierLocal, dossierDistant);
        }

        public Ftp GetModuleFtp()
        {
            return _monClientFtp.GetModuleFtp();
        }

        public void DownloadDossier(ElementFolder dossierDistant, ElementFolder dossierLocal)
        {
            _monClientFtp.DownloadDossier(dossierDistant, dossierLocal);
        }

        public override void Supprimer(ITransfer transfer)
        {
            _monClientFtp.Supprimer(transfer);
        }
    }
}
