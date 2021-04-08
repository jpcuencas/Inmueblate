Feature: AnuncioCEN_DameAnunciosFiltro


@mytag
Scenario: DameAnunciosFiltro_Correcto
	Given se pide un anuncio de tipo 2
	And fecha : "22/11/2015"
	And url : "http.://mianuncio.es"
	When se procesa el filtro
	Then el resultado deber un anuncio

Scenario: DameAnunciosFiltro_Incorrecto1
	Given se pide un anuncio de tipo inexistente 5
	And fecha : "22/11/2015"
	And url : "http.://mianuncio.es"
	When se procesa el filtro
	Then el resultado deber un mensaje de error


Scenario: DameAnunciosFiltro_Incorrecto2
	Given se pide un anuncio de tipo 2
	And fecha incorrecta : "31/02/2015"
	And url : "http.://mianuncio.es"
	When se procesa el filtro
	Then el resultado deber un mensaje de error

Scenario: DameAnunciosFiltro_Incorrecto3
	Given se pide un anuncio de tipo 2
	And fecha : "22/11/2015"
	And url : mianuncio.es"
	When se procesa el filtro
	Then el resultado deber un mensaje de error