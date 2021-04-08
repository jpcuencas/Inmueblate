
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
public int CrearMensajeDeModerador (int p_emisor, int p_receptor, bool p_pendienteModeracion, Nullable<DateTime> p_fechaEnvio, string p_asunto, string p_mensaje, bool p_leido)
{
        /*PROTECTED REGION ID(NuevoInmueblateGenNHibernate.CEN.RedSocial_Mensaje_crearMensajeDeModerador_customized) ENABLED START*/

        MensajeEN mensajeEN = null;

        int oid;

        //Initialized MensajeEN
        mensajeEN = new MensajeEN ();

        if (p_emisor != -1) {
                mensajeEN.Emisor = new NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN ();
                mensajeEN.Emisor.Id = p_emisor;
        }


        if (p_receptor != -1) {
                mensajeEN.Receptor = new NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN ();
                mensajeEN.Receptor.Id = p_receptor;
        }

        mensajeEN.PendienteModeracion = p_pendienteModeracion;

        mensajeEN.FechaEnvio = p_fechaEnvio;

        mensajeEN.Asunto = p_asunto;

        mensajeEN.Cuerpo = p_mensaje;

        mensajeEN.Leido = p_leido;

        //Call to MensajeCAD

        oid = _IMensajeCAD.CrearMensajeDeModerador (mensajeEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
