
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
public partial class UsuarioCEN
{
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> DameUsuariosFiltro (string p_nif, string p_email, string p_apellidos, Nullable<DateTime> p_fechaNacimiento, string p_direccion, string p_poblacion, int first, int size)
{
        /*PROTECTED REGION ID(NuevoInmueblateGenNHibernate.CEN.RedSocial_Usuario_dameUsuariosFiltro_customized) ENABLED START*/
        p_nif = '%' + p_nif + '%';
        p_email = '%' + p_email + '%';
        p_apellidos = '%' + p_apellidos + '%';
        p_direccion = '%' + p_direccion + '%';
        p_poblacion = '%' + p_poblacion + '%';

        return _IUsuarioCAD.DameUsuariosFiltro (p_nif, p_email, p_apellidos, p_fechaNacimiento, p_direccion, p_poblacion, first, size);
        /*PROTECTED REGION END*/
}
}
}
