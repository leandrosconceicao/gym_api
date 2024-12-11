using Gym.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Gym.Domain.Middlewares;
public class CustomValidationFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState
                .Where(m => m.Value.Errors.Count > 0)
                .Select(m => new
                {
                    Field = m.Key,
                    Errors = m.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                });

            var response = new ErrorResponse {
                Message = "Validation failed.",
                Tecnical = errors.ToString()
            };

            context.Result = new JsonResult(response) { StatusCode = 400 };
        }
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}
