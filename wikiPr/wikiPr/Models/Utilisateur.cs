using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using wikiPr.Models.Views;

namespace wikiPr.Models {
    public class Utilisateur {
       // public static string[] Langues = { "fr-CA", "en-CA" };

        public static List<string> Langues = new List<string>();
        
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Indiquez votre prenom")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Indiquez votre nom de famille")]
        public string NomFamille { get; set; }

       // [Uniqueness("Courriel")]
        [Required(ErrorMessage = "Indiquez votre courriel")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Adresse Courriel")]
        public string Courriel { get; set; }

        [Required(ErrorMessage = "Indiquez le mot de passe"), StringLength(50, MinimumLength=6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passse")]
        public string MDP { get; set; }

        //[Required(ErrorMessage = "Confirmez le mot de passe!"), StringLength(50, MinimumLength = 6)]
        //[DataType(DataType.Password)]
        //[Display(Name = "Confirmez le mot de passse:")]
        //[Compare("MDP", ErrorMessage = "Le mot de passe et la confirmation ne correspondent pas.")]
        //public string Confirmation { get; set; }

        [Required(ErrorMessage = "Choisissez la langue")]
        public string Langue { get; set; }

        //14. Pour faciliter la conversion entre un UtilisateurInscription et un Utilisateur, 
        //ajoutez un constructeur 
        //dans la classe Utilisateur qui prend en argument le modèle de présentation.

        public Utilisateur() { }

        public Utilisateur(UtilisateurInscription ui) {
            this.Prenom = ui.Prenom;
            this.NomFamille = ui.NomFamille;
            this.Courriel = ui.Courriel;
            this.MDP = ui.MDP;
            this.Langue = ui.Langue;
        }

        public Utilisateur(UtilisateurProfil up) {
            this.Prenom = up.Prenom;
            this.NomFamille = up.NomFamille;
            this.Langue = up.Langue;
        }

        public Utilisateur(UtilisateurMP ump) {
            this.Courriel = ump.Courriel;
            this.MDP = ump.MDP1;//????
        }

       


        }
}