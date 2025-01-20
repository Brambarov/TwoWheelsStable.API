using static TwoWheelsStable.API.Helpers.Constants.ErrorMessages;

namespace TwoWheelsStable.API.Middleware
{
    public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, UnhandledExceptionError);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exception switch
            {
                ApplicationException => StatusCodes.Status400BadRequest,
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };

            var response = new
            {
                context.Response.StatusCode,
                exception.Message,
                Details = exception.InnerException?.Message
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
