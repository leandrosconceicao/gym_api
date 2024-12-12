using AutoMapper;
using Gym.Domain.Commands.Usuario;
using Gym.Domain.Entities;

namespace Gym.Domain.Profiles;

public class TreinoProfile : Profile
{
    public TreinoProfile() {
        CreateMap<TreinoCommand.CreateCommand, Treino>();
        CreateMap<Treino, TreinoCommand.ReadCommand>();
    }
}
