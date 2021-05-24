using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Models
{
    [Table("comentario")]
    public class Comentario
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Texto")]
        public String Nombre { get; set; }
        
        [Column("IdUsuario")]
        public int IdUsuario { get; set; }
        
        [Column("Fecha")]
        public String Fecha { get; set; }

    }
}
