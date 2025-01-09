using Gym.Domain.Entities;

namespace Gym.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        public Task<Instrutor> AddUsuario(Instrutor instrutor);
        public Task<Aluno> AddUsuario(Aluno instrutor);
        public Task<IEnumerable<Instrutor>> FindAllInstrutores(Guid estabelecimentoId, int offset = 0, int limit = 100);
        public Task<IEnumerable<Aluno>> FindAllAalunos(Guid estabelecimentoId, int offset = 0, int limit = 100);
        public Task<Instrutor?> FindInstrutorById(Guid id);
        public Task<Aluno?> FindAlunoById(Guid id);
        public Task<bool> DeleteAluno(Aluno aluno);
        public Task<bool> DeleteInstrutor(Instrutor aluno);
    }
}
