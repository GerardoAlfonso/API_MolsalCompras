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
    //[Authorize]
    public class ComprasController : ControllerBase
    {
        private readonly FacturaDAO facturaDAO;
        private readonly Vw_ListadoComprasDAO listadoCompradDAO;
        private readonly Vw_DetalleCompraDAO detalleCompraDAO;
        private readonly DetalleFacturaDAO detalleFacturaDAO;
        public ComprasController(FacturaDAO _facturaDAO, DetalleFacturaDAO _detalleFacturaDAO, Vw_ListadoComprasDAO _Vw_listadoComprasDAO, Vw_DetalleCompraDAO _detalleCompraDAO)
        {
            facturaDAO = _facturaDAO;
            detalleFacturaDAO = _detalleFacturaDAO;
            listadoCompradDAO = _Vw_listadoComprasDAO;
            detalleCompraDAO = _detalleCompraDAO;
        }

        [HttpGet]
        [Route("ListarCompras")]
        public IActionResult ListarCompras()
        {
            Reply rp = new Reply();
            try
            {
                IEnumerable<Vw_ListadoCompras> listadoCompras= listadoCompradDAO.GetAll();
                if(listadoCompras.Count() == 0)
                {
                    rp.Status = 0;
                    rp.Message = "No hay informacion para mostrar";
                    return Ok(rp);
                }
                rp.Status = 1;
                rp.Data = listadoCompras;
                return Ok(rp);
            }
            catch(Exception ex)
            {
                rp.Status = 0;
                rp.Message = ex.Message;
                return BadRequest(rp);
            }
        }

        [HttpGet]
        [Route("DetalleCompra")]
        public IActionResult DetalleCompra([FromBody] int Id)
        {
            Reply rp = new Reply();
            DetalleCompraDTO DetalleCompra = new DetalleCompraDTO();
            try
            {
                //Validar si la factura existe
                Vw_ListadoCompras factura = listadoCompradDAO.GetById(Id);
                if (factura == null)
                {
                    rp.Status = 0;
                    rp.Message = "No se encontro la factura";
                    return Ok(rp);
                }
                // guardar informacion de factura en DTO
                DetalleCompra.Factura = factura;

                //obtener los detalles de la factura
                IEnumerable<Vw_DetalleCompra> detalleCompra = detalleCompraDAO.GetAll();
                if(detalleCompra.Count() == 0)
                {
                    rp.Status = 0;
                    rp.Data = DetalleCompra;
                    rp.Message = "No se encontro informacion sobre el detalle de la compra";
                    return Ok(rp);
                }

                //guardar detalle compra en DTO
                DetalleCompra.DetalleCompra = detalleCompra;
                rp.Data = DetalleCompra;
                rp.Status = 1;
                return Ok(rp);
            }
            catch(Exception ex)
            {
                rp.Status = 0;
                rp.Message = ex.Message;
                rp.Data = null;
                return BadRequest(rp);
            }
        }
    }
}
