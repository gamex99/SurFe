using SurFeDatos;
using SurFeEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurFeNegocio
{
    public class ClienteNegocio
    {
        public List<ClienteModel> Get(string filtro)
        {
            ClienteDatos obj = new ClienteDatos();
            return obj.Get(filtro);


        }
        public static int Insert(ClienteModel e)
        {
            if (String.IsNullOrEmpty(e.razon_social))
            {
                return 0;
            }
            if (String.IsNullOrEmpty(e.cuit))
            {
                return 0;
            }
           
            try
            {
                return ClienteDatos.Insert(e);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static bool Update(ClienteModel e)
        {
            if (String.IsNullOrEmpty(e.razon_social))
            {
                return false;
            }
            if (String.IsNullOrEmpty(e.cuit))
            {
                return false;
            }
            
            try
            {
                return ClienteDatos.Update(e);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
