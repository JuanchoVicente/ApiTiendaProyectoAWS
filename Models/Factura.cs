using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Models
{
    [Table("factura")]
    public class Factura
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Producto")]
        public String Producto { get; set; }
        
        [Column("Cantidad")]
        public int Cantidad { get; set; }
        
        [Column("Empleado")]
        public String Empleado { get; set; }
        
        [Column("Total")]
        public int Total { get; set; }


    }
}
