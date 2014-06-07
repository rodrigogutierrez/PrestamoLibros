using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PrestamoLibros.Models
{
    public class PrestamoLibroContext : DbContext
    {
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Sancion> Sanciones { get; set; }
        public DbSet<Prestado> Prestados { get; set; }
    }
}