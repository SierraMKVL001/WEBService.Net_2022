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
    public class DEstatus : IEstatus
    {
        public List<EstatusAlumnos> Consultar()
        {
            List<EstatusAlumnos> _Estatus = new List<EstatusAlumnos>();
            string sql = ConfigurationManager.ConnectionStrings["InstitutoConecction"].ConnectionString;
            string query = "select * from EstatusAlumnos";
            using (SqlConnection conn = new SqlConnection(sql))
            {
                SqlCommand comando = new SqlCommand(query, conn);
                comando.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    _Estatus.Add(
                        new EstatusAlumnos()
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            Clave = reader["Clave"].ToString(),
                            Nombre = reader["Nombre"].ToString()
                        });
                }
                conn.Close();
            }
            return _Estatus;
        }
    }
}
