
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
public partial class HabitacionCEN
{
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN> DameHabitacionFiltro (string p_descripcion, int p_metrosCuadrados, string p_direccion, string p_poblacion, int p_inmueble, int first, int size)
{
        /*PROTECTED REGION ID(NuevoInmueblateGenNHibernate.CEN.RedSocial_Habitacion_dameHabitacionFiltro_customized) ENABLED START*/

        p_descripcion = '%' + p_descripcion + '%';
        p_direccion = '%' + p_direccion + '%';
        p_poblacion = '%' + p_poblacion + '%';

        return _IHabitacionCAD.DameHabitacionFiltro (p_descripcion, p_metrosCuadrados, p_direccion, p_poblacion, p_inmueble, first, size);
        /*PROTECTED REGION END*/
}
}
}
