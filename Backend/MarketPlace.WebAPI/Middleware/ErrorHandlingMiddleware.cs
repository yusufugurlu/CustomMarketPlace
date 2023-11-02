using MarketPlace.Bussiness.Abstract;
using MarketPlace.Common.Exceptions;
using MarketPlace.Common.HttpContent;
using MarketPlace.DataAccess.Contexts;
using MarketPlace.DataTransfer.Dtos.Errors;
using MarketPlace.DataTransfer.Responses;
using System.Linq;

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

        public async Task InvokeAsync(HttpContext context, ILoggerService loggerService, IRolePermissionService rolePermissionService)
        {
            string controller = context.GetRouteData().Values["controller"]?.ToString() ?? "";
            string action = context.GetRouteData().Values["action"]?.ToString() ?? "";


            try
            {
                #region check user has authorize the page
                if (context.Request.Headers.ContainsKey("Page"))
                {
                    List<string> exceptPage = new List<string>();
                    exceptPage.Add("login");
                    exceptPage.Add("reset-password");
                    exceptPage.Add("forgot-password");
                    exceptPage.Add("");
                    string page = context.Request.Headers["Page"].ToString().Replace("/", "");

                    var userId = CurrentUser.UserId();

                    //süper admin ise bütün sayfaları görebilecek.
                    var hasAdminUser = await rolePermissionService.HasUserSuperAdminRole(userId);

                    if (!exceptPage.Any(x => x == page) && !hasAdminUser)
                    {
                        bool existMenu = await rolePermissionService.HasPermissionInMenu(userId, page);
                        if (!existMenu)
                        {
                            throw new RolePermissionException("");
                        }
                    }

                }
                else
                {
                    throw new RolePermissionException("");
                }
                #endregion

                await _next(context);
            }
            catch (RolePermissionException ex)
            {
                await HandleExceptionAsync(context, ex, 403);
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
                await HandleExceptionAsync(context, ex, 500);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception, int statusCodes)
        {
            // Burada hata işleme ve yanıt oluşturma mantığını uygulayabilirsiniz.
            // Örneğin, bir hata sayfasına yönlendirebilir veya JSON hata yanıtı döndürebilirsiniz.

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCodes;

            var response = new MarketPlace.DataTransfer.Responses.ServiceResponse()
            {
                Message = "Internal Server Error",
                Success = false,
                Status = statusCodes,
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
