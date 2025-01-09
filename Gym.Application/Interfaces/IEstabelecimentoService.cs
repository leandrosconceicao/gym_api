using Gym.Application.DTOs;
using Gym.Application.DTOs.ApiResponse;

namespace Gym.Application.Interfaces.Services
{
    public interface IEstabelecimentoService
    { 
        Task<ApiResponse<EstabelecimentoCommand.ReadEstabelecimento>> CreateAsync(EstabelecimentoCommand.CreateEstabelecimento dto);
        Task<ApiResponse<EstabelecimentoCommand.ReadEstabelecimento>> FindOneById(Guid id);
        Task<ApiResponse<IEnumerable<EstabelecimentoCommand.ReadEstabelecimento>>> FindAllAsync(Guid? id = null, int offse = 0, int limit = 100);
        Task<ApiResponse<EstabelecimentoCommand.ReadEstabelecimento>> DeleteAsync(Guid id);
    }
}
