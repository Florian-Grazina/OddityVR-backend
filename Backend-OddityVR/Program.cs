using Backend_OddityVR.Associative_Tables.Article;
using Backend_OddityVR.Associative_Tables.Softskill;
using Backend_OddityVR.Domain.AppService;
using Backend_OddityVR.Domain.Repo;
using Backend_OddityVR.Service;
using BackOddityVR.Domain.Repo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

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

            builder.Services.AddSingleton<IArticleAppService, ArticleAppService>();
            builder.Services.AddSingleton<IBatchAppService, BatchAppService>();
            builder.Services.AddSingleton<ICompanyAppService, CompanyAppService>();
            builder.Services.AddSingleton<IDepartmentAppService, DepartmentAppService>();
            builder.Services.AddSingleton<IProspeAppService, ProspeAppService>();
            builder.Services.AddSingleton<IRoleAppService, RoleAppService>();
            builder.Services.AddSingleton<ISoftskillAppService, SoftskillAppService>();
            builder.Services.AddSingleton<ITestResultAppService, TestResultAppService>();
            builder.Services.AddSingleton<IUserAppService, UserAppService>();

            builder.Services.AddSingleton<Database>();


            //IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            //configurationBuilder.AddJsonFile("appsettings.json");
            //IConfiguration configuration = configurationBuilder.Build();

            //Program.token = configuration["token"];
            //Program.guidID = configuration["guidID"];
            //Program.kind = configuration["kind"];

            builder.Services.AddSingleton<ArticleRepo>();
            builder.Services.AddSingleton<BatchRepo>();
            builder.Services.AddSingleton<CompanyRepo>();
            builder.Services.AddSingleton<DepartmentRepo>();
            builder.Services.AddSingleton<ProspeRepo>();
            builder.Services.AddSingleton<RoleRepo>();
            builder.Services.AddSingleton<SoftskillRepo>();
            builder.Services.AddSingleton<TestResultRepo>();
            builder.Services.AddSingleton<UserRepo>();
            builder.Services.AddSingleton<AuthorRepo>();
            builder.Services.AddSingleton<ReferenceRepo>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });


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
            app.UseAuthentication();


            //app.UseCors(options => options.WithOrigins("http://127.0.0.1:5500").AllowAnyMethod());
            app.UseCors(builder => builder
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());

            app.Run();
        }
    }
}