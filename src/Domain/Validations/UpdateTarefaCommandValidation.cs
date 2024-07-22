using TaskB3.Domain.Commands;

namespace TaskB3.Domain.Validations
{
    public class UpdateTarefaCommandValidation : TarefaValidation<UpdateTarefaCommand>
    {
        public UpdateTarefaCommandValidation()
        {
            ValidateId();
            ValidateDescricao();
            ValidateData();
            ValidateStatus();
        }
    }
}
