using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrestamoLibros.Models
{
    [Table("Carreras")]
    public class Carrera
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength=5)]
        public string Nombre { get; set; }
    }
}