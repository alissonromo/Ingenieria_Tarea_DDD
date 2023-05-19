using System;
using System.Collections.Generic;

namespace Dominio.Core
{
    public interface IRepositorioBase<Entidad> : IDisposable
    {
        IUnidadDeTrabajo UnidadDeTrabajo { get; }

        Entidad Obtener(int id); 

        IEnumerable<Entidad> ObtenerTodas();

        void Modificar(Entidad entidad);

        string Agregar(Entidad entidad);

        string Eliminar(Entidad entidad);
    }
}
