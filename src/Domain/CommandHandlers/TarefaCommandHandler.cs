using System;
using System.Threading;
using System.Threading.Tasks;
using TaskB3.Domain.Commands;
using TaskB3.Domain.Core.Bus;
using TaskB3.Domain.Core.Notifications;
using TaskB3.Domain.Events;
using TaskB3.Domain.Interfaces;
using TaskB3.Domain.Models;
using MediatR;
using TaskB3.Domain.Interfaces.Messaging;

namespace TaskB3.Domain.CommandHandlers
{
    public class TarefaCommandHandler : CommandHandler,
        IRequestHandler<CreateTarefaCommand, bool>,
        IRequestHandler<UpdateTarefaCommand, bool>,
        IRequestHandler<RemoveTarefaCommand, bool>
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IMediatorHandler Bus;
        private readonly IMessagePublisher _messagePublisher;

        public TarefaCommandHandler(ITarefaRepository tarefaRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications,
                                      IMessagePublisher messagePublisher) : base(uow, bus, notifications)
        {
            _tarefaRepository = tarefaRepository;
            Bus = bus;
            _messagePublisher = messagePublisher;
        }

        public Task<bool> Handle(CreateTarefaCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var tarefa = new Tarefa(Guid.NewGuid(), message.Descricao, message.Data, message.Status);

            //Colocar uma validação de proximo status

            //var envelops = new MessageEnvelop[] {new MessageEnvelop()
            //{
            //    Content = new IntegrationCommand
            //    {
            //        CommandNome = "",
            //        Message = "tarefa.JSON",
            //        PublishAt = DateTime.UtcNow
            //    },
            //    RoutingKey = ""
            //}};
            
            //_messagePublisher.Publish(envelops, "Exchange"); 

            _tarefaRepository.Add(tarefa);

            if (Commit())
            {
                Bus.RaiseEvent(new TarefaCreateEvent(message.Id, message.Descricao, message.Data, message.Status));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateTarefaCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var tarefa = new Tarefa(message.Id, message.Descricao, message.Data, message.Status);

            

            _tarefaRepository.Update(tarefa);

            if (Commit())
            {
                Bus.RaiseEvent(new TarefaUpdatedEvent(tarefa.Id, message.Descricao, message.Data, message.Status));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveTarefaCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _tarefaRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new TarefaRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateStatusCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var tarefa = new Tarefa(message.Id, message.Descricao, message.Data, message.Status);
            
            _tarefaRepository.Update(tarefa);

            if (Commit())
            {
                Bus.RaiseEvent(new TarefaUpdatedEvent(tarefa.Id, message.Descricao, message.Data, message.Status));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _tarefaRepository.Dispose();
        }
    }
}
