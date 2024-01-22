using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurFeEntidades
{
    public class Producto
    {
        public int? id {  get; set; }
        public int? barcode { get; set; }
        public string? detalle {  get; set; }
        public int? stock { get; set; }
        public decimal? precio {  get; set; }
    }
}
