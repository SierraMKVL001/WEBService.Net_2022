using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contratos;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Repositorios
{
    public class DAlumno : IAlumno
    {
        public Alumno alumno = new Alumno();
        public void Actualizar(Alumno alumno)
        {
            
            string sql = ConfigurationManager.ConnectionStrings["InstitutoConecction"].ConnectionString;
            string query = $"actualizarAlumnos";
            using (SqlConnection con = new SqlConnection(sql))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IDed", alumno.ID);
                cmd.Parameters.AddWithValue("@nombre", alumno.Nombre);
                cmd.Parameters.AddWithValue("@primer", alumno.PrimerApellido);
                cmd.Parameters.AddWithValue("@segundo", alumno.SegundoApellido);
                cmd.Parameters.AddWithValue("@corr", alumno.Correo);
                cmd.Parameters.AddWithValue("@tel", alumno.Telefono);
                cmd.Parameters.AddWithValue("@fNac", alumno.FechaNacimiento);
                cmd.Parameters.AddWithValue("@curp", alumno.CURP);
                cmd.Parameters.AddWithValue("@sMen", alumno.SueldoMensual);
                cmd.Parameters.AddWithValue("@idEO", alumno.IdEstadoOrig);
                cmd.Parameters.AddWithValue("@idES", alumno.IdEstatus);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Agregar(Alumno alumno)
        {
            int idAlumnoN = 0;
            string sql = ConfigurationManager.ConnectionStrings["InstitutoConecction"].ConnectionString;
            string query = $"agregarAlumnos";
            using (SqlConnection con = new SqlConnection(sql))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", alumno.Nombre);
                cmd.Parameters.AddWithValue("@primer", alumno.PrimerApellido);
                cmd.Parameters.AddWithValue("@segundo", alumno.SegundoApellido);
                cmd.Parameters.AddWithValue("@corr", alumno.Correo);
                cmd.Parameters.AddWithValue("@tel", alumno.Telefono);
                cmd.Parameters.AddWithValue("@fNac", alumno.FechaNacimiento);
                cmd.Parameters.AddWithValue("@curp", alumno.CURP);
                cmd.Parameters.AddWithValue("@sMen", alumno.SueldoMensual);
                cmd.Parameters.AddWithValue("@idEO", alumno.IdEstadoOrig);
                cmd.Parameters.AddWithValue("@idES", alumno.IdEstatus);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public List<Alumno> Consultar()
        {
            List<Alumno> _alumnos = new List<Alumno>();
            string sql = ConfigurationManager.ConnectionStrings["InstitutoConecction"].ConnectionString;
            string query = "select * from Alumnos";
            using (SqlConnection conn = new SqlConnection(sql))
            {
                SqlCommand comando = new SqlCommand(query, conn);
                comando.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    _alumnos.Add(
                        new Alumno()
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            Nombre = reader["nombre"].ToString(),
                            PrimerApellido = reader["primerApellido"].ToString(),
                            SegundoApellido = reader["segundoApellido"].ToString(),
                            Correo = reader["correo"].ToString(),
                            Telefono = reader["telefono"].ToString(),
                            FechaNacimiento =Convert.ToDateTime( reader["fechaNacimiento"]),
                            CURP = reader["curp"].ToString(),
                            SueldoMensual = DBNull.Value.Equals(reader["sueldoMensual"]) ? 0 : Convert.ToDecimal( reader["sueldoMensual"]),
                            IdEstadoOrig = Convert.ToInt32(reader["idEstadoOrigen"]),
                            IdEstatus = Convert.ToInt32(reader["idEstatus"]),
                        });
                }
                conn.Close();
            }
            return _alumnos;
        }

        public Alumno Consultar(int id)
        {
            string sql = ConfigurationManager.ConnectionStrings["InstitutoConecction"].ConnectionString;
            string query = $"consultasAlumnos";
            using (SqlConnection conn = new SqlConnection(sql))
            {
                SqlCommand comando = new SqlCommand(query, conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idAlum",id);
                conn.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    alumno.ID = Convert.ToInt32(reader["id"]);
                    alumno.Nombre = reader["nombre"].ToString();
                    alumno.PrimerApellido = reader["primerApellido"].ToString();
                    alumno.SegundoApellido = reader["segundoApellido"].ToString();
                    alumno.Correo = reader["correo"].ToString();
                    alumno.Telefono = reader["telefono"].ToString();
                    alumno.FechaNacimiento =Convert.ToDateTime(reader["fechaNacimiento"]);
                    alumno.CURP = reader["curp"].ToString();
                    alumno.SueldoMensual = DBNull.Value.Equals(reader["sueldoMensual"]) ? 0 : Convert.ToDecimal(reader["sueldoMensual"]);
                    alumno.IdEstadoOrig=Convert.ToInt32(reader["idEstadoOrigen"]);
                    alumno.IdEstatus = Convert.ToInt32(reader["idEstatus"]);
                }
                conn.Close();
            }
            return alumno;
        }

        public void Eliminar(int id)
        {
            string sql = ConfigurationManager.ConnectionStrings["InstitutoConecction"].ConnectionString;
            string query = $"eliminarAlumnos";
            using (SqlConnection con = new SqlConnection(sql))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idAl", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
