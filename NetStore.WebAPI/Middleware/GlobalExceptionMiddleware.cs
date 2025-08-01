using System.Net;
using System.Text.Json;

namespace NetStore.WebAPI.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
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
                _logger.LogError(ex, $"Unhandled exception occurred: {ex.Message}");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            // Hata durum kodu (ihtiyaca göre geliştirilebilir)
            response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorResponse = new
            {
                StatusCode = response.StatusCode,
                Message = "Sunucu hatası oluştu.",
                Detailed = exception.Message // Prod ortamda gizlenebilir
            };

            var errorJson = JsonSerializer.Serialize(errorResponse);
            return response.WriteAsync(errorJson);
        }
    }
}
