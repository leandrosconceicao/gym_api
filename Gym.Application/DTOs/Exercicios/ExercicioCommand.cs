using Gym.Application.DTOs.Entity;
using Gym.Application.DTOs.GrupoMuscular;

namespace Gym.Application.DTOs.Exercicios;
public class ExercicioCommand
{

    public class CreateExercicio {
        public required string Name { get; set; }
        public Guid? GrupoMuscularId { get; set; }
    }

    public class CreateExercicioSimple
    {
        public string Name { get; set; } = string.Empty;
    }

    public class ReadExercicio : EntityDTOSimple {
        public string Name { get; set; } = string.Empty;
        public Guid GrupoMuscularId { get; set; }
        public GrupoMuscularCommand.ReadGrupoMuscular? GrupoMuscularDetail {get; set;}
    }

}
