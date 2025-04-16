using Gateway.Middlewares;
using Microsoft.AspNetCore.Builder;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot().AddCacheManager(x =>
{
    x.WithDictionaryHandle();
});
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
var app = builder.Build();

app.UseCors();  
app.UseHttpsRedirection();
app.UseMiddleware<TokenCheckerMiddleware>();
app.UseMiddleware<InterceptionMiddleware>();
app.UseAuthorization();
app.UseOcelot().Wait();
app.Run();
