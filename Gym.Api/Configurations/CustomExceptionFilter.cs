using Gym.Application.DTOs.ApiResponse;
using Gym.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Data.Common;

namespace Gym.Domain.Middlewares;
public class CustomExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ExcecaoBase exception)
        {
            var response = new ApiResponse
            {
                Result = false,
                Message = exception.Message,
                StatusCode = (int)exception.HttpStatus
            };
            context.Result = new JsonResult(response) { StatusCode = response.StatusCode };
        } else if (context.Exception is DbException exception1)
        {
            var response = new ApiResponse
            {
                Result = false,
                Message = exception1.Message,
                StatusCode = 500
            };
            context.Result = new JsonResult(response) { StatusCode = response.StatusCode };
        }
        else
        {
            var response = new ApiResponse
            {
                Result = false,
                Message = context.Exception.Message,
                StatusCode = 500
            };
            context.Result = new JsonResult(response) { StatusCode = 500 };
        }

        context.ExceptionHandled = true;
    }
}
