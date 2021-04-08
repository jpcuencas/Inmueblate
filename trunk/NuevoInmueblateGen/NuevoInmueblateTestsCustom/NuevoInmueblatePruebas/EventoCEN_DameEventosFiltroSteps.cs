using System;
using TechTalk.SpecFlow;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NuevoInmueblateTestsCustom.NuevoInmueblatePruebas
{
    [Binding]
    public class EventoCEN_DameEventosFiltroSteps
    {


        static MuroCEN muroCEN = new MuroCEN();
        static EntradaCEN entrCEN = new EntradaCEN();
        static UsuarioCEN usuCEN = new UsuarioCEN();
        static EventoCEN evntCEN = new EventoCEN();
        static GeolocalizacionCEN geoCEN = new GeolocalizacionCEN();
        static int us1;
        static int muroid;
        static int envtid1, envtid2, envtid3, envtid4, envtid5, envtid6;
        static int comid;
        string titulo;
        string cuerpo;
        DateTime fecha;
        IList<EventoEN> eventos1;
        IList<EventoEN> ecventos2;
        int primero;
        int tamanio;
        static int geoid1, geoid2, geoid3;


        [BeforeFeature]
        static public void Creacion()
        {
            us1 = usuCEN.CrearUsuario(1, "jose 1", "97866634",
                "jose@inm.es",
                "Jose1", "887868865", "eljose1@inm.es", "calle 1",
                "mi pueblo", 5, "españa", "1234", DateTime.Parse("26/11/1987"), NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Publico);
            muroid = muroCEN.CrearMuro(true);

            geoid1 = geoCEN.CrearGeolocalizacion(55, 55, "Lugar ecento", "poblacion evento");
            geoid2 = geoCEN.CrearGeolocalizacion(55, 55, "Lugar ecento", "poblacion evento");
            geoid3 = geoCEN.CrearGeolocalizacion(55, 55, "Lugar ecento", "poblacion evento");

        }

        [AfterFeature]
        static public void Destruccion()
        {
            evntCEN.BorrarEvento(envtid1);
            evntCEN.BorrarEvento(envtid2);
            evntCEN.BorrarEvento(envtid3);
            evntCEN.BorrarEvento(envtid4);
            evntCEN.BorrarEvento(envtid5);
            evntCEN.BorrarEvento(envtid6);

            geoCEN.BorrarGeolocalizacion(geoid1);
            geoCEN.BorrarGeolocalizacion(geoid2);
            geoCEN.BorrarGeolocalizacion(geoid3);

            muroCEN.BorrarMuro(muroid);
            usuCEN.BorrarUsuario(us1);

        }
        [Given(@"nombbre: ""(.*)"" desc:""(.*)"" fecha ""(.*)"" cat: ""(.*)"" primero: (.*) ulrimo: (.*)")]
        public void GivenNombbreDescFechaCatPrimeroUlrimo(string p0, string p1, string p2, string p3, int p4, int p5)
        {
            envtid1 = evntCEN.CrearEvento("mi titulo", "esto es el cuerpo", DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum.Deportes, us1, geoid1);
            envtid2 = evntCEN.CrearEvento(" titulo", "esto es el cuerpo", DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum.Negocio, us1, geoid1);
            envtid3 = evntCEN.CrearEvento("mi titulo", "esto  el cuerpo", DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum.Negocio, us1, geoid1);
            envtid4 = evntCEN.CrearEvento(" titulo", "esto es el cuerpo", DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum.Moda, us1, geoid2);
            envtid5 = evntCEN.CrearEvento("mi titulo", "esto es el cuerpo", DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum.Deportes, us1, geoid2);
            envtid6 = evntCEN.CrearEvento("mi titulo", "esto es el cuerpo", DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum.Deportes, us1, geoid3);

        
        
        }
        
        [When(@"Ejecutamos el filtro")]
        public void WhenEjecutamosElFiltro()
        {
            eventos1 = evntCEN.DameEventosFiltro("mi titulo", "esto es el cuerpo", DateTime.Today, int.Parse(NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum.Deportes.ToString()), 0, 10);
        }
        
        [Then(@"Se muestra el resultado")]
        public void ThenSeMuestraElResultado()
        {
            Assert.Equals(eventos1.Count, 3);
        }
    }
}
