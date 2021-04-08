Feature: ComentarioCEN_BorrarReportadores

@mytag
Scenario: BorrarReportadores_Correcta
	Given ids usuario id: 1 id: 2 id: 3 id: 4
	When Borra los repotadores
	Then  guardan correctamente


Scenario: BorrarReportadores_Incorrecta_usuarionoexiste
	Given ids usuario id: 1 id: 233 id: 355 id: 4
	When Borra los repotadores
	Then guardan correctamente


Scenario: BorrarReportadores_Incorrecta_usuarioNull
	Given ids usuario id: 1 id: null id: 3 id: 4
	When Borra los repotadores
	Then guardan correctamente
