using System;
using TechTalk.SpecFlow;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;
using NuevoInmueblateCP.InmueblateCP;
using System.Collections.Generic;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace InmueblateTestCP.InmueblatePruebas
{
    [Binding]
    public class UsuarioCP_AceptarPeticionAmistadSteps
    {
        int idPet;
        static UsuarioCEN usuCEN = new UsuarioCEN();
        static UsuarioCP usuCP = new UsuarioCP();

        int us1;
        int us2;


        static int usuarioA;
        static int usuarioB;
        [BeforeFeature]
        static public void Creacion()
        {
            usuarioA = usuCP.RegistrarUsuario("n1", "a1", "1111", "aa@inm.es", "casa", "esp", "0369", "esp", "aa", "foto", "555", DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Privado);
            usuarioB = usuCP.RegistrarUsuario("n1", "a1", "222", "bb@inm.es", "casa", "esp", "0369", "esp", "bb", "foto", "555", DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Privado);
        }

        [AfterFeature]
        static public void Destruccion()
        {
            usuCEN.BorrarUsuario(usuarioA);
            usuCEN.BorrarUsuario(usuarioB);
        }
        [Given(@"La peticion con id (.*) a sido aceptada")]
        public void GivenLaPeticionConIdASidoAceptada(int p0)
        {
            idPet = p0;
        }
        
        [Given(@"El emisor no es amigo del receptor")]
        public void GivenElEmisorNoEsAmigoDelReceptor()
        {
            us1 = usuarioA;
        }
        
        [Given(@"El receptor no es amigo del emisor")]
        public void GivenElReceptorNoEsAmigoDelEmisor()
        {
            us2 = usuarioB;
        }
        
        [Given(@"El emisor es amigo del receptor")]
        public void GivenElEmisorEsAmigoDelReceptor()
        {

            int pet0 = usuCEN.EnviarPeticionAmistad(usuarioA, usuarioB, "peticion 0", "Usuario A a usuario B");
            us1 = usuarioA;
            us2 = usuarioB;
        }
        
        [Given(@"El receptor es amigo del emisor")]
        public void GivenElReceptorEsAmigoDelEmisor()
        {
            int pet0 = usuCEN.EnviarPeticionAmistad(usuarioB, usuarioA, "peticion 0", "Usuario A a usuario B");
            us1 = usuarioA;
            us2 = usuarioB;
        }
        
        [When(@"Registo el evento en la base de datos")]
        public void WhenRegistoElEventoEnLaBaseDeDatos()
        {
           // usuCP.
        }
    }
}
