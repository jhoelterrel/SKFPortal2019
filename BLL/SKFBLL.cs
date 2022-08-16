using DAL;
using ET;
using System;
using System.Collections.Generic;


namespace BLL
{
    public class SKFBLL
    {
        private readonly EmpleadoSKFDAL datos = new EmpleadoSKFDAL();
        private readonly ReporteSKFDAL reporteDAL = new ReporteSKFDAL();
   

        public List<EmpleadoSKFVacacionET> ListarVacaciones(string ppersonal_id) => datos.ListarVacacionesBD(ppersonal_id);

        public List<EmpleadoSKFSolicitudET> ListarSolicitud(string ppersonal_id) => datos.ListarSolicitudBD(ppersonal_id);

        public UsuarioSKFET Login(String clave, String usuario) => datos.LoginBD(clave, usuario);

        //public EmpleadoSKFBoletaET GenerarBoleta() => datos.GenerarBoletaBD();

        public List<EjercicioSKFET> ListaEjercicio()
        {
            return reporteDAL.ListaEjercicio();
        }

        public List<ProcesoSKFET> ListaProceso()
        {
            return reporteDAL.ListaProceso();
        }

        public List<PeriodoSKFET> ListaPeriodo(int ejercicioID, string personalID)
        {
            return reporteDAL.ListaPeriodo(ejercicioID, personalID);
        }

        public void SolicitarVacaciones(SolicitudVacacionET solicitudVacacion) => datos.SolicitarVacacionesBD(solicitudVacacion);
    }
}
