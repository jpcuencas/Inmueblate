using System;
using TechTalk.SpecFlow;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;
using NuevoInmueblateGenNHibernate.CAD.RedSocial;
using NuevoInmueblateCP.InmueblateCP;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NuevoInmueblateTestCustom.NuevoInmueblatePruebas
{
    [Binding]
    public class SuperUsuarioCEN_LoginSteps
    {
        SuperUsuarioCEN supCEN = new SuperUsuarioCEN();


        NuevoInmueblateGenNHibernate.Enumerated.RedSocial.EstadoLoginEnum estado;
        string w_mail, w_contrasenya;

        [Given(@"Un usuario con email ""(.*)"" y contraseña ""(.*)""")]
        public void GivenUnUsuarioConEmailYContrasena(string pe_mail, string pe_contrasenya)
        {
            w_mail = pe_mail;
            w_contrasenya = pe_contrasenya;
        }

        [Given(@"Un moderador con email ""(.*)"" y contraseña ""(.*)""")]
        public void GivenUnModeradorConEmailYContrasena(string pe_mail, string pe_contrasenya)
        {
            w_mail = pe_mail;
            w_contrasenya = pe_contrasenya;
        }

        [Given(@"Una inmobiliara con email ""(.*)"" y contraseña ""(.*)""")]
        public void GivenUnaInmobiliaraConEmailYContrasena(string pe_mail, string pe_contrasenya)
        {
            w_mail = pe_mail;
            w_contrasenya = pe_contrasenya;
        }

        [When(@"quiero logearme en la red social como ""(.*)""")]
        public void WhenQuieroLogearmeEnLaRedSocialComo(string tipo)
        {
            switch (tipo)
            {
                case "Usuario": estado = supCEN.Login(0, w_mail, w_contrasenya); break;
                case "Moderador": estado = supCEN.Login(0, w_mail, w_contrasenya); break;
                case "Inmobiliaria": estado = supCEN.Login(0, w_mail, w_contrasenya); break;
                default: estado = NuevoInmueblateGenNHibernate.Enumerated.RedSocial.EstadoLoginEnum.NoLogeado; break;
            }
        }


        [Then(@"debo logearme como usuario y devolver (.*)")]
        public void ThenDeboLogearmeComoUsuarioYDevolver(int pe_esperado)
        {
            Assert.AreEqual(pe_esperado, (int)estado);
        }
    }
}
