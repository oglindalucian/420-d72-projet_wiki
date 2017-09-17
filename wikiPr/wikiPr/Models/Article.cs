using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;

namespace wikiPr.Models {
    public class Article {
        // [Uniqueness("Titre")]
        //   [Unique(ErrorMessage = "This already exist !!")]
        //   [Remote("verifierTitre", "home", ErrorMessage = "Titre Already Exist.")]

      //  [Display(Name = "Titre", ResourceType = typeof(ResourceView))]
        [Required(ErrorMessage = "Le titre est requis ")]
        public string Titre { get; set; }

      //  [Display(Name = "Contenu de l'article", ResourceType = typeof(ResourceView))]
        public string Contenu { get; set; }

     //   [Display(Name = "Dernière date de modification", ResourceType = typeof(ResourceView))]
        public DateTime DateModification { get; set; }

     //   [Display(Name = "Révision", ResourceType = typeof(ResourceView))]
        public int Revision { get; set; }

      //  [Display(Name = "Id du contributeur", ResourceType = typeof(ResourceView))]
        public int IdContributeur { get; set; }

        public Article() {}

        public Article(string titre) {
            this.Titre = titre;
        }

        public static List<Article> lesArticles() {
            string chConnexion = ConfigurationManager.ConnectionStrings["WikiCon"].ConnectionString;
            SqlConnection connexion = new SqlConnection(chConnexion);
            string requete = "dbo.GetTitresArticles";
            SqlCommand commande = new SqlCommand(requete, connexion);
            commande.CommandType = System.Data.CommandType.StoredProcedure;
            List<Article> maListe = new List<Article>();
            try {
                connexion.Open();
                SqlDataReader dr = commande.ExecuteReader();
                while (dr.Read()) {
                    Article a = new Article {
                        Titre = (string)dr["Titre"],
                        Contenu = (string)dr["Contenu"],
                        DateModification = (DateTime)dr["DateModification"],
                        Revision = (int)dr["Revision"],
                        IdContributeur = (int)dr["IdContributeur"]
                    };
                    maListe.Add(a);
                }

                dr.Close();
                return maListe;
            }
            catch (Exception e) {
                string Message = e.Message;
            }
            finally {
                connexion.Close();
            }
            return null;
        }
        

        public static void Add(Article a) {
            string chConnexion = ConfigurationManager.ConnectionStrings["WikiCon"].ConnectionString;
            SqlConnection connexion = new SqlConnection(chConnexion);
            string requete = "INSERT INTO Article (Titre, Contenu, DateModification, Revision, IdContributeur) VALUES ('"
            + a.Titre + "','" + a.Contenu + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," + a.Revision + "," + 1 + ")";
            SqlCommand commande = new SqlCommand(requete, connexion);
            commande.CommandType = System.Data.CommandType.Text;
            try {
                connexion.Open();
                commande.ExecuteNonQuery();
                connexion.Close();
            }
            catch { }
        }

        public static Article Find (string titre) {
            string chConnexion = ConfigurationManager.ConnectionStrings["WikiCon"].ConnectionString;
            SqlConnection connexion = new SqlConnection(chConnexion);
            string requete = "SELECT * FROM Article WHERE Titre = '" + titre + "'";
            SqlCommand commande = new SqlCommand(requete, connexion);
            commande.CommandType = System.Data.CommandType.Text;
            try {
                connexion.Open();
                SqlDataReader dr = commande.ExecuteReader();
                dr.Read();
                Article a = new Article {
                    Titre = (string)dr["Titre"],
                    Contenu = (string)dr["Contenu"],
                    DateModification = (DateTime)dr["DateModification"],
                    Revision = (int)dr["Revision"],
                    IdContributeur = (int)dr["IdContributeur"]                    
                };                
                return a;
            }
            catch (Exception e) {
                string Message = e.Message;
            }
            finally {
                connexion.Close();
            }
            return null;
        }        

        public static void Update(Article a) {
            string chConnexion = ConfigurationManager.ConnectionStrings["WikiCon"].ConnectionString;
            SqlConnection connexion = new SqlConnection(chConnexion);
            string requete = "UPDATE Article SET Titre = '" + a.Titre +
                "', DateModification = '" + DateTime.Now + "', Contenu = '" + a.Contenu
                + "' WHERE Titre = '" + a.Titre + "'";
              
            SqlCommand commande = new SqlCommand(requete, connexion);
            commande.CommandType = System.Data.CommandType.Text;
            try {
                connexion.Open();
                commande.ExecuteNonQuery();
                connexion.Close();
            }
            catch { }
        }

        public static void Delete(Article a) {
            string chConnexion = ConfigurationManager.ConnectionStrings["WikiCon"].ConnectionString;
            SqlConnection connexion = new SqlConnection(chConnexion);
            string requete = "DELETE FROM Article WHERE Titre = '" + a.Titre + "'";
            SqlCommand commande = new SqlCommand(requete, connexion);
            commande.CommandType = System.Data.CommandType.Text;
            try {
                connexion.Open();
                commande.ExecuteNonQuery();
                connexion.Close();
            }
            catch { }
        }

        //public class UniquenessAttribute : ValidationAttribute {
        //    string attri { get; set; }
        //    public UniquenessAttribute(string attri) {
        //        this.attri = attri;
        //    }

        //    protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
        //        var property = validationContext.ObjectType.GetProperty(attri);
        //        if (property == null) {
        //            return new ValidationResult(
        //                string.Format("Unknown property: {0}", attri)
        //            );
        //        }

        //        if (attri == "Titre" && Find(value.ToString()) != null) {
        //            return new ValidationResult(validationContext.DisplayName + " existe deja!");
        //        }

        //        return null;
        //    }
        //}
    }
}