Feature: UsuarioCP_ResgistrarUsuario

@mytag
Scenario: ResgistrarUsuario_Nuevo
	Given El usuario "Diana" con mail "ddvc@inm.es" se quiere registrar
	When lo resgitro en mi base de datos
	Then el resultado debe ser distinto de -1

Scenario: ResgistrarUsuario_Nuevo pero ya Existe
	Given El usuario "Isido" con mail "ijsl@inm.es" se quiere registrar
	When lo resgitro en mi base de datos
	Then el resultado debe ser -1
