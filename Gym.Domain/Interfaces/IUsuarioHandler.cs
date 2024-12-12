using Gym.Domain.Commands.Usuario;
using Gym.Domain.Entities;

namespace Gym.Domain.Interfaces
{
    public interface IUsuarioHandler
    {
        Instrutor CreateUsuario(UsuarioCommand.CreateInstrutor command);
        Aluno CreateUsuario(UsuarioCommand.CreateAluno command);

        IApiResponse<UsuarioCommand.ReadInstrutor> ReadUsuario(Instrutor instrutor);
        IApiResponse<IEnumerable<UsuarioCommand.ReadInstrutor>> ReadUsuario(IEnumerable<Instrutor> instrutor);
        IApiResponse<UsuarioCommand.ReadAluno> ReadUsuario(Aluno aluno);
        IApiResponse<IEnumerable<UsuarioCommand.ReadAluno>> ReadUsuario(IEnumerable<Aluno> alunos);

    }
}
