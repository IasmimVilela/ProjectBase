using System;
using TaskB3.Domain.Core.Models;
using TaskB3.Domain.Enums;

namespace TaskB3.Domain.Models
{
    public class Tarefa : EntityAudit
    {
        public Tarefa(Guid id, string descricao, DateTime data, Status status)
        {
            Id = id;
            Descricao = descricao;
            Data = data;
            Status = status;
        }
        protected Tarefa() { }

        public Guid Id { get; set; }

        public string Descricao { get; private set; }

        public DateTime Data { get; private set; }

        public Status Status { get; private set; }
    }
}
