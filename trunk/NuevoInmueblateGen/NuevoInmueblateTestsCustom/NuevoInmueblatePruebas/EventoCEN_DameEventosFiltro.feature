Feature: EventoCEN_DameEventosFiltro

@mytag
Scenario: DameEventosFiltro_Correcta
	Given nombbre: "mi evento" desc:"este es mi mejor evento" fecha "hoy" cat: "moda" primero: 0 ulrimo: 5
	When Ejecutamos el filtro
	Then Se muestra el resultado


Scenario: DameEventosFiltro_sin_parametros	
	Given nombbre: "mi evento" desc:"este es mi mejor evento" fecha "hoy" cat: "moda" primero: 0 ulrimo: 5
	When Ejecutamos el filtro
	Then Se muestra el resultado


