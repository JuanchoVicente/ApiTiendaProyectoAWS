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
    /// Controladora citas
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        RepositoryCita repo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        public CitasController(RepositoryCita repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Lista
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Cita>> GetCitas()
        {
            return this.repo.GetCitas();
        }

        /// <summary>
        /// Buscar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("[action]/{id}")]
        public ActionResult<Cita> BuscarCita(int id)
        {
            return this.repo.BuscarCita(id);
        }

        /// <summary>
        /// Crear
        /// </summary>
        /// <param name="ci"></param>
        [HttpPost]
        public void NuevaCita(Cita ci)
        {
            this.repo.InsertarCita(ci.Tatuaje, ci.IdUsuario
                , ci.Tatuador, ci.Fecha, ci.Comentarios);
        }

        /// <summary>
        /// Modificar
        /// </summary>
        /// <param name="ci"></param>
        [HttpPut]
        public void ModificarCita(Cita ci)
        {
            this.repo.ModificarCita(ci.Id, ci.Tatuaje, ci.IdUsuario
                , ci.Tatuador, ci.Fecha, ci.Comentarios);
        }

        /// <summary>
        /// Eliminar
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public void EliminarCita(int id)
        {
            this.repo.EliminarCita(id);
        }
        
    }
}
