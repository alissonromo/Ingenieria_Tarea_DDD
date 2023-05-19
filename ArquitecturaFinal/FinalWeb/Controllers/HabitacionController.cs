using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacion.Contratos;

namespace FinalWeb.Controllers
{
    public class HabitacionController : Controller
    {
        private IHabitacionServicio _casaHabitacion;

        public HabitacionController(IHabitacionServicio paramHabitacionServicio)
        {
            _casaHabitacion = paramHabitacionServicio;
        }

        public ActionResult Index() // Listar
        {
            var lista = _casaHabitacion.ObtenerTodas();
            return View(lista);
        }

        [HttpPost]
        public ActionResult Create(int id)
        {
            try
            {
                var habitacion = _casaHabitacion.Obtener(id);
                _casaHabitacion.Agregar(habitacion);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var habitacion = _casaHabitacion.Obtener(id);
                _casaHabitacion.Modificar(habitacion);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var entity = _casaHabitacion.Obtener(id);
                _casaHabitacion.Eliminar(entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
