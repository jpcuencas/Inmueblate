

using System;
using System.Text;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGenNHibernate.CAD.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.CAD.RedSocial
{
public class ValoracionCADNav : ValoracionCAD
{
public ValoracionCADNav() : base ()
{
}

public ValoracionCADNav(ISession sessionAux) : base (sessionAux)
{
}
}
}
