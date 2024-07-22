using AutoMapper;
using TaskB3.Application.ViewModels;
using TaskB3.Domain.Commands;

namespace TaskB3.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<TarefaViewModel, CreateTarefaCommand>()
                .ConstructUsing(c => new CreateTarefaCommand(c.Descricao, c.Data, c.Status));
            CreateMap<TarefaViewModel, UpdateTarefaCommand>()
                .ConstructUsing(c => new UpdateTarefaCommand(c.Id, c.Descricao, c.Data, c.Status));
        }
    }
}
