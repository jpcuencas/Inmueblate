using System;
using TechTalk.SpecFlow;
using NuevoInmueblateTestsWCF.ServiceReference1;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NuevoInmueblateTestsWCF.InmueblatePruebas
{
    [Binding]
    public class Moderador_LoginSteps
    {
        ServiceClient servicio = new ServiceClient();
        static ModeradorCEN modCEN = new ModeradorCEN();
        static int mod;
            int log;

        [BeforeFeature]
        static public void Creacion()
        {
            mod = modCEN.CrearModerador(-1,
                        "Alejandro",
                        "9658965",
                        "aaa@inm.es",
                        "su casa",
                        "elda",
                        "58963",
                        "España",
                        "12345", 10,
                        "Aravid",
                        "11111111",
                        DateTime.Today,
                        NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Privado);
        }

        [AfterFeature]
        static public void Destruccion()
        {
            modCEN.BorrarModerador(mod);
        }

        [Given(@"El moderador existente")]
        public void GivenElModeradorExistente()
        {
            if (modCEN.get_IModeradorCAD().ReadOIDDefault(mod) == null)
            {
                Assert.Fail();
            }
        }
        
        [When(@"El moderador se logea")]
        public void WhenElModeradorSeLogea()
        {
            log = (int)servicio.NuevoInmueblate_Moderador_Anonimo_Login(mod, "aaa@inm.es", "12345");
        }

        [When(@"El moderador introduce una contraseña erronea")]
        public void WhenElModeradorIntroduceUnaContrasenaErronea()
        {
            log = (int)servicio.NuevoInmueblate_Moderador_Anonimo_Login(mod, "aaa@inm.es", "12");
        }


        [Then(@"El moderador se ha logeado como (.*)")]
        public void ThenElModeradorSeHaLogeadoComo(int p0)
        {
            Assert.AreEqual(p0, log);
        }
    }
}
