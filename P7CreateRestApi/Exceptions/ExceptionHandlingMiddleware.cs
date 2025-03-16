using System.Net;
using System.Text.Json;

namespace P7CreateRestApi.Exceptions
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

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);

                if (context.Response.StatusCode == (int)HttpStatusCode.Forbidden)
                {
                    await HandleForbiddenResponseAsync(context);
                }
            }
            catch (Exception ex)
            {
                if (ex is KeyNotFoundException || ex is ArgumentException)
                {
                    _logger.LogWarning(ex, "Erreur de validation ou ressource non trouvée.");
                }
                else
                {
                    _logger.LogError(ex, "Une erreur inattendue est survenue.");
                }

                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleForbiddenResponseAsync(HttpContext context)
        {
            var response = new
            {
                statusCode = (int)HttpStatusCode.Forbidden,
                message = "Accès refusé : vous n'avez pas les permissions nécessaires pour cette action."
            };

            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }));
        }


        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = exception switch
            {
                KeyNotFoundException _ => (int)HttpStatusCode.NotFound,
                ArgumentException _ => (int)HttpStatusCode.BadRequest,
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                _ => (int)HttpStatusCode.InternalServerError,
            };

            var response = new
            {
                statusCode,
                message = exception switch
                {
                    KeyNotFoundException => "La ressource demandée est introuvable.",
                    ArgumentException => "Une erreur de validation est survenue.",
                    UnauthorizedAccessException => "Accès non autorisé.",
                    _ => "Une erreur interne est survenue. Contactez le support."
                },
                detailedMessage = exception is KeyNotFoundException ? exception.Message : null
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }));

        }
    }
}
