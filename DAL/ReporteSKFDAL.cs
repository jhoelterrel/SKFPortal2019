using ET;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReporteSKFDAL
    {
        public List<EjercicioSKFET> ListaEjercicio()
        {
            List<EjercicioSKFET> listaEjercicio = new List<EjercicioSKFET>();

            using (ConnectionDB conn = new ConnectionDB())
            {
                using (SqlCommand cmd = new SqlCommand("FEXT_SP_LISTAR_EJERCICIO", conn.connection))
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
                                EjercicioSKFET ejercicio = new EjercicioSKFET
                                {
                                    Ejercicio_Id = reader["Ejercicio_Id"] == null ? "" : Convert.ToString(reader["Ejercicio_Id"]),
                                    Descripcion = reader["Descripcion"] == null ? "" : Convert.ToString(reader["Descripcion"])
                                };

                                listaEjercicio.Add(ejercicio);
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

            return listaEjercicio;
        }
        public List<ProcesoSKFET> ListaProceso()
        {
            List<ProcesoSKFET> listaProceso = new List<ProcesoSKFET>();

            using (ConnectionDB conn = new ConnectionDB())
            {
                using (SqlCommand cmd = new SqlCommand("FEXT_SP_LISTAR_PROCESO", conn.connection))
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
                                ProcesoSKFET proceso = new ProcesoSKFET
                                {
                                    Proceso_Id = reader["Proceso_Id"] == null ? "" : Convert.ToString(reader["Proceso_Id"]),
                                    Proceso = reader["Proceso"] == null ? "" : Convert.ToString(reader["Proceso"])
                                };

                                listaProceso.Add(proceso);
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

            return listaProceso;
        }
        public List<PeriodoSKFET> ListaPeriodo(int ejercicioID, string personalID)
        {
            List<PeriodoSKFET> listaPeriodo = new List<PeriodoSKFET>();

            using (ConnectionDB conn = new ConnectionDB())
            {
                using (SqlCommand cmd = new SqlCommand("FEXT_SP_LISTAR_PERIODO_X_PERSONA", conn.connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EJERCICIO_ID",ejercicioID);
                    cmd.Parameters.AddWithValue("@PERSONAL_ID", personalID);

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                PeriodoSKFET periodo = new PeriodoSKFET
                                {
                                    Periodo_Id = reader["Periodo_Id"] == null ? "" : Convert.ToString(reader["Periodo_Id"]),
                                    Descripcion = reader["Descripcion"] == null ? "" : Convert.ToString(reader["Descripcion"])
                                };

                                listaPeriodo.Add(periodo);
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

            return listaPeriodo;
        }
    }
}
