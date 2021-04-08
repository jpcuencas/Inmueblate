

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
public class CaracteristicaCADNav : CaracteristicaCAD
{
public CaracteristicaCADNav() : base ()
{
}

public CaracteristicaCADNav(ISession sessionAux) : base (sessionAux)
{
}
}
}
