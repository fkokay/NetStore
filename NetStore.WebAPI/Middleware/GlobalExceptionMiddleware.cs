using NetStore.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace NetStore.WebAPI.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            HttpStatusCode status;
            object? responseObj;

            switch (exception)
            {
                case NotFoundException notFoundEx:
                    status = HttpStatusCode.NotFound;
                    responseObj = new { message = notFoundEx.Message };
                    break;

                case ValidationException validationEx:
                    status = HttpStatusCode.BadRequest;
                    responseObj = new { message = validationEx.Message, errors = validationEx.Errors };
                    break;

                case BusinessException businessEx:
                    status = HttpStatusCode.BadRequest;
                    responseObj = new { message = businessEx.Message };
                    break;

                default:
                    status = HttpStatusCode.InternalServerError;
                    responseObj = new { message = "Sunucu hatası oluştu." };
                    break;
            }

            context.Response.StatusCode = (int)status;
            var result = JsonSerializer.Serialize(responseObj);

            return context.Response.WriteAsync(result);
        }
    }
}
