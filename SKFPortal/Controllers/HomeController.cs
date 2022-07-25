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
            List<EmpleadoSFKET> listaEmpleados = new List<EmpleadoSFKET>();

            EmpleadoSFKET ep1 = new EmpleadoSFKET()
            {
                ApellidoMaterno = "Moran",
                ApellidoPaterno = "Zafra",
                Nombres = "Rolando Jesus",
                Sexo = "M"
            };

            listaEmpleados.Add(ep1);

            EmpleadoSFKET ep2 = new EmpleadoSFKET()
            {
                ApellidoMaterno = "Caparachin",
                ApellidoPaterno = "Terrel",
                Nombres = "Jhoel",
                Sexo = "M"
            };

            listaEmpleados.Add(ep2);

            EmpleadoSFKET ep3 = new EmpleadoSFKET()
            {
                ApellidoMaterno = "Carrera",
                ApellidoPaterno = "Aguilar",
                Nombres = "Victor",
                Sexo = "M"
            };

            listaEmpleados.Add(ep3);

            return JsonConvert.SerializeObject(listaEmpleados, Formatting.Indented);
        }
    }
}