namespace EventSourcingWithEventStore.Events
{
    public class UserCreatedEvent : Event
    {
        public Guid Id { get; private set; }
        public string Username { get; private set; }

        public UserCreatedEvent(Guid id, string username) : base()
        {
            AggregateId = id;
            Id = id;
            Username = username;
        }
    }
}
