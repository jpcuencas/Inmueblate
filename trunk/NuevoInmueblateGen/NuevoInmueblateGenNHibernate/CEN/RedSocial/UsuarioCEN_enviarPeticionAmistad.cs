
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
public partial class UsuarioCEN
{
public int EnviarPeticionAmistad (int pe_emisor, int pe_receptor, string pe_asunto, string pe_cuerpo)
{
        /*PROTECTED REGION ID(NuevoInmueblateGenNHibernate.CEN.RedSocial_Usuario_enviarPeticionAmistad) ENABLED START*/
        /*Codigos de error                          */
        /* 0 --> Existe peticion                    */
        /* -1 --> Ya esta en mi lista de amigos     */
        /* -2 --> Ya esta en mi lista de bloqueados */
        /* n --> Id de la peticion creada           */
        UsuarioCEN usuCEN = new UsuarioCEN ();
        PeticionAmistadCEN petCEN = new PeticionAmistadCEN ();
        PeticionAmistadEN petEN = petCEN.DamePeticionDePara (pe_emisor, pe_receptor);
        UsuarioEN emiEN = usuCEN.DameUsuarioPorOID (pe_emisor);

        System.Collections.Generic.IList<UsuarioEN> l_amigos = usuCEN.ObtenerAmigos (pe_receptor, 0, -1);
        System.Collections.Generic.IList<UsuarioEN> l_bloque = usuCEN.ObtenerBloqueadosSP (pe_receptor);

        if (petEN != null) return 0;

        if (l_amigos.Contains (emiEN)) return -1;

        if (l_bloque.Contains (emiEN)) return -2;

        return petCEN.CrearPeticionAmistad (pe_asunto, pe_cuerpo, Enumerated.RedSocial.EstadoSolicitudAmistadEnum.pendiente, pe_emisor, pe_receptor);


        /*PROTECTED REGION END*/
}
}
}
