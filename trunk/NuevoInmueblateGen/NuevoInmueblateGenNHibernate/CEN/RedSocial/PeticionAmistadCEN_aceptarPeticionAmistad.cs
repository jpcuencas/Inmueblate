
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGenNHibernate.CAD.RedSocial;

namespace NuevoInmueblateGenNHibernate.CEN.RedSocial
{
public partial class PeticionAmistadCEN
{
public void AceptarPeticionAmistad (int p_oid)
{
        /*PROTECTED REGION ID(NuevoInmueblateGenNHibernate.CEN.RedSocial_PeticionAmistad_aceptarPeticionAmistad) ENABLED START*/
        PeticionAmistadCEN petCEN = new PeticionAmistadCEN ();

        PeticionAmistadEN peticion = petCEN.DamePeticionAmistadPorOID (p_oid);

        peticion.Estado = Enumerated.RedSocial.EstadoSolicitudAmistadEnum.aceptada;
        if (peticion.Estado != Enumerated.RedSocial.EstadoSolicitudAmistadEnum.aceptada)
                throw new NuevoInmueblateGenNHibernate.Exceptions.ModelException ("No se cumple postcondicion de cambio de estado");

        petCEN.ModificarPeticionAmistad (peticion.Id, peticion.Asunto, peticion.Cuerpo, peticion.Estado);

        /*PROTECTED REGION END*/
}
}
}
