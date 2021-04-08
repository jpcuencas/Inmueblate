
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
public partial class GrupoCEN
{
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GrupoEN> DameGruposFiltro (int p_tipo, string p_nombre, string p_descripcion, int first, int size)
{
        /*PROTECTED REGION ID(NuevoInmueblateGenNHibernate.CEN.RedSocial_Grupo_dameGruposFiltro_customized) ENABLED START*/

        p_nombre = '%' + p_nombre + '%';
        p_descripcion = '%' + p_descripcion + '%';

        return _IGrupoCAD.DameGruposFiltro (p_tipo, p_nombre, p_descripcion, first, size);
        /*PROTECTED REGION END*/
}
}
}
