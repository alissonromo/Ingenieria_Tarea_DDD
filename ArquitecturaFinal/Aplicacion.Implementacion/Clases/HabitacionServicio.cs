using Aplicacion.Contratos;
using Aplicacion.Core;
using AutoMapper;
using Dominio.Contratos;
using Dominio.Core;
using System;
using System.Collections.Generic;

namespace Aplicacion.Implementacion
{
    public class HabitacionServicio : IHabitacionServicio
    {
        private IHabitacionRepositorio _casaRepositorio;

        public HabitacionServicio(IHabitacionRepositorio pCasaRepositorio)
        {
            _casaRepositorio = pCasaRepositorio;
        }

        public HabitacionDTO Obtener(int id)
        {
            var objetoRecuperado = _casaRepositorio.Obtener(id);
            return Mapper.Map<Habitacion, HabitacionDTO>(objetoRecuperado);
        }

        public IEnumerable<HabitacionDTO> ObtenerTodas()
        {
            var lista = _casaRepositorio.ObtenerTodas();
            return Mapper.Map<IEnumerable<Habitacion>, IEnumerable<HabitacionDTO>>(lista);
        }

        public bool Modificar(HabitacionDTO entidad)
        {
            try
            {
                var objetoRecuperado = _casaRepositorio.Obtener(entidad.HabitacionID);
                objetoRecuperado.Descripcion = entidad.Descripcion;
                objetoRecuperado.Numero = entidad.Numero;
                objetoRecuperado.NumeroHabitacion = entidad.NumeroHabitacion;
                Mapper.Map<Habitacion, HabitacionDTO>(objetoRecuperado);
                _casaRepositorio.Modificar(objetoRecuperado);
                _casaRepositorio.UnidadDeTrabajo.Completar();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string Agregar(HabitacionDTO entidad)
        {

            try
            {
                Habitacion habitacion = new Habitacion();
                habitacion.Descripcion = entidad.Descripcion;
                habitacion.Numero = entidad.Numero;
                habitacion.NumeroHabitacion = entidad.NumeroHabitacion;
                Mapper.Map<Habitacion, HabitacionDTO>(habitacion);
                _casaRepositorio.Agregar(habitacion);
                _casaRepositorio.UnidadDeTrabajo.Completar();
                return "registrado";

            }
            catch
            {
                return "no registrado";
            }
        }


        HabitacionServicio() { }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_casaRepositorio != null)
                {
                    _casaRepositorio.Dispose();
                    _casaRepositorio = null;
                }
            }
        }

        string IHabitacionServicio.Eliminar(HabitacionDTO entidad)
        {
            try
            {
                var objetoRecuperado = _casaRepositorio.Obtener(entidad.HabitacionID);
                Mapper.Map<Habitacion, HabitacionDTO>(objetoRecuperado);
                _casaRepositorio.Eliminar(objetoRecuperado);
                _casaRepositorio.UnidadDeTrabajo.Completar();
                return "Habitacion eliminada";

            }
            catch
            {
                return "Habitacion no eliminada";
            }
        }
    }
}
