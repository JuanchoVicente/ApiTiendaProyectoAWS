using ApiTienda.Data;
using ApiTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Repositories
{
    public class RepositoryCategoria
    {
        TiendaContext context;

        public RepositoryCategoria(TiendaContext context)
        {
            this.context = context;
        }

        public List<Categoria> GetCategorias()
        {
            return this.context.Categorias.ToList();
        }

        public Categoria BuscarCategoria(int id)
        {
            return this.context.Categorias.FirstOrDefault
                (x => x.Id == id);
        }

        public void InsertarCategoria(string nombre)
        {
            var max = (from datos in this.context.Categorias
                       select datos.Id).Max();
            Categoria ca = new Categoria();
            ca.Id = max + 1;
            ca.Nombre = nombre;
            this.context.Categorias.Add(ca);
            this.context.SaveChanges();
        }

        public void ModificarCategoria(int id, string nombre)
        {
            Categoria ca = this.BuscarCategoria(id);
            ca.Nombre = nombre;
            this.context.SaveChanges();
        }

        public void EliminarCategoria(int id)
        {
            Categoria ca = this.BuscarCategoria(id);
            this.context.Categorias.Remove(ca);
            this.context.SaveChanges();
        }
                
    }
}
