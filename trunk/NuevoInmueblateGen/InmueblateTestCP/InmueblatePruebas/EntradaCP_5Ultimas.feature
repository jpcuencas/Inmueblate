Feature: EntradaCP_5Ultimas

@mytag
Scenario: Ultimas5_Correcta
	Given Pides las entradas del usuario con id 2
	When realizo la consulta
	Then Se muestra bien

Scenario: Ultimas5_Incorrecta1
	Given Pides las entradas del usuario que no existe con id 8774564654
	When realizo la consulta
	Then Me informa del error

