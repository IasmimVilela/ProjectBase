using System.Threading;
using System.Threading.Tasks;
using TaskB3.Domain.Events;
using MediatR;

namespace TaskB3.Domain.EventHandlers
{
    public class TarefaEventHandler :
        INotificationHandler<TarefaCreateEvent>,
        INotificationHandler<TarefaUpdatedEvent>,
        INotificationHandler<TarefaRemovedEvent>
    {
        public Task Handle(TarefaUpdatedEvent message, CancellationToken cancellationToken)
        { 
            return Task.CompletedTask;
        }

        public Task Handle(TarefaCreateEvent message, CancellationToken cancellationToken)
        { 
            return Task.CompletedTask;
        }

        public Task Handle(TarefaRemovedEvent message, CancellationToken cancellationToken)
        { 
            return Task.CompletedTask;
        }
    }
}
