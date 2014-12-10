namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.loginLabel = new System.Windows.Forms.Label();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.connexionPanel = new System.Windows.Forms.Panel();
            this.sitesButton = new System.Windows.Forms.Button();
            this.connexionButton = new System.Windows.Forms.Button();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.serverLabel = new System.Windows.Forms.Label();
            this.serverTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.deconnexionButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.sendButton = new System.Windows.Forms.Button();
            this.receiveButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.imageListFtp = new System.Windows.Forms.ImageList(this.components);
            this.treeViewLocal = new System.Windows.Forms.TreeView();
            this.treeViewDistant = new System.Windows.Forms.TreeView();
            this.listViewLocal = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.nomLocal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typeLocal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dernModifLocal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nomDistant = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typeDistant = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dernModifDistant = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.connexionPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(123, 17);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(62, 13);
            this.loginLabel.TabIndex = 0;
            this.loginLabel.Text = "Identifiant : ";
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(191, 14);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(100, 20);
            this.loginTextBox.TabIndex = 1;
            // 
            // connexionPanel
            // 
            this.connexionPanel.Controls.Add(this.sitesButton);
            this.connexionPanel.Controls.Add(this.connexionButton);
            this.connexionPanel.Controls.Add(this.portTextBox);
            this.connexionPanel.Controls.Add(this.portLabel);
            this.connexionPanel.Controls.Add(this.serverLabel);
            this.connexionPanel.Controls.Add(this.serverTextBox);
            this.connexionPanel.Controls.Add(this.passwordTextBox);
            this.connexionPanel.Controls.Add(this.passwordLabel);
            this.connexionPanel.Controls.Add(this.loginLabel);
            this.connexionPanel.Controls.Add(this.loginTextBox);
            this.connexionPanel.Controls.Add(this.deconnexionButton);
            this.connexionPanel.Location = new System.Drawing.Point(12, 12);
            this.connexionPanel.Name = "connexionPanel";
            this.connexionPanel.Size = new System.Drawing.Size(972, 48);
            this.connexionPanel.TabIndex = 2;
            // 
            // sitesButton
            // 
            this.sitesButton.Location = new System.Drawing.Point(17, 12);
            this.sitesButton.Name = "sitesButton";
            this.sitesButton.Size = new System.Drawing.Size(75, 23);
            this.sitesButton.TabIndex = 9;
            this.sitesButton.Text = "Sites";
            this.sitesButton.UseVisualStyleBackColor = true;
            // 
            // connexionButton
            // 
            this.connexionButton.Location = new System.Drawing.Point(866, 12);
            this.connexionButton.Name = "connexionButton";
            this.connexionButton.Size = new System.Drawing.Size(87, 23);
            this.connexionButton.TabIndex = 8;
            this.connexionButton.Text = "Connexion";
            this.connexionButton.UseVisualStyleBackColor = true;
            this.connexionButton.Click += new System.EventHandler(this.connexionButton_Click);
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(809, 14);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(36, 20);
            this.portTextBox.TabIndex = 7;
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(768, 17);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(35, 13);
            this.portLabel.TabIndex = 6;
            this.portLabel.Text = "Port : ";
            // 
            // serverLabel
            // 
            this.serverLabel.AutoSize = true;
            this.serverLabel.Location = new System.Drawing.Point(516, 17);
            this.serverLabel.Name = "serverLabel";
            this.serverLabel.Size = new System.Drawing.Size(107, 13);
            this.serverLabel.TabIndex = 5;
            this.serverLabel.Text = "Adresse du serveur : ";
            // 
            // serverTextBox
            // 
            this.serverTextBox.Location = new System.Drawing.Point(629, 14);
            this.serverTextBox.Name = "serverTextBox";
            this.serverTextBox.Size = new System.Drawing.Size(112, 20);
            this.serverTextBox.TabIndex = 4;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(393, 14);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(100, 20);
            this.passwordTextBox.TabIndex = 3;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(307, 17);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(80, 13);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Mot de passe : ";
            // 
            // deconnexionButton
            // 
            this.deconnexionButton.Location = new System.Drawing.Point(866, 12);
            this.deconnexionButton.Name = "deconnexionButton";
            this.deconnexionButton.Size = new System.Drawing.Size(87, 23);
            this.deconnexionButton.TabIndex = 3;
            this.deconnexionButton.Text = "Déconnexion";
            this.deconnexionButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 84);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Location = new System.Drawing.Point(12, 156);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(420, 360);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitContainer2);
            this.panel3.Location = new System.Drawing.Point(564, 156);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(420, 360);
            this.panel3.TabIndex = 5;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(462, 173);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 6;
            this.sendButton.Text = "---->";
            this.sendButton.UseVisualStyleBackColor = true;
            // 
            // receiveButton
            // 
            this.receiveButton.Location = new System.Drawing.Point(461, 295);
            this.receiveButton.Name = "receiveButton";
            this.receiveButton.Size = new System.Drawing.Size(75, 23);
            this.receiveButton.TabIndex = 7;
            this.receiveButton.Text = "<----";
            this.receiveButton.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewLocal);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listViewLocal);
            this.splitContainer1.Size = new System.Drawing.Size(420, 360);
            this.splitContainer1.SplitterDistance = 156;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.treeViewDistant);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listView2);
            this.splitContainer2.Size = new System.Drawing.Size(420, 360);
            this.splitContainer2.SplitterDistance = 156;
            this.splitContainer2.TabIndex = 1;
            // 
            // imageListFtp
            // 
            this.imageListFtp.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListFtp.ImageStream")));
            this.imageListFtp.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListFtp.Images.SetKeyName(0, "ob_4a18d1_dossier.png");
            this.imageListFtp.Images.SetKeyName(1, "icone-fichier.png");
            // 
            // treeViewLocal
            // 
            this.treeViewLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewLocal.ImageIndex = 0;
            this.treeViewLocal.ImageList = this.imageListFtp;
            this.treeViewLocal.Location = new System.Drawing.Point(0, 0);
            this.treeViewLocal.Name = "treeViewLocal";
            this.treeViewLocal.SelectedImageIndex = 0;
            this.treeViewLocal.Size = new System.Drawing.Size(156, 360);
            this.treeViewLocal.TabIndex = 0;
            // 
            // treeViewDistant
            // 
            this.treeViewDistant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewDistant.ImageIndex = 0;
            this.treeViewDistant.ImageList = this.imageListFtp;
            this.treeViewDistant.Location = new System.Drawing.Point(0, 0);
            this.treeViewDistant.Name = "treeViewDistant";
            this.treeViewDistant.SelectedImageIndex = 0;
            this.treeViewDistant.Size = new System.Drawing.Size(156, 360);
            this.treeViewDistant.TabIndex = 1;
            // 
            // listViewLocal
            // 
            this.listViewLocal.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nomLocal,
            this.typeLocal,
            this.dernModifLocal});
            this.listViewLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLocal.Location = new System.Drawing.Point(0, 0);
            this.listViewLocal.Name = "listViewLocal";
            this.listViewLocal.Size = new System.Drawing.Size(260, 360);
            this.listViewLocal.SmallImageList = this.imageListFtp;
            this.listViewLocal.TabIndex = 0;
            this.listViewLocal.UseCompatibleStateImageBehavior = false;
            this.listViewLocal.View = System.Windows.Forms.View.Details;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nomDistant,
            this.typeDistant,
            this.dernModifDistant});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(260, 360);
            this.listView2.SmallImageList = this.imageListFtp;
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // nomLocal
            // 
            this.nomLocal.Text = "Nom";
            this.nomLocal.Width = 53;
            // 
            // typeLocal
            // 
            this.typeLocal.Text = "Type";
            // 
            // dernModifLocal
            // 
            this.dernModifLocal.Text = "Dernière Modification";
            this.dernModifLocal.Width = 163;
            // 
            // nomDistant
            // 
            this.nomDistant.Text = "Nom";
            // 
            // typeDistant
            // 
            this.typeDistant.Text = "Type";
            // 
            // dernModifDistant
            // 
            this.dernModifDistant.Text = "Dernière Modification";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 613);
            this.Controls.Add(this.receiveButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.connexionPanel);
            this.Name = "Form1";
            this.Text = "FTP Client";
            this.connexionPanel.ResumeLayout(false);
            this.connexionPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.Panel connexionPanel;
        private System.Windows.Forms.Button connexionButton;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label serverLabel;
        private System.Windows.Forms.TextBox serverTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Button deconnexionButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button sitesButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button receiveButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeViewLocal;
        private System.Windows.Forms.ImageList imageListFtp;
        private System.Windows.Forms.ListView listViewLocal;
        private System.Windows.Forms.ColumnHeader nomLocal;
        private System.Windows.Forms.ColumnHeader typeLocal;
        private System.Windows.Forms.ColumnHeader dernModifLocal;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView treeViewDistant;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader nomDistant;
        private System.Windows.Forms.ColumnHeader typeDistant;
        private System.Windows.Forms.ColumnHeader dernModifDistant;



    }
}

