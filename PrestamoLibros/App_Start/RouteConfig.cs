using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PrestamoLibros
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "raiz",
                url: "",
                defaults: new { controller = "Libros", action = "Index"},
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            /*rutas del Libro*/
            
            //listar Libros
            routes.MapRoute(
                name: "libros",
                url: "libros",
                defaults: new { controller = "Libros", action = "Index" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            //ranking de libros por carrera
            routes.MapRoute(
                name: "ranking_por_carrera",
                url: "libros/ranking_por_carrera",
                defaults: new { controller = "Libros", action = "RankingLibrosPorCarrera" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            //registrar libro
            routes.MapRoute(
                name: "registrar_libro",
                url: "libros/registrar",
                defaults: new { controller = "Libros", action = "Registrar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            //registrar libro
            routes.MapRoute(
                name: "crear_libro",
                url: "libros/crear",
                defaults: new { controller = "Libros", action = "Crear" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            //editar libro
            routes.MapRoute(
                name: "editar_libro",
                url: "libros/{id}/editar",
                defaults: new { controller = "Libros", action = "Editar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            //prestar libro
            routes.MapRoute(
                name: "prestar_libro",
                url: "libros/{id}/prestar",
                defaults: new { controller = "Libros", action = "Prestar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            //registrar prestamo libro
            routes.MapRoute(
                name: "reg_prestamo_libro",
                url: "libros/{id}/registrar_prestamo",
                defaults: new { controller = "Libros", action = "RegistrarPrestamo" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            //historial prestamos libro
            routes.MapRoute(
                name: "historial_libro",
                url: "libros/{id}/historial_prestamos",
                defaults: new { controller = "Libros", action = "HistorialPrestamos" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            //actualizar libro
            routes.MapRoute(
                name: "actualizar_libro",
                url: "libros/{id}",
                defaults: new { controller = "Libros", action = "Actualizar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            //ver libro
            routes.MapRoute(
                name: "ver_libro",
                url: "libros/{id}",
                defaults: new { controller = "Libros", action = "Ver" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );


            /*Rutas de los alumnos*/
           
            //listar Alumnos
            routes.MapRoute(
                name: "alumnos",
                url: "alumnos",
                defaults: new { controller = "Alumnos", action = "Index" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            //Registrar Alumnos
            routes.MapRoute(
                name: "registrar_alumno",
                url: "alumnos/registrar",
                defaults: new { controller = "Alumnos", action = "Registrar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            //crear Alumnos
            routes.MapRoute(
                name: "crear_alumno",
                url: "alumnos/crear",
                defaults: new { controller = "Alumnos", action = "Crear" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            //editar alumnos
            routes.MapRoute(
                name: "editar_alumno",
                url: "alumnos/{id}/editar",
                defaults: new { controller = "Alumnos", action = "Editar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            //libros en posesion de alumno
            routes.MapRoute(
                name: "libros_posesion_alumno",
                url: "alumnos/{id}/libros",
                defaults: new { controller = "Alumnos", action = "LibrosAlumno" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            //sanciones alumno
            routes.MapRoute(
                name: "sanciones_alumno",
                url: "alumnos/{id}/sanciones",
                defaults: new { controller = "Alumnos", action = "SancionesAlumno" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            //actualizar alumnos
            routes.MapRoute(
                name: "actualizar_alumno",
                url: "alumnos/{id}",
                defaults: new { controller = "Alumnos", action = "Actualizar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            //ver alumnos
            routes.MapRoute(
                name: "ver_alumno",
                url: "alumnos/{id}",
                defaults: new { controller = "Alumnos", action = "Ver" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );


            /*Ruta de las sanciones*/

            //listar sanciones
            routes.MapRoute(
                name: "sanciones",
                url: "sanciones",
                defaults: new { controller = "Sanciones", action = "Index" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            //registrar sanciones
            routes.MapRoute(
                name: "registrar_sancion",
                url: "sanciones/registrar",
                defaults: new { controller = "Sanciones", action = "Registrar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            //registrar sanciones
            routes.MapRoute(
                name: "crear_sancion",
                url: "sanciones/crear",
                defaults: new { controller = "Sanciones", action = "Crear" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            //ranking alumnos con sanciones
            routes.MapRoute(
                name: "ranking_alumnos_sancionados",
                url: "sanciones/ranking",
                defaults: new { controller = "Sanciones", action = "RankingAlumnosSancionados" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            //editar sancion
            routes.MapRoute(
                name: "editar_sancion",
                url: "sanciones/{id}/editar",
                defaults: new { controller = "Sanciones", action = "Editar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            //actializar sancion
            routes.MapRoute(
                name: "actualizar_sancion",
                url: "sanciones/{id}",
                defaults: new { controller = "Sanciones", action = "Actualizar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            //ver sancion
            routes.MapRoute(
                name: "ver_sancion",
                url: "sanciones/{id}",
                defaults: new { controller = "Sanciones", action = "Ver" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );
        }
    }
}