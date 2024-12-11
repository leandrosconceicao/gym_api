using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Domain.Entities
{
    public class Aluno : Usuario
    {
        [Key]
        public required Guid Id { get; set; } = Guid.NewGuid();
        
        [MaxLength(100)]
        public required string Name { get; set; }
    }
}
