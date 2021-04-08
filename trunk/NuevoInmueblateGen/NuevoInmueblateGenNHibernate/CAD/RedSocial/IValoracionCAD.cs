
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial interface IValoracionCAD
{
ValoracionEN ReadOIDDefault (int id);

int CrearValoracion (ValoracionEN valoracion);

void ModificarValoracion (ValoracionEN valoracion);


void BorrarValoracion (int id);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> ObtenerValoracionPendienteModeracion ();


System.Collections.Generic.IList<ValoracionEN> DameTodasValoraciones (int first, int size);


ValoracionEN DameValoracionPorOID (int id);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> ObtenerValoracionesReceptor (int pe_receptor, int first, int size);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> ObtenerValoracionesEmisor (int pe_emisor, int first, int size);


NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN ObtenerValoracionDeA (int pe_emisor, int pe_receptor);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> ObtenerValoracionesEmisorNP (int pe_emisor);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ValoracionEN> ObtenerValoracionesReceptorNP (int pe_receptor);
}
}
