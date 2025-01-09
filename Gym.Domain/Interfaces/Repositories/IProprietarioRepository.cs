using Gym.Domain.Entities;

namespace Gym.Domain.Interfaces.Repositories
{
    public interface IProprietarioRepository
    {
        public Task<Proprietario> AddProprietario(Proprietario Proprietario);
        public Task<IEnumerable<Proprietario>> FindAllProprietarios(int offset = 0, int limit = 100);
        public Task<Proprietario?> FindProprietarioById(Guid id);
        public Task<bool> DeleteProprietario(Proprietario Proprietario);
    }
}
