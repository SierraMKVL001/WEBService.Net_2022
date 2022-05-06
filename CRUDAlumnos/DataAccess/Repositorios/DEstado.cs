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
    public class DEstado : IEstado
    {
        public List<Estado> Consultar()
        {
            List<Estado> lista = new List<Estado>();
            string sql = ConfigurationManager.ConnectionStrings["InstitutoConecction"].ConnectionString;
            string query = "select * from Estados";
            using (SqlConnection conn = new SqlConnection(sql))
            {
                SqlCommand comando = new SqlCommand(query, conn);
                comando.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(
                        new Estado()
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            Nombre = reader["nombre"].ToString(),
                            Curp = reader["curp"].ToString()
                        });
                }
                conn.Close();
            }
            return lista;
        }
    }
}
