
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
public partial class InmobiliariaCEN
{
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmobiliariaEN> DameInmobiliariaFiltro (string p_cif, string p_nombre, string p_descripcion, string p_email, string p_direccion, string p_poblacion, int first, int size)
{
        /*PROTECTED REGION ID(NuevoInmueblateGenNHibernate.CEN.RedSocial_Inmobiliaria_dameInmobiliariaFiltro_customized) ENABLED START*/

        p_cif = '%' + p_cif + '%';
        p_nombre = '%' + p_nombre + '%';
        p_descripcion = '%' + p_descripcion + '%';
        p_email = '%' + p_email + '%';
        p_direccion = '%' + p_direccion + '%';
        p_poblacion = '%' + p_poblacion + '%';

        return _IInmobiliariaCAD.DameInmobiliariaFiltro (p_cif, p_nombre, p_descripcion, p_email, p_direccion, p_poblacion, first, size);
        /*PROTECTED REGION END*/
}
}
}
