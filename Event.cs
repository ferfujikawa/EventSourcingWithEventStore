namespace EventSourcingWithEventStore
{
    public abstract class Event
    {
        public string MessageType { get; private set; }
        public Guid AggregateId { get; protected set; }
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
            MessageType = GetType().Name;
        }
    }
}
