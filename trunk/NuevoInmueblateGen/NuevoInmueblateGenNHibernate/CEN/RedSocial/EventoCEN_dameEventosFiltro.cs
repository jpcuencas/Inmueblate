
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
public partial class EventoCEN
{
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EventoEN> DameEventosFiltro (string p_nombre, string p_descripcion, Nullable<DateTime> p_fecha, int p_categoria, int first, int size)
{
        /*PROTECTED REGION ID(NuevoInmueblateGenNHibernate.CEN.RedSocial_Evento_dameEventosFiltro_customized) ENABLED START*/
        p_nombre = '%' + p_nombre + '%';
        p_descripcion = '%' + p_descripcion + '%';

        return _IEventoCAD.DameEventosFiltro (p_nombre, p_descripcion, p_fecha, p_categoria, first, size);
        /*PROTECTED REGION END*/
}
}
}
