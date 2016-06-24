using Domain.Entidades;
using Infra.Data.Repository;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace SIS.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Painel()
        {
            return View();
        }

        public ActionResult Teste()
        {
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(FormCollection collection)
        {
            //Capturando as variáveis
            var login = collection["Login"];
            var senha = collection["Senha"];
            var lembrar = Convert.ToBoolean(collection["Lembrar"]);

            //Validando o acesso do usuário no AD
            if (Membership.ValidateUser(login, senha))
            {
                FormsAuthentication.SetAuthCookie(login, lembrar);
                return RedirectToAction("Painel", "Home");
            }
            else
            {
                ViewData["Error"] = "Login ou senha inválidos.";
                return View("Login");
            }


        }

        //
        // POST: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }

    }
}