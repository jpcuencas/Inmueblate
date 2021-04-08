Feature: Moderador_Login

Scenario: El moderador se logea correctamente
	Given El moderador existente
	When El moderador se logea
	Then El moderador se ha logeado como 2

Scenario: El moderador se logea erroneamente
	Given El moderador existente
	When El moderador introduce una contraseña erronea
	Then El moderador se ha logeado como 1
