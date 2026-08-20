using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TallerToluca.EN;

namespace TallerToluca.DAL
{
    public class OrdenTrabajoDAL
    {
        public int CrearOrden(OrdenTrabajoEN orden)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"INSERT INTO OrdenesTrabajo (ClienteID, VehiculoID, EmpleadoID, KilometrajeEntrada, DescripcionDiagnostico, Observaciones) 
                                 VALUES (@ClienteID, @VehiculoID, @EmpleadoID, @KM, @Diagnostico, @Observaciones)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ClienteID", orden.ClienteID);
                cmd.Parameters.AddWithValue("@VehiculoID", orden.VehiculoID);
                cmd.Parameters.AddWithValue("@EmpleadoID", orden.EmpleadoID);
                cmd.Parameters.AddWithValue("@KM", orden.KilometrajeEntrada);
                cmd.Parameters.AddWithValue("@Diagnostico", orden.DescripcionDiagnostico);
                cmd.Parameters.AddWithValue("@Observaciones", (object)orden.Observaciones ?? DBNull.Value);
                return cmd.ExecuteNonQuery();
            }
        }

        public List<OrdenTrabajoEN> ConsultarTodas()
        {
            List<OrdenTrabajoEN> lista = new List<OrdenTrabajoEN>();
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"SELECT OrdenID, FechaCreacion, ClienteID, VehiculoID, EmpleadoID, Estado, KilometrajeEntrada, DescripcionDiagnostico, Observaciones 
                                 FROM OrdenesTrabajo ORDER BY OrdenID DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new OrdenTrabajoEN
                    {
                        OrdenID = reader.GetInt32(0),
                        FechaCreacion = reader.GetDateTime(1),
                        ClienteID = reader.GetInt32(2),
                        VehiculoID = reader.GetInt32(3),
                        EmpleadoID = reader.GetInt32(4),
                        Estado = reader.GetString(5),
                        KilometrajeEntrada = reader.GetInt32(6),
                        DescripcionDiagnostico = reader.GetString(7),
                        Observaciones = reader.IsDBNull(8) ? "" : reader.GetString(8)
                    });
                }
            }
            return lista;
        }

        public bool MecanicoTieneOrdenActiva(int empleadoID)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = "SELECT COUNT(*) FROM OrdenesTrabajo WHERE EmpleadoID = @EID AND Estado IN ('Pendiente', 'En Proceso')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EID", empleadoID);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public string ObtenerEstadoOrden(int ordenID)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = "SELECT Estado FROM OrdenesTrabajo WHERE OrdenID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", ordenID);
                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : string.Empty;
            }
        }

        public int ActualizarEstado(int ordenID, string nuevoEstado)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = "UPDATE OrdenesTrabajo SET Estado = @Estado WHERE OrdenID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Estado", nuevoEstado);
                cmd.Parameters.AddWithValue("@ID", ordenID);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
