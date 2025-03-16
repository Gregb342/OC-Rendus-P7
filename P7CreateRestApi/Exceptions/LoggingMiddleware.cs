namespace P7CreateRestApi.Exceptions
{

    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var userName = context.User.Identity?.Name ?? "Utilisateur anonyme";
            var endpoint = context.GetEndpoint()?.DisplayName ?? "Endpoint inconnu";

            _logger.LogInformation($"Utilisateur '{userName}' a accédé à {endpoint}");

            await _next(context);
        }
    }
}
