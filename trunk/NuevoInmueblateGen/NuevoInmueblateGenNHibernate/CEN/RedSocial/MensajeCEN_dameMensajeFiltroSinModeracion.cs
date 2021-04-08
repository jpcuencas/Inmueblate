
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
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> DameMensajeFiltroSinModeracion (string p_asunto, string p_cuerpo, Nullable<DateTime> p_fechaEnvio, int first, int size)
{
        /*PROTECTED REGION ID(NuevoInmueblateGenNHibernate.CEN.RedSocial_Mensaje_dameMensajeFiltroSinModeracion_customized) START*/

        return _IMensajeCAD.DameMensajeFiltroSinModeracion (p_asunto, p_cuerpo, p_fechaEnvio, first, size);
        /*PROTECTED REGION END*/
}
}
}
