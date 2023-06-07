using Backend_OddityVR.Application.AppService;
using Backend_OddityVR.Application.AppService.Interfaces;
using Backend_OddityVR.Domain.Associative_Tables.Article;
using Backend_OddityVR.Domain.Associative_Tables.Softskill;
using Backend_OddityVR.Domain.Service;
using Backend_OddityVR.Infrastructure.Repo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "Dashboard",
                                  policy =>
                                  {
                                      policy.WithOrigins("http://141.94.244.4:8095")
                                      //policy.WithOrigins("http://localhost:4200")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                                  });
                options.AddPolicy(name: "WebsiteForm",
                                  policy =>
                                  {
                                      policy.WithOrigins("http://141.94.244.4")
                                      //policy.WithOrigins("http://127.0.0.1:5501")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                                  });
            });

            builder.Services.AddAuthorization(options =>
            {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                defaultAuthorizationPolicyBuilder = defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
                options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
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

                //app.UseCors(builder => builder
                // .AllowAnyOrigin()
                // .AllowAnyMethod()
                // .AllowAnyHeader());
            }

            app.UseHttpsRedirection();
            app.MapControllers();
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseCors();

            app.Run();
        }
    }
}