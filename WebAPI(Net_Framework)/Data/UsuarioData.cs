using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAPI_Net_Framework_.Models;

namespace WebAPI_Net_Framework_.Data
{
    public class UsuarioData
    {
        public static bool Registrar (Usuario oUsuario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@documentoidentidad", oUsuario.DocumentoIdentidad);
                cmd.Parameters.AddWithValue("@nombres", oUsuario.Nombres);
                cmd.Parameters.AddWithValue("@telefono", oUsuario.Telefono);
                cmd.Parameters.AddWithValue("@correo", oUsuario.correo);
                cmd.Parameters.AddWithValue("@ciudad", oUsuario.Ciudad);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }
        public static bool Modificar(Usuario oUsuario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idusuario", oUsuario.IdUsuario);
                cmd.Parameters.AddWithValue("@documentoidentidad", oUsuario.DocumentoIdentidad);
                cmd.Parameters.AddWithValue("@nombres", oUsuario.Nombres);
                cmd.Parameters.AddWithValue("@telefono", oUsuario.Telefono);
                cmd.Parameters.AddWithValue("@correo", oUsuario.correo);
                cmd.Parameters.AddWithValue("@ciudad", oUsuario.Ciudad);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static List<Usuario> listar() 
        {
           List<Usuario> oListaUsuario = new List<Usuario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaUsuario.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["idusuario"]),
                                DocumentoIdentidad = dr["DocumentoIdentidad"].ToString(),
                                Nombres = dr["Nombres"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                correo = dr["correo"].ToString(),
                                Ciudad = dr["Ciudad"].ToString(),
                                FechaRegistro = Convert.ToDateTime(dr[""].ToString())

                            });
                        }

                    }
                    return oListaUsuario;

                }
                catch (Exception ex)
                {
                    return oListaUsuario;
                }
            }

        }


    }
}