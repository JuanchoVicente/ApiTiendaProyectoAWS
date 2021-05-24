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
    public class MaterialController : ControllerBase
    {
        RepositoryMaterial repo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        public MaterialController(RepositoryMaterial repo)
        {
            this.repo = repo;
        }

        #region GET
            /// <summary>
            /// Lista de materiales
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            public ActionResult<List<Material>> Materiales()
            {
                return this.repo.GetMateriales();
            }

            /// <summary>
            /// Buscar material por identificador
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            [HttpGet]
            [Route("[action]/{id}")]
            public ActionResult<Material> BuscarMaterial(int id)
            {
                return this.repo.BuscarMaterial(id);
            }
        
            /// <summary>
            /// Buscar materiales por nombre
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            [Route("[action]")]
            public ActionResult<List<Material>> BuscarMaterialNombre(string nombre)
            {
                return this.repo.BuscarMaterialNombre(nombre);
            }
        
            /// <summary>
            /// Buscar materiales por categoria
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            [Route("[action]")]
            public ActionResult<List<Material>> BuscarMaterialCategoria(int idcategoria)
            {
                return this.repo.BuscarMaterialCategoria(idcategoria);
            }
        
            /// <summary>
            /// Buscar materiales por precio
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            [Route("[action]")]
            public ActionResult<List<Material>> BuscarMaterialPrecio(int precio)
            {
                return this.repo.BuscarMaterialPrecio(precio);
            }

            /// <summary>
            /// Filtrar el precio por una cantidad
            /// y el mayor primero
            /// </summary>
            /// <param name="precio"></param>
            /// <returns></returns>
            [HttpGet]
            [Route("[action]")]
            public ActionResult<List<Material>> FiltrarPrecioMas(int precio)
            {
                return this.repo.FiltrarPrecioMas(precio);
            }
        
            /// <summary>
            /// Filtrar el precio por una cantidad 
            /// y el mas bajo primero
            /// </summary>
            /// <param name="precio"></param>
            /// <returns></returns>
            [HttpGet]
            [Route("[action]")]
            public ActionResult<List<Material>> FiltrarPrecioMenor(int precio)
            {
                return this.repo.FiltrarPrecioMenor(precio);
            }



        #endregion

        #region POST
        
        /// <summary>
        /// Se crea un nuevo material a partir de los datos
        /// introducidos
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public ActionResult<Material> NuevoMaterial(Material m)
        {
            this.repo.NuevoMaterial(m.Nombre, m.Precio, m.Descripcion
                , m.Imagen, m.Id);
            return this.repo.BuscarMaterial(m.Id);
        }

        #endregion

        #region PUT

        /// <summary>
        /// Modifica un material
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public ActionResult<Material> ModificarMaterial(Material m)
        {
            this.repo.ModificarMaterial(m.Id, m.Nombre, m.Precio, m.Descripcion
                , m.Imagen, m.Id);
            return this.repo.BuscarMaterial(m.Id);
        }

        /// <summary>
        /// Cambia el precio de un material
        /// </summary>
        /// <param name="id"></param>
        /// <param name="precio"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public ActionResult<Material> CambiarPrecio(int id, int precio)
        {
            this.repo.CambiarPrecioMaterial(id, precio);
            return this.repo.BuscarMaterial(id);

        }

        /// <summary>
        /// Sube el precio de una misma categoria
        /// </summary>
        /// <param name="precio"></param>
        /// <param name="idcategoria"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public ActionResult<List<Material>> SubirPreciosCategoria(int precio, int idcategoria)
        {
            this.repo.SubirPrecioPorCategoria(precio, idcategoria);
            return this.repo.BuscarMaterialCategoria(idcategoria);
        }

        /// <summary>
        /// Cambia la descripcion de un material
        /// </summary>
        /// <param name="id"></param>
        /// <param name="descr"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public ActionResult<Material> CambiarDescripcion(int id, string descr)
        {
            this.repo.ModificarDescripcion(id, descr);
            return this.repo.BuscarMaterial(id);
        }
        
        /// <summary>
        /// Añade informacion a la descripcion de un material
        /// </summary>
        /// <param name="id"></param>
        /// <param name="descr"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public ActionResult<Material> AddDescripcion(int id, string descr)
        {
            this.repo.AddModificarDescripcion(id, descr);
            return this.repo.BuscarMaterial(id);
        }

        #endregion

        #region DELETE
        
        /// <summary>
        /// Eliminar un material por idenficador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]")]
        public ActionResult<List<Material>> EliminarMaterial(int id)
        {
            this.repo.EliminarMaterial(id);
            return this.repo.GetMateriales();
        }
        #endregion

    }
}
