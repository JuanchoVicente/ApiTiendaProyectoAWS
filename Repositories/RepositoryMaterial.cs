using ApiTienda.Data;
using ApiTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Repositories
{
    public class RepositoryMaterial
    {
        TiendaContext context;

        public RepositoryMaterial(TiendaContext context)
        {
            this.context = context;
        }        
               
        #region GET
            
            //Lista de materiales
            public List<Material> GetMateriales()
            {
                return this.context.Materiales.ToList();
            }

            //Buscar material por identificador
            public Material BuscarMaterial(int id)
            {
                Material m = this.context.Materiales.FirstOrDefault
                    (x => x.Id == id);
                return m;
            }
            
            //Buscar materiales por nombre
            public List<Material> BuscarMaterialNombre(string nombre)
            {
                var consulta = from datos in this.context.Materiales
                                       where datos.Nombre.Contains(nombre)
                                       select datos;
                return consulta.ToList();
            }
            
            //Buscar materiales por precio
            public List<Material> BuscarMaterialPrecio(int precio)
            {
                var consulta = from datos in this.context.Materiales
                               where datos.Precio == precio
                               select datos;
                return consulta.ToList();
            }

            //Buscar materiales por categoria
            public List<Material> BuscarMaterialCategoria(int idcategoria)
            {
                var consulta = from datos in this.context.Materiales
                               from cat in this.context.Categorias
                               where cat.Id == idcategoria
                               where datos.Categoria == cat.Nombre
                               select datos;
                return consulta.ToList();
            }

            //Filtrar por precio mayor al introducido, 
            // ordenado de mayor al menor precio
            public List<Material> FiltrarPrecioMas(int precio)
            {
                var consulta = from datos in this.context.Materiales
                               where datos.Precio >= precio
                               orderby datos.Precio descending
                               select datos;
                return consulta.ToList();
            }

            //Filtrar por precio menor al introducido, 
            // ordenado de menor al mayor precio
            public List<Material> FiltrarPrecioMenor(int precio)
            {
                var consulta = from datos in this.context.Materiales
                               where datos.Precio <= precio
                               orderby datos.Precio
                               select datos;
                return consulta.ToList();
            }

        #endregion

        #region POST

       //Crear un nuevo material
            public void NuevoMaterial(
                String nombre, int precio, String descripcion
                , string imagen, int idcategoria)
            {
                var max = (from datos in this.context.Materiales
                           select datos.Id).Max();
                Material m = new Material();
                m.Id = max + 1;
                m.Nombre = nombre;
                m.Precio = precio;
                m.Descripcion = descripcion;
                m.Imagen = imagen;
            m.Categoria = idcategoria.ToString();
                this.context.Materiales.Add(m);
                this.context.SaveChanges();
            }


        #endregion

        #region PUT
            //Modificar un material por id
            public void ModificarMaterial (int id, 
                String nombre, int precio, String descripcion
                , string imagen, int idcategoria)
            {
                Material m = this.BuscarMaterial(id);
                m.Nombre = nombre;
                m.Precio = precio;
                m.Descripcion = descripcion;
                m.Imagen = imagen;
                this.context.SaveChanges();
            }

        //Cambiar el precio de un material
            public void CambiarPrecioMaterial(int id, int precio)
            {
                Material m = this.BuscarMaterial(id);
                m.Precio = precio;
                this.context.SaveChanges();
            }

        //Subir el precio de un grupo de materiales
            public void SubirPrecioPorCategoria(int precio, int idcategoria)
            {
                var consulta = from datos in this.context.Materiales
                               from cat in this.context.Categorias
                               where cat.Id == idcategoria
                               select datos;
                foreach (Material m in consulta)
                {
                    m.Precio += precio;
                }
                this.context.SaveChanges();
            }

        //Modificar la descripcion de un material
            public void ModificarDescripcion(int id, string descripcion)
            {
                Material m = this.BuscarMaterial(id);
                m.Descripcion = descripcion;
                this.context.SaveChanges();
            }
        //Añadir datos a la descripcion de un material
            public void AddModificarDescripcion(int id, string descripcion)
            {
                Material m = this.BuscarMaterial(id);
                m.Descripcion += ". "+descripcion;
                this.context.SaveChanges();
            }
        #endregion

        #region DELETE
            public void EliminarMaterial(int id)
            {
                Material m = this.BuscarMaterial(id);
                this.context.Materiales.Remove(m);
                this.context.SaveChanges();
            }

        #endregion

    }
}
