using API_ComprasMosal.BL.Models;
using API_Delivery.BL.Models;
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
            //modelBuilder.Entity<Vw_ListadoCompras>()
            //    .HasNoKey()
            //    .ToView("Vw_ListadoCompras");
            //modelBuilder.Entity<Vw_DetalleCompra>()
            //    .HasNoKey()
            //    .ToView("Vw_DetalleCompra");
        }

        //Auth
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Directorio> Directorio { get; set; }
        public DbSet<Articulo> Articulo { get; set; }



        //public DbSet<Bodega> Bodega { get; set; }
        //public DbSet<Catalogo> Catalogo { get; set; }
        //public DbSet<CatalogoDetalle> CatalogoDetalle { get; set; }
        //public DbSet<Directorio> Directorio { get; set; }
        //public DbSet<Existencia> Existencia { get; set; }
        //public DbSet<Kardex> Kardex { get; set; }
        //public DbSet<Producto> Producto { get; set; }





    }
}
