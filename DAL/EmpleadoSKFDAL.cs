using ET;
using HL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmpleadoSKFDAL
    {
        public List<EmpleadoSKFVacacionET> ListarVacacionesBD()
        {
            List<EmpleadoSKFVacacionET> listaPersonal = new List<EmpleadoSKFVacacionET>();
            
            using(ConnectionDB conn = new ConnectionDB())
            {
                using(SqlCommand cmd = new SqlCommand("PROC_SCIRE1_VACAC_LISTAPERSONAL", conn.connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                EmpleadoSKFVacacionET personal = new EmpleadoSKFVacacionET
                                {
                                    Personal_Id = reader["Personal_Id"] == null ? "" : Convert.ToString(reader["Personal_Id"]),
                                    Nombre_Completo = reader["Nombre_Completo"] == null ? "" : Convert.ToString(reader["Nombre_Completo"]),
                                    Periodo_Id = reader["Periodo_Id"] == null ? "" : Convert.ToString(reader["Periodo_Id"]),
                                    Planilla_Id = reader["Planilla_Id"] == null ? "" : Convert.ToString(reader["Planilla_Id"]),
                                };


                                listaPersonal.Add(personal);
                            }
                            catch (Exception _)
                            {
                                //Log.RegistroLog("Error al obtener un empleado" + ex.Message);
                                continue;
                            }
                        }
                    }
                    else
                    {
                        //Log.RegistroLog("No hay relacion de emmpeados vacaciones");
                    }
                }
            }

            return listaPersonal;
        }
    }
}
