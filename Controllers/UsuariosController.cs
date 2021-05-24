using ApiTienda.Models;
using ApiTienda.Repositories;
using Microsoft.AspNetCore.Authorization;
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
    public class UsuariosController : ControllerBase
    {
        RepositoryUsuario repo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        public UsuariosController(RepositoryUsuario repo)
        {
            this.repo = repo;
        }

        #region GET
        /// <summary>
        /// Listado de usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Usuario>> ListaUsuario()
        {
            return this.repo.GetUsuarios();
        }

        /// <summary>
        /// Buscar usuario, esta con seguridad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult<Usuario> BuscarUsuario(int id)
        {
            return this.repo.BuscarUsuario(id);
        }

        /// <summary>
        /// Paginar de dos en dos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public ActionResult<Object> OrdenarUsers()
        {
            return this.repo.OrdenacionUsuarios();
        }

        [HttpGet]
        [Route("[action]/{nombre}/{id}")]
        public ActionResult<Boolean> UsuarioEnBDD(string nombre, int id)
        {
            Usuario u = this.repo.ExisteUsuario(nombre, id);
            if(u != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region POST/PUT
        /// <summary>
        /// Crear un nuevo usuario con los 
        /// parametros enviados
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="pass"></param>
        /// <param name="edad"></param>
        /// <param name="salud"></param>
        /// <param name="favham"></param>
        /// <param name="favape"></param>
        /// <param name="favvin"></param>
        /// <param name="cesta"></param>
        /// <param name="telefono"></param>
        /// <param name="correo"></param>
        /// <param name="rrss"></param>
        /// <param name="rol"></param>
        /// <param name="hora"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public ActionResult<List<Usuario>> NuevoUsuario(string nombre, 
            string pass, int edad, string salud, string favham, string favape
            , string favvin, int cesta, int telefono, string correo, string rrss,
            string rol, string hora)
        {
            this.repo.InsertarUsuario(nombre, pass, edad, salud, favham, favape
                , favvin, cesta, telefono, correo, rrss, rol, hora);
            return this.repo.GetUsuarios();
        }

        /// <summary>
        /// Modificar usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="pass"></param>
        /// <param name="edad"></param>
        /// <param name="salud"></param>
        /// <param name="favham"></param>
        /// <param name="favape"></param>
        /// <param name="favvin"></param>
        /// <param name="cesta"></param>
        /// <param name="telefono"></param>
        /// <param name="correo"></param>
        /// <param name="rrss"></param>
        /// <param name="rol"></param>
        /// <param name="hora"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public ActionResult<Usuario> ModificarUsuario(int id, string nombre, 
            string pass, int edad, string salud, string favham, string favape
            , string favvin, int cesta, int telefono, string correo, string rrss,
            string rol, string hora)
        {
            this.repo.ModificarUsuario(id, nombre, pass, edad, salud, favham, favape
                , favvin, cesta, telefono, correo, rrss, rol, hora);
            return this.repo.BuscarUsuario(id);
        }

        /// <summary>
        /// Añadir hamburguesa a la lista de favoritos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public ActionResult<Usuario> FavoritosHamburguesas(int id, string nombre)
        {
            this.repo.AñadirFavoritoHam(id, nombre);
            return this.repo.BuscarUsuario(id);
        }

        /// <summary>
        /// Añadir aperitivo a la lista de favoritos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public ActionResult<Usuario> FavoritosAperitivos(int id, string nombre)
        {
            this.repo.AñadirFavoritoApe(id, nombre);
            return this.repo.BuscarUsuario(id);
        }

        /// <summary>
        /// Añadir vino a la lista de favoritos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public ActionResult<Usuario> FavoritosVinos(int id, string nombre)
        {
            this.repo.AñadirFavoritoVin(id, nombre);
            return this.repo.BuscarUsuario(id);
        }

        /// <summary>
        /// Añadir Redes Sociales a la lista
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public ActionResult<Usuario> CambiarRRSS(int id, string nombre)
        {
            this.repo.AñadirRRSS(id, nombre);
            return this.repo.BuscarUsuario(id);
        }

        /// <summary>
        /// Añadir a la cesta
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public ActionResult<Usuario> ModificarCesta(int id, int cantidad)
        {
            this.repo.AñadirCesta(id, cantidad);
            return this.repo.BuscarUsuario(id);
        }

        /// <summary>
        /// Cambiar rol
        /// 1. Administrador
        /// 2. Tatuados
        /// 3. Cliente
        /// 4. Usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nrol"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public ActionResult<Usuario> CambiarRolUsuario(int id, int nrol)
        {
            this.repo.CambiarRol(id, nrol);
            return this.BuscarUsuario(id);
        }

        /// <summary>
        /// Modificar contraseña, solo si confirmar con
        /// administrador para poder cambiar la contraseña,
        /// introducir identificador 
        /// </summary>
        /// <param name="confirmar"></param>
        /// <param name="id"></param>
        /// <param name="nuevapass"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public ActionResult<Usuario> ModificarPass(string confirmar
            , int id, string nuevapass)
        {
            Usuario u = this.repo.BuscarUsuario(id);
            if(confirmar == "administrador")
            {
                this.repo.CambiarContraseña(id, nuevapass);
            }
            return u;
        }


        #endregion

        #region DELETE

        /// <summary>
        /// Eliminar un usuario por identificador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]")]
        public ActionResult<List<Usuario>> EliminarUsuario(int id)
        {
            this.repo.EliminarUsuario(id);
            return this.repo.GetUsuarios();
        }

        #endregion


    }
}
