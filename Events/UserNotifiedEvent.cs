namespace EventSourcingWithEventStore.Events
{
    public class UserNotifiedEvent : Event
    {
        public Guid UserId { get; private set; }
        public string Email { get; private set; }

        public UserNotifiedEvent(Guid userId, string email) : base()
        {
            AggregateId = userId;
            UserId = userId;
            Email = email;
        }
    }
}
