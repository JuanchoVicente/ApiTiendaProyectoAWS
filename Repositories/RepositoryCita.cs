using ApiTienda.Data;
using ApiTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Repositories
{
    public class RepositoryCita
    {
        TiendaContext context;

        public RepositoryCita(TiendaContext context)
        {
            this.context = context;
        }

        public List<Cita> GetCitas()
        {
            return this.context.Citas.ToList();
        }

        public Cita BuscarCita(int id)
        {
            return this.context.Citas.FirstOrDefault
                (x => x.Id == id);
        }

        public void InsertarCita(string tatuaje, int iduser
            , string tatuador, string fecha, string comentario )
        {
            var max = (from datos in this.context.Citas
                       select datos.Id).Max();
            Cita ci = new Cita();
            ci.Id = max + 1;
            ci.Tatuaje = tatuaje;
            ci.IdUsuario = iduser;
            ci.Tatuador = tatuador;
            ci.Fecha = fecha;
            ci.Comentarios = comentario;
            this.context.Citas.Add(ci);
            this.context.SaveChanges();
        }

        public void ModificarCita(int id, string tatuaje, int iduser
            , string tatuador, string fecha, string comentario)
        {
            Cita ci = this.BuscarCita(id);
            ci.Tatuaje = tatuaje;
            ci.IdUsuario = iduser;
            ci.Tatuador = tatuador;
            ci.Fecha = fecha;
            ci.Comentarios = comentario;
            this.context.SaveChanges();
        }

        public void EliminarCita(int id)
        {
            Cita ci = this.BuscarCita(id);
            this.context.Citas.Remove(ci);
            this.context.SaveChanges();
        }
                
    }
}
