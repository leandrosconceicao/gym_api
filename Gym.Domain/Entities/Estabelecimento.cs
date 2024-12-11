using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Domain.Entities
{
    public class Estabelecimento
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(14)]
        public required string Cgc { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }
    }
}
