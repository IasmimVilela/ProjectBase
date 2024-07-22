using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TaskB3.Domain.Enums;

namespace TaskB3.Application.ViewModels
{
    public class TarefaViewModel
    { 
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A Descri��o � Obrigat�ria")]
        [MinLength(2, ErrorMessage = "A Descri��o deve ter entre mais de 2 caracteres")]
        [MaxLength(150, ErrorMessage = "A Descri��o deve ter entre mais de 150 caracteres")] 
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Sataus � Obrigat�ria")]  
        public Status Status { get; set; }

        [Required(ErrorMessage = "A Data � Obrigat�ria")] 
        [DataType(DataType.Date, ErrorMessage = "Formato de data inv�lido")] 
        public DateTime Data { get; set; }
    }
}
