using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace FirstMediatr.Middleware
{
    public class RestApiExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RestApiExceptionHandlingMiddleware> _logger;

        public RestApiExceptionHandlingMiddleware(RequestDelegate next, ILogger<RestApiExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
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

        public async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception is NotImplementedException)
            {
                _logger.LogError(exception, "Not implemented exception occured!");
                var result2 = JsonSerializer.Serialize(exception.Message);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result2);
            }
            else
            {
                _logger.LogError(exception, $"An unhandled exception has occured! {exception.Message}");

                var problemDetails = new ProblemDetails
                {
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                    Title = "Internal Server Error",
                    Status = (int)HttpStatusCode.InternalServerError,
                    Instance = context.Request.Path,
                    Detail = "Internal server error occured!"
                };

                var result = JsonSerializer.Serialize(problemDetails);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result);
            }
        }
    }
}
