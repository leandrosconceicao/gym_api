using AutoMapper;
using Gym.Domain.Commands.Usuario;
using Gym.Domain.Entities;
using Gym.Domain.Interfaces;

namespace Gym.Domain.Handlers;

public class TreinoHandler(IMapper mapper) : ITreinoHandler
{
    public Treino Create(TreinoCommand.CreateCommand command)
    {
        return mapper.Map<Treino>(command);
    }

    public IApiResponse<TreinoCommand.ReadCommand> Read(Treino treino)
    {
        return new SuccessResponse<TreinoCommand.ReadCommand>(MapData(treino));
    }

    public IApiResponse<IEnumerable<TreinoCommand.ReadCommand>> Read(IEnumerable<Treino> treinos)
    {
        return new SuccessResponse<IEnumerable<TreinoCommand.ReadCommand>>(
            treinos.Select(treino => MapData(treino))            
        );
    }

    private TreinoCommand.ReadCommand MapData(Treino treino) => mapper.Map<TreinoCommand.ReadCommand>(treino);
}
