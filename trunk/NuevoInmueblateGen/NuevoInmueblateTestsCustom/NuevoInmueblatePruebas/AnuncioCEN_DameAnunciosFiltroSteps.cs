using System;
using TechTalk.SpecFlow;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NuevoInmueblateTestsCustom.NuevoInmueblatePruebas
{
    [Binding]
    public class AnuncioCEN_DameAnunciosFiltroSteps
    {
        static AnuncioEN anuncio = new AnuncioEN();
        static AnuncioCEN anuncioCEN = new AnuncioCEN();

        DateTime fecha = new DateTime();
        int tipo = 0;
        string url = "";
        static int idanu1, idanu2, idanu3, idanu4, idanu5, idanu6, idanu7;
        IList<AnuncioEN> anuncios1;
        IList<AnuncioEN> anuncios2;

        [BeforeFeature]
        static public void Creacion()
        {
          idanu1=  anuncioCEN.CrearAnuncio("/Content/img/anuncio.JPG", "Anuncio por defecto1", DateTime.Parse("31/02/2015"), NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum.Cultura, "http://miurl");
          idanu2=  anuncioCEN.CrearAnuncio("/Content/img/anuncio.JPG", "Anuncio por defecto2", DateTime.Parse("31/02/2015"), NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum.Cultura, "http://miurl");
          idanu3=  anuncioCEN.CrearAnuncio("/Content/img/anuncio.JPG", "Anuncio por defecto3", DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum.Cultura, "http://miurl");
          idanu4=  anuncioCEN.CrearAnuncio("/Content/img/anuncio.JPG", "Anuncio por defecto4", DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum.Cultura, "http://miurl");
          idanu5 = anuncioCEN.CrearAnuncio("/Content/img/anuncio.JPG", "Anuncio por defecto1", DateTime.Parse("31/02/2015"), NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum.Cultura, "http://miurl");
          idanu6 = anuncioCEN.CrearAnuncio("/Content/img/anuncio.JPG", "Anuncio por defecto2", DateTime.Parse("31/02/2015"), NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum.Cultura, "http://miurl");
          idanu7 = anuncioCEN.CrearAnuncio("/Content/img/anuncio.JPG", "Anuncio por defecto3", DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum.Cultura, "http://miurl");


        }

        [AfterFeature]
        static public void Destruccion()
        {
            anuncioCEN.BorrarAnuncio(idanu1);
            anuncioCEN.BorrarAnuncio(idanu2);
            anuncioCEN.BorrarAnuncio(idanu3);
            anuncioCEN.BorrarAnuncio(idanu4);
            anuncioCEN.BorrarAnuncio(idanu5);
            anuncioCEN.BorrarAnuncio(idanu6);
            anuncioCEN.BorrarAnuncio(idanu7);

        }
        [Given(@"se pide un anuncio de tipo (.*)")]
        public void GivenSePideUnAnuncioDeTipo(int p_tipo)
        {
            tipo = p_tipo;
        }
        
        [Given(@"fecha : ""(.*)""")]
        public void GivenFecha(string p_fecha)
        {
           fecha= DateTime.Parse(p_fecha);
        }
        
        [Given(@"url : ""(.*)""")]
        public void GivenUrl(string p_url)
        {
            url = p_url;
        }
        
        [Given(@"se pide un anuncio de tipo inexistente (.*)")]
        public void GivenSePideUnAnuncioDeTipoInexistente(int p0)
        {
            tipo = 2837462;
        }
        
        [Given(@"fecha incorrecta : ""(.*)""")]
        public void GivenFechaIncorrecta(string p0)
        {
            fecha = DateTime.Parse("31/02/2015");
        }
        
        [Given(@"url : mianuncio\.es""")]
        public void GivenUrlMianuncio_Es()
        {
            //ScenarioContext.Current.Pending();
        }
        
        [When(@"se procesa el filtro")]
        public void WhenSeProcesaElFiltro()
        {
            anuncios1=anuncioCEN.DameAnunciosFiltro(tipo,fecha,url,null,0,-1);
            anuncios2 = anuncioCEN.DameAnunciosFiltro(tipo, fecha, url, null, 0, -1);
        }
        
        [Then(@"el resultado deber un anuncio")]
        public void ThenElResultadoDeberUnAnuncio()
        {
            Assert.Equals(anuncios1.Count, 2);
        }
        
        [Then(@"el resultado deber un mensaje de error")]
        public void ThenElResultadoDeberUnMensajeDeError()
        {
            Assert.Equals(anuncios1,null);
        }
    }
}
