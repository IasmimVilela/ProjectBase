using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace TaskB3.Services.Api.StartupExtensions
{
    public static class ErrorHandlingExtension
    {
        public static IApplicationBuilder UseCustomizedErrorHandling(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            return app;
        }
    }
}
