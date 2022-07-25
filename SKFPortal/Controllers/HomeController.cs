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
        public ActionResult Index()
        {
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

        [HttpGet]
        public string ObtenerRegistroVacacional()
        {
            SKFBLL skfBLL = new SKFBLL();
            List<EmpleadoSKFVacacionET> listaEmpleados = skfBLL.ListarVacaciones();

            return JsonConvert.SerializeObject(listaEmpleados, Formatting.Indented);
        }
    }
}