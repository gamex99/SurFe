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
               // SqlCommand command = new SqlCommand("GetSurFe", connection); //GetSurfeNuevo
                SqlCommand command = new SqlCommand("GetSurFeFinal", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
        
                    command.Parameters.AddWithValue("@filtro", filtro);
            
                try
                {
                    
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ClienteModel emp = new ClienteModel();

                        emp.id = Convert.ToInt32(reader["id_cliente"]);
                        emp.razon_social = Convert.ToString(reader["razon_social"]);
                        emp.condicion_iva = Convert.ToString(reader["condicionIVA"]);
                        emp.id_condicion_iva = Convert.ToInt32(reader["idCondicionIVA"]);
                        emp.tipo_factura = Convert.ToString(reader["tipofactura"]);
                        emp.id_tipo_factura = Convert.ToInt32(reader["tipo_factura"]);
                        emp.cuit = Convert.ToString(reader["cuit"]);  
                        emp.domicilio = Convert.ToString(reader["domicilio"]);                     
                        emp.localidad = Convert.ToString(reader["localidad_loc"]);
                        emp.id_provincia = Convert.ToInt32(reader["provincia"]);
                        emp.provincia = Convert.ToString(reader["provincia_prov"]);
                        emp.id_localidad = Convert.ToInt32(reader["localidad"]);
                        emp.cp = Convert.ToString(reader["cp"]);
                  
                        emp.telefono = Convert.ToString(reader["telefono"]);
                       
                        emp.anulado = Convert.ToBoolean(reader["anulado"]);
                        emp.id_tipo_documento = Convert.ToInt32(reader["tipo_documento"]);
                        emp.documento = Convert.ToString(reader["documento"]);
                        emp.dni = Convert.ToInt32(reader["dni"]);
                        emp.email = Convert.ToString(reader["email"]);
                        emp.barrio = Convert.ToString(reader["barrio"]);
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
        public static int Insert(ClienteModel e)
        {
            int idClienteCreado = 0;
            string conString = System.Configuration.ConfigurationManager.
            ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("InsertSurfe", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
             
                if (e.razon_social != null)
                    command.Parameters.AddWithValue("@razon_social", e.razon_social);
                
                    command.Parameters.AddWithValue("@idCondicionIVA", e.id_condicion_iva);
              if (e.tipo_factura != null)  
                    command.Parameters.AddWithValue("@tipo_factura", e.id_tipo_factura);
                if (e.cuit != null)
                    command.Parameters.AddWithValue("@cuit", e.cuit);
                if (e.domicilio != null)
                    command.Parameters.AddWithValue("@domicilio", e.domicilio);
                    command.Parameters.AddWithValue("@localidad", e.id_localidad);
               
                    command.Parameters.AddWithValue("@provincia", e.id_provincia);
              
                    command.Parameters.AddWithValue("@cp", e.cp);
              
                    command.Parameters.AddWithValue("@telefono", e.telefono);
                    command.Parameters.AddWithValue("@anulado", e.anulado);
                    command.Parameters.AddWithValue("@tipo_documento", e.id_tipo_documento);
                command.Parameters.AddWithValue("@dni", e.dni);
                command.Parameters.AddWithValue("@barrio", e.barrio);
                command.Parameters.AddWithValue("@email", e.email);
                try
                {
                    connection.Open();
                    //Realizo el insert y obtengo el ID generado de la BD
                    idClienteCreado = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception)
                {
                    throw;
                }
                return idClienteCreado;
            }
        }
        public static bool Update(ClienteModel e)
        {
            
            string conString = System.Configuration.ConfigurationManager.
            ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("UpdateSurfe", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                /*
                @razon_social varchar(50),
                @idCondicionIVA int,
                @tipo_factura varchar(50),
                @cuit varchar(50),
                @domicilio varchar(50),
                localidad varchar(50),
                @provincia varchar(50),
                @cp int,
                @telefono varchar(50),
                @anulado bit
                */
                if (e.razon_social != null)
                    command.Parameters.AddWithValue("@razon_social", e.razon_social);

                command.Parameters.AddWithValue("@idCondicionIVA", e.id_condicion_iva);
                if (e.tipo_factura != null)
                    command.Parameters.AddWithValue("@tipo_factura", e.id_tipo_factura);
                if (e.cuit != null)
                    command.Parameters.AddWithValue("@cuit", e.cuit);
                if (e.domicilio != null)
                    command.Parameters.AddWithValue("@domicilio", e.domicilio);
                command.Parameters.AddWithValue("@localidad", e.id_localidad);

                command.Parameters.AddWithValue("@provincia", e.id_provincia);

                command.Parameters.AddWithValue("@cp", e.cp);

                command.Parameters.AddWithValue("@telefono", e.telefono);
                command.Parameters.AddWithValue("@anulado", e.anulado);
                command.Parameters.AddWithValue("@tipo_documento", e.id_tipo_documento);
                command.Parameters.AddWithValue("@dni", e.dni);
                command.Parameters.AddWithValue("@barrio", e.barrio);
                command.Parameters.AddWithValue("@email", e.email);
                try
                {
                    connection.Open();
                    //Realizo el update
                    command.ExecuteNonQuery();

                }
                catch (Exception)
                {
                    throw;
                }
                
            }
            return  true;
        }

    }
}

