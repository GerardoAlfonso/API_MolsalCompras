using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ComprasMosal.BL.DAO
{
    public interface CRUD<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(long Id);
        void Update(TEntity DBEntity, TEntity entity);
        void Delete(TEntity entity);
        int Create(TEntity entity);
    }
}
