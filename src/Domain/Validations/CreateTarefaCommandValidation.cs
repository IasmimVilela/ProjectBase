using TaskB3.Domain.Commands;

namespace TaskB3.Domain.Validations
{
    public class CreateTarefaCommandValidation : TarefaValidation<CreateTarefaCommand>
    {
        public CreateTarefaCommandValidation()
        {
            ValidateDescricao();
            ValidateData();
            ValidateStatus();
        }
    }
}
