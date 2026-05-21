# Allocation Service API
API’et håndterer terminal‑allokering af pakker i det event‑drevne pakkesystem.
Servicen fungerer primært som en prioritetskø, der modtager allokeringsanmodninger, opdaterer kapacitet og publicerer resultater.

Se OpenApi Spec her: [OpenAPI spec](../AllocationService.Api/OpenApiScript/open-api-script.yaml)

#Endpoints
##POST /allocation
Processerer en ny terminal‑allokeringsanmodning og forsøger at allokere pakken baseret på prioritet og tilgængelige terminaler.
Bliver automatisk consumed af Event: allocate-parcel
##Request Body (JSON)
``` json
{
  "trackingNumber": "550e8400-e29b-41d4-a716-446655440000",
  "terminals": [
    "20000000-0000-0000-0000-000000000005",
    "30000000-0000-0000-0000-000000000001"
  ],
  "priority": 1
}
```
##Response (201 Created)
Ingen body returneres ved succes.

#POST /allocation/failed	
Modtager en mislykket allokeringsanmodning og forsøger at reallokere pakken.
Bliver automatisk consumed af Event: allocation-failed
##Request Body (JSON)
``` json
{
  "trackingNumber": "550e8400-e29b-41d4-a716-446655440000",
  "terminalId": "20000000-0000-0000-0000-000000000005"
}
```
##Response (201 Created)
Ingen body returneres ved succes.

#POST /allocation/capacity
Opdaterer terminalkapacitet i cachen og forsøger at allokere ventende pakker i køen.
Bliver automatisk consumed af Event: update-terminal-capacity
##Request Body (JSON)
``` json
{
  "terminalId": "20000000-0000-0000-0000-000000000005",
  "terminalCapacity": 150
}
```
##Response (202 Accepted)
Ingen body returneres ved succes.
##Response example (400 eller 500)
``` json
{
  "message": "Invalid request data"
}
```


# Flow diagram
## POST /allocation
```mermaid
flowchart TD
    A[POST /allocation] --> B[Find terminal with highest capacity]

    B --> C{Any valid terminal found?}
    C -- No --> C1[Return BadRequest]

    C -- Yes --> D{Allocation possible?}

    D -- Yes --> E[Allocate via AllocationService]
    E --> F[Return success result]

    D -- No --> G[Get Queue Terminal from factory]
    G --> H{Factory success?}
    H -- No --> H1[Return error]

    H -- Yes --> I[Enqueue allocation request]
    I --> J[Return queue result]
```

## POST /allocation/failed
```mermaid
flowchart TD
    A[POST /allocation/failed] --> B[Force update terminal]

    B --> C[Create new AllocateRequest]

    C --> D[Call AllocateRequestCommand / POST /allocation]
    D --> E[Return result]
```

## POST /allocation/capacity
```mermaid
flowchart TD
    A[POST /allocation/capacity] --> B[Update terminal capacity in cache]

    B --> C{Cache update success?}
    C -- No --> C1[Return error]

    C -- Yes --> D[Get inmemory queue]

    D --> E{Queue fetch success?}
    E -- No --> E1[Return error]

    E -- Yes --> F[Empty queue based on new capacity]
    F --> G[Return success]
```