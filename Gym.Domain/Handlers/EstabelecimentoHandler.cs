using AutoMapper;
using Gym.Domain.Commands;
using Gym.Domain.Entities;
using Gym.Domain.Interfaces;

namespace Gym.Domain.Handlers
{
    public class EstabelecimentoHandler(IMapper mapper) : IEstabelecimentoHandler
    {
        public Estabelecimento Create(EstabelecimentoCommand.CreateEstabelecimento command)
        {
            return mapper.Map<Estabelecimento>(command);
        }
    }
}
