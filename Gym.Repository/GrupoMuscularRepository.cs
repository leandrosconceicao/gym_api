using Gym.Domain.Entities;
using Gym.Domain.Interfaces;
using Gym.Repository.RepositoryContext;
using Microsoft.EntityFrameworkCore;

namespace Gym.Repository
{
    public class GrupoMuscularRepository(ApiContext context) : IGrupoMuscularRepository
    {
        public async Task<GrupoMuscular> AddAsync(GrupoMuscular grupo)
        {
            try
            {
                context.GruposMusculares.Add(grupo);
                await context.SaveChangesAsync();

                return grupo;
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(GrupoMuscular grupo)
        {
            context.GruposMusculares.Remove(grupo);

            return await context.SaveChangesAsync() != 0;
        }

        public async Task<IEnumerable<GrupoMuscular>> FindAllAsync(Guid estabelecimentoId, int offset = 0, int limit = 100)
        {
            var values = await context.GruposMusculares
                .Skip(offset)
                .Take(limit)
                .ToListAsync();

            return values;
        }

        public async Task<GrupoMuscular?> FindOneById(Guid id)
        {
            return await context.GruposMusculares
                .Include(grupo => grupo.EstabelecimentoDetail)
                .Include(grupo => grupo.Exercicios)
                .FirstOrDefaultAsync(x => x.Id == id)
            ;
        }
    }
}
