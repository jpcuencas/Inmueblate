

using System;
using System.Text;
using NuevoInmueblateGenNHibernate.CEN.RedSocial;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGenNHibernate.CAD.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateLocal.CAD.RedSocial
{
public class EntradaCADNav : EntradaCAD
{
public EntradaCADNav() : base ()
{
}

public EntradaCADNav(ISession sessionAux) : base (sessionAux)
{
}
}
}
