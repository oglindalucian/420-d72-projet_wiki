using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using wikiPr.Models;
using wikiPr.Models.Views;

namespace wikiPr.Controllers
{
    public class UtilisateursController : Controller
    {
        // GET: Utilisateurs
        [HttpGet]
        public ActionResult Connexion() {
            ViewBag.error = "";
           // ViewBag.ReturnUrl = ReturnUrl;
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
            return View();
        }

        [HttpPost]
        public ActionResult Inscription(Utilisateur u) {
            Utilisateurs.Add(u);
            return RedirectToAction("index", "home");
        }

        public ActionResult Profil() {
            //string courriel = User.Identity.Name;//pr
            string courriel = "a@a.a";
            return View(Utilisateurs.FindByCourriel(courriel));
        }

        [HttpPost]
        public ActionResult Profil(Utilisateur u) {
            Utilisateurs.Update(u);
            return RedirectToAction("Index", "home");
        }

        public ActionResult ModifierMdP() {
            string courriel = User.Identity.Name;
            return View(Utilisateurs.FindByCourriel(courriel));
        }

        [HttpPost]
        public ActionResult ModifierMdP(Utilisateur u) {
            string courriel = u.Courriel;
            string motAncien = u.MDP;
            UtilisateurMP ump = new UtilisateurMP(u.Courriel, u.MDP);
            string motNouveau = ump.MDP2;
           // Utilisateurs.Update(courriel, motAncien, motNouveau);
            return RedirectToAction("Index", "home");
        }

    }
}