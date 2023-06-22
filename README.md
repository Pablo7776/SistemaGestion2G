# proyecto2-c-sharp

El Sr E. Musk ha quedado muy conforme con la primera version del Sistema de Gestion y ha decidido incorporar algunos productos de su empresa SPACEX.
Ha decidido enfocar las operaciones en productos especificos y para ello solo nos pide que gestionemos los siguientes modelos de productos:

TESLA: Modelo X, Modelo S y Cybertruck
SPACEX: Starship y Falcon 9

Para los productos TESLA necesita guardar el  año, kilometraje actual, color y quien es el DUEÑO. Además cada modelo tiene datos particulares:

Modelo X:
Autonomia:560km
Asientos: 7
Service: cada 1000km

Modelo S:
Autonomia:650km
Asientos: 5
Service: cada 2000km

Cybertruck:
Autonomia:800km
Asientos: 6
Service: cada 3000km

Para los productos SPACEX necesita guardar el  año, Horas de Vuelo actual, color y que EMPRESA es la DUEÑA. Además cada modelo tiene datos particulares:

Starship:
Autonomia:500hs
Service: cada 1000Hs

Falcon 9:
Autonomia:200Hs
Service: cada 400Hs

La AUTONOMIA de los TESLA se refiere a la cantidad de KMS que hace el vehiculo con 1 carga completa de bateria.
La AUTONOMIA de los SPACEX se refiere a la cantidad de HS que vuela el cohete con 1 carga completa de combustible.
Esta informacion es vital para el Sr Musk ya que puede inferir el nivel de contaminacion de sus cohetes y la vida util de sus baterias.
La seguridad es un aspecto crucial para el Sr. Musk y para ello ideó un sistema de checkeos que sus vehiculos deben realizar exhaustivamente:

(1) Control Cinturones de Seguridad: cada 1000km
(2) Control de Baterias: cada 2000km
(3) Control del Sistema de Propulsion: cada 1000Hs
(4) Control del Sistema de Navegacion: 2500km / 500Hs
(5) Control del Sistema de Traccion: cada 3000km.
(6) Control del motor: cada 3000km.

Durante el ESCANEO, deben realizarse todos los Controles del vehiculo de acuerdo al kilometraje/horas de vuelo. 
Por ej, si se escanea un Modelo S que tiene 2200km, el sistema debe informar que se le realizó 1 service y en el mismo se le checkeó (1) y (2).
Si el Modelo S tuviera 4400km, el sistema debe informar que se le realizaron 2 services:

service1:  (1) y (2)
service 2:  (1), (2),(4),(5) y (6)

Esta versión deberán implementar las siguientes funcionalidades:

* Dar de alta un Tesla y SpaceX,
* Eliminar un Tesla y SpaceX
* Mostrar el Tesla con mas kms.
* Escaneo de un vehiculo
* Mostrar la cantidad de carga de baterias/combustible de todos los vehiculos

