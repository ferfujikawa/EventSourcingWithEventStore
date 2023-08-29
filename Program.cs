using EventSourcingWithEventStore.Events;
using EventSourcingWithEventStore.Repository;
using EventSourcingWithEventStore.Services;

var eventRepository = new EventSourcingRepository(new EventStoreService());

var userId = Guid.NewGuid();

Console.WriteLine("Salvando evento de usuário criado...");
var userCreatedEvent = new UserCreatedEvent(userId, "usuario1");
await eventRepository.SalvarEvento(userCreatedEvent);
Console.WriteLine("Evento salvo!");

Console.WriteLine("Salvando evento de usuário notificado...");
var userNotifiedEvent = new UserNotifiedEvent(userId, "usuario1@email.com");
await eventRepository.SalvarEvento(userNotifiedEvent);
Console.WriteLine("Evento salvo!");

Console.WriteLine("Recuperando eventos...");
var storedEvents = await eventRepository.ObterEventos(userId);
foreach (var storedEvent in storedEvents)
{
    Console.WriteLine("Evento Id: {0}", storedEvent.Id);
    Console.WriteLine("Data: {0}", storedEvent.DataOcorrencia);
    Console.WriteLine("Tipo: {0}", storedEvent.Tipo);
    Console.WriteLine("Dados: {0}", storedEvent.Dados);
    Console.WriteLine("------------------------------------");
}
