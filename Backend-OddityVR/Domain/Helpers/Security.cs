using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Backend_OddityVR.Domain.Helpers
{
    public static class Security
    {
        public static void InitCorsPolicy(WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
                {
                    options.AddPolicy(name: "Dashboard",
                                      policy =>
                                      {
                                          policy.WithOrigins(builder.Configuration["DashboardOrigin"])
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                                      });
                    options.AddPolicy(name: "WebsiteForm",
                                      policy =>
                                      {
                                          policy.WithOrigins(builder.Configuration["WebsiteOrigin"])
                                            .AllowAnyHeader()
                                            .WithMethods("POST");
                                      });
                });
        }

        public static void InitAuthorization(WebApplicationBuilder builder)
        {
            builder.Services.AddAuthorization(options =>
            {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
                defaultAuthorizationPolicyBuilder = defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
                options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
            });
        }

        public static void InitAuthentication(WebApplicationBuilder builder)
        {
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
        }
    }
}
