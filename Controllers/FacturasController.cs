using ApiTienda.Models;
using ApiTienda.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        RepositoryFactura repo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        public FacturasController(RepositoryFactura repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Factura>> GetFactura()
        {
            return this.repo.GetFacturas();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("[action]/{id}")]
        public ActionResult<Factura> BuscarFactura(int id)
        {
            return this.repo.BuscarFactura(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fa"></param>
        [HttpPost]
        public void NuevaFactura(Factura fa)
        {
            this.repo.InsertarFactura(fa.Producto, fa.Cantidad
                , fa.Empleado, fa.Total);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fa"></param>
        [HttpPut]
        public void ModificarFactura(Factura fa)
        {
            this.repo.ModificarFactura(fa.Id,
                fa.Producto, fa.Cantidad
                , fa.Empleado, fa.Total);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public void EliminarFactura(int id)
        {
            this.repo.EliminarFactura(id);
        }
        
    }
}
