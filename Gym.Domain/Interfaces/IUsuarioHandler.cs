using Gym.Domain.Commands.Usuario;
using Gym.Domain.Entities;

namespace Gym.Domain.Interfaces
{
    public interface IUsuarioHandler
    {
        Instrutor CreateUsuario(UsuarioCommand.CreateInstrutor command);

        IApiResponse<UsuarioCommand.ReadInstrutor> ReadInstrutor(Instrutor instrutor);
        IApiResponse<IEnumerable<UsuarioCommand.ReadInstrutor>> ReadInstrutor(IEnumerable<Instrutor> instrutor);

        Aluno CreateUsuario(UsuarioCommand.CreateAluno command);
    }
}
