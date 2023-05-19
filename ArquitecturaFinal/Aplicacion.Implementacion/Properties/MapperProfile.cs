using AutoMapper;
using Dominio.Core;

namespace Aplicacion.Core
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<HabitacionDTO, HabitacionDTO>();
            CreateMap<HabitacionDTO, HabitacionDTO>();
        }
    }
}
