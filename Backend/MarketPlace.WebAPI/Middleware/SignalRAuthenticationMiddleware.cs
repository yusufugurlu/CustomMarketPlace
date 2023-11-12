namespace MarketPlace.WebAPI.Middleware
{
    public class SignalRAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string headerKey;
        private readonly string validGuid;

        public SignalRAuthenticationMiddleware(RequestDelegate next, string headerKey, string validGuid)
        {
            _next = next;
            this.headerKey = headerKey;
            this.validGuid = validGuid;
        }

        public async Task Invoke(HttpContext context)
        {
            string requestGuid = context.Request.Headers[headerKey].ToString();

            if (!string.IsNullOrEmpty(requestGuid) && !string.Equals(requestGuid, validGuid, StringComparison.OrdinalIgnoreCase))
            {
                context.Response.StatusCode = 401; // Erişim reddedildi
                return;
            }

            await _next.Invoke(context);

        }
    }

    public static class SignalRAuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseSignalRAuthenticationMiddleware(this IApplicationBuilder builder, string headerKey, string validGuid)
        {
            return builder.UseMiddleware<SignalRAuthenticationMiddleware>(headerKey, validGuid);
        }
    }
}
