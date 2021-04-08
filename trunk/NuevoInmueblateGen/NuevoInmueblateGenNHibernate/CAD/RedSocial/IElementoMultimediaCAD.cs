
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial interface IElementoMultimediaCAD
{
ElementoMultimediaEN ReadOIDDefault (int id);

int CrearElementoMultimedia (ElementoMultimediaEN elementoMultimedia);

void ModificarElementoMultimedia (ElementoMultimediaEN elementoMultimedia);


void BorrarElementoMultimedia (int id);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> ObtenerElementoPendienteModeracion ();


ElementoMultimediaEN DameElementoMultimediaPorOID (int id);


System.Collections.Generic.IList<ElementoMultimediaEN> DameTodosLosElementosMultimedia (int first, int size);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN> ObtenerElementosMultimediaPorUsuario (int pe_usuario, int first, int size);


void AnyadirUsuario (int p_ElementoMultimedia_OID, int p_usuario_OID);

void EliminarUsuario (int p_ElementoMultimedia_OID, int p_usuario_OID);

System.Collections.Generic.IList<ElementoMultimediaEN> DameTodosElementosMultimediaP (int first, int size);
}
}
