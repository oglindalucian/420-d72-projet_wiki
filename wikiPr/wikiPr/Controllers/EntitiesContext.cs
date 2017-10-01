using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wikiPr.Models;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace wikiPr.Controllers {
    public class EntitiesContext : DbContext {
        public DbSet<Article> ArticleEntities { get; set; }
        public DbSet<Utilisateur> UtilisateurEntities { get; set; }
        public EntitiesContext() : base("WikiCon") {
            Database.SetInitializer<EntitiesContext>(new CreateDatabaseIfNotExists<EntitiesContext>());  //créer la BD
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Article>().ToTable("Article", "dbo"); //creer table Article
            modelBuilder.Entity<Article>().Property(t => t.ArticleId).HasColumnName("ArticleId").HasColumnType("INT");
            modelBuilder.Entity<Article>().HasKey(t => t.ArticleId);
            modelBuilder.Entity<Article>().Property(t => t.ArticleId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
           
            modelBuilder.Entity<Article>().Property(t => t.accederTitre).HasColumnName("Titre");
            modelBuilder.Entity<Article>().Property(t => t.accederContenu).HasColumnName("Contenu");
            modelBuilder.Entity<Article>().Property(t => t.accederDateModification).HasColumnName("DateModification");
            modelBuilder.Entity<Article>().Property(t => t.accederRevision).HasColumnName("Revision");
            modelBuilder.Entity<Article>().Property(t => t.accederIdContributeur).HasColumnName("IdContributeur");

            modelBuilder.Entity<Article>().Property(t => t.accederTitre).IsUnicode(true).HasMaxLength(50).IsRequired(); 
            modelBuilder.Entity<Article>().Property(t => t.accederContenu).IsUnicode(true).HasMaxLength(5000);
            modelBuilder.Entity<Article>().Property(p => p.accederDateModification).HasColumnType("datetime2");
            modelBuilder.Entity<Article>().Property(p => p.accederRevision).HasColumnType("INT");
            modelBuilder.Entity<Article>().Property(p => p.accederIdContributeur).HasColumnType("INT");

            //////

            modelBuilder.Entity<Utilisateur>().ToTable("Utilisateur", "dbo"); //creer table Utilisateur
            modelBuilder.Entity<Utilisateur>().Property(t => t.Id).HasColumnName("Id").HasColumnType("INT");
            modelBuilder.Entity<Utilisateur>().HasKey(t => t.Id);
            modelBuilder.Entity<Utilisateur>().Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();

            modelBuilder.Entity<Utilisateur>().Property(t => t.accederPrenom).HasColumnName("Prenom");
            modelBuilder.Entity<Utilisateur>().Property(t => t.accederNomFamille).HasColumnName("NomFamille");
            modelBuilder.Entity<Utilisateur>().Property(t => t.accederCourriel).HasColumnName("Courriel");
            modelBuilder.Entity<Utilisateur>().Property(t => t.accederMDP).HasColumnName("MDP");
            modelBuilder.Entity<Utilisateur>().Property(t => t.accederLangue).HasColumnName("Langue");
            modelBuilder.Entity<Utilisateur>().Ignore(t => t.accederConfirmation);

            modelBuilder.Entity<Utilisateur>().Property(t => t.accederPrenom).IsUnicode(true).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Utilisateur>().Property(t => t.accederNomFamille).IsUnicode(true).HasMaxLength(50);
            modelBuilder.Entity<Utilisateur>().Property(p => p.accederCourriel).IsUnicode(true).HasMaxLength(50);
            modelBuilder.Entity<Utilisateur>().Property(p => p.accederMDP).IsUnicode(true).HasMaxLength(500);
            modelBuilder.Entity<Utilisateur>().Property(p => p.accederLangue).IsUnicode(true).HasMaxLength(50);



        }

        public class EntitiesInitialize : CreateDatabaseIfNotExists<EntitiesContext> {
            protected override void Seed(EntitiesContext context) {
                base.Seed(context);
                context.ArticleEntities.Add(new Article("article1", "WIKI", new DateTime(2017 - 08 - 09))); //nouveau article
                context.UtilisateurEntities.Add(new Utilisateur("Prenom1", "Nom1", "courriel1@a.a", "aaaaaa", "fr")); //nouvel utilisateur
                context.SaveChanges();
                var initializer = new EntitiesInitialize();
                initializer.InitializeDatabase(new EntitiesContext());
            }
        }

        

        //   public class Database {
        //    var initializer = new CreateDatabaseIfNotExists<EntitiesContext>();
        //    initializer.InitializeDatabase(new EntitiesContext());
        //}


        //public class EntitiesContext : Controller
        //{
        //    // GET: EntitiesContext
        //    public ActionResult Index()
        //    {
        //        return View();
        //    }
        //}
    }
}