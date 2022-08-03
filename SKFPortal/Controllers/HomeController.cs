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
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            if (TempData["Message"] != null)
                ViewBag.Message = TempData["Message"];

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DashBoard()
        {
            return View();
        }

        public ActionResult RegistroVacaciones()
        {
            return View();
        }

        public ActionResult VerBoletas()
        {
            return View();
        }

        [HttpGet]
        public string ObtenerRegistroVacacional()
        {
            SKFBLL skfBLL = new SKFBLL();
            List<EmpleadoSKFVacacionET> listaEmpleados = new List<EmpleadoSKFVacacionET>();
            var _usuarioSKF = (UsuarioSKFET)Session["UsuarioSKF"];

            if (_usuarioSKF != null)
            {
                listaEmpleados = skfBLL.ListarVacaciones(_usuarioSKF.Personal_id);
            }

            return JsonConvert.SerializeObject(listaEmpleados, Formatting.Indented);
        }

      
    }
}