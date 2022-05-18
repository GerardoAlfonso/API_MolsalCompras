using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ComprasMosal.BL.Models
{
    public class CatalogoDetalle
    {

        public int IdDetalle { get; set; }
        public int idCatalogo { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
        public int UsuarioCreacion { get; set; }
        public int UsuarioModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
