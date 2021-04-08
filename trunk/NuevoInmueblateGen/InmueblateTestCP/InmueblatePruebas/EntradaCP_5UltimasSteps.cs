using System;
using TechTalk.SpecFlow;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;
using NuevoInmueblateCP.InmueblateCP;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InmueblateTestCP.InmueblatePruebas
{
    [Binding]
    public class EntradaCP_5UltimasSteps
    {
        EntradaEN entrEN = new EntradaEN();
        static EntradaCEN entrCEN = new EntradaCEN();
        static MuroCEN murCEN = new MuroCEN();
        static UsuarioCEN usuCEN = new UsuarioCEN();
        EntradaCP entrCP= new EntradaCP();
        IList<EntradaEN> entrs;
        int id = 0;
        static int idUsu;
        static int idMuro;
        static int identr1;

        static int identr2;
        static int identr3;
        static int identr4;
        static int identr5;
        static int identr6;

        [BeforeFeature]
        static public void Creacion()
        {
            idMuro = murCEN.CrearMuro(false);
            idUsu = usuCEN.CrearUsuario(idMuro, "casa", "0369345", "esp@esesp.es", "a/ asdaa", "foto town", "555", "essp", "NuevoInmueblaa", 5,"a1","n1", DateTime.Today, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum.Publico);
           
            identr1 = entrCEN.CrearEntrada(DateTime.Today, "mientrada1", "asjkdasdfhasjfhsasj mi entrada1", false, idMuro, idUsu);
            identr2 = entrCEN.CrearEntrada(DateTime.Today, "mientrada2", "asjkdasdfhasjfhsasj mi entrada2", false, idMuro, idUsu);
            identr3 = entrCEN.CrearEntrada(DateTime.Today, "mientrada1", "asjkdasdfhasjfhsasj mi entrada3", false, idMuro, idUsu); 
            identr4 = entrCEN.CrearEntrada(DateTime.Today, "mientrada4", "asjkdasdfhasjfhsasj mi entrada4", false, idMuro, idUsu); 
            identr5 = entrCEN.CrearEntrada(DateTime.Today, "mientrada5", "asjkdasdfhasjfhsasj mi entrada5", false, idMuro, idUsu);
            identr6 = entrCEN.CrearEntrada(DateTime.Today, "mientrada6", "asjkdasdfhasjfhsasj mi entrada6", false, idMuro, idUsu);     

           
         }

        [AfterFeature]
        static public void Destruccion()
        {

            entrCEN.BorrarEntrada(identr1);
            entrCEN.BorrarEntrada(identr2);
            entrCEN.BorrarEntrada(identr3);
            entrCEN.BorrarEntrada(identr4);
            entrCEN.BorrarEntrada(identr5);
            entrCEN.BorrarEntrada(identr6);

            murCEN.BorrarMuro(idMuro);
            usuCEN.BorrarUsuario(idUsu);

        }
        [Given(@"Pides las entradas del usuario con id (.*)")]
        public void GivenPidesLasEntradasDelUsuarioConId(int p_id)
        {
            id = p_id;
        }
        
        [Given(@"Pides las entradas del usuario que no existe con id (.*)")]
        public void GivenPidesLasEntradasDelUsuarioQueNoExisteConId(Decimal p0)
        {
            id = 75757575;
        }
        
        [When(@"realizo la consulta")]
        public void WhenRealizoLaConsulta()
        {

           entrs=entrCP.ultimas5Entradas(id);
        
        }
        
        [Then(@"Se muestra bien")]
        public void ThenSeMuestraBien()
        {
            entrEN = entrCEN.DameEntradaPorOID(identr1);
            Assert.Equals(entrs.IndexOf(entrEN),entrEN);
        }
        
        [Then(@"Me informa del error")]
        public void ThenMeInformaDelError()
        {
            Assert.AreEqual(null, entrs);
              
        }
    }
}
