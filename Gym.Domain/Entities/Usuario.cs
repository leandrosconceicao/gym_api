using Gym.Domain.Entities;

namespace Gym.Domain.Entities
{
    public abstract class Usuario : Base
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
