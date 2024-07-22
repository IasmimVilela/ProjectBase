using TaskB3.Domain.Enums;
using TaskB3.Domain.Models;

namespace TaskB3.Domain.Interfaces
{
    public interface ITarefaRepository : IRepository<Tarefa>
    {
        Tarefa GetByStatus(Status status);
    }
}
