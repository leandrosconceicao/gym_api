using AutoMapper;
using Gym.Domain.Commands;
using Gym.Domain.Entities;

namespace Gym.Domain.Profiles
{
    public class EstabelecimentoProfile : Profile
    {
        public EstabelecimentoProfile() {

            CreateMap<EstabelecimentoCommand.CreateEstabelecimento, Estabelecimento>();

            CreateMap<Estabelecimento, EstabelecimentoCommand.ReadEstabelecimento>();
        }
    }
}
