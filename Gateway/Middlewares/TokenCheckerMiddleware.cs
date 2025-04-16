namespace Gateway.Middlewares
{
    public class TokenCheckerMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Path.Value!;
            if (token.Contains("account/login", StringComparison.InvariantCultureIgnoreCase) ||
                token.Contains("account/register", StringComparison.InvariantCultureIgnoreCase) ||
                    token.Equals("/"))
            {

                await next(context);
                return;
            }
            else
            {
                var authHeader = context.Request.Headers.Authorization;
                if(authHeader.FirstOrDefault() == null)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Unauthorized");
                }
                else
                {
                    await next(context);    
                }
            }
            
        }
    }
}
