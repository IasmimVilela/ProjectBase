using TaskB3.Domain.Commands;

namespace TaskB3.Domain.Validations
{
    public class UpdateStatusCommandValidation : TarefaValidation<UpdateStatusCommand>
    {
        public UpdateStatusCommandValidation()
        {
            ValidateId();
            ValidateDescricao();
            ValidateData();
            ValidateStatus();
        }
    }
}
