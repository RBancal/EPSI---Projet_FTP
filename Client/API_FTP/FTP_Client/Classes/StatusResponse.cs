using API_FTP.FTP_Client.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_FTP.FTP_Client.Classes
{
    /// <summary>
    /// Class renseignant sur la structure d'un statut de type Réponse (StatusResponse)
    /// </summary>
    public class StatusResponse : Status
    {
        /// <summary>
        /// Renseigne sur le statut
        /// </summary>
        protected EStatusResponse _status;

        /// <summary>
        /// Constructeur de la class
        /// </summary>
        /// <param name="unStatut">l'énum statut associé au statut réponse</param>
        public StatusResponse(EStatusResponse unStatut)
        {
            _status = unStatut;
            InitialiserCommentaire(string.Empty);
        }

        /// <summary>
        /// Constructeur de la class avec commentaire personnalisé
        /// </summary>
        /// <param name="commentairePersonalise">l'énum statut associé au statut réponse</param>
        public StatusResponse(string commentairePersonalise)
        {
            _status = EStatusResponse.ReponseCustom;
            InitialiserCommentaire(commentairePersonalise);
        }

        /// <summary>
        /// Converti le statut en valeur int
        /// </summary>
        public int GetStatusCodeConvertInt
        {
            get { return (int)_status; }
        }

        /// <summary>
        /// Retourne le statut
        /// </summary>
        public EStatusResponse GetStatus
        {
            get { return _status; }
        }

        /// <summary>
        /// Retourne le code statut réponse converti en int
        /// </summary>
        /// <returns>int</returns>
        public override int GetStatusCode()
        {
            return GetStatusCodeConvertInt;
        }

        /// <summary>
        /// Retourne la commentaire détaillé de la commande
        /// </summary>
        /// <returns>String</returns>
        public override string GetStatusDetail()
        {
            return Commentaire;
        }

        /// <summary>
        /// Initialise l'attribut commentaire de la classe abtraite
        /// </summary>
        /// <param name="commentairePersonalisee">commentaire personnalisée</param>
        protected void InitialiserCommentaire(string commentairePersonalisee = "")
        {
            switch (_status)
            {
                case EStatusResponse.ReponseCustom:
                    Commentaire = commentairePersonalisee;
                    break;
                case EStatusResponse.DecnnexionReussie:
                    Commentaire = "Déconnexion réussie du client FTP";
                    break;
                case EStatusResponse.ConnexionEtablie:
                    Commentaire = "Connexion etblie par le client FTP";
                    break;
                case EStatusResponse.ConnexionPerdue:
                    Commentaire = "Connexion perdu avec le Serveur FTP";
                    break;
                case EStatusResponse.TelechargementEncours:
                    Commentaire = "En cours de téléchargement...";
                    break;
                case EStatusResponse.EtablissementConnexionEncours:
                    Commentaire = "Entablissement de la connexion en cours...";
                    break;
                case EStatusResponse.ConnexionEnCours:
                    Commentaire = "Connexion en cours...";
                    break;
                case EStatusResponse.ConnexionFermee:
                    Commentaire = "Connexion fermée";
                    break;
                case EStatusResponse.AReussieAjoindreHote:
                    Commentaire = "A réussie à joindre le server FTP";
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Returne ou modifie le commentaire
        /// </summary>
        /// <example>
        ///     Le commentaire aura le formalisme suivant :
        ///         Réponse (Code [N°Code]) : [message]
        ///         
        ///         résultat d'une commande de type "RéponseCunstom"
        ///         Commande (Code 1) : " c'est un detail"
        /// </example>
        protected String Commentaire
        {
            get { return string.Format("Réponse (Code {0}): {1}", (int)_status , _comment); }
            set { _comment = value; }
        }

        public override bool EstUnStatutCommand()
        {
            return false;
        }
    }
}
