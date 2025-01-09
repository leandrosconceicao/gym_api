using Gym.Application.DTOs.ApiResponse;
using Gym.Application.DTOs.Proprietarios;

namespace Gym.Application.Interfaces.Services
{
    public interface IProprietarioService
    {
        public Task<ApiResponse<ProprietarioCommand.ReadProprietario>> AddAsync(ProprietarioCommand.CreateProprietario dto);
        public Task<ApiResponse<IEnumerable<ProprietarioCommand.ReadProprietario>>> FindAllAsync(int offset = 0, int limit = 100);
        public Task<ApiResponse<ProprietarioCommand.ReadProprietario>> FindOneById(Guid id);
        public Task<ApiResponse> DeleteAsync(Guid id);
    }
}
