using Gym.Domain.Commands.Exercicios;
using Gym.Domain.Entities;

namespace Gym.Domain.Commands.Usuario;

public class TreinoCommand
{

    public class CreateCommand {
        public ICollection<ExercicioCommand.CreateExercicio> Exercicios { get; set; } = [];
        public required string Description { get; set; }
        public Guid AlunoId { get; set; }
    }

    public class ReadCommand {
        public ICollection<ExercicioCommand.ReadExercicio> Exercicios { get; set; } = [];
        public required string Description { get; set; }
        public Guid AlunoId { get; set; }
        public UsuarioCommand.ReadAluno AlunoDetail {get; set;}
    }

}
