using EventStore.Client;

namespace EventSourcingWithEventStore.Services
{
    public class EventStoreService : IEventStoreService
    {
        private readonly EventStoreClientSettings _eventStoreClientSettings;
        public EventStoreService()
        {
            _eventStoreClientSettings = EventStoreClientSettings.Create("esdb://127.0.0.1:2113?tls=false&keepAliveTimeout=10000&keepAliveInterval=10000");
        }

        public EventStoreClient GetClient()
        {
            return new EventStoreClient(_eventStoreClientSettings);
        }
    }
}
