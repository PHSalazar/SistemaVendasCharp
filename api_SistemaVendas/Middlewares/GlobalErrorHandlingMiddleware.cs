using api_SistemaVendas.Exceptions;
using System.Net;
using System.Text.Json;

namespace api_SistemaVendas.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
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

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode status;
            string message;

            switch (ex)
            {
                case NotFoundException:
                    status = HttpStatusCode.NotFound;
                    message = ex.Message;
                    break;
                default:
                    status = HttpStatusCode.InternalServerError;
                    message = ex.Message;
                    break;
            }

            var result = JsonSerializer.Serialize(new {status, message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsync(result);
        }
    }
}
