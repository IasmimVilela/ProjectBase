using System;
using TaskB3.Domain.Core.Events;

namespace TaskB3.Domain.Events
{
    public class TarefaRemovedEvent : Event
    {
        public TarefaRemovedEvent(Guid id)
        {
            Id = id; 
        }

        public Guid Id { get; set; }
    }
}
