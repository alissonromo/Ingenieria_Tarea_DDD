using System;
using System.Collections.Generic;

namespace Dominio.Core
{
    public interface IRepositorioBase<Entidad> : IDisposable
    {
        IUnidadDeTrabajo UnidadDeTrabajo { get; }

        Entidad Obtener(int id); 

        IEnumerable<Entidad> ObtenerTodas();

        Entidad Modificar(Entidad entidad);

        void Agregar(Entidad entidad);

        void Eliminar(Entidad entidad);
    }
}
