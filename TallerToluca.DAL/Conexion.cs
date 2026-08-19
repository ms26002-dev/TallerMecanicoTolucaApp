using System;
using System.Data.SqlClient;

namespace TallerToluca.DAL
{
    public static class ConexionDAL
    {
        private static readonly string CadenaConexion =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TallerMecanicoToluca.DB;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection ObtenerConexion()
        {
            var conn = new SqlConnection(CadenaConexion);
            conn.Open();
            return conn;
        }
    }
}
