using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wikiPr.Models;

namespace wikiPr.Controllers
{
    public class homeController : Controller
    {
        // GET: home
        
        public ActionResult Index() {
            ViewBag.lesArticles = Article.lesArticles();
            return View(Article.lesArticles());
        }

        public ActionResult afficher(string titre) {
            Article a = Article.Find(titre);
            ViewBag.letitre = titre;
            ViewBag.lesArticles = Article.lesArticles();
            return View(a);
        }

        //public ActionResult ajouter() { 
        //    ViewBag.lesArticles = Article.lesArticles();
        //    Article a = new Article();           
        //    return View(a);
        //}

        public ActionResult ajouter(string titre) {
            ViewBag.lesArticles = Article.lesArticles();
            if (titre == null) { return View(new Article()); }
            else return View(new Article(titre));
           
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ajouter(Article a) {
            //if (a.Titre == null || a.Titre == "") {
                Article.Add(a); 
            //else {
                Article.Update(a); 
            
            return RedirectToAction("afficher", new { Titre = a.Titre});
        }

        public ActionResult modifier(string titre) {
            ViewBag.titre = titre;
            ViewBag.lesArticles = Article.lesArticles();
            return View(Article.Find(titre));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult modifier(Article a) {
            Article.Update(a);
            // return RedirectToAction("Index");
            return RedirectToAction("afficher", new { Titre = a.Titre });
        }
        
        public ActionResult supprimer(string titre) {
            ViewBag.lesArticles = Article.lesArticles();
            Article a = Article.Find(titre);
            return View(a);
        }

        [HttpPost]
        public ActionResult supprimer(Article a) {
            Article.Delete(a);
            return RedirectToAction("Index");
        }

        public ActionResult appercu() {
            return PartialView("AppercuContent");
        }

        public ActionResult apropos() {
            return View();
        }

      }
}
 
 