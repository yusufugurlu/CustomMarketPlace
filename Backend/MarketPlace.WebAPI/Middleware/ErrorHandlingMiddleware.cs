using MarketPlace.Bussiness.Abstract;
using MarketPlace.DataAccess.Contexts;
using MarketPlace.DataTransfer.Dtos.Errors;
using MarketPlace.DataTransfer.Responses;

namespace MarketPlace.WebAPI.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger, ILogger<ILoggerService> loggerService)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, ILoggerService loggerService)
        {
            string controller = context.GetRouteData().Values["controller"]?.ToString();
            string action = context.GetRouteData().Values["action"]?.ToString();


            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unhandled exception: {ex}");
                await loggerService.LogError(new ErrorLogDto()
                {
                    Timestamp = DateTime.Now,
                    Message = ex.Message,
                    Details = ex?.StackTrace ?? "",
                    Level = "Error",
                    Controller = controller,
                    Action = action
                });
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Burada hata işleme ve yanıt oluşturma mantığını uygulayabilirsiniz.
            // Örneğin, bir hata sayfasına yönlendirebilir veya JSON hata yanıtı döndürebilirsiniz.

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var response = new MarketPlace.DataTransfer.Responses.ServiceResponse()
            {
                Message = "Internal Server Error",
                Success = false,
                Status = StatusCodes.Status500InternalServerError,
            };

            return context.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(response));
        }
    }

    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
