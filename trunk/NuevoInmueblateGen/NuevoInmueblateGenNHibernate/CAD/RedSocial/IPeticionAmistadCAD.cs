
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial interface IPeticionAmistadCAD
{
PeticionAmistadEN ReadOIDDefault (int id);

int CrearPeticionAmistad (PeticionAmistadEN peticionAmistad);

void ModificarPeticionAmistad (PeticionAmistadEN peticionAmistad);


void BorrarPeticionAmistad (int id);




PeticionAmistadEN DamePeticionAmistadPorOID (int id);


System.Collections.Generic.IList<PeticionAmistadEN> DameTodasLasPeticionAmistad (int first, int size);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> DamePeticionPorEmisor (int pe_emisor, int first, int size);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> DamePeticionPorReceptor (int pe_receptor, int first, int size);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> ObtenerPeticionesAmistadEstado (int pe_receptor, int pe_estado, int first, int size);


NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN DamePeticionDePara (int pe_emisor, int pe_receptor);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.PeticionAmistadEN> ObtenerPeticionesAmisitadEstadoEmisor (int pe_emisor, int pe_estado, int first, int size);
}
}
