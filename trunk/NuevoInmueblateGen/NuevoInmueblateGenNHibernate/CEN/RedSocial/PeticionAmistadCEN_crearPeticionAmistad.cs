
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
public int CrearPeticionAmistad (string p_asunto, string p_cuerpo, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.EstadoSolicitudAmistadEnum p_estado, int p_emisor, int p_receptor)
{
        /*PROTECTED REGION ID(NuevoInmueblateGenNHibernate.CEN.RedSocial_PeticionAmistad_crearPeticionAmistad_customized) ENABLED START*/

        UsuarioCEN usuCEN = new UsuarioCEN ();
        PeticionAmistadEN peticionAmistadEN = null;
        int oid;

        if (p_emisor != p_receptor) {
                //Initialized PeticionAmistadEN
                peticionAmistadEN = new PeticionAmistadEN ();
                peticionAmistadEN.Asunto = p_asunto;

                peticionAmistadEN.Cuerpo = p_cuerpo;

                peticionAmistadEN.Estado = p_estado;

                if (p_emisor != -1) {
                        peticionAmistadEN.Emisor = new NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN ();
                        peticionAmistadEN.Emisor.Id = p_emisor;
                }


                if (p_receptor != -1) {
                        peticionAmistadEN.Receptor = new NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN ();
                        peticionAmistadEN.Receptor.Id = p_receptor;
                }

                //Call to PeticionAmistadCAD

                oid = _IPeticionAmistadCAD.CrearPeticionAmistad (peticionAmistadEN);
        }
        else{
                oid = -1;
        }
        return oid;
        /*PROTECTED REGION END*/
}
}
}
