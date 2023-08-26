using Backend_OddityVR.Application.AppService;
using Backend_OddityVR.Application.AppService.Interfaces;
using Backend_OddityVR.Domain.Service;
using Backend_OddityVR.Infrastructure.Repo;

namespace Backend_OddityVR.Domain.Helpers
{
    public static class DependencyInjection
    {
        public static void InitDependencyInjection(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IArticleAppService, ArticleAppService>();
            builder.Services.AddScoped<IBatchAppService, BatchAppService>();
            builder.Services.AddScoped<ICompanyAppService, CompanyAppService>();
            builder.Services.AddScoped<IDepartmentAppService, DepartmentAppService>();
            builder.Services.AddScoped<IProspeAppService, ProspeAppService>();
            builder.Services.AddScoped<IRoleAppService, RoleAppService>();
            builder.Services.AddScoped<ISoftskillAppService, SoftskillAppService>();
            builder.Services.AddScoped<ITestResultAppService, TestResultAppService>();
            builder.Services.AddScoped<IUserAppService, UserAppService>();
            builder.Services.AddScoped<ITokenAppService, TokenAppService>();

            builder.Services.AddScoped<Database>();
            builder.Services.AddScoped<ArticleRepo>();
            builder.Services.AddScoped<BatchRepo>();
            builder.Services.AddScoped<CompanyRepo>();
            builder.Services.AddScoped<DepartmentRepo>();
            builder.Services.AddScoped<ProspeRepo>();
            builder.Services.AddScoped<RoleRepo>();
            builder.Services.AddScoped<SoftskillRepo>();
            builder.Services.AddScoped<TestResultRepo>();
            builder.Services.AddScoped<UserRepo>();
            builder.Services.AddScoped<SoftSkillReferenceRepo>();

        }
    }
}
