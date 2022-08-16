using BLL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SKFPortal.ViewModel
{
    public class vmReporteBoleta
    {
        public string Compania { get; set; }
        public string Planilla { get; set; }
        public List<SelectListItem> ListaEjercicio { get; set; }
        public List<SelectListItem> ListaPeriodo { get; set; }
        public List<SelectListItem> ListaProceso { get; set; }
        public string Ejercicio { get; set; }
        public string Periodo { get; set; }
        public string Proceso { get; set; }

        public vmReporteBoleta()
        {
            UsuarioSKFET usuarioSKF = new UsuarioSKFET();
            SKFBLL sKFBLL = new SKFBLL();

            var currentUsuarioSKF = (UsuarioSKFET)System.Web.HttpContext.Current.Session["UsuarioSKF"];

            if (currentUsuarioSKF != null)
            {
                usuarioSKF = currentUsuarioSKF;
            }

            this.Compania = usuarioSKF.Compania;
            this.Planilla = usuarioSKF.Planilla;


            this.ListaEjercicio = new List<SelectListItem>();

            foreach (var ejercicio in sKFBLL.ListaEjercicio())
            {
                this.ListaEjercicio.Add(new SelectListItem { Value = ejercicio.Ejercicio_Id, Text = ejercicio.Descripcion });
            }

            this.ListaProceso = new List<SelectListItem>();

            foreach (var proceso in sKFBLL.ListaProceso())
            {
                this.ListaProceso.Add(new SelectListItem { Value = proceso.Proceso_Id, Text = proceso.Proceso });
            }

            this.ListaPeriodo = new List<SelectListItem>();

            foreach (var periodo in sKFBLL.ListaPeriodo(Convert.ToInt32(ListaEjercicio.FirstOrDefault().Value), usuarioSKF.Personal_id))
            {
                this.ListaPeriodo.Add(new SelectListItem { Value = periodo.Periodo_Id, Text = periodo.Descripcion });
            }

        }

    }



}