using AutoMapper;
using Gym.Application.DTOs.ApiResponse;
using Gym.Application.DTOs.Proprietarios;
using Gym.Application.Interfaces.Services;
using Gym.Domain.Entities;
using Gym.Domain.Exceptions;
using Gym.Domain.Interfaces.Repositories;

namespace Gym.Application.Services
{
    public class ProprietarioService(IMapper mapper, IProprietarioRepository repository) : IProprietarioService
    {
        public async Task<ApiResponse<ProprietarioCommand.ReadProprietario>> AddAsync(ProprietarioCommand.CreateProprietario dto)
        {
            var newProprietario = await repository.AddProprietario(mapper.Map<Proprietario>(dto));

            return new ApiResponse<ProprietarioCommand.ReadProprietario>(MapData(newProprietario));
        }

        public async Task<ApiResponse> DeleteAsync(Guid id)
        {
            var data = await FindById(id);

            await repository.DeleteProprietario(data);

            return new ApiResponse();
        }

        public async Task<ApiResponse<IEnumerable<ProprietarioCommand.ReadProprietario>>> FindAllAsync(int offset = 0, int limit = 100)
        {
            var values = await repository.FindAllProprietarios(offset, limit);

            return new ApiResponse<IEnumerable<ProprietarioCommand.ReadProprietario>>(MapData(values));
        }

        public async Task<ApiResponse<ProprietarioCommand.ReadProprietario>> FindOneById(Guid id)
        {
            var proprietario = await FindById(id);

            return new ApiResponse<ProprietarioCommand.ReadProprietario>(MapData(proprietario));
        }

        private ProprietarioCommand.ReadProprietario MapData(Proprietario proprietario)
        {
            return mapper.Map<ProprietarioCommand.ReadProprietario>(proprietario);
        }
        private IEnumerable<ProprietarioCommand.ReadProprietario> MapData(IEnumerable<Proprietario> proprietario)
        {
            return mapper.Map<IEnumerable<ProprietarioCommand.ReadProprietario>>(proprietario);
        }

        private async Task<Proprietario> FindById(Guid id)
        {
            var data = await repository.FindProprietarioById(id) ?? throw new NotFoundError("Proprietário não localizado");

            return data;
        }
    }
}
