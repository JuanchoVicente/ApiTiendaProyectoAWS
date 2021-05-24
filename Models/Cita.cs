using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Models
{
    [Table("cita")]
    public class Cita
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Tatuaje")]
        public String Tatuaje { get; set; }
        
        [Column("IdUsuario")]
        public int IdUsuario { get; set; }
        
        [Column("Tatuador")]
        public String Tatuador { get; set; }

        [Column("Fecha")]
        public String Fecha { get; set; }

        [Column("Comentarios")]
        public String Comentarios { get; set; }
    }
}
