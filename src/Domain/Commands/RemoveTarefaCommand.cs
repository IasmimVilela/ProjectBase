using System;
using TaskB3.Domain.Validations;

namespace TaskB3.Domain.Commands
{
    public class RemoveTarefaCommand : TarefaCommand
    {
        public RemoveTarefaCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveTarefaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
