using API_FTP.FTP_Client.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_FTP.FTP_Client.Classes
{
    /// <summary>
    /// Class renseignant sur la structure d'un statut de type commande (StatusCommand)
    /// </summary>
    class StatusCommand : Status
    {
        /// <summary>
        /// Renseigne sur le statut de la commande
        /// </summary>
        protected EStatusCommand _status;

        /// <summary>
        /// Constructeur du statut command
        /// </summary>
        /// <param name="aStatus">l'enum statut commande que vous voulez ajouter</param>
        public StatusCommand(EStatusCommand aStatus)
        {
            _status = aStatus;
            InitialiserCommentaire(string.Empty);
        }

        /// <summary>
        /// Constructeur du statut command avec un commenaire personalisée
        /// </summary>
        /// <param name="commentairePersonalisee">le commentaire personnalisé</param>
        public StatusCommand(String commentairePersonalisee)
        {
            _status = EStatusCommand.DemandePersonalisee;
            InitialiserCommentaire(commentairePersonalisee);
        }

        /// <summary>
        /// Converti le statut en valeur int
        /// </summary>
        public int GetStatusCodeConvertInt
        {
            get { return (int)_status; }
        }

        /// <summary>
        /// Retourne le statut commande
        /// </summary>
        public EStatusCommand GetStatus
        {
            get { return _status; }
        }

        /// <summary>
        /// Retourne le code statut réponse converti en int
        /// </summary>
        /// <returns>int</returns>
        public new int GetStatusCode()
        {
            return GetStatusCodeConvertInt;
        }

        /// <summary>
        /// Retourne la commentaire détaillé de la commande
        /// </summary>
        /// <returns>String</returns>
        public new String GetStatusDetail()
        {
            return Commentaire;
        }

        /// <summary>
        /// Initialise l'attribut commentaire de la classe abtraite
        /// </summary>
        /// <param name="commentairePersonalisee">commentaire personnalisée</param>
        protected void InitialiserCommentaire(string commentairePersonalisee)
        {
            switch (_status)
            {
                case EStatusCommand.DemandeConnexion:
                    Commentaire = "Connexion établie avec le serveur";
                    break;
                case EStatusCommand.DemandeDeconnexion:
                    Commentaire = "Connexion perdu avec le serveur";
                    break;
                case EStatusCommand.DemandePersonalisee:
                    Commentaire = commentairePersonalisee;
                    break;
                default:
                    Commentaire = "";
                    break;
            }
        }

        /// <summary>
        /// Returne ou modifie le commentaire
        /// </summary>
        /// <example>
        ///     Le commentaire aura le formalisme suivant :
        ///         Commande (Code [N°Code]) : [message]
        ///         
        ///         résultat d'une commande de type "DemandeConnexion"
        ///         Commande (Code 1) : "Demande de connexion"
        /// </example>
        protected String Commentaire
        {
            get { return string.Format("Commande (Code {0}) : {1}", (int)_status ,_comment); }
            set { _comment = value; }
        }
    }
}
