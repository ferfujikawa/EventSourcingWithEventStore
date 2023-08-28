# EventSourcingWithEventStore

## Container Docker do EventStoreDB Server

```bash
docker run --name esdb-node -it -p 2113:2113 -p 1113:1113 eventstore/eventstore:latest --insecure --run-projections=All --enable-atom-pub-over-http
```
