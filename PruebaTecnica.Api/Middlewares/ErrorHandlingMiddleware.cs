using System.Net;
using System.Text.Json;

namespace PruebaTecnicaCarsalesBFF.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next) => _next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;
        var message = "Ocurrió un error inesperado en el servidor.";

        if (exception is KeyNotFoundException) code = HttpStatusCode.NotFound;
        else if (exception is UnauthorizedAccessException) code = HttpStatusCode.Unauthorized;

        var result = JsonSerializer.Serialize(new { error = message, detail = exception.Message });

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(result);
    }
}