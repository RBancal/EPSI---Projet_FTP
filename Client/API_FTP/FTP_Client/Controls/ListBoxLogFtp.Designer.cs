namespace API_FTP.FTP_Client.Controls
{
    partial class ListBoxLogFtp
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.lst_messagesLog = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lst_messagesLog
            // 
            this.lst_messagesLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_messagesLog.FormattingEnabled = true;
            this.lst_messagesLog.Location = new System.Drawing.Point(0, 0);
            this.lst_messagesLog.Name = "lst_messagesLog";
            this.lst_messagesLog.Size = new System.Drawing.Size(321, 162);
            this.lst_messagesLog.TabIndex = 0;
            // 
            // PanelLogFtp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lst_messagesLog);
            this.Name = "PanelLogFtp";
            this.Size = new System.Drawing.Size(321, 162);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lst_messagesLog;
    }
}
