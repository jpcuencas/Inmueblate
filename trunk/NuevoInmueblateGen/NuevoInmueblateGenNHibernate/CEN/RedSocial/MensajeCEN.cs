

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
/*
 *      Definition of the class MensajeCEN
 *
 */
public partial class MensajeCEN
{
private IMensajeCAD _IMensajeCAD;

public MensajeCEN()
{
        this._IMensajeCAD = new MensajeCAD ();
}

public MensajeCEN(IMensajeCAD _IMensajeCAD)
{
        this._IMensajeCAD = _IMensajeCAD;
}

public IMensajeCAD get_IMensajeCAD ()
{
        return this._IMensajeCAD;
}

public void ModificarMensaje (int p_oid, bool p_pendienteModeracion, Nullable<DateTime> p_fechaEnvio, string p_asunto, string p_cuerpo, bool p_leido)
{
        MensajeEN mensajeEN = null;

        //Initialized MensajeEN
        mensajeEN = new MensajeEN ();
        mensajeEN.Id = p_oid;
        mensajeEN.PendienteModeracion = p_pendienteModeracion;
        mensajeEN.FechaEnvio = p_fechaEnvio;
        mensajeEN.Asunto = p_asunto;
        mensajeEN.Cuerpo = p_cuerpo;
        mensajeEN.Leido = p_leido;
        //Call to MensajeCAD

        _IMensajeCAD.ModificarMensaje (mensajeEN);
}

public void BorrarMensaje (int id)
{
        _IMensajeCAD.BorrarMensaje (id);
}

public void AnyadirElementosMultimedia (int p_mensaje, System.Collections.Generic.IList<int> p_elementomultimedia)
{
        //Call to MensajeCAD

        _IMensajeCAD.AnyadirElementosMultimedia (p_mensaje, p_elementomultimedia);
}
public void BorrarElementosMultimedia (int p_mensaje, System.Collections.Generic.IList<int> p_elementomultimedia)
{
        //Call to MensajeCAD

        _IMensajeCAD.BorrarElementosMultimedia (p_mensaje, p_elementomultimedia);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> ObtenerMensajePendienteModeracion ()
{
        return _IMensajeCAD.ObtenerMensajePendienteModeracion ();
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> ObtenerMensajesPorUsuario (int p_idUsuario, int first, int size)
{
        return _IMensajeCAD.ObtenerMensajesPorUsuario (p_idUsuario, first, size);
}
public System.Collections.Generic.IList<MensajeEN> DameTodosLosMensajes (int first, int size)
{
        System.Collections.Generic.IList<MensajeEN> list = null;

        list = _IMensajeCAD.DameTodosLosMensajes (first, size);
        return list;
}
public MensajeEN DameMensajePorOID (int id)
{
        MensajeEN mensajeEN = null;

        mensajeEN = _IMensajeCAD.DameMensajePorOID (id);
        return mensajeEN;
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> DameMensajeFiltroConModeracion (string p_asunto, string p_cuerpo, Nullable<DateTime> p_fechaEnvio, bool p_pendienteModeracion, int p_emisor, int p_receptor, int first, int size)
{
        return _IMensajeCAD.DameMensajeFiltroConModeracion (p_asunto, p_cuerpo, p_fechaEnvio, p_pendienteModeracion, p_emisor, p_receptor, first, size);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> DameMensajeFiltroSinModeracion (string p_asunto, string p_cuerpo, Nullable<DateTime> p_fechaEnvio, int p_emisor, int p_receptor, int first, int size)
{
        return _IMensajeCAD.DameMensajeFiltroSinModeracion (p_asunto, p_cuerpo, p_fechaEnvio, p_emisor, p_receptor, first, size);
}
}
}
