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
            Utilisateurs.Add(u);
            return RedirectToAction("index", "home");
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
            return View(Utilisateurs.FindByCourriel(nom));

        }

        [HttpPost]
        public ActionResult Profil(Utilisateur u) {
            Utilisateurs.Update(u);
            return RedirectToAction("Index", "home");
        }

        public ActionResult ModifierMdP() {
            string courriel = User.Identity.Name;

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


            return View(Utilisateurs.FindByCourriel(courriel));
        }

        [HttpPost]
        public ActionResult ModifierMdP(Utilisateur u) {
            //string courriel = u.Courriel;
            //string motAncien = u.MDP;
            //UtilisateurMP ump = new UtilisateurMP(u.Courriel, u.MDP);
            //string motNouveau = ump.MDP2;
            //Utilisateurs.Update(courriel, motAncien, motNouveau);
            Utilisateurs.updates(u);
            return RedirectToAction("Index", "home");
        }

    }
}