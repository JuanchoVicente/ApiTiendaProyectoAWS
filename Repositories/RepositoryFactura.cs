using ApiTienda.Data;
using ApiTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Repositories
{
    public class RepositoryFactura
    {
        TiendaContext context;

        public RepositoryFactura(TiendaContext context)
        {
            this.context = context;
        }

        public List<Factura> GetFacturas()
        {
            return this.context.Facturas.ToList();
        }

        public Factura BuscarFactura(int id)
        {
            return this.context.Facturas.FirstOrDefault
                (x => x.Id == id);
        }

        public void InsertarFactura(string producto, int cantidad
            , string empleado, int total)
        {
            var max = (from datos in this.context.Facturas
                       select datos.Id).Max();
            Factura fa = new Factura();
            fa.Id = max + 1;
            fa.Producto = producto;
            fa.Cantidad = cantidad;
            fa.Empleado = empleado;
            fa.Total = total;
            this.context.Facturas.Add(fa);
            this.context.SaveChanges();
        }

        public void ModificarFactura(int id, string producto, int cantidad
            , string empleado, int total)
        {
            Factura fa = this.BuscarFactura(id);
            fa.Producto = producto;
            fa.Cantidad = cantidad;
            fa.Empleado = empleado;
            fa.Total = total;
            this.context.Facturas.Add(fa);
            this.context.SaveChanges();
        }

        public void EliminarFactura(int id)
        {
            Factura fa = this.BuscarFactura(id);
            this.context.Facturas.Remove(fa);
            this.context.SaveChanges();
        }
                
    }
}
