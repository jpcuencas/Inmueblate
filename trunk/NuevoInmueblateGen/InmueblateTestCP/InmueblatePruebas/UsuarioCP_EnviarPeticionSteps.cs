using System;
using TechTalk.SpecFlow;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateCP.InmueblateCP;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InmueblateTestCP.InmueblatePruebas
{
    [Binding]
    public class UsuarioCP_EnviarPeticionSteps
    {
        //int usua, usub, usuc;
        int peticion;
        SuperUsuarioCEN supCEN = new SuperUsuarioCEN();
        PeticionAmistadCEN petCEN = new PeticionAmistadCEN();
        UsuarioCP usuCP = new UsuarioCP();
        SuperUsuarioEN w_usua, w_usub;
        

        [Given(@"Usuario a con direccion: ""(.*)""")]
        public void GivenUsuarioAConDireccion(string pe_mail)
        {
            w_usua = supCEN.ObtenerUsuarioPorEmail(pe_mail);
        }

        [Given(@"Usuario b con direccion: ""(.*)""")]
        public void GivenUsuarioBConDireccion(string pe_mail)
        {
            w_usub = supCEN.ObtenerUsuarioPorEmail(pe_mail);
        }

        [When(@"el Usuario a le envía la petición al Usuario b")]
        public void WhenElUsuarioALeEnviaLaPeticionAlUsuarioB()
        {
            int u1,u2;
            if (w_usua == null) u1 = -1;
            else u1 = w_usua.Id;
            if (w_usub == null) u2 = -1;
            else u2 = w_usub.Id;
            peticion = usuCP.EnviarPeticionAmistad(u1, u2, "Amistad", "Se mi amigo");
        }

        [Then(@"el resultado deber ser ditinto a (.*)")]
        public void ThenElResultadoDeberSerDitintoA(int pe_noesperado)
        {
            Assert.AreNotEqual(pe_noesperado, peticion);
            if (peticion != -1)
            {
                petCEN.BorrarPeticionAmistad(peticion);
            }
        }

        [Then(@"el resultado deberia ser (.*)")]
        public void ThenElResultadoDeberiaSer(int pe_esperado)
        {
            Assert.AreEqual(pe_esperado, peticion);
        }

    }
}
