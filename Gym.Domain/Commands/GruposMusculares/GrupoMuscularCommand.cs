using Gym.Domain.Commands.Exercicios;
using Gym.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Gym.Domain.Commands.GrupoMuscular
{
    public class GrupoMuscularCommand
    {
        public class ReadGrupoMuscular
        {
            public Guid Id { get; set; }
            public required string Name { get; set; }
            public Guid EstabelecimentoId { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
            public ICollection<ExercicioCommand.ReadExercicio> Exercicios { get; set; } = [];
            public virtual Estabelecimento EstabelecimentoDetail { get; set; }
        }

        public class CreateGrupoMuscular
        {
            [MinLength(1)]
            [MaxLength(255)]
            public required string Name { get; set; }

            [Required]
            public Guid EstabelecimentoId { get; set; }
            public ICollection<ExercicioCommand.CreateExercicio>? Exercicios { get; set; }
        }
    }
}
