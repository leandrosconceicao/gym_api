using AutoMapper;
using Gym.Domain.Commands.GrupoMuscular;
using Gym.Domain.Entities;

namespace Gym.Domain.Profiles
{
    public class GrupoMuscularProfile : Profile
    {
        public GrupoMuscularProfile() 
        {
            CreateMap<GrupoMuscularCommand.CreateGrupoMuscular, GrupoMuscular>();

            CreateMap<GrupoMuscular, GrupoMuscularCommand.ReadGrupoMuscular>();
        }
    }
}
