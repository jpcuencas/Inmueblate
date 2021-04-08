using System;
using TechTalk.SpecFlow;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateCP.InmueblateCP;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InmueblateTestCP.InmueblatePruebas
{
    [Binding]
    public class UsuarioCP_ResgistrarUsuarioSteps
    {
        string nombre, mail;
        SuperUsuarioCEN supCEN = new SuperUsuarioCEN();
        UsuarioCP usuCP = new UsuarioCP();
        
        int usuario;

        [Given(@"El usuario ""(.*)"" con mail ""(.*)"" se quiere registrar")]
        public void GivenElUsuarioConMailSeQuiereRegistrar(string p_nombre, string p_mail)
        {
            nombre = p_nombre;
            mail = p_mail;
        }
        
        [When(@"lo resgitro en mi base de datos")]
        public void WhenLoResgitroEnMiBaseDeDatos()
        {
            usuario = usuCP.RegistrarUsuario(nombre, "a1", "444", mail, "casa", "pueblo", "00", "españa", "ij", "foto", "34234", DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Amigos);
        }

        [Then(@"el resultado debe ser distinto de (.*)")]
        public void ThenElResultadoDebeSerDistintoDe(int pe_noesperado)
        {
            Assert.AreNotEqual(pe_noesperado, usuario);
            if (usuario != -1)
            {
                supCEN.BorrarSuperUsuario(usuario);
                usuario = -1;
            }
        }

        [Then(@"el resultado debe ser (.*)")]
        public void ThenElResultadoDebeSer(int pe_esperado)
        {
            Assert.AreEqual(pe_esperado, usuario);
        }


    }
}
