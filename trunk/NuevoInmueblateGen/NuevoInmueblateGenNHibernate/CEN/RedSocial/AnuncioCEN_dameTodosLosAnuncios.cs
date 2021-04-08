
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
public System.Collections.Generic.IList<AnuncioEN> DameTodosLosAnuncios (int first, int size)
{
        /*PROTECTED REGION ID(NuevoInmueblateGenNHibernate.CEN.RedSocial_Anuncio_dameTodosLosAnuncios_customized) START*/

        System.Collections.Generic.IList<AnuncioEN> list = null;

        list = _IAnuncioCAD.DameTodosLosAnuncios (first, size);
        return list;
        /*PROTECTED REGION END*/
}
}
}
