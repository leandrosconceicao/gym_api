using Gym.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Gym.Domain.Middlewares;
public class CustomExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var response = new ErrorResponse {
            Message = "Ocorreu um problema, estamos trabalhando para corrigir",
            Tecnical = context.Exception.Message
        };

        if (context.Exception is KeyNotFoundException)
        {
            response = new ErrorResponse{
                Message = "Resource not found.",
                Tecnical = context.Exception.Message
            };
            context.Result = new JsonResult(response) { StatusCode = 404 };
        }
        else
        {
            context.Result = new JsonResult(response) { StatusCode = 500 };
        }

        context.ExceptionHandled = true;
    }
}
