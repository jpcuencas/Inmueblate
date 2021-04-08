
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial interface IInmobiliariaCAD
{
System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PaginaCorporativaEN>         GetAllPaginaCorporativaOfInmobiliaria_NuevoInmueblate (int id);

System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN>    GetAllEventosOfInmobiliaria_NuevoInmueblate (int id);

System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN>  GetAllInmueblesOfInmobiliaria_NuevoInmueblate (int id);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN> GetAllInmobiliaria_NuevoInmueblate ();
}
}
