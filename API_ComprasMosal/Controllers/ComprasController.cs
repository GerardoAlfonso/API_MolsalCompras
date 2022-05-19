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
        private readonly DetalleFacturaDAO detalleFacturaDAO;
        public ComprasController(FacturaDAO _facturaDAO, DetalleFacturaDAO _detalleFacturaDAO)
        {
            facturaDAO = _facturaDAO;
            detalleFacturaDAO = _detalleFacturaDAO;
        }
        [HttpGet]
        [Route("ListarCompras")]
        public IActionResult ListarCompras()
        {
            Reply rp = new Reply();
            try
            {
                IEnumerable<Factura> factura = facturaDAO.GetAll();
                if(factura.Count() == 0)
                {
                    rp.Status = 0;
                    rp.Message = "No hay informacion para mostrar";
                    return Ok(rp);
                }
                rp.Status = 1;
                rp.Data = factura;
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
                Factura factura = facturaDAO.GetById(Id);
                if(factura == null)
                {
                    rp.Status = 0;
                    rp.Message = "No se encontro la factura";
                    return Ok(rp);
                }
                IEnumerable<DetalleFactura> detalleFactura = detalleFacturaDAO.GetDetalleFactura(Id);
                if(detalleFactura.Count() == 0)
                {
                    rp.Status = 0;
                    rp.Message = "No se encontro informacion sobre el detalle de la compra";
                    return Ok(rp);
                }
                DetalleCompra.Factura = factura;
                DetalleCompra.DetalleCompra = detalleFactura;
                rp.Data = DetalleCompra;
                rp.Status = 1;
                return Ok(rp);
            }
            catch(Exception ex)
            {
                rp.Status = 0;
                rp.Message = ex.Message;
                return BadRequest(rp);
            }
        }
    }
}
