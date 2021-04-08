
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
public partial class SuperUsuarioCEN
{
public void AnyadirEntradasReportadas (int p_SuperUsuario_OID, System.Collections.Generic.IList<int> p_entradasReportadas_OIDs)
{
        /*PROTECTED REGION ID(NuevoInmueblateGenNHibernate.CEN.RedSocial_SuperUsuario_anyadirEntradasReportadas_customized) START*/


        //Call to SuperUsuarioCAD

        _ISuperUsuarioCAD.AnyadirEntradasReportadas (p_SuperUsuario_OID, p_entradasReportadas_OIDs);

        /*PROTECTED REGION END*/
}
}
}
