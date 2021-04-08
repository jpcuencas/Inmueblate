
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
public partial class AnuncioCEN
{
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.AnuncioEN> DameAnunciosFiltro (int p_tipo, Nullable<DateTime> p_fechaCaducidad, string p_url, string p_descripcion, int first, int size)
{
        /*PROTECTED REGION ID(NuevoInmueblateGenNHibernate.CEN.RedSocial_Anuncio_dameAnunciosFiltro_customized) ENABLED START*/
        p_url = '%' + p_url + '%';
        p_descripcion = '%' + p_descripcion + '%';
        return _IAnuncioCAD.DameAnunciosFiltro (p_tipo, p_fechaCaducidad, p_url, p_descripcion, first, size);
        /*PROTECTED REGION END*/
}
}
}
