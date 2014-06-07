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
    public class AlumnosController : Controller
    {
        //
        // GET: /Alumnos/
        PrestamoLibroContext _db = new PrestamoLibroContext();

        public ActionResult Index()
        {
            var alumnos = _db.Alumnos.ToList();
            return View(alumnos);
        }

        public ActionResult Ver(int id)
        {
            Alumno a = _db.Alumnos.Find(id);
            return View(a);
        }

        public ActionResult Editar(int id)
        {
            Alumno a = _db.Alumnos.Find(id);
            ViewBag.carreras = _db.Carreras.ToList();
            return View(a);
        }

        public ActionResult Registrar()
        {
            ViewBag.carreras = _db.Carreras.ToList();
            return View();
        }

        public ActionResult LibrosAlumno(int id)
        {
            Alumno a = _db.Alumnos.Find(id);
            var libros = (from l in _db.Libros
                          where l.LibroPrestado.Where(al => al.AlumnoId == id).Count() > 0
                          select l).ToList();
            ViewBag.libros = libros;
            return View(a);
        }

        public ActionResult SancionesAlumno(int id)
        {
            Alumno a = _db.Alumnos.Find(id);
            var sanciones = (from s in _db.Sanciones
                             where s.Alumno.Id == id
                             select s).ToList();
            ViewBag.sanciones = sanciones;
            return View(a);
        }

        public ActionResult Crear(Alumno a)
        {
            if (ModelState.IsValid)
            {
                _db.Alumnos.Add(a);
                _db.SaveChanges();
                Flash.Instance.Success("El alumno fue creado con exito.");
                return RedirectToRoute("alumnos");
            }
            Flash.Instance.Error("Ha ocurrido un error registrando al alumno, intente nuevamente");
            return RedirectToRoute("registrar_alumno");
        }

        public ActionResult Actualizar(int id, Alumno a)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(a).State = System.Data.EntityState.Modified;
                _db.SaveChanges();
                Flash.Instance.Success("El alumno fue actualizado correctamente.");
                return RedirectToRoute("ver_alumno", new { id = id });
            }
            Flash.Instance.Error("Ha ocurrido un error al actualizar al alumno, intente nuevamente.");
            return RedirectToRoute("editar_alumno", new { id = id });
        }
    }
}
