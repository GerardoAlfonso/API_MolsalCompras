using API_ComprasMosal.BL.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ComprasMosal.DAL
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() { }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
        public DbContext DbContext { set; get; }


        //Auth
        public DbSet<Usuario> Usuario { get; set; }
        //public DbSet<Bodega> Bodega { get; set; }
        //public DbSet<Catalogo> Catalogo { get; set; }
        //public DbSet<CatalogoDetalle> CatalogoDetalle { get; set; }
        //public DbSet<DetalleFactura> DetalleFactura { get; set; }
        //public DbSet<Directorio> Directorio { get; set; }
        //public DbSet<Existencia> Existencia { get; set; }
        //public DbSet<Factura> Factura { get; set; }
        //public DbSet<Kardex> Kardex { get; set; }
        //public DbSet<Producto> Producto { get; set; }
        //public DbSet<Proveedor> Proveedor { get; set; }





    }
}
