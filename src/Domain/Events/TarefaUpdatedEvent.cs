using System;
using TaskB3.Domain.Core.Events;
using TaskB3.Domain.Enums;

namespace TaskB3.Domain.Events
{
    public class TarefaUpdatedEvent : Event
    {
        public TarefaUpdatedEvent(Guid id, string descricao, DateTime data, Status status)
        {
            Id = id;
            Descricao = descricao;
            Data = data;
            Status = status;
        } 

        public Guid Id { get; set; }

        public string Descricao { get; private set; }

        public DateTime Data { get; private set; }

        public Status Status { get; private set; }
    }
}
