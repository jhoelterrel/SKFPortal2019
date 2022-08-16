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

        public List<EmpleadoSKFSolicitudET> ListarSolicitudBD(string pPersonal_ID)
        {
            List<EmpleadoSKFSolicitudET> listaSolicitudPersonal = new List<EmpleadoSKFSolicitudET>();

            using (ConnectionDB conn = new ConnectionDB())
            {
                using (SqlCommand cmd = new SqlCommand("FEXT_SP_REPORTE_RECORD_VACACIONAL", conn.connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Personal", pPersonal_ID);
                    cmd.CommandTimeout = 120;
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                EmpleadoSKFSolicitudET solicitud = new EmpleadoSKFSolicitudET
                                {
                                    //Compania = reader["T_PERCOMPANIA"] == null ? "" : Convert.ToString(reader["T_PERCOMPANIA"]),
                                    //Ruc = reader["T_PERRUC"] == null ? "" : Convert.ToString(reader["T_PERRUC"]),
                                    //Direccion = reader["T_PERDIRECCION"] == null ? "" : Convert.ToString(reader["T_PERDIRECCION"]),
                                    //Jefe = reader["T_PERJEFE"] == null ? "" : Convert.ToString(reader["T_PERJEFE"]),
                                    //Location = reader["T_PERLOCACION"] == null ? "" : Convert.ToString(reader["T_PERLOCACION"]),
                                    //Cargo = reader["T_PERCARGO"] == null ? "" : Convert.ToString(reader["T_PERCARGO"]),
                                    //Area = reader["T_PERAREA"] == null ? "" : Convert.ToString(reader["T_PERAREA"]),
                                    //Proyecto = reader["T_PERPROYECTO"] == null ? "" : Convert.ToString(reader["T_PERPROYECTO"]),
                                    //Ccosto = reader["T_PERCCOSTO"] == null ? "" : Convert.ToString(reader["T_PERCCOSTO"]),
                                    //PersonalID = reader["T_PERPERSONAL_ID"] == null ? "" : Convert.ToString(reader["T_PERPERSONAL_ID"]),
                                    //NombreCompleto = reader["T_PERNOMBRECOMPLETO"] == null ? "" : Convert.ToString(reader["T_PERNOMBRECOMPLETO"]),
                                    //TipoDocumento = reader["T_PERTIPDOC"] == null ? "" : Convert.ToString(reader["T_PERTIPDOC"]),
                                    //NumeroDocumento = reader["T_PERNRODOC"] == null ? "" : Convert.ToString(reader["T_PERNRODOC"]),
                                    //FechaIngreso = reader["T_PERFECHA_INGRESO"] == null ? "" : Convert.ToString(reader["T_PERFECHA_INGRESO"]),
                                    //PeriodoVacacional = reader["T_PERPERIODOVACACIONAL"] == null ? "" : Convert.ToString(reader["T_PERPERIODOVACACIONAL"]),
                                    //FechaInicioSalida = reader["T_PERFECHA_INI_SALIDA"] == null ? "" : Convert.ToString(reader["T_PERFECHA_INI_SALIDA"]),
                                    //FechaFinSalida = reader["T_PERFECHA_FIN_SALIDA"] == null ? "" : Convert.ToString(reader["T_PERFECHA_FIN_SALIDA"]),
                                    //DiasSalida = reader["T_PERDIASSALIDA"] == null ? "" : Convert.ToString(reader["T_PERDIASSALIDA"]),
                                    //DiasIndemnizable = reader["T_PER_DIAS_INDEMNIZABLE"] == null ? "" : Convert.ToString(reader["T_PER_DIAS_INDEMNIZABLE"]),
                                    //DiasPendiente = reader["T_PER_DIAS_PENDIENTE"] == null ? "" : Convert.ToString(reader["T_PER_DIAS_PENDIENTE"]),
                                    //DiasTruncos = reader["T_PERDIAS_TRUNCO"] == null ? "" : Convert.ToString(reader["T_PERDIAS_TRUNCO"])
                                };
                                listaSolicitudPersonal.Add(solicitud);
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

            return listaSolicitudPersonal;
        }
        public List<EmpleadoSKFVacacionET> ListarVacacionesBD(string pPersonal_ID)
        {
            List<EmpleadoSKFVacacionET> listaPersonal = new List<EmpleadoSKFVacacionET>();
            
            using(ConnectionDB conn = new ConnectionDB())
            {
                using(SqlCommand cmd = new SqlCommand("FEXT_SP_REPORTE_RECORD_VACACIONAL", conn.connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Personal", pPersonal_ID);
                    cmd.CommandTimeout = 120;
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
                                    Compania = reader["T_PERCOMPANIA"] == null ? "" : Convert.ToString(reader["T_PERCOMPANIA"]),
                                    Ruc = reader["T_PERRUC"] == null ? "" : Convert.ToString(reader["T_PERRUC"]),
                                    Direccion = reader["T_PERDIRECCION"] == null ? "" : Convert.ToString(reader["T_PERDIRECCION"]),
                                    Jefe = reader["T_PERJEFE"] == null ? "" : Convert.ToString(reader["T_PERJEFE"]),
                                    Location = reader["T_PERLOCACION"] == null ? "" : Convert.ToString(reader["T_PERLOCACION"]),
                                    Cargo = reader["T_PERCARGO"] == null ? "" : Convert.ToString(reader["T_PERCARGO"]),
                                    Area = reader["T_PERAREA"] == null ? "" : Convert.ToString(reader["T_PERAREA"]),
                                    Proyecto = reader["T_PERPROYECTO"] == null ? "" : Convert.ToString(reader["T_PERPROYECTO"]),
                                    Ccosto= reader["T_PERCCOSTO"] == null ? "" : Convert.ToString(reader["T_PERCCOSTO"]),
                                    PersonalID = reader["T_PERPERSONAL_ID"] == null ? "" : Convert.ToString(reader["T_PERPERSONAL_ID"]),
                                    NombreCompleto = reader["T_PERNOMBRECOMPLETO"] == null ? "" : Convert.ToString(reader["T_PERNOMBRECOMPLETO"]),
                                    TipoDocumento = reader["T_PERTIPDOC"] == null ? "" : Convert.ToString(reader["T_PERTIPDOC"]),
                                    NumeroDocumento = reader["T_PERNRODOC"] == null ? "" : Convert.ToString(reader["T_PERNRODOC"]),
                                    FechaIngreso = reader["T_PERFECHA_INGRESO"] == null ? "" : Convert.ToString(reader["T_PERFECHA_INGRESO"]),
                                    PeriodoVacacional = reader["T_PERPERIODOVACACIONAL"] == null ? "" : Convert.ToString(reader["T_PERPERIODOVACACIONAL"]),
                                    FechaInicioSalida = reader["T_PERFECHA_INI_SALIDA"] == null ? "" : Convert.ToString(reader["T_PERFECHA_INI_SALIDA"]),
                                    FechaFinSalida = reader["T_PERFECHA_FIN_SALIDA"] == null ? "" : Convert.ToString(reader["T_PERFECHA_FIN_SALIDA"]),
                                    DiasSalida = reader["T_PERDIASSALIDA"] == null ? "" : Convert.ToString(reader["T_PERDIASSALIDA"]),
                                    DiasIndemnizable = reader["T_PER_DIAS_INDEMNIZABLE"] == null ? "" : Convert.ToString(reader["T_PER_DIAS_INDEMNIZABLE"]),
                                    DiasPendiente = reader["T_PER_DIAS_PENDIENTE"] == null ? "" : Convert.ToString(reader["T_PER_DIAS_PENDIENTE"]),
                                    DiasTruncos = reader["T_PERDIAS_TRUNCO"] == null ? "" : Convert.ToString(reader["T_PERDIAS_TRUNCO"])
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

        //public EmpleadoSKFBoletaET GenerarBoletaBD()
        //{
        //    EmpleadoSKFBoletaET boletaSKFET = new EmpleadoSKFBoletaET();

        //    using (ConnectionDB conn = new ConnectionDB())
        //    {
        //        using (SqlCommand cmd = new SqlCommand("FEXT_SP_USUARIOS_LOGIN", conn.connection))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@VC_USUARIO", "");


        //            conn.Open();

        //            SqlDataReader reader = cmd.ExecuteReader();

        //            if (reader.HasRows)
        //            {
        //                while (reader.Read())
        //                {
        //                    //FALTA
        //                }
        //            }

        //            conn.Close();
        //        }
        //    }

        //    return boletaSKFET;
        //}

        public UsuarioSKFET LoginBD(String clave, String usuario)
        {
            UsuarioSKFET usuarioSKFET = new UsuarioSKFET();

            using (ConnectionDB conn = new ConnectionDB())
            {
                using (SqlCommand cmd = new SqlCommand("FEXT_SP_USUARIOS_LOGIN", conn.connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@VC_USUARIO", usuario);
                    cmd.Parameters.AddWithValue("@VC_CLAVE", clave);



                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            usuarioSKFET.Compania = reader["Compania"] == null ? string.Empty : Convert.ToString(reader["Compania"]);
                            usuarioSKFET.Planilla = reader["Planilla"] == null ? string.Empty : Convert.ToString(reader["Planilla"]);
                            usuarioSKFET.Personal_id = reader["Personal_id"] == null ? string.Empty : Convert.ToString(reader["Personal_id"]);
                            usuarioSKFET.Apellido_Paterno = reader["Apellido_Paterno"] == null ? string.Empty : Convert.ToString(reader["Apellido_Paterno"]);
                            usuarioSKFET.Apellido_Materno = reader["Apellido_Materno"] == null ? string.Empty : Convert.ToString(reader["Apellido_Materno"]);
                            usuarioSKFET.Nombres = reader["Nombres"] == null ? string.Empty : Convert.ToString(reader["Nombres"]);
                            usuarioSKFET.Nro_Doc = reader["Nro_Doc"] == null ? string.Empty : Convert.ToString(reader["Nro_Doc"]);
                            usuarioSKFET.Email = reader["Email"] == null ? string.Empty : Convert.ToString(reader["Email"]);
                            usuarioSKFET.Nro_Doc_Jefe = reader["Nro_Doc_Jefe"] == null ? string.Empty : Convert.ToString(reader["Nro_Doc_Jefe"]);
                            usuarioSKFET.Jefe = reader["Jefe"] == null ? string.Empty : Convert.ToString(reader["Jefe"]);
                            usuarioSKFET.Email_Jefe = reader["Email_Jefe"] == null ? string.Empty : Convert.ToString(reader["Email_Jefe"]);
                            usuarioSKFET.Is_Jefe = reader["Is_Jefe"] == null ? false : Convert.ToBoolean(reader["Is_Jefe"]);
                            usuarioSKFET.Is_RRHH = reader["Is_RRHH"] == null ? false : Convert.ToBoolean(reader["Is_RRHH"]);
                        }
                    }

                    conn.Close();
                }
            }

            return usuarioSKFET;
        }

        public void SolicitarVacacionesBD(SolicitudVacacionET solicitudVacacion)
        {
            using (ConnectionDB conn = new ConnectionDB())
            {
                using (SqlCommand cmd = new SqlCommand("FEXT_SP_SOLICITAR_VACACIONES", conn.connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CH_PERSONAL_ID", solicitudVacacion.Personal_ID);
                    cmd.Parameters.AddWithValue("@CH_NRO_DOCUMENTO", solicitudVacacion.Nro_Documento);
                    cmd.Parameters.AddWithValue("@VC_NOMBRES", solicitudVacacion.Nombres);
                    cmd.Parameters.AddWithValue("@VC_APELLIDO_PATERNO", solicitudVacacion.Apellido_Paterno);
                    cmd.Parameters.AddWithValue("@VC_APELLIDO_MATERNO", solicitudVacacion.Apellido_Materno);
                    cmd.Parameters.AddWithValue("@VC_EMAIL", solicitudVacacion.Email);

                    cmd.Parameters.AddWithValue("@CH_PERSONAL_ID_JEFE", solicitudVacacion.Personal_ID_Jefe);
                    cmd.Parameters.AddWithValue("@CH_NRO_DOCUMENTO_JEFE", solicitudVacacion.Nro_Documento_Jefe);
                    cmd.Parameters.AddWithValue("@VC_NOMBRES_JEFE", solicitudVacacion.Nombres_Jefe);
                    cmd.Parameters.AddWithValue("@VC_APELLIDO_PATERNO_JEFE", solicitudVacacion.Apellido_Paterno_Jefe);
                    cmd.Parameters.AddWithValue("@VC_APELLIDO_MATERNO_JEFE", solicitudVacacion.Apellido_Materno_Jefe);
                    cmd.Parameters.AddWithValue("@VC_EMAIL_JEFE", solicitudVacacion.Email_Jefe);

	                cmd.Parameters.AddWithValue("@IN_NRO_DIAS", solicitudVacacion.Nro_Dias);
                    cmd.Parameters.AddWithValue("@DT_FECHA_INICIO", solicitudVacacion.FechaInicio);
                    cmd.Parameters.AddWithValue("@DT_FECHA_FIN", solicitudVacacion.FechaFin);

                    conn.Open();

                    conn.Close();
                }
            }
        }

        
    }
}
