using System.Net;

namespace Gym.Domain.Exceptions
{
    public class NotFoundError : ExcecaoBase
    {
        public NotFoundError(string? message = null)
        {
            HttpStatus = HttpStatusCode.NotFound;
            Mensagem = message ?? "Registro não encontrado";
        }
    }

    public class DuplicateDataError : ExcecaoBase
    {
        public DuplicateDataError(string? message = null)
        {
            HttpStatus = HttpStatusCode.Conflict;
            Mensagem = message ?? "Registro duplicado";
        }
    }

    public class DatabaseError : ExcecaoBase
    {
        public DatabaseError(string? message = null)
        {
            HttpStatus = HttpStatusCode.InternalServerError;
            Mensagem = message ?? "Houve um erro no banco de Dados";
        }
    }

    public class UnknowError : ExcecaoBase
    {
        public UnknowError(string message)
        {
            HttpStatus = HttpStatusCode.InternalServerError;
            Mensagem = message;
        }
    }
}
