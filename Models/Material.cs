using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Models
{
    [Table("material")]
    public class Material
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Nombre")]
        public String Nombre { get; set; }
        [Column("Categoria")]
        public String Categoria { get; set; }
        [Column("Precio")]
        public int Precio { get; set; }
        [Column("Descripcion")]
        public String Descripcion { get; set; }
        [Column("Imagen")]
        public String Imagen { get; set; }
    }
}
