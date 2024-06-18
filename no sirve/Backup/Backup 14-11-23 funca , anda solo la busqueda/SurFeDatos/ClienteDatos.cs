    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SurFeEntidades;

namespace SurFeDatos
{
    public class ClienteDatos
    {
        public  List<ClienteModel> Get(string filtro)
        {
            List<ClienteModel> list = new List<ClienteModel>();
            string conString = System.Configuration.ConfigurationManager.
            ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand("GetSurFe", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
        
                    command.Parameters.AddWithValue("@filtro", filtro);
            
                try
                {
                    //que es esto para pp3?
                    //pp2 ok
                    // bueno mira para las busquedas te aconsejo un datatable pero aguanta q vemos este error despues
                    //te muestro la otra manera de hacer
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ClienteModel emp = new ClienteModel();

                        emp.id = Convert.ToInt32(reader["id_cliente"]);
                        emp.razon_social = Convert.ToString(reader["razon_social"]);
                        emp.condicion_iva = Convert.ToString(reader["condicionIVA"]);
                        emp.tipo_factura = Convert.ToString(reader["tipo_factura"]);
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
                    return list;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        
        }
    }
}

