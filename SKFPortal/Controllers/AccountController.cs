using BLL;
using SKFPortal.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SKFPortal.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Dashboard", "Home");
            }
            vmUser vm = new vmUser();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(vmUser vm)
        {
            SKFBLL skfBLL = new SKFBLL();
            String resultLogin = skfBLL.Login(vm.password, vm.username);

            switch (resultLogin)
            {
                case "0":               
                    TempData["Message"] = "Contraseña incorrecta";
                    return View(vm);
                    break;
                case "1":
                    FormsAuthentication.SetAuthCookie(vm.username, false);
                    Session["USERLOGIN"] = vm;
                    break;
                case "2":
                    TempData["Message"] = "Usuario no encontrado";
                    return View(vm);
                    break;
            }



            return RedirectToAction("Dashboard", "Home");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
    }
}
