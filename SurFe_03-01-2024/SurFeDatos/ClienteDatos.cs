﻿    using System;
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
                            emp.cp = Convert.ToString(reader["cp"]);
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
        public static int Insert(ClienteModel e)
        {
            int idClienteCreado = 0;
            string conString = System.Configuration.ConfigurationManager.
            ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("InsertSurfe", connection);
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
                if (e.condicion_iva != null)
                    command.Parameters.AddWithValue("@idCondicionIVA", e.condicion_iva);
                if (e.condicion_iva != null)
                    command.Parameters.AddWithValue("@tipo_factura", e.tipo_factura);
                if (e.cuit != null)
                    command.Parameters.AddWithValue("@cuit", e.cuit);
                if (e.domicilio != null)
                    command.Parameters.AddWithValue("@domicilio", e.domicilio);
                if (e.localidad != null)
                    command.Parameters.AddWithValue("@localidad", e.localidad);
                if (e.provincia != null)
                    command.Parameters.AddWithValue("@provincia", e.provincia);
                if (e.cp != null)
                    command.Parameters.AddWithValue("@cp", e.cp);
                if (e.telefono != null)
                    command.Parameters.AddWithValue("@telefono", e.telefono);
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

    }
}

