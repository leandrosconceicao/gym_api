using Gym.Domain.Utils;

namespace Gym.Domain.Entities
{
    public class Proprietario : Entity
    {
        public Proprietario(string name, string cgc, string username, string password)
        {
            Name = name;
            Cgc = cgc;
            Username = username;
            Password = Crypto.GetHashedPassword(password);
        }

        public Proprietario(Guid id, string name, string cgc, string username, string password)
        {
            Id = id;
            Name = name;
            Cgc = cgc;
            Username = username;
            Password = Crypto.GetHashedPassword(password);
            CreatedAt = new DateTime();
        }

        public string Username { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public string Cgc { get; private set; } = string.Empty;
        public virtual ICollection<Estabelecimento> Estabelecimentos { get; set; } = [];
    }
}
