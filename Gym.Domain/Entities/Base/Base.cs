using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Domain.Entities;

public abstract class Base
{
        public required Guid EstabelecimentoId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }
        public required virtual Estabelecimento EstabelecimentoDetail { get; set; }
}
