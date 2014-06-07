using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrestamoLibros.Models
{
    [Table("Libros")]
    public class Libro
    {
        public int Id { get; set; }

        [Required]
        [StringLength(35, MinimumLength=15)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(30, MinimumLength=5)]
        public string Autor { get; set; }

        [Required]
        [Range(1700, 2013)]
        public int Anio { get; set; }

        [Required]
        [StringLength(10, MinimumLength=10)]
        public string ISBN { get; set; }

        public virtual ICollection<Prestado> LibroPrestado { get; set; }
    }
}