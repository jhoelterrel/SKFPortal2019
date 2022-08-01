using BLL;
using ET;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SKFPortal.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            
            if (TempData["Message"] != null)
                ViewBag.Message = TempData["Message"];

            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult DashBoard()
        {
            return View();
        }

        [Authorize]
        public ActionResult RegistroVacaciones()
        {
            return View();
        }

        [HttpGet]
        public string ObtenerRegistroVacacional(string personal_id)
        {
            SKFBLL skfBLL = new SKFBLL();
            List<EmpleadoSKFVacacionET> listaEmpleados = skfBLL.ListarVacaciones(personal_id);

            return JsonConvert.SerializeObject(listaEmpleados, Formatting.Indented);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Login(String clave, String usuario)
        {
            SKFBLL skfBLL = new SKFBLL();
            String resultLogin = skfBLL.Login(clave, usuario);
            String action = "";
            switch (resultLogin)
            {
                case "0":
                    action = "Index";
                    TempData["Message"] = "Contraseña incorrecta";
                    break;
                case "1":
                    action = "Dashboard";
                    break;
                case "2":
                    action = "Index";
                    TempData["Message"] = "Usuario no encontrado";
                    break;
            }

            return RedirectToAction(action, "Home");
        }
    }
}