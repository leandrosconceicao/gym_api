using AutoMapper;
using Gym.Application.DTOs.ApiResponse;
using Gym.Application.DTOs.Usuario;
using Gym.Application.Interfaces.Services;
using Gym.Domain.Entities;
using Gym.Domain.Exceptions;
using Gym.Domain.Interfaces.Repositories;

namespace Gym.Application.Services;

public class TreinoService(IMapper mapper, ITreinoRepository repository) : ITreinoService
{
    public async Task<ApiResponse<TreinoCommand.ReadCommand>> AddAsync(TreinoCommand.CreateCommand dto)
    {
        var treino = await repository.AddAsync(mapper.Map<Treino>(dto));

        return new ApiResponse<TreinoCommand.ReadCommand>(MapData(treino));
    }

    public Task<ApiResponse> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResponse<IEnumerable<TreinoCommand.ReadCommand>>> FindAllAsync(Guid estabelecimentoId, Guid? id, int? offset = 0, int? limit = 100)
    {
        var values = await repository.FindAsync(estabelecimentoId, id, offset, limit);

        return new ApiResponse<IEnumerable<TreinoCommand.ReadCommand>>(MapData(values));
    }

    public async Task<ApiResponse<TreinoCommand.ReadCommand>> FindOneByIdAsync(Guid id)
    {
        var value = await repository.FindAsync(id) ?? throw new NotFoundError("Treino não localizado");

        return new ApiResponse<TreinoCommand.ReadCommand>(MapData(value));
    }

    private TreinoCommand.ReadCommand MapData(Treino treino) => mapper.Map<TreinoCommand.ReadCommand>(treino);
    private IEnumerable<TreinoCommand.ReadCommand> MapData(IEnumerable<Treino> treino) => mapper.Map<IEnumerable<TreinoCommand.ReadCommand>>(treino);
}
