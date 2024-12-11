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

        public IApiResponse<UsuarioCommand.ReadInstrutor> ReadInstrutor(Instrutor instrutor)
        {
            var parsed = mapper.Map<UsuarioCommand.ReadInstrutor>(instrutor);

            return new SuccessResponse<UsuarioCommand.ReadInstrutor>(parsed);
        }
        public IApiResponse<IEnumerable<UsuarioCommand.ReadInstrutor>> ReadInstrutor(IEnumerable<Instrutor> instrutores)
        {
            return new SuccessResponse<IEnumerable<UsuarioCommand.ReadInstrutor>>(
                instrutores.Select(instrutor => mapper.Map<UsuarioCommand.ReadInstrutor>(instrutor))
            );
        }
    }
}
