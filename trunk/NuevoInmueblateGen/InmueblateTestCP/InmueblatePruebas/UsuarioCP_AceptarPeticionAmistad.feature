Feature: UsuarioCP_AceptarPeticionAmistad

@mytag
Scenario: Aceptar_Peticion_Correcta
	Given La peticion con id 2 a sido aceptada
	And El emisor no es amigo del receptor
	And El receptor no es amigo del emisor
	When Registo el evento en la base de datos
	Then el resultado debe ser distinto de -1

Scenario: Aceptar_Peticion_Incorrecta1
	Given La peticion con id 2 a sido aceptada
	And El emisor es amigo del receptor
	And El receptor no es amigo del emisor
	When Registo el evento en la base de datos
	Then el resultado debe ser -1

Scenario: Aceptar_Peticion_Incorrecta2
	Given La peticion con id 2 a sido aceptada
	And El emisor no es amigo del receptor
	And El receptor es amigo del emisor
	When Registo el evento en la base de datos
	Then el resultado debe ser -1

Scenario: Aceptar_Peticion_Incorrecta3
	Given La peticion con id 2 a sido aceptada
	And El emisor es amigo del receptor
	And El receptor es amigo del emisor
	When Registo el evento en la base de datos
	Then el resultado debe ser -1
