
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial interface IAnuncioCAD
{
AnuncioEN ReadOIDDefault (int id);

int CrearAnuncio (AnuncioEN anuncio);

void ModificarAnuncio (AnuncioEN anuncio);


void BorrarAnuncio (int id);


System.Collections.Generic.IList<AnuncioEN> DameTodosLosAnuncios (int first, int size);


AnuncioEN DameAnuncioPorOID (int id);



System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.AnuncioEN> DameAnunciosFiltro (int p_tipo, Nullable<DateTime> p_fechaCaducidad, string p_url, string p_descripcion, int first, int size);
}
}
