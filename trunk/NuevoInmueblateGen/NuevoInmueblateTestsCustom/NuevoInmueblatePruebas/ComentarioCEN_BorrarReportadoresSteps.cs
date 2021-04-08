using System;
using TechTalk.SpecFlow;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;
using System.Collections.Generic;

namespace NuevoInmueblateTestsCustom
{
    [Binding]
    public class ComentarioCEN_BorrarReportadoresSteps
    {
        static MuroCEN muroCEN = new MuroCEN();
        static EntradaCEN entrCEN = new EntradaCEN();
        static UsuarioCEN usuCEN = new UsuarioCEN();
        static ComentarioCEN comCEN = new ComentarioCEN();
        static int us1, us2, us3, us4, us5;
        static int muroid;
        static int entrid;
        static int comid;
        List<int> usuarios = new List<int>();

        [BeforeFeature]
        static public void Creacion()
        {
            us1 = usuCEN.CrearUsuario(1, "jose 1", "97866634",
               "jos555e@inm.es",
               "Jos55e1", "85587868865", "eljo55se1@inm.es", "calle 1",
               "mi pueblo", 5, "españa", "1234", DateTime.Parse("26/11/1987"), NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Publico);
            us2 = usuCEN.CrearUsuario(1, "jose 1", "97866634",
               "jose@55inm.es",
               "Jo55se1", "88785568865", "eljose1@inm.es", "calle 1",
               "mi pueblo", 5, "españa", "1234", DateTime.Parse("26/11/1987"), NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Publico);
            us3 = usuCEN.CrearUsuario(1, "jose 1", "97866634",
               "jose55@inm.es",
               "Jos55e1", "5555", "eljose1@inm.es", "calle 1",
               "mi pueblo", 5, "españa", "1234", DateTime.Parse("26/11/1987"), NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Publico);
            us4 = usuCEN.CrearUsuario(1, "jose 1", "97866634",
               "jose@inm.es",
               "Jose1", "887868865", "eljose1@inm.es", "calle 1",
               "mi pueblo", 5, "españa", "1234", DateTime.Parse("26/11/1987"), NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Publico);
            us5 = usuCEN.CrearUsuario(1, "jose 1", "9786556634",
               "jose@inm.es",
               "Jos5555e1", "887868865", "eljo55se1@inm.es", "calle 1",
               "mi pueblo", 5, "españa", "1234", DateTime.Parse("26/11/1987"), NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Publico);
            
            muroid = muroCEN.CrearMuro(true);
            entrid = entrCEN.CrearEntrada(DateTime.Today, "mi titulo", "esto es el cuerpo", true, muroid, us5);
            comid = comCEN.CrearComentario("esto es un comentario", false, DateTime.Today, us5, entrid);

        }

        [AfterFeature]
        static public void Destruccion()
        {
            comCEN.BorrarComentario(comid);
            muroCEN.BorrarMuro(muroid);
            entrCEN.BorrarEntrada(entrid);
            usuCEN.BorrarUsuario(us1);
            usuCEN.BorrarUsuario(us2);
            usuCEN.BorrarUsuario(us3);
            usuCEN.BorrarUsuario(us4);
            usuCEN.BorrarUsuario(us5);
        }
        [Given(@"ids usuario id: (.*) id: (.*) id: (.*) id: (.*)")]
        public void GivenIdsUsuarioIdIdIdId(int p0, int p1, int p2, int p3)
        {
            usuarios.Add(us1);
            usuarios.Add(us2);
            usuarios.Add(us3);
            usuarios.Add(us4);
            usuarios.Add(us5);
        }
        
        [Given(@"ids usuario id: (.*) id: null id: (.*) id: (.*)")]
        public void GivenIdsUsuarioIdIdNullIdId(int p0, int p1, int p2)
        {
            usuarios.Add(us1);
            usuarios.Add(us2);
            usuarios.Add(0);
            usuarios.Add(us4);
            usuarios.Add(us5);
        }
        
        [When(@"Borra los repotadores")]
        public void WhenBorraLosRepotadores()
        {
            comCEN.BorrarReportadores(comid, usuarios);
        }
        
        [Then(@"guardan correctamente")]
        public void ThenGuardanCorrectamente()
        {
            

        }
    }
}
