using System;
using TechTalk.SpecFlow;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;
using System.Collections.Generic;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NuevoInmueblateTestsCustom.NuevoInmueblatePruebas
{
    [Binding]
    public class EntradaCEN_DameEntradasFiltroSteps
    {

        static MuroCEN muroCEN = new MuroCEN();
        static EntradaCEN entrCEN = new EntradaCEN();
        static UsuarioCEN usuCEN = new UsuarioCEN();
        static ComentarioCEN comCEN = new ComentarioCEN();
        static int us1;
        static int muroid;
        static int entrid1, entrid2, entrid3, entrid4, entrid5, entrid6;
        static int comid;
        string titulo;
        string cuerpo;
        DateTime fecha;
        IList<EntradaEN> entradas1;
        IList<EntradaEN> entradas2;
        int primero;
        int tamanio;

        [BeforeFeature]
        static public void Creacion()
        {
            us1 = usuCEN.CrearUsuario(1, "jose 1", "97866634",
                "jose@inm.es",
                "Jose1", "887868865", "eljose1@inm.es", "calle 1",
                "mi pueblo", 5, "españa", "1234", DateTime.Parse("26/11/1987"), NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Publico);
            muroid = muroCEN.CrearMuro(true);

            entrid1 = entrCEN.CrearEntrada(DateTime.Today, "mi titulo", "esto es el cuerpo", true, muroid, us1);
            entrid2= entrCEN.CrearEntrada(DateTime.Today, "mi titulo", "esto es el cuerpo", true, muroid, us1);
            entrid3 = entrCEN.CrearEntrada(DateTime.Today, "mi titulo", "esto es el cuerpo", true, muroid, us1);
            entrid4 = entrCEN.CrearEntrada(DateTime.Today, "mi titulo", "esto es el cuerpo", true, muroid, us1);
            entrid5 = entrCEN.CrearEntrada(DateTime.Today, "mi titulo", "esto es el cuerpo", true, muroid, us1);
            entrid6 = entrCEN.CrearEntrada(DateTime.Today, "mi titulo", "esto es el cuerpo", true, muroid, us1);
            comid = comCEN.CrearComentario("esto es un comentario", false, DateTime.Today, us1, entrid1);

        }

        [AfterFeature]
        static public void Destruccion()
        {
            comCEN.BorrarComentario(comid);
            entrCEN.BorrarEntrada(entrid1);
            entrCEN.BorrarEntrada(entrid2);
            entrCEN.BorrarEntrada(entrid3);
            entrCEN.BorrarEntrada(entrid4);
            entrCEN.BorrarEntrada(entrid5);
            entrCEN.BorrarEntrada(entrid6);
            muroCEN.BorrarMuro(muroid);
            usuCEN.BorrarUsuario(us1);

        }

        [Given(@"Entrada por titulo: ""(.*)"" cuerpo: ""(.*)"" fecha: ""(.*)"" filtroPDMod: true pendiente:true usuario:(.*) primero: (.*) tamanio: (.*)")]
        public void GivenEntradaPorTituloCuerpoFechaFiltroPDModTruePendienteTrueUsuarioPrimeroTamanio(string p0, string p1, string p2, int p3, int p4, int p5)
        {
            titulo = p0;
            cuerpo = p1;
            fecha = DateTime.Parse(p2);

            primero = p4;
            tamanio = p5;
            
        }
        
        [Given(@"Entrada por titulo: ""(.*)"" cuerpo: ""(.*)"" fecha:null filtroPDMod: true pendiente:true usuario:(.*) primero: (.*) tamanio: (.*)")]
        public void GivenEntradaPorTituloCuerpoFechaNullFiltroPDModTruePendienteTrueUsuarioPrimeroTamanio(string p0, string p1, int p2, int p3, int p4)
        {
            titulo = p0;
            cuerpo = p1;
            fecha = DateTime.Parse("31/02/2015");

            primero = p3;
            tamanio = p4;
        }
        
        [When(@"Filtro por entrada")]
        public void WhenFiltroPorEntrada()
        {
            entradas1=entrCEN.DameEntradasFiltro(titulo, cuerpo, fecha, true, true, us1, primero, tamanio);
            entradas2 = entrCEN.DameEntradasFiltro(titulo, cuerpo, fecha, true, true, us1, primero, tamanio);
        }
        
        [Then(@"devuelve resultado correcto")]
        public void ThenDevuelveResultadoCorrecto()
        {
            Assert.AreNotEqual(null, entradas1);
            Assert.AreNotEqual(entradas2, entradas1);

        }
        
        [Then(@"devuelve un error")]
        public void ThenDevuelveUnError()
        {
            Assert.AreEqual(null, entradas1);
        }
    }
}
