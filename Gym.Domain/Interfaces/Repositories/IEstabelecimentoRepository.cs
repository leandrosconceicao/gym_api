using Gym.Domain.Entities;

namespace Gym.Domain.Interfaces.Repositories
{
    public interface IEstabelecimentoRepository
    {
        Task<IEnumerable<Estabelecimento>> FindAllAsync(Guid? id = null, int offset = 0, int limit = 100);
        Task<Estabelecimento?> FindOneById(Guid id);
        Task<Estabelecimento> Add(Estabelecimento item);
        Task<bool> Delete(Estabelecimento id);
    }
}
