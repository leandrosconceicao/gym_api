using Gym.Domain.Commands;
using Gym.Domain.Entities;

namespace Gym.Domain.Interfaces
{
    public interface IEstabelecimentoHandler
    {
        Estabelecimento Create(EstabelecimentoCommand.CreateEstabelecimento command);
    }
}
