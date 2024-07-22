using System.Linq;
using TaskB3.Domain.Interfaces;
using TaskB3.Domain.Models;
using TaskB3.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using TaskB3.Domain.Enums;

namespace TaskB3.Infra.Data.Repository
{
    public class TarefaRepository : Repository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public Tarefa GetByStatus(Status Status)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Status == Status);
        }
    }
}
