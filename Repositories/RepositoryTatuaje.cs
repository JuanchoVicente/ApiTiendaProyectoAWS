using ApiTienda.Data;
using ApiTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Repositories
{
    public class RepositoryTatuaje
    {
        TiendaContext context;

        public RepositoryTatuaje(TiendaContext context)
        {
            this.context = context;
        }

        #region Metodos GET
            //Lista de tatuajes
            public List<Tatuaje> GetTatuajes()
            {
                return this.context.Tatuajes.ToList();
            }
            
            //Filtrar tatuajes por precio
            public List<Tatuaje> TatuajeEntrePrecios(int min, int max)
            {
                var consulta = from datos in this.context.Tatuajes
                               where datos.Precio > min &&
                               datos.Precio < max
                               select datos;
                return consulta.ToList();
            }

            //Precio mayor que el introducido
            public List<Tatuaje> TatuajesMasPrecio(int precio)
            {
                var consulta = from datos in this.context.Tatuajes
                               where datos.Precio > precio
                               select datos;
                return consulta.ToList();
            }

            //Precio menor que el introducido
            public List<Tatuaje> TatuajesMenosPrecio(int precio)
            {
                var consulta = from datos in this.context.Tatuajes
                               where datos.Precio < precio
                               select datos;
                return consulta.ToList();
            }

            //Filtrar por tamaño y precio (igual o mayor)
            public List<Tatuaje> TatuajesTamañoPrecio(string size, int precio)
            {
                var consulta = from datos in this.context.Tatuajes
                               where datos.Tamaño == size &&
                               datos.Precio >= precio
                               select datos;
                return consulta.ToList();
            }

            //Listado de tamaños ordenado descendentemente
            public List<String> ListaTamaños()
            {
                var consulta = (from datos in this.context.Tatuajes
                                orderby datos.Tamaño descending
                                select datos.Tamaño).Distinct();
                return consulta.ToList();
            }

            //Listado de precios sin repetir de los tatuajes 
            public List<int> ListaPrecios()
            {
                var consulta = (from datos in this.context.Tatuajes
                                select datos.Precio).Distinct();
                return consulta.ToList();
            }

        #endregion

        #region Metodos POST
        //Crear nuevo tatuaje
        public void NuevoTatuaje(string nombre
                , string autor, string tamaño, string color
                , int precio, string imagen)
            {
                var m = (from datos in this.context.Tatuajes
                         select datos.Id).Max();
                Tatuaje tatu = new Tatuaje();
                tatu.Id = m + 1;
                tatu.Nombre = nombre;
                tatu.Autor = autor;
                tatu.Tamaño = tamaño;
                tatu.Color = color;
                tatu.Precio = precio;
                tatu.Imagen = imagen;
                this.context.Tatuajes.Add(tatu);
                this.context.SaveChanges();
            }

            //Buscar tatuaje por identificador
            public Tatuaje BuscarTatuaje(int id)
            {
                return this.context.Tatuajes.Where(
                    x => x.Id == id).FirstOrDefault();
            }

            //Buscar tatuaje por nombre
            public List<Tatuaje> BuscarTatuajeNombre(string nombre)
            {
                var consulta = from datos in this.context.Tatuajes
                               where datos.Nombre.Contains(nombre)
                               select datos;
                return consulta.ToList();
            }

            //Buscar tatuaje por precio
            public List<Tatuaje> BuscarTatuajePrecio(int precio)
            {
                var consulta = from datos in this.context.Tatuajes
                               where datos.Precio == precio
                               select datos;
                return consulta.ToList();
            }

        #endregion

        #region Metodos PUT
            //Modificar tatuaje por id
            public void ModificarTatuaje(int id, string nombre
                , string autor, string tamaño, string color
                , int precio, string imagen)
            {
                Tatuaje tatu = this.BuscarTatuaje(id);
                tatu.Nombre = nombre;
                tatu.Autor = autor;
                tatu.Tamaño = tamaño;
                tatu.Color = color;
                tatu.Precio = precio;
                tatu.Imagen = imagen;
                this.context.SaveChanges();
            }

            //Cambiar precio del tatuaje
            public void CambiarPrecioTatuaje(int id, int precio)
            {
                Tatuaje t = this.BuscarTatuaje(id);
                if (precio > 0)
                {
                    t.Precio = precio;
                    this.context.SaveChanges();
                }
            }

            //Subir precio del tatuaje
            public void SubirPrecioTatuaje(int id, int precio)
            {
                Tatuaje t = this.BuscarTatuaje(id);
                t.Precio += precio;
                this.context.SaveChanges();
            }

            //Cambiar precio a tatuajes con el mismo tamaño
            public void ModificarPrecioPorTamaño(int precio, string tamaño)
            {
                var consulta = from datos in this.context.Tatuajes
                               where datos.Tamaño == tamaño
                               select datos;
                foreach (Tatuaje t in consulta)
                {
                    t.Precio = precio;
                }
                this.context.SaveChanges();
            }

            //Cambiar imagen del tatuaje
            public void CambiarImagenTatuaje(int id, string img)
            {
                Tatuaje t = this.BuscarTatuaje(id);
                t.Imagen = img;
                this.context.SaveChanges();
            }


        #endregion

        #region Metodos DELETE
        //Eliminar tatuaje
        public void EliminarTatuaje(int id)
            {
                Tatuaje tatu = this.BuscarTatuaje(id);
                this.context.Tatuajes.Remove(tatu);
                this.context.SaveChanges();
            }

            //Eliminar tatuajes por precio
            public void EliminarTatusPrecio(int precio)
            {
                var consulta = from datos in this.context.Tatuajes
                               where datos.Precio == precio
                               select datos;
                foreach (Tatuaje t in consulta)
                {
                    this.context.Tatuajes.Remove(t);
                }
                this.context.SaveChanges();
            }

        #endregion
          
    }
}
