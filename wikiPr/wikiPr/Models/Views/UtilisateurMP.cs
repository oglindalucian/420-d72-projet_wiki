using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wikiPr.Models.Views {
    public class UtilisateurMP {

        [Required(ErrorMessage = "Indiquez votre courriel")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Adresse Courriel")]
        public string Courriel { get; set; }

        [Required(ErrorMessage = "Indiquez le mot de passe ancien"), StringLength(50, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passse")]
        public string MDP1 { get; set; }

        [Required(ErrorMessage = "Indiquez le mot de passe nouveau"), StringLength(50, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passse")]
        public string MDP2 { get; set; }


        public UtilisateurMP(string courriel, string mdp) {
            this.Courriel = courriel;
            this.MDP1 = mdp;
        }
    }
}