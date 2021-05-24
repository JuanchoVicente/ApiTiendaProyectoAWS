using ApiTienda.Data;
using ApiTienda.Helpers;
using ApiTienda.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Repositories
{
    public class RepositoryUsuario
    {
        TiendaContext context;

        public RepositoryUsuario(TiendaContext context)
        {
            this.context = context;
        }

        #region GET
        public List<Usuario> GetUsuarios()
        {
            return this.context.Usuarios.ToList();
        }


        public Usuario BuscarUsuario(int id)
        {
            return this.context.Usuarios.Where(x =>
            x.Id == id).FirstOrDefault();
        }
        public Usuario ExisteUsuario(string nombre, int idempleado)
        {
            Usuario u = this.context.Usuarios.SingleOrDefault(
                x => x.Nombre == nombre && x.Id == idempleado);
            return u;
        }

        public Object OrdenacionUsuarios()
        {
            var consulta = (from datos in this.context.Usuarios
                            orderby datos.Nombre ascending
                            select new
                            {
                                datos.Nombre,
                                datos.Rol
                            }).Skip(2).Take(2);
            return consulta;
        }

        #endregion

        #region POST/PUT
        public void InsertarUsuario(string nombreuser, string passuser
            , int edad, string salud, string favham, string favape
            , string favvin, int cesta, int telefono
            , string correo, string rrss, string rol, string hora)
        {
            var max = (from datos in this.context.Usuarios
                       select datos.Id).Max();
            Usuario usuario = new Usuario();
            usuario.Id = max + 1;
            usuario.Nombre = nombreuser;
            String salt = CypherService.GetSalt();
            usuario.Salt = salt;
            byte[] respuesta =
            CypherService.CifrarContenido(passuser, salt);
            usuario.Pass = respuesta;
            usuario.Edad = edad;
            usuario.Salud = salud;
            usuario.FavsTatuajes = "";
            usuario.Facturas = "";
            usuario.Citas = "";
            usuario.Cesta = cesta;
            usuario.Telefono = telefono;
            usuario.Correo = correo;
            usuario.RedesSociales = rrss;
            usuario.Rol = rol;
            usuario.Hora = hora;
            usuario.Comentarios = "";
            this.context.Usuarios.Add(usuario);
            this.context.SaveChanges();
        }
        
        public void ModificarUsuario(int idusuario, string nombreuser, string passuser
            , int edad, string salud, string favham, string favape
            , string favvin, int cesta, int telefono
            , string correo, string rrss, string rol, string hora)
        {
            Usuario usuario = this.BuscarUsuario(idusuario);
            usuario.Nombre = nombreuser;
            String salt = CypherService.GetSalt();
            usuario.Salt = salt;
            byte[] respuesta =
            CypherService.CifrarContenido(passuser, salt);
            usuario.Pass = respuesta;
            usuario.Edad = edad;
            usuario.Salud = salud;
            usuario.FavsTatuajes = "";
            usuario.Facturas = "";
            usuario.Citas = "";
            usuario.Cesta = cesta;
            usuario.Telefono = telefono;
            usuario.Correo = correo;
            usuario.RedesSociales = rrss;
            usuario.Rol = rol;
            usuario.Hora = hora;
            usuario.Comentarios = "";
            this.context.SaveChanges();
        }


        public void AñadirFavoritoHam(int id, string nombre)
        {
            Usuario u = this.BuscarUsuario(id);
            this.context.SaveChanges();
        }
        
        public void AñadirFavoritoApe(int id, string nombre)
        {
            Usuario u = this.BuscarUsuario(id);
            this.context.SaveChanges();
        }        
        
        public void AñadirFavoritoVin(int id, string nombre)
        {
            Usuario u = this.BuscarUsuario(id);
            this.context.SaveChanges();
        }
        
        public void AñadirRRSS(int id, string nombre)
        {
            Usuario u = this.BuscarUsuario(id);
            u.RedesSociales += ". "+nombre;
            this.context.SaveChanges();
        }
        
        public void AñadirCesta(int id, int cantidad)
        {
            Usuario u = this.BuscarUsuario(id);
            u.Cesta += cantidad;
            this.context.SaveChanges();
        }

        public void CambiarRol(int id, int numerorol)
        {
            Usuario u = this.BuscarUsuario(id);
            if(numerorol == 1)
            {
                u.Rol = "administrador";
            }
            else if(numerorol == 2)
            {
                u.Rol = "tatuador";
            }
            else if(numerorol == 3)
            {
                u.Rol = "cliente";
            }
            else
            {
                u.Rol = "usuario";
            }
            this.context.SaveChanges();
        }

        public void CambiarContraseña(int id, string nuevopass)
        {
            Usuario usuario = this.BuscarUsuario(id);
            String salt = CypherService.GetSalt();
            usuario.Salt = salt;
            byte[] respuesta =
            CypherService.CifrarContenido(nuevopass, salt);
            usuario.Pass = respuesta;
        }
        #endregion

        #region DELETE

        public void EliminarUsuario(int id)
        {
            Usuario u = this.BuscarUsuario(id);
            this.context.Usuarios.Remove(u);
            this.context.SaveChanges();
        }
        #endregion


    }
}
