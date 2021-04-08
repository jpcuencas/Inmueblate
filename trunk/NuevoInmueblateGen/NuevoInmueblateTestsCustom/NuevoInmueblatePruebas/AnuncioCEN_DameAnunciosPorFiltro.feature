Feature: AnuncioCEN_DameAnunciosPorFiltro

@mytag
Scenario: DameAnunciosPorFiltro_Correcta
	Given Anuncio por tipo: 2 fecha: "26/11/2015" url: "http://miancunio1.com" desc: "anuncio 1" primero: 0 tamanio: 5
	When Filtro por anuncio
	Then devuelve resultado

Scenario: DameAnunciosPorFiltro_SinUnParametro
	Given Anuncio por tipo: 2 fecha: "26/11/2015" url: "http://miancunio1.com" primero: 0 tamanio: 5
	When Filtro por anuncio
	Then devuelve resultado

Scenario: DameAnunciosPorFiltro_Incorrecta
	Given Anuncio por tipo: 2 fecha: "5" url: "http://miancunio1.com" desc: "anuncio 1" primero: 0 tamanio: 5
	When Filtro por anuncio
	Then devuelve error