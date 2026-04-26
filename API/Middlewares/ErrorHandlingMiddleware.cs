using System.Net;
using System.Text.Json;
using static Application.Exceptions.Exceptions;

namespace API.Middlewares;

public class ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
{
    private readonly ILogger<ErrorHandlingMiddleware> _logger = logger;
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NoContentException ex)
        {
            await HandleNoContentExceptionAsync(context, ex);
        }
        catch (NotFoundException ex)
        {
            _logger.LogWarning("Recurso não encontrado: {Message}", ex.Message);

            await HandleNotFoundExceptionAsync(context, ex);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro interno no servidor");

            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleNoContentExceptionAsync(HttpContext context, NoContentException exception)
    {
        var response = new
        {
            message = exception.Message ?? "Recurso não encontrado",
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.NotFound;

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private static async Task HandleNotFoundExceptionAsync(HttpContext context, NotFoundException exception)
    {
        var response = new
        {
            message = exception.Message ?? "Recurso não encontrado",
            statusCode = (int)HttpStatusCode.NotFound
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.NotFound;

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = new
        {
            message = "Erro interno no servidor",
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
