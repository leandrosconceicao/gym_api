using Gym.Domain.Entities;
using Gym.Domain.Interfaces;
using Gym.Repository.RepositoryContext;
using Microsoft.EntityFrameworkCore;

namespace Gym.Repository
{
    public class EstabelecimentoRepository(ApiContext context) : IEstabelecimentoRepository
    {
        public async Task<Estabelecimento> Add(Estabelecimento item)
        {
            context.Estabelecimentos.Add(item);

            await context.SaveChangesAsync();

            return item;
        }

        public async Task<bool> Delete(Estabelecimento data)
        {
            context.Estabelecimentos.Remove(data);

            var deletedId = await context.SaveChangesAsync();

            return deletedId != 0;
        }

        public async Task<IEnumerable<Estabelecimento>> FindAllAsync(Guid? id, int offset = 0, int limit = 100)
        {
            var query = context.Set<Estabelecimento>().AsQueryable();

            if (id.HasValue) {
                query = query.Where(e => e.Id == id);
            }
            
            return await query.ToListAsync();
        }

        public async Task<Estabelecimento?> FindOneById(Guid id)
        {
            var values = await context.Estabelecimentos.FirstOrDefaultAsync(x => x.Id == id);

            return values;
        }
    }
}
