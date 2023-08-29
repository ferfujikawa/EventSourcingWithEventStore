namespace EventSourcingWithEventStore.Events
{
    public class UserCreatedEvent : Event
    {
        public Guid UserId { get; private set; }
        public string Username { get; private set; }

        public UserCreatedEvent(Guid userId, string username) : base()
        {
            AggregateId = userId;
            UserId = userId;
            Username = username;
        }
    }
}
