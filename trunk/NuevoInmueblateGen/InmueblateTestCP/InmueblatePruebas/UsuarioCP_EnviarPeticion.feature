Feature: UsuarioCP_EnviarPeticion

@mytag
Scenario: EnviarPeticion_Usuario a to b
	Given Usuario a con direccion: "ijsl@inm.es"
	And Usuario b con direccion: "crt@inm.es"
	When el Usuario a le envía la petición al Usuario b
	Then el resultado deber ser ditinto a -1

Scenario: EnviarPetcion_Usuario a to a
	Given Usuario a con direccion: "ijsl@inm.es"
	And Usuario b con direccion: "ijsl@inm.es"
	When el Usuario a le envía la petición al Usuario b
	Then el resultado deberia ser 0

Scenario: EnviarPeticion_A Usuario que no existe
	Given Usuario a con direccion: "ijsl@inm.es"
	And Usuario b con direccion: "noexsite@inm.es"
	When el Usuario a le envía la petición al Usuario b
	Then el resultado deberia ser 1

Scenario: EnviarPeticion_Ya existe peticion
	Given Usuario a con direccion: "4@inm.es"
	And Usuario b con direccion: "5@inm.es"
	When el Usuario a le envía la petición al Usuario b
	Then el resultado deberia ser 3
