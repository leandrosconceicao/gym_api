using AutoMapper;
using Gym.Application.DTOs;
using Gym.Application.DTOs.ApiResponse;
using Gym.Application.Interfaces;
using Gym.Application.Interfaces.Services;
using Gym.Domain.Entities;
using Gym.Domain.Exceptions;
using Gym.Domain.Interfaces.Repositories;

namespace Gym.Application.Services
{
    public sealed class EstabelecimentoService(IMapper mapper, IEstabelecimentoRepository repository) : IEstabelecimentoService
    {
        public async Task<ApiResponse<EstabelecimentoCommand.ReadEstabelecimento>> CreateAsync(EstabelecimentoCommand.CreateEstabelecimento dto)
        {
            var data = mapper.Map<Estabelecimento>(dto);

            var estabelecimento = await repository.Add(data);

            return new ApiResponse<EstabelecimentoCommand.ReadEstabelecimento>(
                mapper.Map<EstabelecimentoCommand.ReadEstabelecimento>(estabelecimento)
            );
        }

        public async Task<ApiResponse<IEnumerable<EstabelecimentoCommand.ReadEstabelecimento>>> FindAllAsync(Guid? id = null, int offse = 0, int limit = 100)
        {
            var values = await repository.FindAllAsync(id, offse, limit);

            return new ApiResponse<IEnumerable<EstabelecimentoCommand.ReadEstabelecimento>>(
                mapper.Map<IEnumerable<EstabelecimentoCommand.ReadEstabelecimento>>(values)
            );
        }

        public async Task<ApiResponse<EstabelecimentoCommand.ReadEstabelecimento>> FindOneById(Guid id)
        {
            var value = await repository.FindOneById(id);

            if (value == null)
                throw new NotFoundError("Estabelecimento não localizado");

            return new ApiResponse<EstabelecimentoCommand.ReadEstabelecimento>(mapper.Map<EstabelecimentoCommand.ReadEstabelecimento>(value));
        }

        public async Task<ApiResponse<EstabelecimentoCommand.ReadEstabelecimento>> DeleteAsync(Guid id)
        {
            var value = await repository.FindOneById(id);

            if (value == null)
                throw new NotFoundError("Estabelecimento não localizado");

            await repository.Delete(value);

            return new ApiResponse<EstabelecimentoCommand.ReadEstabelecimento>(mapper.Map<EstabelecimentoCommand.ReadEstabelecimento>(value));
        }
    }
}
