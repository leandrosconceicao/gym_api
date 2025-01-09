using Gym.Application.DTOs.ApiResponse;
using Gym.Application.DTOs.GrupoMuscular;

namespace Gym.Application.Interfaces.Services
{
    public interface IGrupoMuscularService
    {
        public Task<ApiResponse<GrupoMuscularCommand.ReadGrupoMuscular>> AddAsync(GrupoMuscularCommand.CreateGrupoMuscular dto);
        public Task<ApiResponse> DeleteAsync(Guid id);
        public Task<ApiResponse<IEnumerable<GrupoMuscularCommand.ReadGrupoMuscular>>> FindAllAsync(Guid estabelecimentoId, int offset = 0, int limit = 100);
        public Task<ApiResponse<GrupoMuscularCommand.ReadGrupoMuscular>> FindOneById(Guid id);
    }
}
