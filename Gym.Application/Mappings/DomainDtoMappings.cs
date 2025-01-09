using AutoMapper;
using Gym.Application.DTOs;
using Gym.Application.DTOs.Exercicios;
using Gym.Application.DTOs.GrupoMuscular;
using Gym.Application.DTOs.Proprietarios;
using Gym.Application.DTOs.Usuario;
using Gym.Domain.Entities;

namespace Gym.Application.Mappings
{
    public class DomainDtoMappings : Profile
    {
        public DomainDtoMappings() {

            CreateMap<EstabelecimentoCommand.CreateEstabelecimento, Estabelecimento>();

            CreateMap<Estabelecimento, EstabelecimentoCommand.ReadEstabelecimento>();

            CreateMap<ExercicioCommand.CreateExercicio, Exercicio>();

            CreateMap<Exercicio, ExercicioCommand.ReadExercicio>();

            CreateMap<GrupoMuscularCommand.CreateGrupoMuscular, GrupoMuscular>();

            CreateMap<GrupoMuscular, GrupoMuscularCommand.ReadGrupoMuscular>();

            CreateMap<ProprietarioCommand.CreateProprietario, Proprietario>();

            CreateMap<Proprietario, ProprietarioCommand.ReadProprietario>();

            CreateMap<TreinoCommand.CreateCommand, Treino>();

            CreateMap<Treino, TreinoCommand.ReadCommand>();

            CreateMap<UsuarioCommand.CreateInstrutor, Instrutor>();

            CreateMap<UsuarioCommand.CreateAluno, Aluno>();

            CreateMap<Instrutor, UsuarioCommand.ReadInstrutor>();

            CreateMap<Aluno, UsuarioCommand.ReadAluno>();

        }
    }
}
