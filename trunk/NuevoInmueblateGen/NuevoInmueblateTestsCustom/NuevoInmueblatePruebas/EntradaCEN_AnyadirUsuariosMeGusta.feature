Feature: EntradaCEN_AnyadirUsuariosMeGusta


@mytag
Scenario: AnyadirUsuariosMeGusta_Correcta
	Given id usuario id: 1 id: 2 id: 3 id: 4
	When añade usuarios me gusta
	Then guarda correctamente


Scenario: AnyadirUsuariosMeGusta_Incorrecta_usuarionoexiste
	Given ids no existe usuario id: 1 id: 233 id: 355 id: 4
	When añade usuarios me gusta
	Then guarda correctamente


Scenario: AnyadirUsuariosMeGusta_Incorrecta_usuarioNull
	Given id usuario id: 1 id: null id: 3 id: 4
	When añade usuarios me gusta
	Then guarda correctamente
