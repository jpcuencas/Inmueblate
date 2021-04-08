

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
public class ElementoMultimediaCADNav : ElementoMultimediaCAD
{
public ElementoMultimediaCADNav() : base ()
{
}

public ElementoMultimediaCADNav(ISession sessionAux) : base (sessionAux)
{
}
}
}
