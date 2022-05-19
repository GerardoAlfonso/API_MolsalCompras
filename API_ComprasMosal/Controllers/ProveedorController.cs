using API_ComprasMosal.BL.DAO;
using API_ComprasMosal.BL.DTO;
using API_ComprasMosal.BL.Models;
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
    public class ProveedorController : ControllerBase
    {
        private readonly ProveedorDAO proveedorDAO;

        public ProveedorController(ProveedorDAO _proveedorDAO)
        {
            proveedorDAO = _proveedorDAO;
        }


        [HttpGet]
        [Route("GetProveedores")]
        public IActionResult GetProveedores()
        {
            Reply rp = new Reply();
            try
            {
                IEnumerable<Proveedor> proveedor = proveedorDAO.GetAll();
                if(proveedor.Count() == 0)
                {
                    rp.Status = 0;
                    rp.Message = "No se encontro informacion de proveedores";
                    rp.Data = null;
                    return BadRequest(rp);
                }
                rp.Status = 1;
                rp.Data = proveedor;
                return Ok(rp);
            }
            catch (Exception ex)
            {
                rp.Status = 0;
                rp.Message = ex.Message;
                rp.Data = null;
                return BadRequest(rp);
            }
        }

        [HttpGet]
        [Route("GetResumenProveedores")]
        public IActionResult GetResumenProveedores()
        {
            Reply rp = new Reply();
            try
            {
                IEnumerable<Proveedor> proveedores = proveedorDAO.GetAll();
                if (proveedores.Count() == 0)
                {
                    rp.Status = 0;
                    rp.Message = "No se encontro informacion de proveedores";
                    rp.Data = null;
                    return BadRequest(rp);
                }

                List<Proveedor> LProveedor = proveedores.ToList();
                List<ResumenProveedores> resumen = new List<ResumenProveedores>();

                foreach(var item in proveedores)
                {
                    ResumenProveedores obj = new ResumenProveedores();
                    obj.Nombre = item.Nombre;
                    obj.idProveedor = (int)item.idProveedor;
                    resumen.Add(obj);
                }


                rp.Status = 1;
                rp.Data = resumen;
                return Ok(rp);
            }
            catch (Exception ex)
            {
                rp.Status = 0;
                rp.Message = ex.Message;
                rp.Data = null;
                return BadRequest(rp);
            }
        }
    }
}

