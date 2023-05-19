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
                var _objeto = new Dominio.Core.Habitacion();
                Mapper.Map(entidad, _objeto);
                _casaRepositorio.Agregar(_objeto);
                _casaRepositorio.UnidadDeTrabajo.Completar();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Agregar(HabitacionDTO entidad)
        {
            try
            {
                var _objeto = new Habitacion();
                Mapper.Map(entidad, _objeto);
                _casaRepositorio.Agregar(_objeto);
                _casaRepositorio.UnidadDeTrabajo.Completar();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Eliminar(HabitacionDTO entidad)
        {
            try
            {
                var _objeto = new Dominio.Core.Habitacion();
                Mapper.Map(entidad, _objeto);
                _casaRepositorio.Eliminar(_objeto);
                _casaRepositorio.UnidadDeTrabajo.Completar();
                return true;
            }
            catch
            {
                return false;
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
    }
}
