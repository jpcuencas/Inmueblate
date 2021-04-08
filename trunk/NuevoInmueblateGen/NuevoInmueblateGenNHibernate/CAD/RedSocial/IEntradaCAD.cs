
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial interface IEntradaCAD
{
EntradaEN ReadOIDDefault (int id);

int CrearEntrada (EntradaEN entrada);

void ModificarEntrada (EntradaEN entrada);


void BorrarEntrada (int id);


void AnyadirElementosMultimedia (int p_entrada, System.Collections.Generic.IList<int> p_elementomultimedia);

void BorrarElementosMultimedia (int p_entrada, System.Collections.Generic.IList<int> p_elementomultimedia);

void AnyadirReportador (int p_entrada, System.Collections.Generic.IList<int> p_superusuario);

void AnyadirUsuariosMeGusta (int p_entrada, System.Collections.Generic.IList<int> p_superusuario);

System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> ObtenerEntradasPorModerar (string p_filter);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> ObtenerEntradasPorMuro (int p_muro, int first, int size);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> ObtenerEntradasPendientesPorGrupo (int pe_ID);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> ObtenerEntradasPendientesPorUsuario (int pe_ID);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> DameEntradasFiltroConModeracion (string p_titulo, string p_cuerpo, Nullable<DateTime> p_fechaPublicacion, bool p_pendienteModeracion, int p_usuario, int first, int size);


System.Collections.Generic.IList<EntradaEN> DameTodasLasEntradas (int first, int size);


EntradaEN DameEntradaPorOID (int id);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> DameEntradasFiltroSinModeracion (string p_titulo, string p_cuerpo, Nullable<DateTime> p_fechaPublicacion, int p_usuario, int first, int size);



System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN> DameEntradasPorMuro (int p_muro, int first, int size);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> ObtenerElementosMultimedia (int pe_entrada);
}
}
