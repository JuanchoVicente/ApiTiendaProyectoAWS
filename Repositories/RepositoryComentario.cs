using ApiTienda.Data;
using ApiTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Repositories
{
    public class RepositoryComentario
    {
        TiendaContext context;

        public RepositoryComentario(TiendaContext context)
        {
            this.context = context;
        }

        public List<Comentario> GetComentarios()
        {
            return this.context.Comentarios.ToList();
        }

        public Comentario BuscarComentario(int id)
        {
            return this.context.Comentarios.FirstOrDefault
                (x => x.Id == id);
        }

        public void InsertarComentario(string nombre, int iduser
            , string fecha)
        {
            var max = (from datos in this.context.Comentarios
                       select datos.Id).Max();
            Comentario co = new Comentario();
            co.Id = max + 1;
            co.Nombre = nombre;
            co.IdUsuario = iduser;
            co.Fecha = fecha;
            this.context.Comentarios.Add(co);
            this.context.SaveChanges();
        }

        public void ModificarComentario(int id, string nombre, int iduser
            , string fecha)
        {
            Comentario co = this.BuscarComentario(id);
            co.Nombre = nombre;
            co.IdUsuario = iduser;
            co.Fecha = fecha;
            this.context.Comentarios.Add(co);
            this.context.SaveChanges();
        }

        public void EliminarComentario(int id)
        {
            Comentario co = this.BuscarComentario(id);
            this.context.Comentarios.Remove(co);
            this.context.SaveChanges();
        }
                
    }
}
