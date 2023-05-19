using Aplicacion.Core;
using System;
using System.Collections.Generic;

namespace Aplicacion.Contratos
{
    public interface IHabitacionServicio : IDisposable
    {
        HabitacionDTO Obtener(int id);

        IEnumerable<HabitacionDTO> ObtenerTodas();

        bool Modificar(HabitacionDTO entidad);

        bool Agregar(HabitacionDTO entidad);

        bool Eliminar(HabitacionDTO entidad);
    }
}
