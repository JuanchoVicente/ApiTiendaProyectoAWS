using ApiTienda.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class TiendaContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public TiendaContext(DbContextOptions<TiendaContext> options) : base(options) { }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Categoria> Categorias { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Material> Materiales { get; set; }
        public DbSet<Tatuaje> Tatuajes { get; set; }
        public DbSet<Tienda> Tiendas {get; set;}
        public DbSet<Usuario> Usuarios {get; set;}
    }
}
