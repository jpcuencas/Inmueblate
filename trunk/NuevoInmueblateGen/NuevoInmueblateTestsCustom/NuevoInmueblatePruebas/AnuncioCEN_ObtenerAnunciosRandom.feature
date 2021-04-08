Feature: AnuncioCEN_ObtenerAnunciosRandom

@mytag
Scenario: ObtenerAnunciosRandom_Obtener 5 anuncios
	Given quiero 5 anuncios aleatorios
	When busco mis anuncios
	Then deberia otener 5 anuncios

Scenario: ObtenerAnunciosRandom_Obtener 15 anuncios
	Given quiero 15 anuncios aleatorios
	When busco mis anuncios
	Then deberia otener 10 anuncios

Scenario: ObtenerAnunciosRandom_Obtener -5 anuncios
	Given quiero -5 anuncios aleatorios
	When busco mis anuncios
	Then deberia otener 0 anuncios

Scenario: ObtenerAnunciosRandom_Obtener 3 anuncios distintos
	Given quiero 3 anuncios aleatorios
	When creo dos listas de mis anuncios
	Then las listas deberian ser distintas
