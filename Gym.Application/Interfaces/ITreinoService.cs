using Gym.Application.DTOs.ApiResponse;
using Gym.Application.DTOs.Usuario;
using Gym.Domain.Entities;

namespace Gym.Application.Interfaces.Services;

public interface ITreinoService
{
    public Task<ApiResponse<TreinoCommand.ReadCommand>> AddAsync(TreinoCommand.CreateCommand dto);
    public Task<ApiResponse<TreinoCommand.ReadCommand>> FindOneByIdAsync(Guid id);
    public Task<ApiResponse<IEnumerable<TreinoCommand.ReadCommand>>> FindAllAsync(Guid estabelecimentoId, Guid? id, int? offset = 0, int? limit = 100);
    public Task<ApiResponse> DeleteAsync(Guid id);
}
