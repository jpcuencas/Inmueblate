using System;
using TechTalk.SpecFlow;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateCP.InmueblateCP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace InmueblateTestCP.InmueblatePruebas
{
    [Binding]
    public class MensajeCP_CrearMensajeSteps
    {
        static UsuarioCEN usuCEN = new UsuarioCEN();
        static UsuarioCP usuCP = new UsuarioCP();
        MensajeCEN menCEM = new MensajeCEN();
        MensajeCP menCP = new MensajeCP();
        IList<MensajeEN> mens;
        String cuerpo;

        static int a, b;
        int men;

        [BeforeFeature]
        static public void Creacion()
        {
            a = usuCP.RegistrarUsuario("n1","a1","1111","aa@inm.es","casa","esp","0369","esp","aa","foto","555",DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Privado);
            b = usuCP.RegistrarUsuario("n1", "a1", "222", "bb@inm.es", "casa", "esp", "0369", "esp", "bb", "foto", "555", DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Privado);
        }

        [AfterFeature]
        static public void Destruccion()
        {
            usuCEN.BorrarUsuario(a);
            usuCEN.BorrarUsuario(b);
        }

        [Given(@"Un usario le envia un mensaje a otro")]
        public void GivenUnUsarioLeEnviaUnMensajeAOtro()
        {
            
        }

        [When(@"El usuario a le envia el mensaje ""(.*)"" al usuario b")]
        public void WhenElUsuarioALeEnviaElMensajeAlUsuarioB(string pe_men)
        {
            cuerpo = pe_men;
            men = menCP.CrearMensaje(false, DateTime.Today, "asunto", pe_men, false, a, b);
        }

        
        [Then(@"El usuario b tene un nuevo mensaje")]
        public void ThenElUsuarioBTeneUnNuevoMensaje()
        {
            bool men = false;
            mens = menCEM.ObtenerMensajesPorUsuario(b,1,10);
            
            foreach (MensajeEN m in mens)
            {
                if (m.Cuerpo == cuerpo)
                {
                    men = true;
                }
            }

            Assert.IsTrue(men);
        }
    }
}
