using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurFeEntidades
{
    public class ClienteModel
    {
        public int? id { get; set; } //
        public string? razon_social { get; set; }//
        public string? condicion_iva { get; set; }//
        public int id_condicion_iva {  get; set; }//
        public string? tipo_factura { get; set; }//
        public int id_tipo_factura { get; set; }//
        public string? cuit {  get; set; }//
        public string? domicilio { get; set; }//
        public string? localidad { get; set; }//
        public string? provincia {  get; set; }//
        public int id_provincia { get; set; }//
        public int id_localidad { get; set; }//
        public string? cp { get; set; } //
        public string? telefono { get; set; }//
        public bool anulado { get; set; }//
        public int id_tipo_documento { get; set;  }//
        public string? documento { get; set; }//
        public int dni { get; set; }    //
        public string? email { get; set; }
        public string? barrio { get; set; }
    }
}
