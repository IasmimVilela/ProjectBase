using System.Threading.Tasks;
using TaskB3.Domain.Core.Commands;
using TaskB3.Domain.Core.Events;

namespace TaskB3.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
