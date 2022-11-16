using API_ComprasMosal.DAL;
using API_Delivery.BL.DAO;
using API_Delivery.BL.Models;
using System.Collections.Generic;
using System.Linq;

namespace API_Delivery.BL.Implement
{
    public class ArticuloImplement : ArticuloDAO
    {
        private readonly ApplicationDBContext context;

        public ArticuloImplement(ApplicationDBContext context)
        {
            this.context = context;
        }

        public int Create(Articulo entity)
        {
            context.Articulo.Add(entity);
            context.SaveChanges();
            return entity.idArticulo;
        }

        public void Delete(Articulo entity)
        {
            Articulo DBEntity = context.Articulo.FirstOrDefault(e => e.idArticulo == entity.idArticulo);
            DBEntity.Estado = 0;
            context.SaveChanges();
        }

        public IEnumerable<Articulo> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public List<Articulo> GetAllActive()
        {
            return context.Articulo.Where(e => e.Estado == 1).ToList();
        }

        public Articulo GetById(long Id)
        {
            return context.Articulo.FirstOrDefault(e => e.idArticulo == Id);
        }

        public void Update(Articulo DBEntity, Articulo entity)
        {
            DBEntity.idArticulo = entity.idArticulo;
            DBEntity.idArticulo = entity.idArticulo;
            DBEntity.Nombre = entity.Nombre;
            DBEntity.Descripción = entity.Descripción;
            DBEntity.Existencia = entity.Existencia;
            DBEntity.precio = entity.precio;
            DBEntity.Estado = entity.Estado;
            context.SaveChanges();
        }
    }
}
