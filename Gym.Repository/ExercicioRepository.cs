using Gym.Domain.Entities;
using Gym.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gym.Repository.RepositoryContext;

public class ExercicioRepository(ApiContext context) : IExercicioRepository
{
    public async Task<Exercicio> AddAsync(Exercicio exercicio)
    {
        context.Exercicios.Add(exercicio);

        await context.SaveChangesAsync();
        
        return exercicio;
    }

    public async Task<bool> DeleteOneAsync(Exercicio exercicio)
    {
        context.Exercicios.Remove(exercicio);

        return await context.SaveChangesAsync() != 0;
    }

    public async Task<IEnumerable<Exercicio>> FindAllAsync(Guid grupoMuscularId, int offset = 0, int limit = 100)
    {
        return await context.Exercicios
            .Where(exercicio => exercicio.GrupoMuscularId == grupoMuscularId)
            .Skip(offset)
            .Take(limit)
            .ToListAsync();
    }

    public async Task<Exercicio?> FindOneAsync(int id)
    {
        return await context.Exercicios
            .Include(exercicio => exercicio.GrupoMuscularDetail)
            .FirstOrDefaultAsync(exercicio => exercicio.Id == id);
    }
}
