# TheParcelApplication : Parcel Routing & Allocation System
Microservices • Event‑Driven Architecture • CI/CD • Kubernetes • Algortimer

Dette repository indeholder et komplet, event‑drevet microservice‑system, der simulerer håndtering, routing og allokering af pakker i et produktionslignende miljø.
Projektet er udviklet som en del af et semesterforløb med fokus på microservices, DevOps, container‑orkestrering og algoritmisk forståelse.

# Fagelementer
Semesteret består af følgende fagelementer. Microservices‑delen er gennemført som tilbud fra UCL/Kaj, mens de øvrige elementer er gennemført som selvstudie:

* Microservices (10 ECTS)
* Algoritmer og datastrukturer (5 ECTS)
* CI/CD og DevOps principper (10 ECTS)
* Kubernetes og container orkestrering (5 ECTS)

# Dokumentation
Der er oprettet C4 model: [C4](https://isoflow.io/project/cmnn3ibsq017smc1vpqpz8e93)

Repository docs, Dapr Components og kubernetes manifest kan findes i mappen [/Docs](Docs)
Hvis der ønskes services specifikke dokumentation kan de findes i hver microservice i deres README
[ParcelService](src/ParcelService)
[RoutingService](src/RoutingService)
[AllocationService](src/AllocationService)
[TerminalService](src/TerminalService)