using Gym.Application.DTOs.Entity;
using Gym.Application.DTOs.Exercicios;
using System.ComponentModel.DataAnnotations;

namespace Gym.Application.DTOs.GrupoMuscular
{
    public class GrupoMuscularCommand
    {
        public class ReadGrupoMuscular : EntityDTO
        {
            public required string Name { get; set; }
            public Guid EstabelecimentoId { get; set; }
            public ICollection<ExercicioCommand.ReadExercicio> Exercicios { get; set; } = [];
            public EstabelecimentoCommand.ReadEstabelecimento? Estabelecimento { get; set; }
        }

        public class CreateGrupoMuscular
        {
            [MinLength(1)]
            [MaxLength(255)]
            public required string Name { get; set; }

            [Required]
            public Guid EstabelecimentoId { get; set; }
            public IEnumerable<ExercicioCommand.CreateExercicioSimple>? Exercicios { get; set; } = [];
        }
    }
}
