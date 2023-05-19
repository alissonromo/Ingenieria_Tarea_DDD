using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacion.Contratos;
using Aplicacion.Core;

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
        public ActionResult Create(FormCollection form)
        {
            try
            {
                HabitacionDTO habitacion = new HabitacionDTO();
                int numero;
                int numeroHabitacion;
                int.TryParse(form["numero"], out numero);
                int.TryParse(form["Numerohabitacion"], out numeroHabitacion);

                habitacion.Numero = numero;
                habitacion.Descripcion = form["descripcion"];
                habitacion.NumeroHabitacion = numeroHabitacion;
                // var habitacion = _casaHabitacion.Obtener(id);

                _casaHabitacion.Agregar(habitacion);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            try
            {
                int numeroId;
                int.TryParse(form["numeroId"], out numeroId);
                var habitacion = _casaHabitacion.Obtener(numeroId);
                
                
                int numero;
                int numeroHabitacion;
                int.TryParse(form["numero"], out numero);
                int.TryParse(form["Numerohabitacion"], out numeroHabitacion);
                habitacion.Numero = numero;
                habitacion.Descripcion = form["descripcion"];
                habitacion.NumeroHabitacion = numeroHabitacion;

                _casaHabitacion.Modificar(habitacion);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
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