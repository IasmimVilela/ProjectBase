using System;
using System.Text;
using TaskB3.Infra.CrossCutting.Identity.Authorization;
using TaskB3.Infra.CrossCutting.Identity.Data;
using TaskB3.Infra.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace TaskB3.Services.Api.StartupExtensions
{
    public static class AuthExtension
    {
        public static IServiceCollection AddCustomizedAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var secretKey = configuration.GetValue<string>("SecretKey");
            var _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();

            var jwtAppSettingOptions = configuration.GetSection(nameof(JwtIssuerOptions));

            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;
            });


            services.AddAuthorization(options =>
            {
                var policy1 = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .RequireRole("Admin")
                    .AddRequirements(new ClaimRequirement("Tarefa_Write", "Write"))
                    .Build();
                var policy2 = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .RequireRole("Admin")
                    .AddRequirements(new ClaimRequirement("Tarefa_Remove", "Remove"))
                    .Build();
                options.AddPolicy("CanWriteTarefaData", policy1);
                options.AddPolicy("CanRemoveTarefaData", policy2);
            });

            return services;
        }

        public static IApplicationBuilder UseCustomizedAuth(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}
