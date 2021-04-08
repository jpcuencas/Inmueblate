
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
public partial class MensajeCEN
{
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> DameMensajeFiltro (string p_asunto, string p_cuerpo, Nullable<DateTime> p_fechaEnvio, bool p_filtrarPendienteModeracion, bool p_pendienteModeracion, int p_emisor, int p_receptor, int first, int size)
{
        /*PROTECTED REGION ID(NuevoInmueblateGenNHibernate.CEN.RedSocial_Mensaje_dameMensajeFiltro) ENABLED START*/

        p_asunto = '%' + p_asunto + '%';
        p_cuerpo = '%' + p_cuerpo + '%';

        if (p_filtrarPendienteModeracion) {
                return DameMensajeFiltroConModeracion (p_asunto, p_cuerpo, p_fechaEnvio, p_pendienteModeracion, p_emisor, p_receptor, first, size);
        }
        else{
                return DameMensajeFiltroSinModeracion (p_asunto, p_cuerpo, p_fechaEnvio, p_emisor, p_receptor, first, size);
        }

        /*PROTECTED REGION END*/
}
}
}
