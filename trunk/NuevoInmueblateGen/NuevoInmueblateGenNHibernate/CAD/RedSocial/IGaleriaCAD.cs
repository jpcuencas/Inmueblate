
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial interface IGaleriaCAD
{
GaleriaEN ReadOIDDefault (int id);

int CrearGaleria (GaleriaEN galeria);

void ModificarGaleria (GaleriaEN galeria);


void BorrarGaleria (int id);


void AnyadirElementoMultimedia (int p_Galeria_OID, System.Collections.Generic.IList<int> p_elementosMultimedia_OIDs);

void BorrarElementoMultimedia (int p_Galeria_OID, System.Collections.Generic.IList<int> p_elementosMultimedia_OIDs);

GaleriaEN DameGaleriaPorOID (int id);


System.Collections.Generic.IList<GaleriaEN> DameTodasLasGalerias (int first, int size);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN> ObtenerGaleriasPorUsuario (int pe_usuario, int first, int size);


NuevoInmueblateGenNHibernate.EN.RedSocial.GaleriaEN ObtenerGaleriaPerfil (int pe_usuario);
}
}
