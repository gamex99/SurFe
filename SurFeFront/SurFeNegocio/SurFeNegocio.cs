using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurFeDatos;
using SurFeEntidades;

namespace SurFeNegocio
{
    public class SurFeNegocio
    {
        public static List<Cliente> Get(Cliente e)
        {
            try
            {
                return SurFeDatos.SurFeDatos.Get(e);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
