using API_ComprasMosal.BL.Models;
using API_Delivery.BL.DTO.Request;
using API_Delivery.BL.DTO.Response;
using API_Delivery.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Delivery.BL.DAO
{
    public interface UsuarioDAO : CRUD<Usuario>
    {
        void Desactivar(long? IdUsuario);
        void Activar(long? IdUsuario);
        void ActualizarInfo(Usuario entity);
        Usuario? LogIn(LogInDTO usuarios);
        Directorio getUserInfoDir(string UserName);

    }
}
