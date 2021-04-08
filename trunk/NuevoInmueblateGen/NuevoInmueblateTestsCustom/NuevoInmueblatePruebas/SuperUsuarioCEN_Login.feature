Feature: SuperUsuarioCEN_Login

@mytag
Scenario: Login_Logeo erroneo
	Given Un usuario con email "ddv@inm.es" y contraseña "ddv"
	When quiero logearme en la red social como "Usuario"
	Then debo logearme como usuario y devolver 1

Scenario: Login_Logeo como moderador
	Given Un moderador con email "avam@inm.es" y contraseña "avam"
	When quiero logearme en la red social como "Moderador"
	Then debo logearme como usuario y devolver 2

Scenario: Login_Logeo como usuario
	Given Un usuario con email "ijsl@inm.es" y contraseña "ijsl"
	When quiero logearme en la red social como "Usuario"
	Then debo logearme como usuario y devolver 3

Scenario: Login_Logeo como Inmobiliaria
	Given Una inmobiliara con email "jpcs@inm.es" y contraseña "jpcs"
	When quiero logearme en la red social como "Inmobiliaria"
	Then debo logearme como usuario y devolver 4