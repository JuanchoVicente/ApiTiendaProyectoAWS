using ApiTienda.Data;
using ApiTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Repositories
{
    public class RepositoryTienda
    {
        TiendaContext context;

        public RepositoryTienda(TiendaContext context)
        {
            this.context = context;
        }

        public List<Tienda> GetTiendas()
        {
            return this.context.Tiendas.ToList();
        }

        public Tienda BuscarTienda(int id)
        {
            return this.context.Tiendas.FirstOrDefault
                (x => x.Id == id);
        }

        public void InsertarTienda(string nombre, string lugar
            , string empleados, string direccion
            , string telefono )
        {
            var max = (from datos in this.context.Tiendas
                       select datos.Id).Max();
            Tienda ti = new Tienda();
            ti.Id = max + 1;
            ti.Nombre = nombre;
            ti.Lugar = lugar;
            ti.Empleados = empleados;
            ti.Direccion = direccion;
            ti.Telefono = telefono;
            this.context.Tiendas.Add(ti);
            this.context.SaveChanges();
        }

        public void ModificarTienda(int id, string nombre, string lugar
            , string empleados, string direccion, string telefono)
        {
            Tienda ti = this.BuscarTienda(id);
            ti.Nombre = nombre;
            ti.Lugar = lugar;
            ti.Empleados = empleados;
            ti.Direccion = direccion;
            ti.Telefono = telefono;
            this.context.SaveChanges();
        }

        public void EliminarCita(int id)
        {
            Tienda ti = this.BuscarTienda(id);
            this.context.Tiendas.Remove(ti);
            this.context.SaveChanges();
        }
                
    }
}
