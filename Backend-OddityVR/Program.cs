using Backend_OddityVR.Domain.Helpers;
using Microsoft.OpenApi.Models;

namespace Backend_OddityVR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            DependencyInjection.InitDependencyInjection(builder);
            Security.InitCorsPolicy(builder);
            Security.InitAuthorization(builder);
            Security.InitAuthentication(builder);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "OddityVR",
                    Description = "An ASP.NET Core Web API for managing OddityVR Dashboard",
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.MapControllers();

            app.UseCors();
            app.UseAuthorization();
            app.UseAuthentication();

            app.Run();
        }
    }
}