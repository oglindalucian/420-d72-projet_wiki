using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using wikiPr.Models.Views;
using wikiPr.Ressource;


namespace wikiPr.Models {
    public class Utilisateur {
       // public static string[] Langues = { "fr-CA", "en-CA" };

        //public static List<string> Langues = new List<string>();

       // public static
          //  enum Langues { fr, en, es };
        enum Langues : byte { fr, en, es };
        
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Indiquez votre prenom")]
       // [Display(Name = "Prenom", ResourceType = typeof(ResourceView))]
        [Display(Name = "Prenom")]
       // [Required]
       
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Indiquez votre nom de famille")]
       // [Display(Name = "Nom de famille", ResourceType = typeof(ResourceView))]
        [Display(Name = "Nom de famille")]
        
      //  [Required]
        public string NomFamille { get; set; }

        [Required(ErrorMessage = "Indiquez votre courriel")]
        // [Uniqueness("Courriel")]
      //  [Display(Name = "Adresse courriel", ResourceType = typeof(ResourceView))]
        [Display(Name = "Adresse courriel")]   
       
        [DataType(DataType.EmailAddress)]
       // [Required]
        public string Courriel { get; set; }

      //  [Required]
        [Required(ErrorMessage = "Indiquez le mot de passe"), StringLength(50, MinimumLength=6)]
        [DataType(DataType.Password)]
       // [Display(Name = "Mot de passe", ResourceType = typeof(ResourceView))]
        [Display(Name = "Mot de passse")]
        public string MDP { get; set; }

       // [Required(ErrorMessage = "Confirmez le mot de passe!"), StringLength(50, MinimumLength = 6)]
        //[Required]
        //[DataType(DataType.Password)]
        //// [Display(Name = "Confirmez le mot de passse:")]
        ////[Compare("MDP", ErrorMessage = "Le mot de passe et la confirmation ne correspondent pas.")]
        //[Compare("MDP")]
        //public string Confirmation { get; set; }

        //[Required]
        [Required(ErrorMessage = "Choisissez la langue")]
       // [Display(Name = "Langue", ResourceType = typeof(ResourceView))]
        [Display(Name = "Langue")]
        public string Langue { get; set; }

       
        public Utilisateur() { }
        
        public Utilisateur(int id) {
            this.Id = id;
        }

        public Utilisateur (int id, string langue) {
            this.Id = id;
            this.Langue = langue;
        }

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

       public static Utilisateur defaut = new Utilisateur(-1, "fr");


        }
}