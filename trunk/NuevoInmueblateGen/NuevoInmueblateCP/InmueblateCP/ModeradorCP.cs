using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;
using NuevoInmueblateGenNHibernate.CAD.RedSocial;
using NuevoInmueblateGenNHibernate.Enumerated.RedSocial;

namespace NuevoInmueblateCP.InmueblateCP
{
    public class ModeradorCP: BasicCP
    {
        public ModeradorCP() : base() { }

        public ModeradorCP(ISession sessionAux) : base(sessionAux) { }

        public void BorrarEntradaPendienteDeModerarcion(int p_entrada)
        {
            try
            {
                SessionInitializeTransaction();

                // codigo que va a atacar a la bd
                EntradaCEN entradaCEN = new EntradaCEN(new EntradaCAD(session));
                ComentarioCEN comentarioCEN=new ComentarioCEN(new ComentarioCAD(session));
                EntradaEN entr = entradaCEN.get_IEntradaCAD().ReadOIDDefault(p_entrada);
                
                for(int i=0; i<entr.Comentarios.Count;i++)
                {
                    comentarioCEN.BorrarComentario(entr.Comentarios[i].Id);
                }

                entradaCEN.BorrarEntrada(entr.Id);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                SessionClose();
            }
        }
    }
}
