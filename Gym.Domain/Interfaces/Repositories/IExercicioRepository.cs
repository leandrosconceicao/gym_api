using Gym.Domain.Entities;

namespace Gym.Domain.Interfaces.Repositories
{
    public interface IExercicioRepository
    {
        Task<Exercicio> AddAsync(Exercicio exercicio);

        Task<Exercicio?> FindOneAsync(int id);

        Task<IEnumerable<Exercicio>> FindAllAsync(Guid grupoMuscularId, int offset = 0, int limit = 100);

        Task<bool> DeleteOneAsync(Exercicio id);
    }
}
