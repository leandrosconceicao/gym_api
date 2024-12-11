using Gym.Domain.Entities;

namespace Gym.Domain.Interfaces
{
    public interface IGrupoMuscularRepository
    {
        Task<GrupoMuscular> AddAsync(GrupoMuscular grupo);

        Task<IEnumerable<GrupoMuscular>> FindAllAsync(Guid estabelecimentoId, int offset = 0, int limit = 100);

        Task<GrupoMuscular?> FindOneById(Guid id);

        Task<bool> DeleteAsync(GrupoMuscular grupo);
    }
}
