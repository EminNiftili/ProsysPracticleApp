using Microsoft.AspNetCore.Builder;
using ProsysTestApp.ApiConfig.MiddleWares;

namespace ProsysTestApp.ApiConfig.Extensions
{
    public static class AppBuilderExtension
    {
        public static void UseGlobalException(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalErrorHandlingMiddleware>();
        }
    }
}
