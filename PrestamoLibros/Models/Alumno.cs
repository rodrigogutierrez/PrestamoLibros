using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrestamoLibros.Models
{
    [Table("Alumnos")]
    public class Alumno
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength=15)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(10, MinimumLength=9)]
        public string Rut { get; set; }

        [Required]
        [Range(0, 999999)]
        public int NumeroMatricula { get; set; }

        //declaracion de la relacion entre el alumno y la sancion
        public virtual ICollection<Sancion> Sanciones { get; set; }

        //declaracion de la relacion entre el alumno y la carrera
        public int CarreraId { get; set; }
        public virtual Carrera Carrera { get; set; }

        public virtual ICollection<Prestado> LibroPrestado { get; set; }
    }
}   