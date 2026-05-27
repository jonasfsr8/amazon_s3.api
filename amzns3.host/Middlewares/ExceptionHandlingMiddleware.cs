using amzns3.host.Exceptions;
using System.Text.Json;
using tube_catcher.module.Common;

namespace amzns3.host.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);

                if (!context.Response.HasStarted &&
                    (context.Response.StatusCode == StatusCodes.Status401Unauthorized ||
                     context.Response.StatusCode == StatusCodes.Status403Forbidden))
                {
                    await HandleStatusCodeAsync(context);
                }
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);

                await HandleExceptionAsync(context, exception);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (context.Response.HasStarted)
            {
                _logger.LogWarning(
                    "A resposta já foi iniciada; o middleware de exceção não será executado.");

                return;
            }

            var statusCode = GetStatusCode(exception);

            var message = GetMessage(exception);

            var response = ApiResponse<object>.ErrorResponse(message);

            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var json = JsonSerializer.Serialize(response);

            await context.Response.WriteAsync(json);
        }

        private async Task HandleStatusCodeAsync(HttpContext context)
        {
            if (context.Response.HasStarted)
            {
                return;
            }

            var message = context.Response.StatusCode switch
            {
                StatusCodes.Status401Unauthorized => "Não autorizado.",
                StatusCodes.Status403Forbidden => "Proibido.",
                _ => "Ocorreu um erro inesperado."
            };

            var response = ApiResponse<object>.ErrorResponse(message);

            context.Response.ContentType = "application/json";

            var json = JsonSerializer.Serialize(response);

            await context.Response.WriteAsync(json);
        }

        private static int GetStatusCode(Exception exception) => exception switch
        {
            UnauthorizedAccessException => StatusCodes.Status401Unauthorized,

            NotFoundException => StatusCodes.Status404NotFound,

            ArgumentException => StatusCodes.Status400BadRequest,

            TimeoutException => StatusCodes.Status408RequestTimeout,

            InvalidOperationException => StatusCodes.Status503ServiceUnavailable,

            _ => StatusCodes.Status500InternalServerError
        };

        private static string GetMessage(Exception exception) => exception switch
        {
            NotFoundException => exception.Message,

            ArgumentException => exception.Message,

            UnauthorizedAccessException => exception.Message,

            TimeoutException => "Request timeout.",

            InvalidOperationException => exception.Message,

            _ => exception.Message
        };
    }
}
