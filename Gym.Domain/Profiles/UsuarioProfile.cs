using AutoMapper;
using Gym.Domain.Commands.Usuario;
using Gym.Domain.Entities;

namespace Gym.Domain.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile() 
        {
            CreateMap<UsuarioCommand.CreateInstrutor, Instrutor>();

            CreateMap<UsuarioCommand.CreateAluno, Aluno>();

            CreateMap<Instrutor, UsuarioCommand.ReadInstrutor>();
        }
    }
}
