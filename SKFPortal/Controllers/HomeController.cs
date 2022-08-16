using BLL;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DAL;
using ET;
using Newtonsoft.Json;
using SKFPortal.Models;
using SKFPortal.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

        public ActionResult MisSolicitudesJefe()
        {
            return View();
        }
        public ActionResult MisSolicitudesRRHH()
        {
            return View();
        }

        public ActionResult RegistroVacaciones()
        {
            return View();
        }

        public ActionResult VerBoletas()
        {
            vmReporteBoleta vmodel = new vmReporteBoleta();

            return View(vmodel);
        }

        [HttpGet]
        public void GenerarReporteBoleta( string cPeriodo,string cPeriodo_D, string cProceso, string cProceso_D)
        {
            #region nuevo
            ReportParams _reportParams = new ReportParams();

            _reportParams.RptFileName = "NEO_Boleta_Pago.rpt";
            _reportParams.cPeriodo = cPeriodo;
            _reportParams.cPeriodo_D = cPeriodo_D;
            _reportParams.cProceso = cProceso;
            _reportParams.cProceso_D = cProceso_D;

            var usuario = (UsuarioSKFET)Session["UsuarioSKF"];

            if (usuario != null)
            {
                _reportParams.cPersonal_Id = usuario.Personal_id;
                _reportParams.cPersonal_Id_D = usuario.Nombres +" "+ usuario.Apellido_Paterno + " " + usuario.Apellido_Materno;
            }

            System.Web.HttpContext.Current.Session["_reportParams"] = _reportParams;
            #endregion

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

        [HttpGet]
        public string ObtenerSolicitudes()
        {
            SKFBLL skfBLL = new SKFBLL();
            List<EmpleadoSKFSolicitudET> listaEmpleadosSolicitud = new List<EmpleadoSKFSolicitudET>();
            var _usuarioSKF = (UsuarioSKFET)Session["UsuarioSKF"];

            if (_usuarioSKF != null)
            {
                listaEmpleadosSolicitud = skfBLL.ListarSolicitud(_usuarioSKF.Personal_id);
            }

            return JsonConvert.SerializeObject(listaEmpleadosSolicitud, Formatting.Indented);
        }

        [HttpGet]
        public FileResult GenerarBoleta()
        {

            string DataBase = "SCIRERH";
            string User = "sa";
            string Password = "@Admin123";
            string Instance = "CLRLAP122";

            string PathReportes = @"D:\Fuentes\SKF_PORTAL_2019\SKF_Portal_2019\SKFPortal\Reportes\";
            string PathPDF = @"D:\Fuentes\SKF_PORTAL_2019\SKF_Portal_2019\SKFPortal\PDF\";
            String nombreArchivo = "Boleta" + DateTime.Now.ToString("dd-MM-yyyy") + ".pdf";
            String rutaArchivo = PathPDF + nombreArchivo;

            var _usuarioSKF = (UsuarioSKFET)Session["UsuarioSKF"];
           

            ReportDocument oRep = new ReportDocument();

            ParameterFields parametros = new ParameterFields();
            ParameterField parametro1 = new ParameterField();
            ParameterField parametro2 = new ParameterField();
            ParameterField parametro3 = new ParameterField();
            ParameterDiscreteValue valor1 = new ParameterDiscreteValue();
            ParameterDiscreteValue valor2 = new ParameterDiscreteValue();
            ParameterDiscreteValue valor3 = new ParameterDiscreteValue();


            parametro1.ParameterValueType = ParameterValueKind.StringParameter;
            parametro1.Name = "@Personal";
            valor1.Value = "000152";
            parametro1.CurrentValues.Add(valor1);
            parametros.Add(parametro1);

            parametro2.ParameterValueType = ParameterValueKind.StringParameter;
            parametro2.Name = "@cPeriodo";
            valor2.Value = "0334";
            parametro2.CurrentValues.Add(valor2);
            parametros.Add(parametro2);

            parametro3.ParameterValueType = ParameterValueKind.StringParameter;
            parametro3.Name = "@cProceso";
            valor3.Value = "01";
            parametro3.CurrentValues.Add(valor3);
            parametros.Add(parametro3);

            oRep.Load(PathReportes + "NEO_Boleta_Pago.rpt");

            oRep.SetDatabaseLogon(User, Password, Instance, DataBase);

            oRep.ExportToDisk(ExportFormatType.PortableDocFormat, PathPDF + nombreArchivo);

            return File(rutaArchivo, "application/pdf", nombreArchivo);
        }
    }
}