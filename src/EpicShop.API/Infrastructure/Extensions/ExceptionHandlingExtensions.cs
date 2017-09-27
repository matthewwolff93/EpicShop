using EpicShop.API.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace EpicShop.API.Infrastructure.Extensions
{
    public static class ExceptionHandlingExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionHandler>();
        }
    }
}
