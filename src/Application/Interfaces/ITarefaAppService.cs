using System;
using System.Collections.Generic;
using TaskB3.Application.EventSourcedNormalizers;
using TaskB3.Application.ViewModels;

namespace TaskB3.Application.Interfaces
{
    public interface ITarefaAppService : IDisposable
    {
        void Create(TarefaViewModel customerViewModel);
        IEnumerable<TarefaViewModel> GetAll();
        IEnumerable<TarefaViewModel> GetAll(int skip, int take);
        TarefaViewModel GetById(Guid id);
        void Update(TarefaViewModel customerViewModel);
        void Remove(Guid id);
        IList<TarefaHistoryData> GetAllHistory(Guid id);
    }
}
