using Gym.Domain.Commands.Usuario;
using Gym.Domain.Entities;

namespace Gym.Domain.Interfaces;

public interface ITreinoHandler
{
    Treino Create(TreinoCommand.CreateCommand command);
    IApiResponse<TreinoCommand.ReadCommand> Read(Treino treino);
    IApiResponse<IEnumerable<TreinoCommand.ReadCommand>> Read(IEnumerable<Treino> treinos);
}
