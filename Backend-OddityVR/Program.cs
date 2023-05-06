using Backend_OddityVR.Article;
using Backend_OddityVR.Company;
using Backend_OddityVR.Prospe;
using Backend_OddityVR.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace Backend_OddityVR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

            builder.Services.AddScoped<RoleAppService>();
            builder.Services.AddScoped<CompanyAppService>();
            builder.Services.AddScoped<ArticleAppService>();
            builder.Services.AddScoped<ProspeAppService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();


            //app.UseCors(options => options.WithOrigins("http://127.0.0.1:5500").AllowAnyMethod());
            app.UseCors(builder => builder
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());

            app.Run();
        }
    }
}