using AutoMapper;
using Gym.Domain.Commands.Exercicios;
using Gym.Domain.Entities;
using Gym.Domain.Interfaces;

namespace Gym.Domain.Handlers;

public class ExercicioHandler(IMapper mapper) : IExercicioHandler
{
    public Exercicio Create(ExercicioCommand.CreateExercicio command)
    {
        return mapper.Map<Exercicio>(command);
    }

    public IApiResponse<ExercicioCommand.ReadExercicio> Read(Exercicio data)
    {
        return new SuccessResponse<ExercicioCommand.ReadExercicio>(MapData(data));
    }

    public IApiResponse<IEnumerable<ExercicioCommand.ReadExercicio>> Read(IEnumerable<Exercicio> data)
    {
        return new SuccessResponse<IEnumerable<ExercicioCommand.ReadExercicio>>(data.Select(value => MapData(value)));
    }

    private ExercicioCommand.ReadExercicio MapData(Exercicio data)
    {
        return mapper.Map<ExercicioCommand.ReadExercicio>(data);
    }
}
