﻿using Datos.Persistencia.Core;
using Dominio.Core;
using System.Collections.Generic;
using System.Linq;

namespace Datos.Persistencia.Repositorios
{
    public class RepositorioBase<Entidad> : IRepositorioBase<Entidad> where Entidad : class
    {
        readonly IContextoUnidadDeTrabajo _unidadDeTrabajo;

        public IUnidadDeTrabajo UnidadDeTrabajo
        {
            get { return _unidadDeTrabajo; }
        }

        public RepositorioBase(IContextoUnidadDeTrabajo unidadTrabajo)
        {
            _unidadDeTrabajo = unidadTrabajo;
        }

        public Entidad Obtener(int id)
        {
            return _unidadDeTrabajo.Set<Entidad>().Find(id);
        }

        public IEnumerable<Entidad> ObtenerTodas()
        {
            return _unidadDeTrabajo.Set<Entidad>().ToList();
        }

        public void Modificar(Entidad entidad)
        {
           // return _unidadDeTrabajo.Set<Entidad>().Add(entidad);
            _unidadDeTrabajo.Completar();
        }

        public void Dispose()
        {
            _unidadDeTrabajo.Dispose();
        }

        public string Eliminar(Entidad entidad)
        {
            _unidadDeTrabajo.Set<Entidad>().Remove(entidad);
            return "true";
        }

        string IRepositorioBase<Entidad>.Agregar(Entidad entidad)
        {
            _unidadDeTrabajo.Set<Entidad>().Add(entidad);
            return "true";
        }
    }
}