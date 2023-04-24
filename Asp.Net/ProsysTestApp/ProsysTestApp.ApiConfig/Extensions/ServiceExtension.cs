using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using ProsysTestApp.ApiConfig.Handlers;
using ProsysTestApp.Core.AutoMapper;
using ProsysTestApp.Data.DataAccess;
using ProsysTestApp.Data.DataAccess.Ef;
using ProsysTestApp.Logic.Services;
using ProsysTestApp.Logic.Services.Implementation;

namespace ProsysTestApp.ApiConfig.Extensions
{
    public static class ServiceExtension
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
        }
        public static void AddMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<ILessonService, LessonService>();
        }
        public static void AddNonAuthConfig(this IServiceCollection services)
        {
            services.AddAuthentication("BasicAuthentication")
                   .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
        }
    }
}
