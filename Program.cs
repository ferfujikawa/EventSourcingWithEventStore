using EventSourcingWithEventStore;

var evento = new UserCreatedEvent(Guid.NewGuid(), "usuario1@email.com");

var eventRepository = new EventSourcingRepository(new EventStoreService());
await eventRepository.SalvarEvento(evento);
Console.WriteLine("Evento salvo");

await eventRepository.ObterEventos(evento.Id);