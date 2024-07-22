using System;
using System.Collections.Generic;
using TaskB3.Domain.Core.Events;

namespace TaskB3.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
