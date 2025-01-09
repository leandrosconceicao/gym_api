namespace Gym.Domain.Entities
{
    public abstract class Usuario : EstabelecimentoEntity
    {
        private string _username = string.Empty;

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value.ToLower();
            }
        }
        public string Password { get; set; } = string.Empty;
    }
}
