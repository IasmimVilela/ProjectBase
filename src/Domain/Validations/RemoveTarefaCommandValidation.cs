using TaskB3.Domain.Commands;

namespace TaskB3.Domain.Validations
{
    public class RemoveTarefaCommandValidation : TarefaValidation<RemoveTarefaCommand>
    {
        public RemoveTarefaCommandValidation()
        {
            ValidateId();
        }
    }
}
