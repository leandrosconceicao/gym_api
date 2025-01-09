using Gym.Domain.Entities;

namespace Gym.Domain.Interfaces.Repositories;

public interface ITreinoRepository
{

    Task<Treino> AddAsync(Treino treino);
    Task<IEnumerable<Treino>> FindAsync(Guid estabelcimentoId, Guid? id, int? offset = 0, int? limit = 100);
    Task<Treino?> FindAsync(Guid id);
    Task<bool> DeleteAsync(Treino treino);

}
