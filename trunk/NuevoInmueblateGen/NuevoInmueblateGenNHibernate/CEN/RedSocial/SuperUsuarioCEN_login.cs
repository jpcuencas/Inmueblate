
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
public partial class SuperUsuarioCEN
{
public NuevoInmueblateGenNHibernate.Enumerated.RedSocial.EstadoLoginEnum Login (int p_oid, string p_email, string p_pass)
{
        /*PROTECTED REGION ID(NuevoInmueblateGenNHibernate.CEN.RedSocial_SuperUsuario_login) ENABLED START*/

        /*
         *  Funcion revisada
         */
        //try
        //{
        Enumerated.RedSocial.EstadoLoginEnum result = Enumerated.RedSocial.EstadoLoginEnum.NoLogeado;

        SuperUsuarioCEN supCEN = new SuperUsuarioCEN ();
        // Type t;
        //SuperUsuarioEN usuario = _ISuperUsuarioCAD.ReadOIDDefault (p_oid);
        SuperUsuarioEN usuario = supCEN.ObtenerUsuarioPorEmail (p_email);
        if (usuario == null) {
                return Enumerated.RedSocial.EstadoLoginEnum.NoLogeado;
        }

        if (p_email == "" || p_pass == "") {
                return Enumerated.RedSocial.EstadoLoginEnum.NoLogeado;
        }

        if (usuario.Password.Equals (Utils.Util.GetEncondeMD5 (p_pass))) {
                switch (usuario.GetType ().Name) {
                case "UsuarioEN": result = Enumerated.RedSocial.EstadoLoginEnum.Usuario; break;

                case "ModeradorEN": result = Enumerated.RedSocial.EstadoLoginEnum.Moderador; break;

                case "InmobiliariaEN": result = Enumerated.RedSocial.EstadoLoginEnum.Inmobiliaria; break;

                default: result = Enumerated.RedSocial.EstadoLoginEnum.NoLogeado; break;
                }
        }

        return result;

        /*PROTECTED REGION END*/
}
}
}
