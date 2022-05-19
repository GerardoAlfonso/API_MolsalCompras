using API_ComprasMosal.BL.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ComprasMosal.DAL
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() { }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
        public DbContext DbContext { set; get; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vw_ListadoCompras>()
                .HasNoKey()
                .ToView("Vw_ListadoCompras");
            modelBuilder.Entity<Vw_DetalleCompra>()
                .HasNoKey()
                .ToView("Vw_DetalleCompra");
        }

        //Auth
        public DbSet<Usuario>Usuario { get; set; }
        public DbSet<Factura>Factura { get; set; }
        public DbSet<DetalleFactura>DetalleFactura { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Vw_ListadoCompras> Vw_ListadoCompras { get; set; }
        public DbSet<Vw_DetalleCompra> Vw_DetalleCompra { get; set; }

        //public DbSet<Bodega> Bodega { get; set; }
        //public DbSet<Catalogo> Catalogo { get; set; }
        //public DbSet<CatalogoDetalle> CatalogoDetalle { get; set; }
        //public DbSet<Directorio> Directorio { get; set; }
        //public DbSet<Existencia> Existencia { get; set; }
        //public DbSet<Kardex> Kardex { get; set; }
        //public DbSet<Producto> Producto { get; set; }





    }
}
