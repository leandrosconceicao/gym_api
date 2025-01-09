using Gym.Application.DTOs.Entity;
using Gym.Application.DTOs.Exercicios;

namespace Gym.Application.DTOs.Usuario;

public class TreinoCommand
{

    public class CreateCommand {
        public ICollection<ExercicioCommand.CreateExercicio> Exercicios { get; set; } = [];
        public required string Description { get; set; }
        public Guid AlunoId { get; set; }
    }

    public class ReadCommand : EntityDTO {
        public ICollection<ExercicioCommand.ReadExercicio> Exercicios { get; set; } = [];
        public required string Description { get; set; }
        public Guid AlunoId { get; set; }
        public UsuarioCommand.ReadAluno? AlunoDetail {get; set;}
    }

}
