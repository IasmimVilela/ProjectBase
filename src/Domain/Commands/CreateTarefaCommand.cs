using System;
using TaskB3.Domain.Enums;
using TaskB3.Domain.Validations;

namespace TaskB3.Domain.Commands
{
    public class CreateTarefaCommand : TarefaCommand
    {
        public CreateTarefaCommand(string descricao, DateTime data, Status status)
        { 
            Descricao = descricao;
            Data = data;
            Status = status;
        }

        public override bool IsValid()
        { 
            ValidationResult = new CreateTarefaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
