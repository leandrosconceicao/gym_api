using AutoMapper;
using Gym.Domain.Commands.Exercicios;
using Gym.Domain.Entities;

namespace Gym.Domain.Profiles;

public class ExercicioProfile : Profile
{
    public ExercicioProfile() {
        
        CreateMap<ExercicioCommand.CreateExercicio, Exercicio>();
        CreateMap<Exercicio, ExercicioCommand.ReadExercicio>();
    }
}
