Feature: ComentarioCEN_AnyadirReportador

@mytag
Scenario: AnyadirReportador_Correcto
	Given recive una lista de reportadores correcta
	When Se procesa y añade la lista
	Then Los reportadores se han añadido

Scenario: AnyadirReportador_Incorreco1
	Given recive una lista de reportadores correcta y el comentario no existe
	When Se procesa y añade la lista
	Then Le lanza un error

Scenario: AnyadirReportador_Incorrecto2
	Given recive una lista de reportadores correcta
	When Se procesa y añade la lista
	Then Le lanza un error
