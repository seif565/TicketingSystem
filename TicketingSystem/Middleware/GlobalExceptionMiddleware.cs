using Microsoft.AspNetCore.Mvc;
using TicketingSystem.Domain.Exceptions;

namespace TicketingSystem.Middleware;

public class GlobalExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            ProblemDetails problemDetails;
            if (ex is NotFoundException)
            {
                problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Not Found",
                    Detail = "An issue with retrieving an entity was encountered"
                };
            }
            else
            {
                problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Internal server error",
                    Detail = "A problem occured when processing the request"
                };
            }
            context.Response.StatusCode = problemDetails.Status.Value;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(problemDetails);
            await context.Response.Body.FlushAsync();
        }
    }
}
