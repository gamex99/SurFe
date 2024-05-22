using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurFeFront
{
    public class ClaseCompartida
    {
        public static int categoria;
        public static int barcode;
        public static string detalle;
        public static int stock;
        public static decimal precio;
        public static int operador = 1;
        public static string carpetaTemp = Path.Combine(Path.GetTempPath(), "SurFeDatosTemp");


        //login

        public static string nombre;
        public static string apellido;
        public static string departamnto;
        public static int idDepartamento;
        //login 
    }
}
