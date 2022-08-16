using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SKFPortal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SKFPortal.Reportes.Boleta
{
    public partial class ReporteBoletasViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadReport();
        }

        public void LoadReport() {
            var reportParam = (ReportParams)System.Web.HttpContext.Current.Session["_reportParams"];
            string path = ConfigurationManager.AppSettings["report:path"].ToString();
            string user = ConfigurationManager.AppSettings["db:User"].ToString();
            string pass = ConfigurationManager.AppSettings["db:Password"].ToString();
            string server = ConfigurationManager.AppSettings["db:Server"].ToString();
            string database = ConfigurationManager.AppSettings["db:Database"].ToString();
            path = string.Format("{0}{1}", path, reportParam.RptFileName);

            ReportDocument rd = new ReportDocument();

            ParameterFields parametros = new ParameterFields();
            ParameterField parametro1 = new ParameterField();
            ParameterField parametro2 = new ParameterField();
            ParameterField parametro3 = new ParameterField();
            ParameterDiscreteValue valor1 = new ParameterDiscreteValue();
            ParameterDiscreteValue valor2 = new ParameterDiscreteValue();
            ParameterDiscreteValue valor3 = new ParameterDiscreteValue();


            parametro1.ParameterValueType = ParameterValueKind.StringParameter;
            parametro1.Name = "@Personal";
            valor1.Value = reportParam.cPersonal_Id.ToString();
            parametro1.CurrentValues.Add(valor1);
            parametros.Add(parametro1);

            parametro2.ParameterValueType = ParameterValueKind.StringParameter;
            parametro2.Name = "@cPeriodo";
            valor2.Value = reportParam.cPeriodo.ToString();
            parametro2.CurrentValues.Add(valor2);
            parametros.Add(parametro2);

            parametro3.ParameterValueType = ParameterValueKind.StringParameter;
            parametro3.Name = "@cProceso";
            valor3.Value = reportParam.cProceso.ToString();
            parametro3.CurrentValues.Add(valor3);
            parametros.Add(parametro3);

            rd.Load(path);
            rd.SetDatabaseLogon(user, pass, server, database);
            Boleta_Pago.ReportSource = rd;
            Boleta_Pago.ParameterFieldInfo = parametros;
            Boleta_Pago.ID = "BOLETA_PAGO_"+ reportParam.cProceso_D.ToString()+"_"+reportParam.cPeriodo_D.ToString() + "_" + reportParam.cPersonal_Id.ToString();
            Boleta_Pago.EnableDrillDown = false;
            Boleta_Pago.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
        }
    }
}