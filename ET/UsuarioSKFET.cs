using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class UsuarioSKFET
    {
        public string Compania { get; set; }
        public string Planilla { get; set; }
        public string Personal_id { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombres { get; set; }
        public string Nro_Doc { get; set; }
        public string Email { get; set; }    
        public string Nro_Doc_Jefe { get; set; }
        public string Jefe { get; set; }
        public string Email_Jefe { get; set; }
        public bool Is_RRHH { get; set; }
        public bool Is_Jefe { get; set; }

    }
}
