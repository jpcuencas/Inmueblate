Feature: MensajeCEN_CrearMensajeDeModerador

@mytag
Scenario: CrearMensajeDeModerador_Correcta
	Given idemisor: 1 idreceptor: 5 pendiente: true fecha: "26/11/2013" asunto: "el asunto del mensaje" mensaje: "esto es el mensaje en si..." leido : false
	When Creamos el mensaje
	Then El mensaje se ha creado correctamente


Scenario: CrearMensajeDeModerador_Incorrecta1
	Given idemisor: -1 idreceptor: 5 pendiente: true fecha: "26/11/2013" asunto: "el asunto del mensaje" mensaje: "esto es el mensaje en si..." leido : false
	When Creamos el mensaje
	Then El mensaje se ha creado correctamente

