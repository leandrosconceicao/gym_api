using Gym.Application.DTOs.Entity;
using System.ComponentModel.DataAnnotations;

namespace Gym.Application.DTOs.Usuario
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

        public class ReadInstrutor : EntityDTO
        {
            public required string Name { get; set; }

            public Guid EstabelecimentoId { get; set; }

            public required string Username { get; set; }

            public EstabelecimentoCommand.ReadEstabelecimento? Estabelecimento { get; set; }
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

        public class ReadAluno : EntityDTO
        {
            public required string Name { get; set; }
            public required Guid EstabelecimentoId { get; set; }
            public required string Username { get; set; }
            public EstabelecimentoCommand.ReadEstabelecimento? Estabelecimento {get; set;}
        }
    }
}
