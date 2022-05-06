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
    public class DItemISR : IItemISR
    {
        public List<ItemISR> Consultar()
        {
            List<ItemISR> list = new List<ItemISR>();
            string sql = ConfigurationManager.ConnectionStrings["InstitutoConecction"].ConnectionString;
            string query = "select * from TablaISR";
            using (SqlConnection conn = new SqlConnection(sql))
            {
                SqlCommand comando = new SqlCommand(query, conn);
                comando.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(
                        new ItemISR()
                        {
                            LimInf =Convert.ToDecimal(reader["LimInf"]),
                            LimSup =Convert.ToDecimal( reader["LimSup"]),
                            CuotaFija = Convert.ToDecimal(reader["CuotaFija"]),
                            PorExced = Convert.ToDecimal(reader["ExedLimInf"]),
                            Subcidio = Convert.ToDecimal(reader["Subsidio"])
                        });
                }
                conn.Close();
            }
            return list;
        }
    }
}
