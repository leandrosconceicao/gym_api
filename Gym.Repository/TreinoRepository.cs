using Gym.Domain.Entities;
using Gym.Domain.Interfaces.Repositories;
using Gym.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Gym.Repository;

public class TreinoRepository(ApplicationDbContext context) : ITreinoRepository
{
    public async Task<Treino> AddAsync(Treino treino)
    {
        context.Treinos.Add(treino); 
        
        await context.SaveChangesAsync();

        return treino;
    }

    public async Task<IEnumerable<Treino>> FindAsync(Guid estabelcimentoId, Guid? id, int? offset = 0, int? limit = 100)
    {
        var query = context.Set<Treino>().AsQueryable();

        query = query.Where(treino => treino.EstabelecimentoId == estabelcimentoId);

        if (id.HasValue) {
            query = query.Where(treino => treino.Id == id.Value);
        }

        return await query.ToListAsync();
    }

    public async Task<Treino?> FindAsync(Guid id)
    {
        return await context.Treinos.FirstOrDefaultAsync(treino => treino.Id == id);
    }

    public async Task<bool> DeleteAsync(Treino treino)
    {
        context.Treinos.Remove(treino);

        return await context.SaveChangesAsync() != 0;
    }
}
