
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGenNHibernate.CAD.RedSocial;

namespace NuevoInmueblateGenNHibernate.CEN.RedSocial
{
public partial class EntradaCEN
{
public void AnyadirUsuariosMeGusta (int p_entrada, System.Collections.Generic.IList<int> p_superusuario)
{
        /*PROTECTED REGION ID(NuevoInmueblateGenNHibernate.CEN.RedSocial_Entrada_anyadirUsuariosMeGusta_customized) ENABLED START*/


        SuperUsuarioCEN superUsuarioCEN = new SuperUsuarioCEN ();
        SuperUsuarioEN usuario = superUsuarioCEN.get_ISuperUsuarioCAD ().ReadOIDDefault (p_superusuario [0]);
        EntradaEN entrada = _IEntradaCAD.ReadOIDDefault (p_entrada);

        if (!entrada.UsuariosMeGusta.Contains (usuario)) {
                _IEntradaCAD.AnyadirUsuariosMeGusta (p_entrada, p_superusuario);
        }

        /*PROTECTED REGION END*/
}
}
}
