using System;
using Gym.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gym.Domain.Middlewares;

public class ValidationProblemDetailResult : IActionResult
{
    public async Task ExecuteResultAsync(ActionContext context)
    {
        var keys = context.ModelState.Keys;
        var dic = context.ModelState.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
            );
        var problemDetails = new ErrorResponse {
            Message = "Dados Enviados são inválidos",
            Tecnical = string.Join("\n", dic.Select(dt => $"{dt.Key} - ${string.Join(",", dt.Value)}"))
        };
        var objectResult = new ObjectResult(problemDetails) { StatusCode = problemDetails.StatusCode };
        await objectResult.ExecuteResultAsync(context);
    }
}
