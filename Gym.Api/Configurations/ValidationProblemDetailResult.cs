using Gym.Application.DTOs.ApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace Gym.Domain.Middlewares;

public class ValidationProblemDetailResult : IActionResult
{
    public async Task ExecuteResultAsync(ActionContext context)
    {
        var keys = context.ModelState.Keys;
        var dic = context.ModelState.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray() ?? []
            );
        var problemDetails = new ApiResponse {
            Result = false,
            Message = $"Dados Enviados são inválidos - {string.Join(", ", dic.Select(dt => $"{dt.Key} - ${string.Join(",", dt.Value)}"))}",
            StatusCode = 400
        };
        var objectResult = new ObjectResult(problemDetails) { StatusCode = problemDetails.StatusCode };
        await objectResult.ExecuteResultAsync(context);
    }
}
