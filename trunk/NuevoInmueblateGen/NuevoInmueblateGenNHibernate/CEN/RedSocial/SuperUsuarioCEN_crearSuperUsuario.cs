
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
public int CrearSuperUsuario (int p_muro, string p_nombre, string p_telefono, string p_email, string p_direccion, string p_poblacion, string p_codigoPostal, string p_pais, String p_password, float p_valoracionMedia)
{
        /*PROTECTED REGION ID(NuevoInmueblateGenNHibernate.CEN.RedSocial_SuperUsuario_crearSuperUsuario_customized) START*/

        SuperUsuarioEN superUsuarioEN = null;

        int oid;

        //Initialized SuperUsuarioEN
        superUsuarioEN = new SuperUsuarioEN ();

        if (p_muro != -1) {
                superUsuarioEN.Muro = new NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN ();
                superUsuarioEN.Muro.Id = p_muro;
        }

        superUsuarioEN.Nombre = p_nombre;

        superUsuarioEN.Telefono = p_telefono;

        superUsuarioEN.Email = p_email;

        superUsuarioEN.Direccion = p_direccion;

        superUsuarioEN.Poblacion = p_poblacion;

        superUsuarioEN.CodigoPostal = p_codigoPostal;

        superUsuarioEN.Pais = p_pais;

        superUsuarioEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        superUsuarioEN.ValoracionMedia = p_valoracionMedia;

        //Call to SuperUsuarioCAD

        oid = _ISuperUsuarioCAD.CrearSuperUsuario (superUsuarioEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
