
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
public partial class EntradaCEN
{
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> DameEntradasFiltro (string p_titulo, string p_cuerpo, Nullable<DateTime> p_fechaPublicacion, bool p_filtrarPendienteModeracion, bool p_pendienteModeracion, int p_usuario, int first, int size)
{
        /*PROTECTED REGION ID(NuevoInmueblateGenNHibernate.CEN.RedSocial_Entrada_dameEntradasFiltro) ENABLED START*/

        // Write here your custom code...
        p_titulo = '%' + p_titulo + '%';
        p_cuerpo = '%' + p_cuerpo + '%';

        if (p_filtrarPendienteModeracion) {
                return DameEntradasFiltroConModeracion (p_titulo, p_cuerpo, p_fechaPublicacion, p_pendienteModeracion, p_usuario, first, size);
        }
        else{
                return DameEntradasFiltroSinModeracion (p_titulo, p_cuerpo, p_fechaPublicacion, p_usuario, first, size);
        }

        /*PROTECTED REGION END*/
}
}
}
