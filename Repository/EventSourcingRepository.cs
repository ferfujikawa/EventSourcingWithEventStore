﻿using EventSourcingWithEventStore.Entities;
using EventSourcingWithEventStore.Events;
using EventSourcingWithEventStore.Services;
using EventStore.Client;
using System.Text;
using System.Text.Json;

namespace EventSourcingWithEventStore.Repository
{
    public class EventSourcingRepository : IEventSourcingRepository
    {
        private readonly IEventStoreService _eventStoreService;

        public EventSourcingRepository(IEventStoreService eventStoreService)
        {
            _eventStoreService = eventStoreService;
        }

        public async Task<IEnumerable<StoredEvent>> ObterEventos(Guid aggregateId)
        {
            var eventos = _eventStoreService.GetClient().ReadStreamAsync(
                Direction.Forwards,
                aggregateId.ToString(),
                StreamPosition.Start,
                500);

            var listaEventos = new List<StoredEvent>();

            foreach (var resolvedEvent in await eventos.ToListAsync())
            {
                var dataEncoded = Encoding.UTF8.GetString(@resolvedEvent.Event.Data.ToArray());

                var jsonData = JsonSerializer.Deserialize<Event>(dataEncoded);

                if (jsonData != null)
                {
                    var evento = new StoredEvent(
                    resolvedEvent.Event.EventId.ToGuid(),
                    resolvedEvent.Event.EventType,
                    jsonData.Timestamp,
                    dataEncoded);

                    listaEventos.Add(evento);
                }
            }

            return listaEventos.OrderBy(e => e.DataOcorrencia);
        }

        public async Task SalvarEvento<TEvent>(TEvent evento) where TEvent : Event
        {
            await _eventStoreService.GetClient().AppendToStreamAsync(
                evento.AggregateId.ToString(),
                StreamState.Any,
                FormatarEvento(evento));
        }

        private static IEnumerable<EventData> FormatarEvento<TEvent>(TEvent evento) where TEvent : Event
        {
            yield return new EventData(
                Uuid.NewUuid(),
                evento.MessageType,
                JsonSerializer.SerializeToUtf8Bytes(evento),
                null);
        }
    }
}
