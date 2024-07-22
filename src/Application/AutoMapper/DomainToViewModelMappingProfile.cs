using AutoMapper;
using TaskB3.Application.ViewModels;
using TaskB3.Domain.Models;

namespace TaskB3.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Tarefa, TarefaViewModel>();
        }
    }
}
