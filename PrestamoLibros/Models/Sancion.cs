using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrestamoLibros.Models
{
    [Table("Sanciones")]
    public class Sancion
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25, MinimumLength=10)]
        public string Descripcion { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        public int AlumnoId { get; set; }
        public virtual Alumno Alumno { get; set; }
    }
}