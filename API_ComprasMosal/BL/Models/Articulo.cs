using System.ComponentModel.DataAnnotations;

namespace API_Delivery.BL.Models
{
    public class Articulo
    {
        [Key]
        public int idArticulo { get; set; }
        public string Nombre { get; set; }
        public string Descripción { get; set; }
        public int Existencia { get; set; }
        public double precio { get; set; }
        public int Estado { get; set; }


    }
}