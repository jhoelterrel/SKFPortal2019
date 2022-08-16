using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SKFPortal.Models
{
    public class ReportParams
    {
        public string RptFileName { get; set; }
        public string ReportTitle { get; set; }
        public string cPersonal_Id { get; set; }
        public string cPersonal_Id_D { get; set; }
        public string cPeriodo { get; set; }
        public string cPeriodo_D { get; set; }
        public string cProceso { get; set; }
        public string cProceso_D { get; set; }
    }
}