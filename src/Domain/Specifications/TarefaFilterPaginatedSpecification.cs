using TaskB3.Domain.Models;

namespace TaskB3.Domain.Specifications
{
    public class TarefaFilterPaginatedSpecification : BaseSpecification<Tarefa>
    {
        public TarefaFilterPaginatedSpecification(int skip, int take)
            : base(i => true)
        {
            ApplyPaging(skip, take);
        }
    }
}
