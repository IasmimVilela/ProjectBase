using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using TaskB3.Application.EventSourcedNormalizers;
using TaskB3.Application.Interfaces;
using TaskB3.Application.ViewModels;
using TaskB3.Domain.Commands;
using TaskB3.Domain.Core.Bus;
using TaskB3.Domain.Interfaces;
using TaskB3.Domain.Specifications;
using TaskB3.Infra.Data.Repository.EventSourcing;

namespace TaskB3.Application.Services
{
    public class TarefaAppService : ITarefaAppService
    {
        private readonly IMapper _mapper;
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public TarefaAppService(IMapper mapper,
                                  ITarefaRepository customerRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _tarefaRepository = customerRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<TarefaViewModel> GetAll()
        {
            return _tarefaRepository.GetAll().ProjectTo<TarefaViewModel>(_mapper.ConfigurationProvider);
        }

        public IEnumerable<TarefaViewModel> GetAll(int skip, int take)
        {
            return _tarefaRepository.GetAll(new TarefaFilterPaginatedSpecification(skip, take))
                .ProjectTo<TarefaViewModel>(_mapper.ConfigurationProvider);
        }

        public TarefaViewModel GetById(Guid id)
        {
            return _mapper.Map<TarefaViewModel>(_tarefaRepository.GetById(id));
        }

        public void Create(TarefaViewModel customerViewModel)
        {
            var createCommand = _mapper.Map<CreateTarefaCommand>(customerViewModel);
            Bus.SendCommand(createCommand);
        }

        public void Update(TarefaViewModel customerViewModel)
        {
            var updateCommand = _mapper.Map<UpdateTarefaCommand>(customerViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveTarefaCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public IList<TarefaHistoryData> GetAllHistory(Guid id)
        {
            return TarefaHistory.ToJavaScriptTarefaHistory(_eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
