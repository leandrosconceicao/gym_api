using Gym.Domain.Entities;
using Gym.Domain.Exceptions;
using Gym.Domain.Interfaces;
using Gym.Repository.RepositoryContext;
using Microsoft.EntityFrameworkCore;
using System;
namespace Gym.Repository
{
    public class UsuarioRepository(ApiContext context) : IUsuarioRepository
    {
        public async Task<Instrutor> AddUsuario(Instrutor instrutor)
        {

            try
            {
                context.Instrutores.Add(instrutor);

                await context.SaveChangesAsync();

                return instrutor;

            } catch (Exception exception)
            {
                if (exception.Source == "MySql.EntityFrameworkCore" && (exception?.InnerException?.Message ?? "").Contains("Duplicate"))
                    throw new DuplicateDataError("Instrutor já cadastrado nesse estabelecimento, username inválido");

                throw;

            }
        }

        public async Task<Aluno> AddUsuario(Aluno aluno)
        {
            context.Alunos.Add(aluno);

            await context.SaveChangesAsync();

            return aluno;
        }

        public async Task<bool> DeleteAluno(Aluno aluno)
        {
            context.Alunos.Remove(aluno);

            return await context.SaveChangesAsync() != 0;
        }

        public async Task<bool> DeleteInstrutor(Instrutor instrutor)
        {
            context.Instrutores.Remove(instrutor);

            return await context.SaveChangesAsync() != 0;
        }

        public async Task<IEnumerable<Aluno>> FindAllAalunos(Guid estabelecimentoId, int offset = 0, int limit = 100)
        {
            var values = await context.Alunos.Where(
                aluno => aluno.EstabelecimentoId == estabelecimentoId)
            .Skip(offset)
            .Take(limit)
            .ToListAsync();

            return values;
        }

        public async Task<IEnumerable<Instrutor>> FindAllInstrutores(Guid estabelecimentoId, int offset = 0, int limit = 100)
        {
            var values = await context.Instrutores.Where(
                aluno => aluno.EstabelecimentoId == estabelecimentoId)
            .Skip(offset)
            .Take(limit)
            .ToListAsync();

            return values;
        }

        public async Task<Aluno?> FindAlunoById(Guid id)
        {
            return await context.Alunos
                .Include(aluno => aluno.EstabelecimentoDetail)
                .FirstOrDefaultAsync(aluno => aluno.Id == id);
        }

        public async Task<Instrutor?> FindInstrutorById(Guid id)
        {
            return await context.Instrutores
                .Include(instrutor => instrutor.EstabelecimentoDetail)
                .FirstOrDefaultAsync(instrutor => instrutor.Id == id);
        }
    }
}
