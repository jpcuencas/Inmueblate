Feature: MensajeCP_CrearMensaje

@mytag
Scenario: Envio de mensaje
	Given Un usario le envia un mensaje a otro
	When El usuario a le envia el mensaje "hola" al usuario b
	Then El usuario b tene un nuevo mensaje
