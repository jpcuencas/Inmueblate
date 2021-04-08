
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial interface IMensajeCAD
{
MensajeEN ReadOIDDefault (int id);

int CrearMensaje (MensajeEN mensaje);

void ModificarMensaje (MensajeEN mensaje);


void BorrarMensaje (int id);


void AnyadirElementosMultimedia (int p_mensaje, System.Collections.Generic.IList<int> p_elementomultimedia);

void BorrarElementosMultimedia (int p_mensaje, System.Collections.Generic.IList<int> p_elementomultimedia);

System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> ObtenerMensajePendienteModeracion ();


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> ObtenerMensajesPorUsuario (int p_idUsuario, int first, int size);


System.Collections.Generic.IList<MensajeEN> DameTodosLosMensajes (int first, int size);


MensajeEN DameMensajePorOID (int id);



System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> DameMensajeFiltroConModeracion (string p_asunto, string p_cuerpo, Nullable<DateTime> p_fechaEnvio, bool p_pendienteModeracion, int p_emisor, int p_receptor, int first, int size);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.MensajeEN> DameMensajeFiltroSinModeracion (string p_asunto, string p_cuerpo, Nullable<DateTime> p_fechaEnvio, int p_emisor, int p_receptor, int first, int size);


int CrearMensajeDeModerador (MensajeEN mensaje);
}
}
