using Entities.Error;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AspBase.Extensions.Middleware;

public static class ExceptionExtensionMiddleware
{
    public static void ConfigureExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.ContentType = "application/problem+json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature is not null)
                {
                    var error = contextFeature.Error;
                    
                    // StatusCode belirle
                    var statusCode = error switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    context.Response.StatusCode = statusCode;

                    var problemDetails = new ProblemDetails
                    {
                        Status = statusCode,
                        Title = GetDefaultTitle(statusCode),
                        Detail = error.Message,
                        Instance = context.Request.Path
                    };

                    await context.Response.WriteAsJsonAsync(problemDetails);
                }
            });
        });
    }

    private static string GetDefaultTitle(int statusCode) => statusCode switch
    {
        StatusCodes.Status404NotFound => "Resource Not Found",
        StatusCodes.Status401Unauthorized => "Unauthorized",
        StatusCodes.Status500InternalServerError => "Internal Server Error",
        _ => "Unexpected Error"
    };
}