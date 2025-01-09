using Gym.Application.DTOs.ApiResponse;
using Gym.Application.DTOs.Exercicios;

namespace Gym.Domain.Interfaces.Services;

public interface IExercicioService
{
    public Task<ApiResponse<ExercicioCommand.ReadExercicio>> AddAsync(ExercicioCommand.CreateExercicio dto);
    public Task<ApiResponse<ExercicioCommand.ReadExercicio>> FindOneById(int id);
    public Task<ApiResponse<IEnumerable<ExercicioCommand.ReadExercicio>>> FindAllAsync(Guid grupoMuscularId, int offset = 0, int limit = 100);
    public Task<ApiResponse<ExercicioCommand.ReadExercicio>> DeleteAsync(int id);

}
