
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial interface IComentarioCAD
{
ComentarioEN ReadOIDDefault (int id);

int CrearComentario (ComentarioEN comentario);

void ModificarComentario (ComentarioEN comentario);


void BorrarComentario (int id);


void AnyadirElementosMultimedia (int p_comentario, System.Collections.Generic.IList<int> p_elementomultimedia);

void BorrarElementosMultimedia (int p_comentario, System.Collections.Generic.IList<int> p_elementomultimedia);

void AnyadirReportador (int p_comentario, System.Collections.Generic.IList<int> p_superusuario);

void BorrarReportadores (int p_comentario, System.Collections.Generic.IList<int> p_superusuario);

System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> ObtenerComentarioPendienteModeracion ();


ComentarioEN DameComentarioPorOID (int id);


System.Collections.Generic.IList<ComentarioEN> DameTodosLosComentarios (int first, int size);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ComentarioEN> ObtenerComentariosPorEntrada (int p_entrada);
}
}
