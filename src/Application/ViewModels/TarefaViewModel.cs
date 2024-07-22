using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TaskB3.Domain.Enums;

namespace TaskB3.Application.ViewModels
{
    public class TarefaViewModel
    { 
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A Descrição é Obrigatória")]
        [MinLength(2, ErrorMessage = "A Descrição deve ter entre mais de 2 caracteres")]
        [MaxLength(150, ErrorMessage = "A Descrição deve ter entre mais de 150 caracteres")] 
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Sataus é Obrigatória")]  
        public Status Status { get; set; }

        [Required(ErrorMessage = "A Data é Obrigatória")] 
        [DataType(DataType.Date, ErrorMessage = "Formato de data inválido")] 
        public DateTime Data { get; set; }
    }
}
