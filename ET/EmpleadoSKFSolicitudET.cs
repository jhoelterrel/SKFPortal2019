using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class EmpleadoSKFSolicitudET
    {
        public decimal IN_NRO_SOLICITUD          { get; set; }
        public string CH_PERSONAL_ID            { get; set; }
        public string CH_NRO_DOCUMENTO          { get; set; }
        public string VC_NOMBRES                { get; set; }
        public string VC_APELLIDO_PATERNO       { get; set; }
        public string VC_APELLIDO_MATERNO       { get; set; }
        public string VC_EMAIL                  { get; set; }
        public string CH_PERSONAL_ID_JEFE       { get; set; }
        public string CH_NRO_DOCUMENTO_JEFE     { get; set; }
        public string VC_NOMBRES_JEFE           { get; set; }
        public string VC_APELLIDO_PATERNO_JEFE  { get; set; }
        public string VC_APELLIDO_MATERNO_JEFE  { get; set; }
        public string VC_EMAIL_JEFE             { get; set; }
        public int IN_NRO_DIAS               { get; set; }
        public DateTime DT_FECHA_INICIO           { get; set; }
        public DateTime DT_FECHA_FIN              { get; set; }
        public string CH_SITUACION_REGISTRO     { get; set; }
        public int IN_PROCESADO              { get; set; }
        public int IN_INDICADOR_FLUJO        { get; set; }
        public string CH_ESTADO_REGISTRADO      { get; set; }
}
}
