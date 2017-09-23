using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using wikiPr.Models;
using wikiPr.Ressource;

namespace wikiPr.Controllers
{
    public class homeController : Controller
    {
        // GET: home
        string str;

        //public Thread Language() {
        //    str = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];
        //    Utilisateur u = Utilisateurs.FindByCourriel(User.Identity.Name);
        //    if (u != null) str = u.Langue;

        //    if (str.IndexOf("fr") != -1) {
        //        Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr");

        //    }
        //    if (str.IndexOf("en") != -1) {
        //        Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en");

        //    }
        //    else {

        //        Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("es");
        //    }
        //}

        

        public ActionResult Index() {
            ViewBag.lesArticles = Article.lesArticles();

            str = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];
            Utilisateur u = Utilisateurs.FindByCourriel(User.Identity.Name);
            if (User.Identity.IsAuthenticated && u != null) str = u.Langue;

            if (str.IndexOf("fr") != -1) {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr");

            }
            if (str.IndexOf("en") != -1) {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en");

            }
            else {

                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("es");
            }

            string cookie = "";
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("Cookie")) {
                cookie = this.ControllerContext.HttpContext.Request.Cookies["Cookie"].Value;
            }
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cookie);

                return View(Article.lesArticles());
        }



        //[ChildActionOnly()]
        public ActionResult ViewLang() {
            return PartialView();
        }

        [HttpPost]
        public ActionResult ViewLang(Utilisateur u) {
            HttpCookie cookie = new HttpCookie("Cookie");
            cookie.Value = Request.Form["lalang"];
            this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);

            //if (User.Identity.IsAuthenticated) {
            //    Utilisateurs.updatelangue(u);
            //}
            //else {
            //    string langue = Request.Form["lalang"];// Request.QueryString["lalang"];//Request.Form["lalang"];
            //    if (!string.IsNullOrEmpty(langue)) {
            //        Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(langue);
            //    }
            //}
            return PartialView();
        }

        //[HttpPost]
        //public ActionResult ViewLang(string lang) {
        //    // Utilisateur u = new Utilisateur(-1, lang);
        //    //Utilisateurs.editlangue(lang);
        //    lang = Request.Form["lang"];

        //    //HttpCookie myCookie = new HttpCookie("UserLanguage");
        //    //myCookie["Language"] = "Arial";
        //    //myCookie["Color"] = "Blue";
        //    //myCookie.Expires = DateTime.Now.AddDays(1d);
        //    //Response.Cookies.Add(myCookie);



        //    if (lang != null) {
        //        if (lang.IndexOf("fr") != -1) {
        //            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr");

        //        }
        //        if (lang.IndexOf("en") != -1) {
        //            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en");

        //        }
        //        else {

        //            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("es");
        //        }
        //    }
        //    return PartialView();
        //    //return new RedirectResult(Request.UrlReferrer.AbsoluteUri);
        //}

        public ActionResult afficher(string titre) {
            Article a = Article.Find(titre);
            ViewBag.letitre = titre;
            ViewBag.lesArticles = Article.lesArticles();

            str = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];
            Utilisateur u = Utilisateurs.FindByCourriel(User.Identity.Name);
            if (User.Identity.IsAuthenticated && u != null) str = u.Langue;

            if (str.IndexOf("fr") != -1) {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr");

            }
            if (str.IndexOf("en") != -1) {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en");

            }
            else {

                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("es");
            }

            return View(a);
        }

        [Authorize]
        public ActionResult ajouter(string titre) {
            ViewBag.lesArticles = Article.lesArticles();

            str = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];
            Utilisateur u = Utilisateurs.FindByCourriel(User.Identity.Name);
            if (User.Identity.IsAuthenticated && u != null) str = u.Langue;

            if (str.IndexOf("fr") != -1) {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr");

            }
            if (str.IndexOf("en") != -1) {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en");

            }
            else {

                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("es");
            }

            if (titre == null) { return View(new Article()); }
            else return View(new Article(titre));

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ajouter(Article a) {
            Article.Add(a);
            string courriel = User.Identity.Name;
            Utilisateur u = Utilisateurs.FindByCourriel(courriel);
            int id = u.Id;
            Article.Update(a, id);
            

          //  str = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];
          //  Utilisateur u = Utilisateurs.FindByCourriel(User.Identity.Name);
            //if (u != null) str = u.Langue;

            //if (str.IndexOf("fr") != -1) {
            //    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr");

            //}
            //if (str.IndexOf("en") != -1) {
            //    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en");

            //}
            //else {

            //    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("es");
            //}


            return RedirectToAction("afficher", new { Titre = a.Titre });
            }

        [Authorize]
        public ActionResult modifier(string titre) {
            ViewBag.titre = titre;
            ViewBag.lesArticles = Article.lesArticles();

            str = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];
            Utilisateur u = Utilisateurs.FindByCourriel(User.Identity.Name);
            if (User.Identity.IsAuthenticated && u != null) str = u.Langue;

            if (str.IndexOf("fr") != -1) {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr");

            }
            if (str.IndexOf("en") != -1) {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en");

            }
            else {

                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("es");
            }


            return View(Article.Find(titre));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult modifier(Article a) {
            string courriel = User.Identity.Name;
            Utilisateur u = Utilisateurs.FindByCourriel(courriel);
            int id = u.Id;
            Article.Update(a, id);

            //str = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];
            //  Utilisateur u = Utilisateurs.FindByCourriel(User.Identity.Name);
            //    if (u != null) str = u.Langue;

            //    if (str.IndexOf("fr") != -1) {
            //        Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr");

            //    }
            //    if (str.IndexOf("en") != -1) {
            //        Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en");

            //    }
            //    else {

            //        Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("es");
            //    }


            return RedirectToAction("afficher", new { Titre = a.Titre });
        }

        [Authorize]
        public ActionResult supprimer(string titre) {
            ViewBag.lesArticles = Article.lesArticles();
            Article a = Article.Find(titre);

            str = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];
            Utilisateur u = Utilisateurs.FindByCourriel(User.Identity.Name);
            if (User.Identity.IsAuthenticated && u != null) str = u.Langue;

            if (str.IndexOf("fr") != -1) {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr");

            }
            if (str.IndexOf("en") != -1) {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en");

            }
            else {

                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("es");
            }


            return View(a);
        }

        [HttpPost]
        public ActionResult supprimer(Article a) {
            Article.Delete(a);
            return RedirectToAction("Index");
        }

        public ActionResult apropos() {
            return View();
        }

        [ChildActionOnly()]
        public ActionResult ViewUp() {
            return PartialView();
        }

        [ChildActionOnly()]
        public ActionResult ViewListe() {
            ViewBag.lesArticles = Article.lesArticles();
            return PartialView(ViewBag.lesArticles);
        }

        //[ChildActionOnly()]
        //public ActionResult Appercu(Article a) {
        //    // ViewBag.lesArticles = Article.lesArticles();
        //    ViewBag.Contenu = a.Contenu; //??????
        //    return PartialView(ViewBag.Contenu);
        //}

        //public ActionResult Apercu(string s) {
        //    Apercu ap = new Models.Apercu(s);
        //    ViewBag.Contenu = ap.Content; //??????
        //    return View(new Apercu(s));
        //}

        //public JsonResult verifierTitre(string Titre) {
        //    var validateName = Article.FirstOrDefault
        //                        (x => x.Titre == Titre);
        //    if (validateName != null) {
        //        return Json(false, JsonRequestBehavior.AllowGet);
        //    }
        //    else {
        //        return Json(true, JsonRequestBehavior.AllowGet);
        //    }
        //}

    /*    public ActionResult GetMessageRessource() {

            string str;
            str = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];
            //Article a = new Article();
            //a.Titre = "Yousra";
            //mess.Contenu = "Bienvenue en Web ASP.Net MVC4";
            //mess.Date = new DateTime(2017, 09, 08);
            if (str.IndexOf("fr") != -1 && str.IndexOf("en") == -1 && str.IndexOf("es") == -1) {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr");

            }
            else if (str.IndexOf("fr") == -1 && str.IndexOf("en") != -1 && str.IndexOf("es") == -1) {

                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en");
            }
            else if (str.IndexOf("fr") == -1 && str.IndexOf("en") == -1 && str.IndexOf("es") != -1) {

                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("es");
            }


            // return View(mess);
            return View();
        }    */

    }
}
 
 