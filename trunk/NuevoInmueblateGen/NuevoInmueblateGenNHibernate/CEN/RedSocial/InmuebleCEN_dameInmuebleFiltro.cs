
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
public partial class InmuebleCEN
{
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN> DameInmuebleFiltro (int p_inmobiliaria, string p_descripcion, int p_tipo, int p_metrosCuadrados, int p_precio, string p_direccion, string p_poblacion, int first, int size)
{
        /*PROTECTED REGION ID(NuevoInmueblateGenNHibernate.CEN.RedSocial_Inmueble_dameInmuebleFiltro_customized) ENABLED START*/

        p_descripcion = '%' + p_descripcion + '%';
        p_direccion = '%' + p_direccion + '%';
        p_poblacion = '%' + p_poblacion + '%';

        return _IInmuebleCAD.DameInmuebleFiltro (p_inmobiliaria, p_descripcion, p_tipo, p_metrosCuadrados, p_precio, p_direccion, p_poblacion, first, size);
        /*PROTECTED REGION END*/
}
}
}
