using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Models
{
    [Table("tienda")]
    public class Tienda
    {
        [Key]
        [Column("Id")]
        public int Id {get; set;} 

        [Column("Nombre")]
        public String Nombre { get; set; }
        
        [Column("Lugar")]
        public String Lugar { get; set; }
        
        [Column("Empleados")]
        public String Empleados { get; set; }

        [Column("Direccion")]
        public String Direccion { get; set; }
        
        [Column("Telefono")]
        public String Telefono { get; set; }

    }
}
