using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ComprasMosal.BL.DTO
{
    public class LogInDTO
    {
        public string Token { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public string NombreUsuario { get; set; }

    }
}
