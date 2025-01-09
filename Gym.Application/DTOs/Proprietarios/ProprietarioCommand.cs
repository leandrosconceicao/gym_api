using Gym.Application.DTOs.Entity;
using System.ComponentModel.DataAnnotations;

namespace Gym.Application.DTOs.Proprietarios
{
    public class ProprietarioCommand
    {
        public class CreateProprietario
        {
            [Required]
            public required string Name { get; set; }

            [Required]
            public required string Cgc { get; set; }

            [Required]
            [MinLength(1)]
            [MaxLength(128)]
            public required string Username { get; set; }

            [Required]
            [MinLength(1)]
            public required string Password { get; set; }


        }

        public class ReadProprietario : EntityDTO {
            public string Name { get; set; } = string.Empty;
            public string Username { get; set; } = string.Empty;
            public IEnumerable<EstabelecimentoCommand.ReadEstabelecimento>? Estabelecimentos { get; set; }
        }
    }
}
