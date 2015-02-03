﻿using API_FTP.FTP_Client;
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

        public frm_clientFtp()
        {
            InitializeComponent();
            //PopulateTreeView(treeViewLocal, @"C:\");
            _mesGestionnaires = new Dictionary<string, IManager>();
            _mesGestionnaires.Add("$LocalManager", ManagerFactory.Fabriquer("$LocalManager", lst_messagesLog));
            _maConfigCourrante = new Configuration();
            ITransfer unTransfert = new ElementFolder(@"d:\");
            TreeNode rootNode = new TreeNode(unTransfert.GetName());
            rootNode.Tag = unTransfert;

            List<ITransfer> mesTranferables = _mesGestionnaires["$LocalManager"].ListerContenu(unTransfert);

            ExtraireNode(rootNode, mesTranferables, trv_arboLocal);
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
                    unNoeudAMettreAJour.Nodes.Clear();
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
                _mesGestionnaires["$DistantManager"] = ManagerFactory.Fabriquer("$DistantManager", lst_messagesLog, (Configuration)_maConfigCourrante.Clone());
            }
            else
            {
                _mesGestionnaires.Add("$DistantManager", ManagerFactory.Fabriquer("$DistantManager", lst_messagesLog, (Configuration)_maConfigCourrante.Clone()));
            }

            List<ITransfer> desTransfertDistant = ((DistantManager)_mesGestionnaires["$DistantManager"]).ListerContenu();

            TreeNode rootNode = new TreeNode(_maConfigCourrante.GetUriChaine());
            rootNode.Tag = desTransfertDistant.First();
            trv_arboDistant.Nodes.Clear();
            ExtraireNode(rootNode, desTransfertDistant, trv_arboDistant);
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
            AfficherTreeNode(trv_arboLocal, lst_itranfertLocal);
        }

        private void AfficherTreeNode(TreeView uneTreeView, ListView uneListeRecepteur)
        {
            ITransfer unTranferable = null;

            if (!string.IsNullOrEmpty(uneTreeView.SelectedNode.Text))
            {
                unTranferable = (ITransfer)uneListeRecepteur.SelectedItems[0].Tag;
                List<ITransfer> lesTranferables = new List<ITransfer>();

                if (unTranferable.EstUnDossier())
                {
                    TreeNode leNodeSelectionne = new TreeNode();
                    leNodeSelectionne.Text = unTranferable.GetName();
                    leNodeSelectionne.ImageIndex = 0;
                    leNodeSelectionne.Tag = unTranferable;
                    int indiceTrouve = RechercherTreeNode(leNodeSelectionne, uneTreeView);

                    if(uneTreeView.Name.Equals("lst_itranfertLocal"))
                    {
                        lesTranferables = _mesGestionnaires["$LocalManager"].ListerContenu(unTranferable);
                    }
                    else
                    {
                        lesTranferables = _mesGestionnaires["$DistantManager"].ListerContenu(unTranferable);
                        leNodeSelectionne.Nodes.Clear();
                        ExtraireNode(lesTranferables, leNodeSelectionne);
                    }

                    uneTreeView.SelectedNode = uneTreeView.SelectedNode.Nodes[indiceTrouve];
                    uneTreeView.Select();
                    uneTreeView.SelectedNode.Expand();

                }
            }




        }

        private int RechercherTreeNode(TreeNode leNodeRechercher, TreeView unTreeView)
        {
            bool aTrouve = false;
            int iSousArbo = 0;
            int indiceTrouve = -1;

            while (!aTrouve && iSousArbo < unTreeView.SelectedNode.Nodes.Count)
            {
                if (unTreeView.SelectedNode.Nodes[iSousArbo].Text.Equals(leNodeRechercher.Text))
                {
                    indiceTrouve = iSousArbo;
                    aTrouve = true;
                }

                iSousArbo++;
            }

            return indiceTrouve;
        }

        private void trv_arboDistant_AfterSelect(object sender, TreeViewEventArgs e)
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
            AfficherTreeNode(trv_arboDistant, lst_itransfertDistant);
        }

        private void btn_recuperer_Click(object sender, EventArgs e)
        {
            if (_mesGestionnaires.ContainsKey("$DistantManager"))
            {
                DistantManager monManager = (DistantManager)_mesGestionnaires["$DistantManager"];

                if (!string.IsNullOrEmpty(trv_arboLocal.SelectedNode.Text))
                {
                    monManager.Download((ElementFolder)trv_arboDistant.SelectedNode.Tag, (ElementFile)lst_itransfertDistant.SelectedItems[0].Tag, (ElementFolder)trv_arboLocal.SelectedNode.Tag);
                    trv_arboLocal.SelectedNode.Nodes.Clear();
                    ExtraireNode(_mesGestionnaires["$LocalManager"].ListerContenu((ITransfer)trv_arboLocal.SelectedNode.Tag), trv_arboLocal.SelectedNode);
                    trv_arboLocal_AfterSelect(sender, e);
                }
                else
                {
                    MessageBox.Show("merci de sélectionner le dossier de destination");
                }
                
            }
        }

        private void btn_envoyer_Click(object sender, EventArgs e)
        {
            if (_mesGestionnaires.ContainsKey("$DistantManager"))
            {
                DistantManager monManager = (DistantManager)_mesGestionnaires["$DistantManager"];

                if (!string.IsNullOrEmpty(trv_arboLocal.SelectedNode.Text))
                {
                    monManager.Upload((ElementFolder)trv_arboDistant.SelectedNode.Tag, (ElementFile)lst_itransfertDistant.SelectedItems[0].Tag, (ElementFolder)trv_arboLocal.SelectedNode.Tag);
                }
                else
                {
                    MessageBox.Show("merci de sélectionner le dossier de destination");
                }
            }
        }

        /* private void deconnexionButton_Click(object sender, EventArgs e)
        {
            connexionButton.Show();
        } */
    }
}
