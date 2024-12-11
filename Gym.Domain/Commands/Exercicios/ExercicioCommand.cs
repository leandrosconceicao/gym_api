using Gym.Domain.Commands.GrupoMuscular;

namespace Gym.Domain.Commands.Exercicios;
public class ExercicioCommand
{

    public class CreateExercicio {
        required public int Id { get; set; }
        public required string Name { get; set; }
        public required Guid GrupoMuscularId { get; set; }
    }

    public class ReadExercicio {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid GrupoMuscularId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public GrupoMuscularCommand.ReadGrupoMuscular? GrupoMuscularDetail {get; set;}
    }

}
