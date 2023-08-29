using EventSourcingWithEventStore.Events;
using EventSourcingWithEventStore.Repository;
using EventSourcingWithEventStore.Services;

var evento = new UserCreatedEvent(Guid.NewGuid(), "usuario1@email.com");

Console.WriteLine("Salvando evento...");
var eventRepository = new EventSourcingRepository(new EventStoreService());
await eventRepository.SalvarEvento(evento);
Console.WriteLine("Evento salvo!");

Console.WriteLine("Recuperando eventos...");
var storedEvents = await eventRepository.ObterEventos(evento.Id);
foreach (var storedEvent in storedEvents)
{
    Console.WriteLine("Evento Id: {0}", storedEvent.Id);
    Console.WriteLine("Data: {0}", storedEvent.DataOcorrencia);
    Console.WriteLine("Tipo: {0}", storedEvent.Tipo);
    Console.WriteLine("Dados: {0}", storedEvent.Dados);
}
