using System;
using TechTalk.SpecFlow;

namespace NuevoInmueblateTestsCustom.NuevoInmueblatePruebas
{
    [Binding]
    public class MensajeCEN_CrearMensajeDeModeradorSteps
    {
        [Given(@"idemisor: (.*) idreceptor: (.*) pendiente: true fecha: ""(.*)"" asunto: ""(.*)"" mensaje: ""(.*)"" leido : false")]
        public void GivenIdemisorIdreceptorPendienteTrueFechaAsuntoMensajeLeidoFalse(int p0, int p1, string p2, string p3, string p4)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Creamos el mensaje")]
        public void WhenCreamosElMensaje()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"El mensaje se ha creado correctamente")]
        public void ThenElMensajeSeHaCreadoCorrectamente()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
