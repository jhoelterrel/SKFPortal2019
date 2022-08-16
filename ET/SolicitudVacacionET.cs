using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class SolicitudVacacionET
    {
        public String Personal_ID { get; set; }
        public String Nro_Documento { get; set; }
        public String Nombres { get; set; }
        public String Apellido_Paterno { get; set; }
        public String Apellido_Materno { get; set; }
        public String Email { get; set; }
        public String Personal_ID_Jefe { get; set; }
        public String Nro_Documento_Jefe { get; set; }
        public String Nombres_Jefe { get; set; }
        public String Apellido_Paterno_Jefe { get; set; }
        public String Apellido_Materno_Jefe { get; set; }
        public String Email_Jefe { get; set; }
        public int Nro_Dias { get; set;}
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
