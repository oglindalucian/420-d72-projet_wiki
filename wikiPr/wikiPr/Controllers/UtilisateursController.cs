using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using wikiPr.Models;
using wikiPr.Models.Views;
using wikiPr.Ressource;

namespace wikiPr.Controllers
{
    public class UtilisateursController : Controller
    {
        // GET: Utilisateurs

        string str;

        /*    [HttpGet]
            public ActionResult Connexion(string ReturnUrl = "") {  //string ReturnUrl = ""
                ViewBag.error = "";
                ViewBag.ReturnUrl = ReturnUrl;

    /*
                str = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];
                //Utilisateur u = Utilisateurs.FindByCourriel(User.Identity.Name);
                //if (u != null) str = u.Langue;

                if (str.IndexOf("fr") != -1) {
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr");

                }
                if (str.IndexOf("en") != -1) {
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en");

                }
                else {

                    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("es");
                }    */

        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Connexion(string username, string password, string ReturnUrl = "") {
        //    ViewBag.error = "";
        //    ViewBag.ReturnUrl = ReturnUrl;
        //    if (!Utilisateurs.Authentifie(username, password)) {
        //        ViewBag.error = "Nom d'utilisateur ou mot de passe invalide!";
        //        return View();
        //    }
        //    else {
        //        FormsAuthentication.SetAuthCookie(username, false);
        //        if (ReturnUrl == "") {
        //            return RedirectToAction("index", "home");
        //        }
        //        else {
        //            return Redirect(ReturnUrl);
        //        }
        //    }
        //}
        /*
                [HttpPost]
                public ActionResult Connexion(string username, string password, string ReturnUrl = "")

        {
                    /*
                                str = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];
                                Utilisateur u = Utilisateurs.FindByCourriel(username);
                                if (u!=null) str = u.Langue;

                                if (str.IndexOf("fr") != -1) {
                                    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr");

                                }
                                if (str.IndexOf("en") != -1) {
                                    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en");

                                }
                                else  {

                                    Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("es");
                                }

                        */
        //ViewBag.error = "";
        //ViewBag.ReturnUrl = ReturnUrl;
        //if (!Utilisateurs.Authentifie(username, password)) {
        //    ViewBag.error = "Nom d'utilisateur ou mot de passe invalide!";
        //    return View();
        //}
        //else {
        //    FormsAuthentication.SetAuthCookie(username, false);
        //    if (ReturnUrl == "") {
        //        return RedirectToAction("index", "home");
        //    }
        //    else {
        //        return Redirect(ReturnUrl);
        //    }
        //}
        /*
                    ViewBag.error = "";
                    ViewBag.ReturnUrl = ReturnUrl;
                    if (!Utilisateurs.Authentifie(username, password)) {
                        ViewBag.error = "Nom d'utilisateur ou mot de passe invalide!";
                        return View();
                    }
                    else {
                        FormsAuthentication.SetAuthCookie(username, false);
                        if (ReturnUrl == "") {
                            return RedirectToAction("Index", "Home");
                        }
                        else {
                            return Redirect(ReturnUrl);
                        }
                    }
                }   */

        public ActionResult Connexion() {
            ViewBag.error = "";
            return View();
        }

        [HttpPost]
        public ActionResult Connexion(string username, string password, string ReturnUrl = "") {
            ViewBag.error = "";
            ViewBag.ReturnUrl = ReturnUrl;
            if (!Utilisateurs.Authentifie(username, password)) {
                ViewBag.error = "Nom d'utilisateur ou mot de passe invalide!";
                return View();
            }
            else {
                FormsAuthentication.SetAuthCookie(username, false);
                if (ReturnUrl == "") {
                    return RedirectToAction("index", "home");
                }
                else {
                    return Redirect(ReturnUrl);
                }
            }
        }




        public ActionResult Logout() {
            FormsAuthentication.SignOut();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public ActionResult Inscription() {

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
            return View();
        }

        [HttpPost]
        public ActionResult Inscription(Utilisateur u) {
            if (ModelState.IsValid) { 
                Utilisateurs.Add(u);
                return RedirectToAction("index", "home");
            }
            return View();
        }

        //public ActionResult Profil() {
            //string courriel = User.Identity.Name;//pr

     /*       str = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];
            Utilisateur u = Utilisateurs.FindByCourriel(User.Identity.Name);
            if (u != null) str = u.Langue;

            if (str.IndexOf("fr") != -1) {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr");

            }
            if (str.IndexOf("en") != -1) {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en");

            }
            else {

                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("es");
            }

    */
        //    string courriel = User.Identity.Name; 
        //    return View(Utilisateurs.FindByCourriel(courriel));
        //}

        //[HttpPost]
        //public ActionResult Profil(Utilisateur u) {
        //    Utilisateurs.Update(u);
        //    return RedirectToAction("Index", "home");
        //}

        public ActionResult Profil() { 
            string nom = User.Identity.Name;
            Utilisateur u = Utilisateurs.FindByCourriel(User.Identity.Name);
            UtilisateurProfil up = new UtilisateurProfil(u);
            str = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];
           
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
            return View(up);

        }

        [HttpPost]
        public ActionResult Profil(UtilisateurProfil up) {
            Utilisateur u = Utilisateurs.FindByCourriel(User.Identity.Name); 
            if (ModelState.IsValid) {
               Utilisateurs.Ajour(u, up);//
               return RedirectToAction("index", "home");
           }
           
           return View();
          
            // return new RedirectResult(Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult ModifierMdP() {
            
            string courriel = User.Identity.Name;

            Utilisateur u = Utilisateurs.FindByCourriel(User.Identity.Name);
            UtilisateurMP ump = new UtilisateurMP();
            str = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];            
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

            // ViewBag.Passwd = u.MDP; 
           
            return View(ump);
        }

        [HttpPost]
        public ActionResult ModifierMdP(UtilisateurMP ump) {
            string er = "";         
            Utilisateur u = Utilisateurs.FindByCourriel(User.Identity.Name);
            if (User.Identity.IsAuthenticated && u != null) str = u.Langue;

            if (str.IndexOf("fr") != -1) {
                er = "Le mot de passe fourni est incorrect.";

            }
            if (str.IndexOf("en") != -1) {
                er = "Wrong password.";

            }
            else {

                er = "Contraseña incorrecta.";
            }
            if (Utilisateurs.hacherMot(ump.MDP1).Trim() == u.MDP.Trim()) {
                ViewBag.error = "";
                if (ModelState.IsValid) {
                    Utilisateurs.Ajour(u, ump);
                    return RedirectToAction("Index", "home");
                }               
            }
            else { ViewBag.error = er; }
            return View();
        }

    }
}