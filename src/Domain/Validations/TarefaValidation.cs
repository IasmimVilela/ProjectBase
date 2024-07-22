using System;
using TaskB3.Domain.Commands;
using FluentValidation;

namespace TaskB3.Domain.Validations
{
    public abstract class TarefaValidation<T> : AbstractValidator<T> where T : TarefaCommand
    {
        protected void ValidateDescricao()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("Certifique-se de ter inserido a Descrição. ")
                .Length(2, 150).WithMessage("A Descrição deve ter entre 2 e 150 caracteres. ");
        }

        protected void ValidateData()
        {
            RuleFor(c => c.Data)
                .NotEmpty().WithMessage("Certifique-se de ter inserido a Data. ")
                .Must(HaveMinimumAge)
                .WithMessage("A data deve ser maior ou igual à data de hoje. ");
        }

        protected void ValidateStatus()
        {
            RuleFor(c => c.Status)
                .NotEmpty().WithMessage("Certifique-se de ter inserido o Status. ");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEmpty();
        }

        protected static bool HaveMinimumAge(DateTime data)
        {
            return data <= DateTime.Now;
        }
    } 
}
