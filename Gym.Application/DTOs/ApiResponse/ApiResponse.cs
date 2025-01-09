using System.Text.Json.Serialization;

namespace Gym.Application.DTOs.ApiResponse;

public sealed class ApiResponse<T>(T result, string message = "", int statusCode = 200) where T : class
{
    [JsonPropertyName("message")]
    public string Message { get; set; } = message;

    [JsonPropertyName("result")]
    public bool Result { get; set; } = true;

    [JsonPropertyName("statusCode")]
    public int StatusCode { get; set; } = statusCode;
    public T Dados { get; private set; } = result;
}

public sealed class ApiResponse(string message = "", int statusCode = 200)
{
    [JsonPropertyName("message")]
    public string Message { get; set; } = message;

    [JsonPropertyName("result")]
    public bool Result { get; set; } = true;

    [JsonPropertyName("statusCode")]
    public int StatusCode { get; set; } = statusCode;
}
