using BLL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SKFPortal.Controllers
{
    [Authorize]
    public class JsonController : Controller
    {
        private SKFBLL sKFBLL = new SKFBLL();

        public JsonResult ObtenerPeriodo(string Ejercicio_Id)
        {
            var usuario = (UsuarioSKFET)Session["UsuarioSKF"];

            if (usuario != null)
            {
                var periodos = sKFBLL.ListaPeriodo(Convert.ToInt32(Ejercicio_Id), usuario.Personal_id);
                return Json(periodos, JsonRequestBehavior.AllowGet);
            }
            return Json("",JsonRequestBehavior.AllowGet);
        }
    }
}