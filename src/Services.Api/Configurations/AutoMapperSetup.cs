using System;
using AutoMapper;
using TaskB3.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace TaskB3.Services.Api.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(AutoMapperConfig.CreateMappings());
        }
    }
}
