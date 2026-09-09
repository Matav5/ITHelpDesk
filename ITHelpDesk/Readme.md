


Při spuštění se ideálně přihlašte jako admin. Aktuálně se na přihlášeného uživatele jen bere vpotaz při notifikování o změnách. Aplikace má jen 2 příkazy a to process (spustí simulaci řešení incidentu) a exit (ukončí aplikaci).

## Template
Složka Incidents - Incident je zde jako base class ve které je definován životní cyklus řešení incidentu. 
Každý derivovaný incident má potom svůj specifický postup v řešení daného incidentu.

## Chain of Responsibility 
Složka Handlers - SupportHandler je zde jako base class ve které je proces postupného zpracování a eskalace na další incident.
Jedotlivé handlery jsou populovány jednotlivými uživateli, které jsou schopný daný level incidentu řešit.
Každý derivovaný handler má podmínky priorit, které musí být splněny, aby mohl incident zpracovat. Pokud podmínky nejsou splněny, handler předá incident dalšímu handleru v řetězci.


## Factory method 
IncidentFactory - volá se createIncident, která vrací konkrétní objekt incidentu podle Enum parametru typu incidentu.

## Observer

Uživatel sleduje změny incidentů. Pokud dojde ke změně tak je uživatel upozorněn a pokud se ho daná změna týká (admin/zadavatel incidentu), tak se uživateli přidá notifikace která se vypíše v dalším cyklu aplikace.



Program aktuálně disponuje jen kostrou ukládání a načítání incidentů. Chybí diskriminátor který by vytvářel správný typ incidentu při načítání z JSON souboru. K dodělání by bylo potřeba změnit jen způsob načítání např na čistý txt a při načtení podle typu pro daný řádek vytvořit přes Factory metodu správnou metodu