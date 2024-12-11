using Gym.Domain.Commands.Exercicios;
using Gym.Domain.Entities;

namespace Gym.Domain.Interfaces;

public interface IExercicioHandler
{
    public Exercicio Create(ExercicioCommand.CreateExercicio command);
    public IApiResponse<ExercicioCommand.ReadExercicio> Read(Exercicio data);
    public IApiResponse<IEnumerable<ExercicioCommand.ReadExercicio>> Read(IEnumerable<Exercicio> data);
    
}
