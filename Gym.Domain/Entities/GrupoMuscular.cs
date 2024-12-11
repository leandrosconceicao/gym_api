using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Domain.Entities
{
    public class GrupoMuscular
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [MaxLength(255)]
        public required string Name { get; set; }

        public required Guid EstabelecimentoId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }
        public ICollection<Exercicio> Exercicios { get; set; } = []; 
        public virtual Estabelecimento EstabelecimentoDetail { get; set; }
    }
}
