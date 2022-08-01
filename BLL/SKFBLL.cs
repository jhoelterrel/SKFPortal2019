using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SKFBLL
    {
        private readonly EmpleadoSKFDAL datos = new EmpleadoSKFDAL();
        public List<EmpleadoSKFVacacionET> ListarVacaciones() => datos.ListarVacacionesBD();

        public String Login(String clave, String usuario) => datos.LoginBD(clave, usuario);
    }
}
