using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrestamoLibros.Models
{
    [Table("Prestados")]
    public class Prestado
    {
        [Key]
        [Column(Order = 1)]
        public int AlumnoId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int LibroId { get; set; }

        public virtual Alumno Alumno { get; set; }
        public virtual Libro Libro { get; set; }
    }
}