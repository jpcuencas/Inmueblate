using System;
using TechTalk.SpecFlow;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;
using NuevoInmueblateGenNHibernate.CAD.RedSocial;
using NuevoInmueblateCP.InmueblateCP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace NuevoInmueblateTestCustom.NuevoInmueblatePruebas
{
    [Binding]
    public class AnuncioCEN_ObtenerAnunciosRandomSteps
    {
        int w_numAnuncios;
        IList<AnuncioEN> w_lista1, w_lista2;

        AnuncioCEN anuCEN = new AnuncioCEN();

        [Given(@"quiero (.*) anuncios aleatorios")]
        public void GivenQuieroAnunciosAleatorios(int pe_numero)
        {
            w_numAnuncios = pe_numero;
        }

        [When(@"busco mis anuncios")]
        public void WhenBuscoMisAnuncios()
        {
            w_lista1 = anuCEN.ObtenerAnunciosRandom(w_numAnuncios);
        }

        [When(@"creo dos listas de mis anuncios")]
        public void WhenCreoDosListasDeMisAnuncios()
        {
            w_lista1 = anuCEN.ObtenerAnunciosRandom(w_numAnuncios);
            w_lista2 = anuCEN.ObtenerAnunciosRandom(w_numAnuncios);
        }

        [Then(@"deberia otener (.*) anuncios")]
        public void ThenDeberiaOtenerAnuncios(int pe_esperado)
        {
            Assert.AreEqual(pe_esperado, w_lista1.Count);
        }

        [Then(@"las listas deberian ser distintas")]
        public void ThenLasListasDeberianSerDistintas()
        {
            if (w_lista1 == w_lista2)
            {
                Assert.Fail();
            }
            else
            {
                Assert.IsTrue(true);
            }

            w_lista1.Clear();
            w_lista2.Clear();
            w_numAnuncios = -1;
        }

    }
}