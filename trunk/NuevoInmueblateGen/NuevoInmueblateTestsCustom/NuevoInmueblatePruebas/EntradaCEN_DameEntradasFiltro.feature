Feature: EntradaCEN_DameEntradasFiltro

@mytag
Scenario: DameEntradasFiltro_Correcta
	Given Entrada por titulo: "titulo 1" cuerpo: "esto es el cuerpo1" fecha: "23/11/2013" filtroPDMod: true pendiente:true usuario:2 primero: 0 tamanio: 5
	When Filtro por entrada
	Then devuelve resultado correcto

Scenario: DameEntradasFiltro_SinUnParametro
	Given Entrada por titulo: "titulo 1" cuerpo: "esto es el cuerpo1" fecha:null filtroPDMod: true pendiente:true usuario:2 primero: 0 tamanio: 5
	When Filtro por entrada
	Then devuelve resultado correcto

Scenario: DameEntradasFiltro_Incorrecta
	Given Entrada por titulo: "titulo 1" cuerpo: "esto es el cuerpo1" fecha:null filtroPDMod: true pendiente:true usuario:2 primero: 0 tamanio: 5
	When Filtro por entrada
	Then devuelve un error
