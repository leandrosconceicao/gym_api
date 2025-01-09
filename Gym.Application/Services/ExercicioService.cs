using AutoMapper;
using Gym.Application.DTOs.ApiResponse;
using Gym.Application.DTOs.Exercicios;
using Gym.Domain.Entities;
using Gym.Domain.Exceptions;
using Gym.Domain.Interfaces.Repositories;
using Gym.Domain.Interfaces.Services;

namespace Gym.Application.Services;

public class ExercicioService(IMapper mapper, IExercicioRepository repository) : IExercicioService
{
    public async Task<ApiResponse<ExercicioCommand.ReadExercicio>> AddAsync(ExercicioCommand.CreateExercicio dto)
    {
        var value = await repository.AddAsync(MapCreateData(dto));

        return new ApiResponse<ExercicioCommand.ReadExercicio>(MapReadData(value));
    }
    public async Task<ApiResponse<IEnumerable<ExercicioCommand.ReadExercicio>>> FindAllAsync(Guid grupoMuscularId, int offset = 0, int limit = 100)
    {
        var values = await repository.FindAllAsync(grupoMuscularId, offset, limit);

        return new ApiResponse<IEnumerable<ExercicioCommand.ReadExercicio>>(MapReadData(values));
    }

    public async Task<ApiResponse<ExercicioCommand.ReadExercicio>> FindOneById(int id)
    {
        var value = await repository.FindOneAsync(id);

        if (value == null)
            throw new NotFoundError("Exercicio não localizado");

        return new ApiResponse<ExercicioCommand.ReadExercicio>(MapReadData(value));
    }

    public async Task<ApiResponse<ExercicioCommand.ReadExercicio>> DeleteAsync(int id)
    {
        var value = await repository.FindOneAsync(id);

        if (value == null)
            throw new NotFoundError("Exercicio não localizado");

        await repository.DeleteOneAsync(value);

        return new ApiResponse<ExercicioCommand.ReadExercicio>(MapReadData(value));

    }

    private IEnumerable<ExercicioCommand.ReadExercicio> MapReadData(IEnumerable<Exercicio> values)
    {
        return mapper.Map<IEnumerable<ExercicioCommand.ReadExercicio>>(values);
    }

    private ExercicioCommand.ReadExercicio MapReadData(Exercicio data)
    {
        return mapper.Map<ExercicioCommand.ReadExercicio>(data);
    }
    private Exercicio MapCreateData(ExercicioCommand.CreateExercicio data)
    {
        return mapper.Map<Exercicio>(data);
    }
}
