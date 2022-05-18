using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ComprasMosal.BL.Models
{
    public class Factura
    {
        public int idFactura { get; set; }
        public int idProveedor { get; set; }
        public string Correlativo { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int Estado { get; set; }
        public int UsuarioCreacion { get; set; }
        public int UsuarioModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
