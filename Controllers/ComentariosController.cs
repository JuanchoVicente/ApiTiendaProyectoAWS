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
    public class ComentariosController : ControllerBase
    {
        RepositoryComentario repo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        public ComentariosController(RepositoryComentario repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Lista
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Comentario>> GetComentarios()
        {
            return this.repo.GetComentarios();
        }

        /// <summary>
        /// Buscar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("[action]/{id}")]
        public ActionResult<Comentario> BuscarComentarios(int id)
        {
            return this.repo.BuscarComentario(id);
        }
        
        /// <summary>
        /// Nuevo
        /// </summary>
        /// <param name="co"></param>
        [HttpPost]
        public void NuevaComentarios(Comentario co)
        {
            this.repo.InsertarComentario(co.Nombre, co.IdUsuario, co.Fecha);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="co"></param>
        [HttpPut]
        public void ModificarComentario(Comentario co)
        {
            this.repo.ModificarComentario(
                co.Id, co.Nombre, co.IdUsuario, co.Fecha);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public void EliminarComentario(int id)
        {
            this.repo.EliminarComentario(id);
        }
        
    }
}
