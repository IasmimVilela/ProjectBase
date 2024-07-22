using TaskB3.Application.Interfaces;
using TaskB3.Application.Services;
using TaskB3.Domain.CommandHandlers;
using TaskB3.Domain.Commands;
using TaskB3.Domain.Core.Bus;
using TaskB3.Domain.Core.Events;
using TaskB3.Domain.Core.Notifications;
using TaskB3.Domain.EventHandlers;
using TaskB3.Domain.Events;
using TaskB3.Domain.Interfaces;
using TaskB3.Domain.Providers.Webhooks;
using TaskB3.Domain.Providers.Http;
using TaskB3.Domain.Providers.Mail;
using TaskB3.Infra.CrossCutting.Bus;
using TaskB3.Infra.CrossCutting.Identity.Authorization;
using TaskB3.Infra.CrossCutting.Identity.Models;
using TaskB3.Infra.CrossCutting.Identity.Services;
using TaskB3.Infra.Data.EventSourcing;
using TaskB3.Infra.Data.Repository;
using TaskB3.Infra.Data.Repository.EventSourcing;
using TaskB3.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using TaskB3.Domain.Providers.Crons;
using TaskB3.Domain.Providers.Hubs.Notification;
using TaskB3.Domain.Interfaces.Messaging;
using TaskB3.Infra.Data.Messaging.RabbitMQ;

namespace TaskB3.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddHttpContextAccessor();
            // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<ITarefaAppService, TarefaAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<TarefaCreateEvent>, TarefaEventHandler>();
            services.AddScoped<INotificationHandler<TarefaUpdatedEvent>, TarefaEventHandler>();
            services.AddScoped<INotificationHandler<TarefaRemovedEvent>, TarefaEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<CreateTarefaCommand, bool>, TarefaCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateTarefaCommand, bool>, TarefaCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveTarefaCommand, bool>, TarefaCommandHandler>();
             
            // Domain - 3rd parties
            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<IMailService, MailService>();

            // Domain - Providers
            services.AddScoped<INotificationProvider, NotificationProvider>();
            services.AddScoped<IWebhookProvider, WebhookProvider>();
            services.AddScoped<ICronProvider, CronProvider>();

            // Infra - Data
            services.AddScoped<ITarefaRepository, TarefaRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
            services.AddSingleton<IJwtFactory, JwtFactory>();


            services.AddScoped<IMessagePublisher, MessagePublisher>();
            services.AddScoped<ISenderEmail, SenderEmail>(); 
        }
    }
}
