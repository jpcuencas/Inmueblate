using System;
using TechTalk.SpecFlow;

namespace InmueblateTestCP
{
    [Binding]
    public class UsuarioCP_AceptarPeticionAmistadSteps
    {
        [Given(@"La peticion con id (.*) a sido aceptada")]
        public void GivenLaPeticionConIdASidoAceptada(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"El emisor no es amigo del receptor")]
        public void GivenElEmisorNoEsAmigoDelReceptor()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"El receptor no es amigo del emisor")]
        public void GivenElReceptorNoEsAmigoDelEmisor()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"El emisor es amigo del receptor")]
        public void GivenElEmisorEsAmigoDelReceptor()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"El receptor es amigo del emisor")]
        public void GivenElReceptorEsAmigoDelEmisor()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Registo el evento en la base de datos")]
        public void WhenRegistoElEventoEnLaBaseDeDatos()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
