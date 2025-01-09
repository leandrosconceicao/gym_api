using Gym.Domain.Entities;
using Gym.Domain.Exceptions;
using Gym.Domain.Interfaces.Repositories;
using Gym.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Gym.Repository
{
    public class EstabelecimentoRepository(ApplicationDbContext context) : IEstabelecimentoRepository
    {
        public async Task<Estabelecimento> Add(Estabelecimento item)
        {
            try
            {
                context.Estabelecimentos.Add(item);

                await context.SaveChangesAsync();

                return item;

            }
            catch (Exception e)
            {
                throw new DatabaseError(e.InnerException?.Message);
            }
        }

        public async Task<bool> Delete(Estabelecimento data)
        {
            try {
                context.Estabelecimentos.Remove(data);

                var deletedId = await context.SaveChangesAsync();

                return deletedId != 0;
            }
            catch (Exception e)
            {
                throw new DatabaseError(e.InnerException?.Message);
            }
        }

        public async Task<IEnumerable<Estabelecimento>> FindAllAsync(Guid? id, int offset = 0, int limit = 100)
        {
            try
            {
                var query = context.Set<Estabelecimento>().AsQueryable();

                if (id.HasValue) {
                    query = query.Where(e => e.Id == id);
                }
            
                return await query.ToListAsync();
            }
            catch (Exception e)
            {
                throw new DatabaseError(e.InnerException?.Message);
            }
        }

        public async Task<Estabelecimento?> FindOneById(Guid id)
        {
            try
            {
                var values = await context.Estabelecimentos
                    .Include(data => data.Proprietario)
                    .FirstOrDefaultAsync(x => x.Id == id);

                return values;
            }
            catch (Exception e)
            {
                throw new DatabaseError(e.InnerException?.Message);
            }
        }
    }
}
