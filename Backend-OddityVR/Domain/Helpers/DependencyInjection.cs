using Backend_OddityVR.Application.AppService;
using Backend_OddityVR.Application.AppService.Interfaces;
using Backend_OddityVR.Domain.Associative_Tables.Article;
using Backend_OddityVR.Domain.Associative_Tables.Softskill;
using Backend_OddityVR.Domain.Service;
using Backend_OddityVR.Infrastructure.Repo;

namespace Backend_OddityVR.Domain.Helpers
{
    public static class DependencyInjection
    {
        public static void InitDependencyInjection(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IArticleAppService, ArticleAppService>();
            builder.Services.AddSingleton<IBatchAppService, BatchAppService>();
            builder.Services.AddSingleton<ICompanyAppService, CompanyAppService>();
            builder.Services.AddSingleton<IDepartmentAppService, DepartmentAppService>();
            builder.Services.AddSingleton<IProspeAppService, ProspeAppService>();
            builder.Services.AddSingleton<IRoleAppService, RoleAppService>();
            builder.Services.AddSingleton<ISoftskillAppService, SoftskillAppService>();
            builder.Services.AddSingleton<ITestResultAppService, TestResultAppService>();
            builder.Services.AddSingleton<IUserAppService, UserAppService>();
            builder.Services.AddSingleton<ITokenAppService, TokenAppService>();

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

        }
    }
}
