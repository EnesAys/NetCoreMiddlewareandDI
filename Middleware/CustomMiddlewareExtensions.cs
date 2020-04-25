using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NetCoreMiddlewareandDI.Services;

namespace NetCoreMiddlewareandDI.Middleware
{
    public static class ApiMiddlewareExtensions
    {
        public static IServiceCollection AddServiceInjections(this IServiceCollection services)
        {
            services.AddTransient<INameService, NameService>();
            services.AddTransient(typeof(IGenericService<>), typeof(GenericService<>));
            return services;
        }
        public static IApplicationBuilder UseCustomRoute(this IApplicationBuilder builder)
        {
            return builder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapGet("/test", async context =>
                {
                    await context.Response.WriteAsync("Successfully registered custom route");
                });
            });
            //return builder.UseMiddleware<MyMiddleware>(); 
        }
    }

    // public class MyMiddleware
    // {
    //     private readonly RequestDelegate _next;

    //     public MyMiddleware(RequestDelegate next)
    //     {
    //         _next = next;
    //     }

    //     public Task Invoke(HttpContext httpContext)
    //     {

    //         return _next(httpContext);
    //     }
    // }

}