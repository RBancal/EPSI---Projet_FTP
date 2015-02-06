using API_FTP.FTP_Client;
using API_FTP.FTP_Client.Classes;
using API_FTP.FTP_Client.Factory;
using API_FTP.FTP_Client.Interfaces;
using Limilabs.FTP.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class frm_clientFtp : Form
    {
        private IDictionary<string, IManager> _mesGestionnaires;
        private Configuration _maConfigCourrante;
        private IDictionary<string, BackgroundWorker> _mesBackgroundworkers;
        private BackgroundWorker _monBckGroundWorkerPrincipal;

        public frm_clientFtp()
        {
            InitializeComponent();
            //PopulateTreeView(treeViewLocal, @"C:\");
            _mesGestionnaires = new Dictionary<string, IManager>();
            _mesGestionnaires.Add("$LocalManager", ManagerFactory.Fabriquer("$LocalManager", _maConfigCourrante));
            VariablesGlobales._leLog = new LogFtp();
            VariablesGlobales._leLog.DefinirElementLogable(lst_messagesLog);
            _maConfigCourrante = new Configuration();
            ITransfer unTransfert = new ElementFolder(@"d:\");
            TreeNode rootNode = new TreeNode();
            rootNode.Name = unTransfert.GetName();
            rootNode.Text = unTransfert.GetName();
            rootNode.Tag = unTransfert;

            List<ITransfer> mesTranferables = _mesGestionnaires["$LocalManager"].ListerContenu(unTransfert);

            ExtraireNode(mesTranferables, rootNode);
            trv_arboLocal.Nodes.Add(rootNode);
        }

        private void ExtraireNode(List<ITransfer> mesTranferables, TreeNode unNoeudAMettreAJour)
        {
            foreach (ITransfer item in mesTranferables)
            {
                TreeNode unNoeudEnfant = new TreeNode(item.GetName());
                unNoeudEnfant.Tag = item;
                

                ElementFolder unFolder = null;

                if (item.EstUnDossier())
                {
                    unFolder = (ElementFolder)item;
                    ExtraireNode(unFolder.ListerContenu(), unNoeudEnfant);
                    unNoeudAMettreAJour.Nodes.Add(unNoeudEnfant);
                }
            }
        }

        private void ExtraireNode(TreeNode unNoeuSource, List<ITransfer> mesTranferables, TreeNode unNoeudParent)
        {
            foreach (ITransfer item in mesTranferables)
            {
                TreeNode unNoeudEnfant = new TreeNode(item.GetName());
                unNoeudEnfant.Tag = item;

                ElementFolder unFolder = null;

                if (item.EstUnDossier())
                {
                    unFolder = (ElementFolder)item;
                    ExtraireNode(unNoeudEnfant, unFolder.ListerContenu(), unNoeuSource);
                }
                else
                {
                    unNoeuSource.Nodes.Add(unNoeudEnfant);
                }
            }

            unNoeudParent.Nodes.Add(unNoeuSource);
        }

        private void ExtraireNode(TreeNode unNoeuSource, List<ITransfer> mesTranferables, TreeView unTreeViewParent)
        {
            foreach (ITransfer item in mesTranferables)
            {
                TreeNode unNoeudEnfant = new TreeNode(item.GetName());
                unNoeudEnfant.Tag = item;

                ElementFolder unFolder = null;

                if (item.EstUnDossier())
	            {
		            unFolder = (ElementFolder) item;
                    ExtraireNode(unFolder.ListerContenu(), unNoeudEnfant);
                    unNoeuSource.Nodes.Add(unNoeudEnfant);
	            }
            }

            unTreeViewParent.Nodes.Add(unNoeuSource);
        }

        private void PopulateTreeView(TreeView treeView ,string path)
        {
            TreeNode rootNode;

            DirectoryInfo info = new DirectoryInfo(path);
            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                GetDirectories(info.GetDirectories(), rootNode);
                treeView.Nodes.Add(rootNode);
            }
            //FileInfo infoF = new FileInfo("toto");
            //int size = (int) infoF.Length;
        }

        private void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs)
            {
                try
                {
                    aNode = new TreeNode(subDir.Name, 0, 0);
                    aNode.Tag = subDir;
                    aNode.ImageKey = "folder";
                    nodeToAddTo.Nodes.Add(aNode);

                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
                catch (InvalidOperationException)
                {
                    continue;
                }
                catch (NullReferenceException)
                {
                    continue;
                }
            }
        }

        private void connexionButton_Click(object sender, EventArgs e)
        {
            string login = loginTextBox.Text;
            string password = passwordTextBox.Text;
            string address = serverTextBox.Text;
            int port = int.Parse(portTextBox.Text);

            _maConfigCourrante.MotDePass = password;
            _maConfigCourrante.Login = login;
            _maConfigCourrante.Port = port;
            _maConfigCourrante.Host = serverTextBox.Text;

            if (_mesGestionnaires.ContainsKey("$DistantManager"))
            {
                _mesGestionnaires["$DistantManager"] = ManagerFactory.Fabriquer("$DistantManager", (Configuration)_maConfigCourrante);
            }
            else
            {
                _mesGestionnaires.Add("$DistantManager", ManagerFactory.Fabriquer("$DistantManager", (Configuration)_maConfigCourrante));
                DistantManager monDistantManage = (DistantManager)_mesGestionnaires["$DistantManager"];
            }

            ITransfer unDossierRoot = new ElementFolder(_maConfigCourrante.GetUriChaine(), ((DistantManager)_mesGestionnaires["$DistantManager"]).ListerContenu());

            TreeNode rootNode = new TreeNode();
            rootNode.Text = _maConfigCourrante.GetUriChaine();
            rootNode.Tag = unDossierRoot;
            trv_arboDistant.Nodes.Clear();
            ExtraireNode(rootNode, ((ElementFolder)unDossierRoot).ListerContenu(), trv_arboDistant);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ListerContenuLocal(object sender, EventArgs e)
        {
            ITransfer unTransferable = (ITransfer)trv_arboLocal.SelectedNode.Tag;
            ElementFolder unDossier = null;

            if (unTransferable.EstUnDossier())
            {
                unDossier = (ElementFolder)unTransferable;
                lst_itranfertLocal.Items.Clear();

                foreach (ITransfer item in unDossier.ListerContenu())
                {
                    ListViewItem uneListItem = new ListViewItem();
                    uneListItem.Text = item.GetName();
                    uneListItem.Tag = item;

                    if (item.EstUnDossier())
                    {
                        uneListItem.ImageIndex = 0;
                    }
                    else
                    {
                        uneListItem.ImageIndex = 1;
                    }

                    lst_itranfertLocal.Items.Add(uneListItem);
                }
            }
        }

        private void trv_arboLocal_AfterSelect(object sender, EventArgs e)
        {
            ListerContenuLocal(sender, e);
        }

        private void lst_itranfertLocal_DoubleClick(object sender, EventArgs e)
        {
            AfficherTreeNode(trv_arboLocal.SelectedNode, lst_itranfertLocal);
        }

        private void AfficherTreeNode(TreeNode uneTreeNode, ListView uneListeRecepteur, bool actionLocal = true)
        {
            ITransfer unTranferable = null;

            if (!string.IsNullOrEmpty(uneTreeNode.Text))
            {
                unTranferable = (ITransfer)uneListeRecepteur.SelectedItems[0].Tag;
                List<ITransfer> lesTranferables = new List<ITransfer>();

                if (unTranferable.EstUnDossier())
                {
                    TreeNode leNodeSelectionne = new TreeNode();
                    leNodeSelectionne.Text = unTranferable.GetName();
                    leNodeSelectionne.Name = unTranferable.GetName();
                    leNodeSelectionne.ImageIndex = 0;
                    leNodeSelectionne.Tag = unTranferable;
                    int indiceTrouve = RechercherTreeNode(leNodeSelectionne, uneTreeNode);
                    bool managerExiste = false;
                    
                    if (actionLocal)
                    {
                        if (_mesGestionnaires.ContainsKey("$LocalManager"))
                        {
                            lesTranferables = _mesGestionnaires["$LocalManager"].ListerContenu(unTranferable);
                            leNodeSelectionne.Nodes.Clear();
                            ExtraireNode(lesTranferables, leNodeSelectionne);
                            managerExiste = true;
                        }
                        else
                        {
                            MessageBox.Show("Le gestionnaire de fichier local n'est pas présent dans le gestionnaire !");
                        }
                    }
                    else
                    {
                        if (_mesGestionnaires.ContainsKey("$DistantManager"))
                        {
                            lesTranferables = _mesGestionnaires["$DistantManager"].ListerContenu(unTranferable);
                            leNodeSelectionne.Nodes.Clear();
                            ExtraireNode(lesTranferables, leNodeSelectionne);
                            managerExiste = true;
                        }
                        else
                        {
                            MessageBox.Show("La connexion au serveur ftp n'est pas configurée !");
                        }
                    }

                    if (managerExiste)
                    {
                        uneTreeNode = uneTreeNode.Nodes[indiceTrouve];

                        if (actionLocal)
                        {
                            trv_arboLocal.Select();
                            trv_arboLocal.SelectedNode = uneTreeNode;
                        }
                        else
                        {
                            trv_arboDistant.Select();
                            trv_arboDistant.SelectedNode = uneTreeNode;
                        }

                        uneTreeNode.Expand();   
                    }
                }
            }




        }

        private int RechercherTreeNode(TreeNode leNodeRechercher, TreeNode unTreeNode)
        {
            bool aTrouve = false;
            int iSousArbo = 0;
            int indiceTrouve = -1;

            while (!aTrouve && iSousArbo < unTreeNode.Nodes.Count)
            {
                if (unTreeNode.Nodes[iSousArbo].Text.Equals(leNodeRechercher.Text))
                {
                    indiceTrouve = iSousArbo;
                    aTrouve = true;
                }

                iSousArbo++;
            }

            return indiceTrouve;
        }

        private void trv_arboDistant_AfterSelect(object sender, EventArgs e)
        {
            ListerContenuDistant(sender, e);
        }

        private void ListerContenuDistant(object sender, EventArgs e)
        {
            ITransfer unTransferable = (ITransfer)trv_arboDistant.SelectedNode.Tag;
            ElementFolder unDossier = null;

            if (unTransferable.EstUnDossier())
            {
                unDossier = (ElementFolder)unTransferable;
                lst_itransfertDistant.Items.Clear();

                List<ITransfer> desTransfertDistant = ((DistantManager)_mesGestionnaires["$DistantManager"]).ListerContenu(unDossier);
                trv_arboDistant.SelectedNode.Nodes.Clear();
                ExtraireNode(desTransfertDistant, trv_arboDistant.SelectedNode);

                foreach (ITransfer item in desTransfertDistant)
                {
                    ListViewItem uneListItem = new ListViewItem();
                    uneListItem.Text = item.GetName();
                    uneListItem.Tag = item;

                    if (item.EstUnDossier())
                    {
                        uneListItem.ImageIndex = 0;
                    }
                    else
                    {
                        uneListItem.ImageIndex = 1;
                    }

                    lst_itransfertDistant.Items.Add(uneListItem);
                }
            }
            else
            {
                lst_itransfertDistant.Items.Clear();
            }
        }

        private void lst_itransfertDistant_DoubleClick(object sender, EventArgs e)
        {
            AfficherTreeNode(trv_arboDistant.SelectedNode, lst_itransfertDistant, false);
        }

        private void btn_recuperer_Click(object sender, EventArgs e)
        {
            DownloadITranfert(sender, e, (ITransfer)lst_itransfertDistant.SelectedItems[0].Tag);
        }

        private void DownloadITranfert(object sender, EventArgs e, ITransfer unDossierOuFichier)
        {
            if (_mesGestionnaires.ContainsKey("$DistantManager"))
            {
                DistantManager monManager = (DistantManager)_mesGestionnaires["$DistantManager"];


                if (!string.IsNullOrEmpty(trv_arboLocal.SelectedNode.Text))
                {
                    if (!string.IsNullOrEmpty(lst_itransfertDistant.SelectedItems[0].Text))
                    {
                        if (!string.IsNullOrEmpty(trv_arboDistant.SelectedNode.Text))
                        {
                            ITransfer unTranferable = (ITransfer)lst_itransfertDistant.SelectedItems[0].Tag;
                            ElementFolder unElementFolder = unElementFolder = (ElementFolder)trv_arboLocal.SelectedNode.Tag;

                            if (unTranferable.EstUnDossier())
                            {
                                DownloadDossier(sender, e, monManager, unTranferable);
                            }
                            else
                            {
                                DownloadFichier(monManager, unTranferable);
                            }

                            trv_arboLocal.SelectedNode.Nodes.Clear();

                            unElementFolder.Rafraichir();
                            ExtraireNode(_mesGestionnaires["$LocalManager"].ListerContenu(unElementFolder), trv_arboLocal.SelectedNode);
                            
                            LocalManager monLocalManager = (LocalManager)_mesGestionnaires["$LocalManager"];
                            
                            trv_arboLocal_AfterSelect(sender, e);

                            trv_arboDistant.SelectedNode.Nodes.Clear();
                            ExtraireNode(_mesGestionnaires["$DistantManager"].ListerContenu((ITransfer)trv_arboDistant.SelectedNode.Tag), trv_arboDistant.SelectedNode);
                            trv_arboDistant_AfterSelect(sender, e);
                        }
                        else
                        {

                        }
                    }
                }
            }
        }

        private void DownloadFichier(DistantManager monManager, ITransfer unTranferable)
        {
            monManager.Download((ElementFolder)trv_arboDistant.SelectedNode.Tag, (ElementFile)unTranferable, (ElementFolder)trv_arboLocal.SelectedNode.Tag);
        }

        private void DownloadDossier(object sender, EventArgs e, DistantManager monManager, ITransfer unTranferable)
        {
            monManager.DownloadDossier((ElementFolder)lst_itransfertDistant.SelectedItems[0].Tag, (ElementFolder)trv_arboLocal.SelectedNode.Tag);
        }

        private void btn_envoyer_Click(object sender, EventArgs e)
        {
            UploadITranfert(sender, e, (ITransfer)lst_itranfertLocal.SelectedItems[0].Tag);
        }

        private void UploadITranfert(object sender, EventArgs e, ITransfer unDossierOuFichier)
        {
            if (_mesGestionnaires.ContainsKey("$DistantManager"))
            {
                DistantManager monManager = (DistantManager)_mesGestionnaires["$DistantManager"];

                if (!string.IsNullOrEmpty(trv_arboLocal.SelectedNode.Text))
                {
                    if (!string.IsNullOrEmpty(lst_itranfertLocal.SelectedItems[0].Text))
                    {
                        ITransfer unTranferable = (ITransfer)lst_itranfertLocal.SelectedItems[0].Tag;

                        if (unTranferable.EstUnDossier())
                        {
                            UploadDossier(sender, e, monManager, unTranferable);
                        }
                        else
                        {
                            UploadFichier(monManager, unTranferable);
                        }

                        trv_arboDistant.SelectedNode.Nodes.Clear();
                        ExtraireNode(_mesGestionnaires["$DistantManager"].ListerContenu((ITransfer)trv_arboDistant.SelectedNode.Tag), trv_arboDistant.SelectedNode);
                        trv_arboDistant_AfterSelect(sender, e);
                    }
                    else
                    {
                        VariablesGlobales._leLog.LogCustom("Vous n'avez pas sélectionné de dossier local. Veuillez un sélectionner un pour l'upload.");
                    }
                }
                else
                {
                    VariablesGlobales._leLog.LogCustom("Vous n'avez as sélectionné un élement de l'arborescence locale. Veuillez en sélectionner une.");
                }

            }
            else
            {
                VariablesGlobales._leLog.LogCustom("merci de sélectionner le dossier de destination");
            }
        }

        private void UploadFichier(DistantManager monManager, ITransfer unTranferable)
        {
            monManager.Upload((ElementFolder)trv_arboLocal.SelectedNode.Tag, (ElementFile)unTranferable, (ElementFolder)trv_arboDistant.SelectedNode.Tag);
        }

        private void UploadDossier(object sender, EventArgs e, DistantManager monManager, ITransfer unTranferable)
        {
            ElementFolder unFolderSelectionne = (ElementFolder)unTranferable;

            monManager.UploadDossier((ElementFolder)lst_itranfertLocal.SelectedItems[0].Tag, (ElementFolder)trv_arboDistant.SelectedNode.Tag);
            
        }

        private void lst_itranfertLocal_ContextMenuStripChanged(object sender, EventArgs e)
        {
            if (lst_itranfertLocal.SelectedIndices != null)
            {
                cms_localAction.Enabled = false;
            }
        }

        private void lst_itranfertLocal_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lst_itranfertLocal.Items.Count>0)
                {
                    if (lst_itranfertLocal.SelectedIndices.Count>0)
                    {
                        cms_localAction.Enabled = true;
                    }
                }
                else
                {
                    cms_localAction.Enabled = false;
                }
            }
        }

        private void tsmi_supprimer_Click(object sender, EventArgs e)
        {
            if (lst_itranfertLocal.FocusedItem.Tag != null)
            {
                _mesGestionnaires["$LocalManager"].Supprimer((ITransfer)lst_itranfertLocal.FocusedItem.Tag);
                ElementFolder unFolder = (ElementFolder)trv_arboLocal.SelectedNode.Tag;
                //unFolder.Rafraichir();

                //trv_arboLocal.SelectedNode.Nodes.Clear();
                //ExtraireNode(_mesGestionnaires["$LocalManager"].ListerContenu(unFolder), trv_arboLocal.SelectedNode);
            }
        }

        private void lst_messagesLog_ControlAdded(object sender, ControlEventArgs e)
        {
            lst_messagesLog.Select();
        }

        private void cms_localAction_Opening(object sender, CancelEventArgs e)
        {

        }

        /* private void deconnexionButton_Click(object sender, EventArgs e)
        {
            connexionButton.Show();
        } */
    }
}
