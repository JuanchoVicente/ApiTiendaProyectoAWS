using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Models
{
    [Table("tatuaje")]
    public class Tatuaje
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Nombre")]
        public String Nombre { get; set; }
        [Column("Autor")]
        public String Autor { get; set; }
        [Column("Size")]
        public String Tamaño { get; set; }
        [Column("Color")]
        public String Color { get; set; }
        [Column("Precio")]
        public int Precio { get; set; }
        [Column("Imagen")]
        public String Imagen { get; set; }
    }
}
