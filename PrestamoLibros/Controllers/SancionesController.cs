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
    public class SancionesController : Controller
    {
        //
        // GET: /Sanciones/
        PrestamoLibroContext _db = new PrestamoLibroContext();

        public ActionResult Index()
        {
            var sanciones = _db.Sanciones.ToList();
            return View(sanciones);
        }

        public ActionResult Ver(int id)
        {
            Sancion s = _db.Sanciones.Find(id);
            return View(s);
        }

        public ActionResult Editar(int id)
        {
            Sancion s = _db.Sanciones.Find(id);
            ViewBag.alumnos = _db.Alumnos.ToList();
            return View(s);
        }

        public ActionResult Registrar()
        {
            ViewBag.alumnos = _db.Alumnos.ToList();
            return View();
        }

        public ActionResult RankingAlumnosSancionados()
        {
            var ranking = (from a in _db.Alumnos
                          select new RankingSancionesViewModel
                          {
                              Id = a.Id,
                              Nombres = a.Nombres,
                              CantidadSanciones = a.Sanciones.Count
                          }).ToList();
            return View(ranking);
        }

        public ActionResult Crear(Sancion s)
        {
            if (ModelState.IsValid)
            {
                _db.Sanciones.Add(s);
                _db.SaveChanges();
                Flash.Instance.Success("Se ha registrado la sanción correctamente");
                return RedirectToRoute("sanciones");
            }
            Flash.Instance.Error("Ocurrió un error al registrar sanción, intente nuevamente");
            return RedirectToRoute("registrar_sancion");
        }
    }
}
