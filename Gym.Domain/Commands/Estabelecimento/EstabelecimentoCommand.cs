using System.ComponentModel.DataAnnotations;

namespace Gym.Domain.Commands 
{ 
    public class EstabelecimentoCommand
    {
        public class CreateEstabelecimento
        {
            [MinLength(1)]
            public required string Name { get; set; }

            [MaxLength(14)]
            [MinLength(11)]
            public required string Cgc { get; set; }
        }

        public class ReadEstabelecimento {
            
            public string Name { get; set; } = string.Empty;
        }
    }
}
