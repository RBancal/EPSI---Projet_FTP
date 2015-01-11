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
    class StatusResponse : Status
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
                default:
                    break;
            }
        }

        /// <summary>
        /// Returne ou modifie le commentaire
        /// </summary>
        protected String Commentaire
        {
            get { return string.Format("Réponse : {0}", _comment); }
            set { _comment = value; }
        }
    }
}
