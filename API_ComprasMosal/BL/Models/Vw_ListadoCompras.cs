using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_ComprasMosal.BL.Models
{
    [Table("Vw_ListadoCompras")]
    public class Vw_ListadoCompras
    {
        
        [ForeignKey("idFactura")]
        public int? idFactura { get; set; }
        public string? Nombre { get; set; }
        public string Correlativo { get; set; }
        public DateTime? Fecha { get; set; }
        public double? Total { get; set; }
        public int? Estado { get; set; }
    }
}
