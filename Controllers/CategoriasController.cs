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
    public class CategoriasController : ControllerBase
    {
        RepositoryCategoria repo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        public CategoriasController(RepositoryCategoria repo)
        {
            this.repo = repo;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Categoria>> GetCategorias()
        {
            return this.repo.GetCategorias();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("[action]/{id}")]
        public ActionResult<Categoria> BuscarCategoria(int id)
        {
            return this.repo.BuscarCategoria(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cate"></param>
        [HttpPost]
        public void NuevaCategoria(Categoria cate)
        {
            this.repo.InsertarCategoria(cate.Nombre);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cate"></param>
        [HttpPut]
        public void ModificarCategoria(Categoria cate)
        {
            this.repo.ModificarCategoria(cate.Id, cate.Nombre);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public void EliminarCategoria(int id)
        {
            this.repo.EliminarCategoria(id);
        }
        
    }
}
