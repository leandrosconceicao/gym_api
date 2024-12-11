using System.ComponentModel.DataAnnotations;

namespace Gym.Domain.Commands.Usuario
{
    public class UsuarioCommand
    {
        public class CreateInstrutor
        {
            [MinLength(1)]
            public required string Name { get; set; }

            public required Guid EstabelecimentoId { get; set; }

            [MinLength(1)]
            public required string Username { get; set; }

            [MinLength(1)]
            public required string Password { get; set; }
        }

        public class ReadInstrutor
        {
            public Guid Id { get; set; }

            public required string Name { get; set; }

            public Guid EstabelecimentoId { get; set; }

            public required string Username { get; set; }

            public DateTime CreatedAt { get; set; }

            public DateTime UpdatedAt { get; set; }

            public EstabelecimentoCommand.ReadEstabelecimento EstabelecimentoDetail { get; set; }
        }

        public class CreateAluno
        {
            [MinLength(1)]
            public required string Name { get; set; }

            public required Guid EstabelecimentoId { get; set; }

            [MinLength(1)]
            public required string Username { get; set; }

            [MinLength(1)]
            public required string Password { get; set; }
        }
    }
}
