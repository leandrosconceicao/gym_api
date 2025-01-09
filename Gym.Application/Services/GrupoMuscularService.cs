using AutoMapper;
using Gym.Application.DTOs.ApiResponse;
using Gym.Application.DTOs.GrupoMuscular;
using Gym.Application.Interfaces.Services;
using Gym.Domain.Entities;
using Gym.Domain.Exceptions;
using Gym.Domain.Interfaces.Repositories;

namespace Gym.Application.Services
{
    public class GrupoMuscularService(IMapper mapper, IGrupoMuscularRepository repository) : IGrupoMuscularService
    {
        public async Task<ApiResponse<GrupoMuscularCommand.ReadGrupoMuscular>> AddAsync(GrupoMuscularCommand.CreateGrupoMuscular dto)
        {
            var grupo = await repository.AddAsync(mapper.Map<GrupoMuscular>(dto));

            return new ApiResponse<GrupoMuscularCommand.ReadGrupoMuscular>(MapData(grupo));
        }

        public async Task<ApiResponse> DeleteAsync(Guid id)
        {
            var grupo = await repository.FindOneById(id) 
                ?? throw new NotFoundError("Grupo muscular não localizado");

            await repository.DeleteAsync(grupo);

            return new ApiResponse {
                StatusCode = 204,
            };
        }

        public async Task<ApiResponse<IEnumerable<GrupoMuscularCommand.ReadGrupoMuscular>>> FindAllAsync(Guid estabelecimentoId, int offset = 0, int limit = 100)
        {
            var grupos = await repository.FindAllAsync(estabelecimentoId, offset, limit);

            return new ApiResponse<IEnumerable<GrupoMuscularCommand.ReadGrupoMuscular>>(MapData(grupos));
        }

        public async Task<ApiResponse<GrupoMuscularCommand.ReadGrupoMuscular>> FindOneById(Guid id)
        {
            var grupo = await repository.FindOneById(id) 
                ?? throw new NotFoundError("Grupo muscular não localizado");

            return new ApiResponse<GrupoMuscularCommand.ReadGrupoMuscular>(MapData(grupo));
        }

        private IEnumerable<GrupoMuscularCommand.ReadGrupoMuscular> MapData(IEnumerable<GrupoMuscular> grupos) {
            return mapper.Map<IEnumerable<GrupoMuscularCommand.ReadGrupoMuscular>>(grupos);
        }

        private GrupoMuscularCommand.ReadGrupoMuscular MapData(GrupoMuscular grupo)
        {
            return mapper.Map<GrupoMuscularCommand.ReadGrupoMuscular>(grupo);
        }
    }
}
