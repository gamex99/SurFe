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
    }
}
