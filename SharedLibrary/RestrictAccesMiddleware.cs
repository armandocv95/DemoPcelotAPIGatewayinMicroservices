using Microsoft.AspNetCore.Http;

namespace SharedLibrary
{
    public class RestrictAccesMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            var referrer = context.Request.Headers["Referrer"].FirstOrDefault(); ;
            if (string.IsNullOrEmpty(referrer))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Access Denied");
                return;
            }
            await next(context);
        }
    }
}
