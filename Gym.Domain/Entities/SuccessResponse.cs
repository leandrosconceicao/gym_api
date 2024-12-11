using Gym.Domain.Interfaces;

namespace Gym.Domain.Entities;

public class SuccessResponse<T>(T result, string message = "", int statusCode = 200) : IApiResponse<T> where T : class
{
    public string Message { get; set; } = message;
    public string? Tecnical { get; set; }
    public bool Result { get; set; } = true;
    public int StatusCode { get; set; } = statusCode;
    public T Dados { get; private set; } = result;
}
