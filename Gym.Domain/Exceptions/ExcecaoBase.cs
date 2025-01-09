using System.Net;

namespace Gym.Domain.Exceptions
{
    public class ExcecaoBase : Exception
    {
        public string Mensagem { get; protected set; } = string.Empty;
        public HttpStatusCode HttpStatus { get; protected set; }
        public string Excecao { get; protected set; } = string.Empty;

        public override string Message { get {
                return Mensagem;
            }
        }
    }
}
