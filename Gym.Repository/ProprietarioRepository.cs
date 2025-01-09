using Gym.Domain.Entities;
using Gym.Domain.Exceptions;
using Gym.Domain.Interfaces.Repositories;
using Gym.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Gym.Repository
{
    public class ProprietarioRepository(ApplicationDbContext context) : IProprietarioRepository
    {
        public async Task<Proprietario> AddProprietario(Proprietario proprietario)
        {
            try
            {
                context.Proprietarios.Add(proprietario);

                await context.SaveChangesAsync();

                return proprietario;

            } catch (Exception e)
            {
                throw new DatabaseError(e.InnerException?.Message);
            }
        }

        public async Task<bool> DeleteProprietario(Proprietario proprietario)
        {
            try
            {
                context.Proprietarios.Remove(proprietario);

                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                throw new DatabaseError(e.InnerException?.Message);
            }
        }

        public async Task<IEnumerable<Proprietario>> FindAllProprietarios(int offset = 0, int limit = 100)
        {
            try
            {
                return await context.Proprietarios
                    .Skip(offset)
                    .Take(limit)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw new DatabaseError(e.InnerException?.Message);
            }
        }

        public Task<Proprietario?> FindProprietarioById(Guid id)
        {
            try
            {
                return context.Proprietarios
                    .Include(prop => prop.Estabelecimentos)
                    .FirstOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception e)
            {
                throw new DatabaseError(e.InnerException?.Message);
            }
        }
    }
}
