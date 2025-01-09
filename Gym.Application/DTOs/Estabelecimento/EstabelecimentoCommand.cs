using Gym.Application.DTOs.Entity;
using Gym.Application.DTOs.Proprietarios;
using System.ComponentModel.DataAnnotations;

namespace Gym.Application.DTOs 
{ 
    public class EstabelecimentoCommand
    {
        public class CreateEstabelecimento
        {
            [Required]
            public Guid ProprietarioId { get; set; }

            [MinLength(1)]
            [MaxLength(128)]
            public required string Name { get; set; }
        }

        public class ReadEstabelecimento : EntityDTO {

            public string Name { get; set; } = string.Empty;
            public Guid ProprietarioId { get; set; }
            public ProprietarioCommand.ReadProprietario? Proprietario { get; set; }
        }
    }
}
