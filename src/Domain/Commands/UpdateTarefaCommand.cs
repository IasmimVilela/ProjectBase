using System;
using TaskB3.Domain.Enums;
using TaskB3.Domain.Validations;

namespace TaskB3.Domain.Commands
{
    public class UpdateTarefaCommand : TarefaCommand
    {
        public UpdateTarefaCommand(Guid id, string descricao, DateTime data, Status status)
        {
            Id = id;
            Descricao = descricao;
            Data = data;
            Status = status;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateTarefaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
