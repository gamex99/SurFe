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


        //proveedores
        public static string razon_rosial;
        public static long cuit;
        public static string direccion;
        public static long tel;
        public static string correo;
        public static int idlocalidad;



        //proveedores

        //cargar factura
        public static string id_factura;
        //cargarfactura
    }
}
