using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SurFeEntidades;

namespace SurFeDatos
{
    public class SurFeDatos
    {
        public static List<Cliente> Get(Cliente e)
        {
            List<Cliente> list = new List<Cliente>();
            string conString = System.Configuration.ConfigurationManager.
            ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand("empleadosGet", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                if (e.id != null)
                    command.Parameters.AddWithValue("@id", e.id);
                if (e.razon_social != null)
                    command.Parameters.AddWithValue("@razon_social", e.razon_social);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Cliente emp = new Cliente();

                        emp.id = Convert.ToInt32(reader["id"]);
                        emp.razon_social = Convert.ToString(reader["razon_social"]);
                        emp.condicion_iva = Convert.ToString(reader["condicion_iva"]);
                        emp.tipo_factura = Convert.ToString(reader["tipo_facutra"]);
                        emp.cuit = Convert.ToString(reader["cuit"]);
                        if (reader["domicilio"].GetType() != typeof(DBNull))
                            emp.domicilio = Convert.ToString(reader["domicilio"]);
                        if (reader["localidad"].GetType() != typeof(DBNull))
                            emp.localidad = Convert.ToString(reader["localidad"]);
                        if (reader["provincia"].GetType() != typeof(DBNull))
                            emp.provincia = Convert.ToString(reader["provincia"]);
                        if (reader["cp"].GetType() != typeof(DBNull))
                            emp.cp = Convert.ToInt32(reader["cp"]);
                        if (reader["telefono"].GetType() != typeof(DBNull))
                            emp.telefono = Convert.ToString(reader["telefono"]);

                        
                        list.Add(emp);
                    }
                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return list;
        }
    }
}

