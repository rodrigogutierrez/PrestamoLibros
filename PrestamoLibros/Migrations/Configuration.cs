namespace PrestamoLibros.Migrations
{
    using PrestamoLibros.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PrestamoLibros.Models.PrestamoLibroContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PrestamoLibros.Models.PrestamoLibroContext context)
        {
            //carrera
            context.Carreras.AddOrUpdate(
                c => c.Nombre,
                new Carrera { Nombre = "Nutricion" },
                new Carrera { Nombre = "Informática" },
                new Carrera { Nombre = "Auditoria" },
                new Carrera { Nombre = "Redes" },
                new Carrera { Nombre = "Enfermeria" }
            );
            context.SaveChanges();

            //ID de las carreras para ser usados en alumno
            int nutricion = context.Carreras.ToList().Single(c => c.Nombre == "Nutricion").Id;
            int informatica = context.Carreras.ToList().Single(c => c.Nombre == "Informática").Id;
            int auditoria = context.Carreras.ToList().Single(c => c.Nombre == "Auditoria").Id;
            int redes = context.Carreras.ToList().Single(c => c.Nombre == "Redes").Id;
            int enfermeria = context.Carreras.ToList().Single(c => c.Nombre == "Enfermeria").Id;

            //Libro
            context.Libros.AddOrUpdate(
                l => l.Nombre,
                new Libro {
                    Nombre = "El Principito y la tortuga",
                    Autor = "Jean Philipe de Pardeu",
                    Anio = 1850,
                    ISBN = "123456789a"
                },
                new Libro {
                    Nombre = "De Amor y de Sombras, comunacho",
                    Autor = "Isabel Allende Allende",
                    Anio = 1985,
                    ISBN = "123456789b"
                },
                new Libro {
                    Nombre = "La confesión, the confesion",
                    Autor = "John Grisham Grisham",
                    Anio = 1990,
                    ISBN = "123456789C"
                }
            );
            context.SaveChanges();

            //Alumno

            context.Alumnos.AddOrUpdate(
                a => a.Nombres,
                new Alumno
                {
                    Nombres = "Rodrigo Gutierrez Benitez",
                    Rut = "16873858-7",
                    NumeroMatricula = 123456,
                    CarreraId = informatica
                },

                new Alumno
                {
                    Nombres = "Benjamin Oyarzo Gutierrez",
                    Rut = "11111111-1",
                    NumeroMatricula = 234567,
                    CarreraId = redes
                },

                new Alumno
                {
                    Nombres = "Javiera Oyarzo Gutierrez",
                    Rut = "22222222-2",
                    NumeroMatricula = 345678,
                    CarreraId = enfermeria
                },

                new Alumno
                {
                    Nombres = "Erick Aguilar Gutierrez",
                    Rut = "33333333-3",
                    NumeroMatricula = 456789,
                    CarreraId = auditoria
                }
            );
            context.SaveChanges();

            //ID de los alumnos para ser usados en las sanciones y libros
            int alumno1 = context.Alumnos.ToList().Single(c => c.Nombres == "Rodrigo Gutierrez Benitez").Id;
            int alumno2 = context.Alumnos.ToList().Single(c => c.Nombres == "Benjamin Oyarzo Gutierrez").Id;
            int alumno3 = context.Alumnos.ToList().Single(c => c.Nombres == "Javiera Oyarzo Gutierrez").Id;
            int alumno4 = context.Alumnos.ToList().Single(c => c.Nombres == "Erick Aguilar Gutierrez").Id;

            //sanciones
            context.Sanciones.AddOrUpdate(
                s => s.Descripcion,
                new Sancion { 
                    Descripcion = "entrega 10 dias de atraso",
                    Fecha = new DateTime(2014, 06, 03),
                    AlumnoId = alumno1
                },

                new Sancion { 
                    Descripcion = "entrega 2 dias de atraso",
                    Fecha = new DateTime(2014, 06, 01),
                    AlumnoId = alumno2
                },

                new Sancion { 
                    Descripcion = "entrega 5 dias de atraso",
                    Fecha = new DateTime(2014, 05, 31),
                    AlumnoId = alumno3
                },

                new Sancion { 
                    Descripcion = "entrega 20 dias de atraso",
                    Fecha = new DateTime(2014, 05, 30),
                    AlumnoId = alumno4
                }
            );
            context.SaveChanges();

            //ID de los libros para ser usado en el prestamo de los libros
            int libro1 = context.Libros.ToList().Single(c => c.Nombre == "El Principito y la tortuga").Id;
            int libro2 = context.Libros.ToList().Single(c => c.Nombre == "De Amor y de Sombras, comunacho").Id;
            int libro3 = context.Libros.ToList().Single(c => c.Nombre == "La confesión, the confesion").Id;

            //libros prestados
            context.Prestados.AddOrUpdate(
                p => p.LibroId,
                new Prestado {
                    AlumnoId = alumno1,
                    LibroId = libro1
                },
                new Prestado {
                    AlumnoId = alumno2,
                    LibroId = libro1
                },
                new Prestado {
                    AlumnoId = alumno3,
                    LibroId = libro1
                },
                new Prestado {
                    AlumnoId = alumno1,
                    LibroId = libro2
                },
                new Prestado {
                    AlumnoId = alumno1,
                    LibroId = libro3
                },
                new Prestado {
                    AlumnoId = alumno2,
                    LibroId = libro2
                },
                new Prestado {
                    AlumnoId = alumno3,
                    LibroId = libro2
                },
                new Prestado {
                    AlumnoId = alumno4,
                    LibroId = libro1
                },
                new Prestado {
                    AlumnoId = alumno4,
                    LibroId = libro2
                },
                new Prestado {
                    AlumnoId = alumno4,
                    LibroId = libro3
                }
            );
        }
    }
}
