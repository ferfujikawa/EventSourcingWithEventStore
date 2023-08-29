using EventStore.Client;

namespace EventSourcingWithEventStore.Services
{
    public interface IEventStoreService
    {
        EventStoreClient GetClient();
    }
}
