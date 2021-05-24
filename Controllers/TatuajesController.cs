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
    public class TatuajesController : ControllerBase
    {
        RepositoryTatuaje repo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        public TatuajesController(RepositoryTatuaje repo)
        {
            this.repo = repo;
        }

        #region Metodos GET

            /// <summary>
            /// Mostrar los tatuajes
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            public ActionResult<List<Tatuaje>> GetTatuajes()
            {
                return this.repo.GetTatuajes();
            }

            /// <summary>
            /// Buscar un tatuaje por identificador
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            [HttpGet]
            [Route("{id}")]
            public ActionResult<Tatuaje> BuscarTatuaje(int id)
            {
                return this.repo.BuscarTatuaje(id);
            }

            /// <summary>
            /// Buscar tatuaje por nombre (que contenga el parametro)
            /// </summary>
            /// <param name="nombre"></param>
            /// <returns></returns>
            [HttpGet]
            [Route("[action]/{nombre}")]
            public ActionResult<List<Tatuaje>> BuscarTatuajeNombre(string nombre)
            {
                return this.repo.BuscarTatuajeNombre(nombre);
            }
        
            /// <summary>
            /// Buscar tatuaje por precio exacto
            /// </summary>
            /// <param name="precio"></param>
            /// <returns></returns>
            [HttpGet]
            [Route("[action]/{precio}")]
            public ActionResult<List<Tatuaje>> BuscarTatuajePrecio(int precio)
            {
                return this.repo.BuscarTatuajePrecio(precio);
            }

            /// <summary>
            /// Añadir un nuevo tatuaje
            /// </summary>
            /// <param name="t"></param>
            [HttpPost]
            public void NuevoTatuaje(Tatuaje t)
            {
                this.repo.NuevoTatuaje(t.Nombre, t.Autor, t.Tamaño
                    , t.Color, t.Precio, t.Imagen);
            }
                
            /// <summary>
            /// Lista de precios mayor que el introducido
            /// </summary>
            /// <param name="precio"></param>
            /// <returns></returns>
            [HttpGet]
            [Route("[action]/{precio}")]
            public ActionResult<List<Tatuaje>> PrecioMayor(int precio)
            {
                return this.repo.TatuajesMasPrecio(precio);
            }
        
            /// <summary>
            /// Lista de precios menor que el introducido
            /// </summary>
            /// <param name="precio"></param>
            /// <returns></returns>
            [HttpGet]
            [Route("[action]/{precio}")]
            public ActionResult<List<Tatuaje>> PrecioMenor(int precio)
            {
                return this.repo.TatuajesMenosPrecio(precio);
            }
                
            /// <summary>
            /// Filtrar entre un menor y un mayor precio
            /// </summary>
            /// <param name="min"></param>
            /// <param name="max"></param>
            /// <returns></returns>
            [HttpGet]
            [Route("[action]/{min}/{max}")]
            public ActionResult<List<Tatuaje>> EntrePrecios(int min, int max)
            {
                return this.repo.TatuajeEntrePrecios(min, max);
            }
        
            /// <summary>
            /// Filtrar por tamaño y precio
            /// </summary>
            /// <param name="size"></param>
            /// <param name="precio"></param>
            /// <returns></returns>
            [HttpGet]
            [Route("[action]/{min}/{max}")]
            public ActionResult<List<Tatuaje>> BuscarTamañaPrecio(string size, int precio)
            {
                return this.repo.TatuajesTamañoPrecio(size, precio);
            }

            /// <summary>
            /// Lista de tamaños sin repetir
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            [Route("[action]")]
            public ActionResult<List<String>> ListaTamaños()
            {
                return this.repo.ListaTamaños();
            }
        
            /// <summary>
            /// Lista de precios sin repetir
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            [Route("[action]")]
            public ActionResult<List<int>> ListaPrecios()
            {
                return this.repo.ListaPrecios();
            }
        #endregion

        #region Metodos PUT
            /// <summary>
            /// Modificar un tatuaje
            /// </summary>
            /// <param name="t"></param>
            [HttpPut]
            public void ModificarTatuaje(Tatuaje t)
            {
                this.repo.ModificarTatuaje(t.Id, t.Nombre, t.Autor, t.Tamaño
                    , t.Color, t.Precio, t.Imagen);
            }

            /// <summary>
            /// Cambiar precio de un tatuaje concreto
            /// </summary>
            /// <param name="id"></param>
            /// <param name="precio"></param>
            /// <returns></returns>
            [HttpPut]
            [Route("[action]")]
            public ActionResult<Tatuaje> CambiarPrecio(int id, int precio)
            {
                this.repo.CambiarPrecioTatuaje(id, precio);
                return this.repo.BuscarTatuaje(id);
            }

            /// <summary>
            /// Añadir precio del parametro al precio
            /// del tatuaje
            /// </summary>
            /// <param name="id"></param>
            /// <param name="precio"></param>
            [HttpPut]
            [Route("[action]")]
            public ActionResult<Tatuaje> SubirPrecio(int id, int precio)
            {
                this.repo.SubirPrecioTatuaje(id, precio);
                return this.repo.BuscarTatuaje(id);
            }

            /// <summary>
            /// Cambiar la imagen de un tatuaje concreto
            /// </summary>
            /// <param name="id"></param>
            /// <param name="img"></param>
            /// <returns></returns>
            [HttpPut]
            [Route("[action]")]
            public ActionResult<Tatuaje> CambiarImagen(int id, string img)
            {
                this.repo.CambiarImagenTatuaje(id, img);
                return this.repo.BuscarTatuaje(id);
            }

            /// <summary>
            /// Modificar el precio de una lista de tatuajes 
            /// en referencia a tener el mismo tamaño
            /// </summary>
            /// <param name="precio"></param>
            /// <param name="tamaño"></param>
            /// <returns></returns>
            [HttpPut]
            [Route("[action]")]
            public ActionResult<List<Tatuaje>> ModificarPrecioPorTamaño(
                int precio, string tamaño) 
            {
                this.repo.ModificarPrecioPorTamaño(precio, tamaño);
                return this.repo.BuscarTatuajePrecio(precio);
            }
        #endregion

        #region Metodos DELETE

            /// <summary>
            /// Eliminar tatuaje por identificador
            /// </summary>
            /// <param name="id"></param>
            [HttpDelete]
            public void EliminarTatuaje(int id)
            {
                this.repo.EliminarTatuaje(id);
            }

            /// <summary>
            /// Eliminar todos los tatuajes con el 
            /// precio indicado
            /// </summary>
            /// <param name="precio"></param>
            /// <returns></returns>
            [HttpDelete]
            [Route("[action]")]
            public ActionResult<List<Tatuaje>> EliminarVariosPorPrecio(int precio)
        {
            this.repo.EliminarTatusPrecio(precio);
            return this.repo.GetTatuajes();
        }
        #endregion
    }
}
