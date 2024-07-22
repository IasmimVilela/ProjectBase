using System.Text.Json;
using System.Text;
using RabbitMQ;
using RabbitMQ.Client;
using TaskB3.Domain.Core.Events;
using Microsoft.Extensions.DependencyInjection;

namespace TaskB3.Services.Api.StartupExtensions
{
    public static class RabbitMqExtension
    {
        public static IServiceCollection AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = new ConnectionFactory()
            {
                HostName = configuration["RabbitMq:HostName"],
                UserName = configuration["RabbitMq:UserName"],
                Password = configuration["RabbitMq:Password"]
            };

            services.AddSingleton<IConnectionFactory>(connection);
             
            return services;
        } 
    }
}
