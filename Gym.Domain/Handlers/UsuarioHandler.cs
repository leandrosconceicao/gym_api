using AutoMapper;
using Gym.Domain.Commands.Usuario;
using Gym.Domain.Entities;
using Gym.Domain.Interfaces;
using Gym.Domain.Utils;

namespace Gym.Domain.Handlers
{
    public class UsuarioHandler(IMapper mapper) : IUsuarioHandler
    {
        public Instrutor CreateUsuario(UsuarioCommand.CreateInstrutor command)
        {
            var usuario = mapper.Map<Instrutor>(command);

            usuario.Password = Crypto.GetHashedPassword(usuario.Password);

            return usuario;
        }

        public Aluno CreateUsuario(UsuarioCommand.CreateAluno command)
        {
            return mapper.Map<Aluno>(command);
        }

        public IApiResponse<UsuarioCommand.ReadInstrutor> ReadUsuario(Instrutor instrutor)
        {
            var parsed = mapper.Map<UsuarioCommand.ReadInstrutor>(instrutor);

            return new SuccessResponse<UsuarioCommand.ReadInstrutor>(parsed);
        }
        public IApiResponse<UsuarioCommand.ReadAluno> ReadUsuario(Aluno aluno)
        {
            var parsed = mapper.Map<UsuarioCommand.ReadAluno>(aluno);

            return new SuccessResponse<UsuarioCommand.ReadAluno>(parsed);
        }
        public IApiResponse<IEnumerable<UsuarioCommand.ReadAluno>> ReadUsuario(IEnumerable<Aluno> alunos)
        {
            return new SuccessResponse<IEnumerable<UsuarioCommand.ReadAluno>>(
                alunos.Select(instrutor => mapper.Map<UsuarioCommand.ReadAluno>(instrutor))
            );
        }

        public IApiResponse<IEnumerable<UsuarioCommand.ReadInstrutor>> ReadUsuario(IEnumerable<Instrutor> instrutores)
        {
            return new SuccessResponse<IEnumerable<UsuarioCommand.ReadInstrutor>>(
                instrutores.Select(instrutor => mapper.Map<UsuarioCommand.ReadInstrutor>(instrutor))
            );
        }
    }
}
