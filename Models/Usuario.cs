using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nombre")]
        public String Nombre { get; set; }

        [Column("Pass")]
        public byte[] Pass { get; set; }

        [Column("Salt")]
        public String Salt { get; set; }

        [Column("Edad")]
        public int Edad { get; set; }

        [Column("Salud")]
        public String Salud { get; set; }

        [Column("FavsTatuajes")]
        public String FavsTatuajes { get; set; }

        [Column("Facturas")]
        public String Facturas { get; set; }

        [Column("Citas")]
        public String Citas { get; set; }

        [Column("Cesta")]
        public int Cesta { get; set; }

        [Column("Telefono")]
        public int Telefono { get; set; }

        [Column("Correo")]
        public String Correo { get; set; }

        [Column("RRSS")]
        public String RedesSociales { get; set; }

        [Column("Rol")]
        public String Rol { get; set; }

        [Column("Hora")]
        public String Hora { get; set; }
        
        [Column("Comentarios")]
        public String Comentarios { get; set; }


    }
}
