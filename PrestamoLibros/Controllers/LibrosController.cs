using MvcFlash.Core;
using MvcFlash.Core.Extensions;
using PrestamoLibros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrestamoLibros.Controllers
{
    public class LibrosController : Controller
    {
        //
        // GET: /Libros/
        PrestamoLibroContext _db = new PrestamoLibroContext();

        public ActionResult Index()
        {
            var libros = _db.Libros.ToList();
            return View(libros);
        }

        public ActionResult Ver(int id)
        {
            Libro l = _db.Libros.Find(id);
            return View(l);
        }

        public ActionResult Editar(int id)
        {
            Libro l = _db.Libros.Find(id);
            return View(l);
        }

        public ActionResult Registrar()
        {
            return View();
        }

        public ActionResult Prestar(int id)
        {
            Libro l = _db.Libros.Find(id);
            ViewBag.alumnos = _db.Alumnos.ToList();
            return View(l);
        }

        public ActionResult RankingLibrosPorCarrera()
        {            
            return View();
        }

        public ActionResult HistorialPrestamos(int id)
        {
            Libro l = _db.Libros.Find(id);
            var alumno = (from a in _db.Alumnos
                          where a.LibroPrestado.Where(li => li.LibroId == id).Count() > 0
                          select a).ToList();
            ViewBag.alumnos = alumno;
            return View(l);
        }

        public ActionResult Crear(Libro l)
        {
            if (ModelState.IsValid)
            {
                _db.Libros.Add(l);
                _db.SaveChanges();
                Flash.Instance.Success("El libro fue creado correctamente.");
                return RedirectToRoute("libros");
            }
            Flash.Instance.Error("Ha ocurrido un error al crear el libro, intente nuevamente");
            return RedirectToRoute("registrar_libro");
        }

        public ActionResult Actualizar(Libro l, int id)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(l).State = System.Data.EntityState.Modified;
                _db.SaveChanges();
                Flash.Instance.Success("Se ha actualizado el libro.");
                return RedirectToRoute("ver_libro", new { id = id});
            }
            Flash.Instance.Error("Ha ocurrido un error actualizando el libro, intente nuevamente");
            return RedirectToRoute("editar_libro", new { id = id });
        }

        public ActionResult RegistrarPrestamo(int id, FormCollection coleccion)
        {
            try
            {
                Libro l = _db.Libros.Find(id);
                l.LibroPrestado.Add(
                    new Prestado { 
                        LibroId = id,
                        AlumnoId = Convert.ToInt32(coleccion.Get("AlumnoId"))
                    }
                );
                _db.SaveChanges();
                Flash.Instance.Success("Se ha registrado correctamente el prestamo.");
                return RedirectToRoute("historial_libro", new { id = id });
            }                         
            catch (Exception e)
            {
                Flash.Instance.Error("Ha ocurrido un error al registrar el prestamo, intente nuevamente.");
                return RedirectToRoute("prestar_libro", new { id = id });
            }
        }
    }
}
