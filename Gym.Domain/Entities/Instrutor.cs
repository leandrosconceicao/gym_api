using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Domain.Entities
{
    public class Instrutor : Usuario
    {
        [Key]
        public required Guid Id { get; set; } = Guid.NewGuid();
        
        [MaxLength(100)]
        public required string Name { get; set; }
        // public required Guid EstabelecimentoId { get; set; }

        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // public DateTime CreatedAt { get; set; }

        // [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        // public DateTime UpdatedAt { get; set; }
        // public virtual Estabelecimento EstabelecimentoDetail { get; set; }
    }
}
