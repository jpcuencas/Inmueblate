
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial interface IFotografiaCAD
{
FotografiaEN ReadOIDDefault (int id);

int CrearFotografia (FotografiaEN fotografia);

void ModificarFotografia (FotografiaEN fotografia);


void BorrarFotografia (int id);



System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN> ObtenerTodasFotografiasPorModerar ();


FotografiaEN DameFotografiaPorOID (int id);


System.Collections.Generic.IList<FotografiaEN> DameTodasLasFotografias (int first, int size);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN> ObtenerFotografiasPorUsuario (int pe_usuario, int first, int size);


NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN ObtenerFotoPerfil (int pe_usuario);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.FotografiaEN> ObtenerFotosPorGaleria (int pe_galeria, int first, int size);
}
}
