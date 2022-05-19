using API_ComprasMosal.BL.DAO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ComprasMosal.Controllers
{
    [ApiController]
    [EnableCors("AllowOrigin")]
    [Route("[controller]")]
    //[Authorize]
    public class ComprasController : ControllerBase
    {
        private readonly UsuarioDAO usuarioDAO;
        public ComprasController(UsuarioDAO userDAO)
        {
            usuarioDAO = userDAO;
        }
    }
}
