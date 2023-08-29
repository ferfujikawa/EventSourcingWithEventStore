using EventSourcingWithEventStore.Entities;
using EventSourcingWithEventStore.Events;

namespace EventSourcingWithEventStore.Repository
{
    public interface IEventSourcingRepository
    {
        Task SalvarEvento<TEvent>(TEvent evento) where TEvent : Event;
        Task<IEnumerable<StoredEvent>> ObterEventos(Guid aggregateId);
    }
}