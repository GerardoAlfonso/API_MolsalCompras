using API_ComprasMosal.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ComprasMosal.BL.DAO
{
    public interface UsuarioDAO : CRUD<Usuario>
    {
        void Desactivar(long? IdUsuario);
        void Activar(long? IdUsuario);
        void ActualizarInfo(Usuario entity);
        int Create(Usuario usuario);
        void Delete(Usuario entity);
        void Update(Usuario DBEntity, Usuario entity);
        Usuario LogIn(Usuario usuarios);
        Usuario getUserInfo(string UserName);
        Usuario GetById(long Id);
        IEnumerable<Usuario> GetAll();

    }
}
