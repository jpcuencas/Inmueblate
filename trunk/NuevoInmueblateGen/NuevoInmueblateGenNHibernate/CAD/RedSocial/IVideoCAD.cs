
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial interface IVideoCAD
{
VideoEN ReadOIDDefault (int id);

int CrearVideo (VideoEN video);

void ModificarVideo (VideoEN video);


void BorrarVideo (int id);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN> ObtenerTodosVideosPorModerar ();


VideoEN DameVideoPorOID (int id);


System.Collections.Generic.IList<VideoEN> DameTodosLosVideos (int first, int size);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN> ObtenerVideosPorUsuario (int pe_usuario, int first, int size);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.VideoEN> ObtenerVideosPorGaleria (int pe_galeria, int first, int size);
}
}
