using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_FTP.FTP_Client.Enums
{
    public enum EStatusResponse : int
    {
        ReponseCustom = 1,
        DecnnexionReussie = 2,
        ConnexionEtablie = 3,
        ConnexionPerdue = 4,
        TelechargementEncours = 5,
        EtablissementConnexionEncours = 6,
        ConnexionEnCours = 7,
        ConnexionFermee = 8,
        AReussieAjoindreHote,
        AuthentificationReussie,
        ListeTrouvee,
        RepertoireInexistant,
        RepertoireParDefaut,
        RepertoireParDefautDefini,
        ChangementRepertoireEffectue,
        FermetureDuFlux,
        FermetureDuFluxReussie,
        GenerationElementTransferables
    }
}
