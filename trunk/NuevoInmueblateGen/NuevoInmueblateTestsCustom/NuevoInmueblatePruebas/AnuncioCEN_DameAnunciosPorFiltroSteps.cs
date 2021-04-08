using System;
using TechTalk.SpecFlow;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;
using NuevoInmueblateCP.InmueblateCP;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NuevoInmueblateTestsCustom.NuevoInmueblatePruebas
{
    
    [Binding]
    public class AnuncioCEN_DameAnunciosPorFiltroSteps
    {
        static UsuarioCEN usuCEN = new UsuarioCEN();
        static AnuncioCEN anuCEN = new AnuncioCEN();
        IList<AnuncioEN> anuncios;

        int tipo;
        DateTime fecha;
        string descripcion;
        string url;
        int primero;
        int tamanio;

        static int an1, an2, an3, an4, an5, an6;
        int men;

        [BeforeFeature]
        static public void Creacion()
        {
            DateTime fecha1=DateTime.Parse("26/11/2015");
            DateTime fecha2 = DateTime.Parse("26/11/2016");
            DateTime fecha3 = DateTime.Today;
            an1 = anuCEN.CrearAnuncio("imgParaAnuncio1.jpg", "anuncio 1", fecha1, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum.Cultura, "http://mianuncio1.com");
            an2 = anuCEN.CrearAnuncio("imgParaAnuncio1.jpg", "anuncio 2", fecha1, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum.Cultura, "http://mianuncio2.com");
            an3 = anuCEN.CrearAnuncio("imgParaAnuncio1.jpg", "anuncio 3", fecha1, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum.Cultura, "http://mianuncio3.com");
            an4 = anuCEN.CrearAnuncio("imgParaAnuncio1.jpg", "anuncio 4", fecha2, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum.Cultura, "http://mianuncio4.com");
            an5 = anuCEN.CrearAnuncio("imgParaAnuncio1.jpg", "anuncio 5", fecha2, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum.Cultura, "http://mianuncio5.com");
            an6 = anuCEN.CrearAnuncio("imgParaAnuncio1.jpg", "anuncio 6", fecha3, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum.Cultura, "http://mianuncio6.com");
            


        }

        [AfterFeature]
        static public void Destruccion()
        {
            anuCEN.BorrarAnuncio(an1);
            anuCEN.BorrarAnuncio(an2);
            anuCEN.BorrarAnuncio(an3);
            anuCEN.BorrarAnuncio(an4);
            anuCEN.BorrarAnuncio(an5);
            anuCEN.BorrarAnuncio(an6);
        }

        [Given(@"Anuncio por tipo: (.*) fecha: ""(.*)"" url: ""(.*)"" desc: ""(.*)"" primero: (.*) tamanio: (.*)")]
        public void GivenAnuncioPorTipoFechaUrlDescPrimeroTamanio(int p0, string p1, string p2, string p3, int p4, int p5)
        {
            tipo = p0;
            fecha = DateTime.Parse(p1);
            url = p2;
            descripcion = p3;
            primero = p4;
            tamanio = p5;
        }
        
        [Given(@"Anuncio por tipo: (.*) fecha: ""(.*)"" url: ""(.*)"" primero: (.*) tamanio: (.*)")]
        public void GivenAnuncioPorTipoFechaUrlPrimeroTamanio(int p0, string p1, string p2, int p3, int p4)
        {
            tipo = p0;
            fecha = DateTime.Parse(p1);
            url = p2;
            primero = p3;
            tamanio = p4;
        }
        
        [Given(@"Anuncio por tipo: (.*) fecha: ""(.*)"" url: ""(.*)"" desc: ""(.*)"" primero: (.*) tamanio: (.*)")]
        public void GivenAnuncioPorTipoFechaUrlDescPrimeroTamanio(int p0, int p1, string p2, string p3, int p4, int p5)
        {
            tipo = p0;
            fecha = DateTime.Parse( p1.ToString());
            url = p2;
            descripcion = p3;
            primero = p4;
            tamanio = p5;
        }
        
        [When(@"Filtro por anuncio")]
        public void WhenFiltroPorAnuncio()
        {
            anuncios=anuCEN.DameAnunciosFiltro(tipo, fecha, url, descripcion, primero, tamanio);
        }
        
        [Then(@"devuelve resultado")]
        public void ThenDevuelveResultado()
        {
            Assert.Equals(anuncios[0].Descripcion,"anuncio 1");
        }
        
        [Then(@"devuelve error")]
        public void ThenDevuelveError()
        {
            Assert.Equals(anuncios[0].Descripcion, null);
        }
    }
}
