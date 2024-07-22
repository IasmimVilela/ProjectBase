using System;
using TaskB3.Domain.Core.Commands;
using TaskB3.Domain.Enums;

namespace TaskB3.Domain.Commands
{
    public abstract class TarefaCommand : Command
    {
        public Guid Id { get; protected set; } 
        public string? Descricao { get; protected set; }
        public DateTime Data { get; protected set; }
        public Status Status { get; protected set; }
    }
}
