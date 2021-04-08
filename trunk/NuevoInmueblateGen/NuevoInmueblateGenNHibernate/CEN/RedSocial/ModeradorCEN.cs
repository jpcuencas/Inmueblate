

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
/*
 *      Definition of the class ModeradorCEN
 *
 */
public partial class ModeradorCEN
{
private IModeradorCAD _IModeradorCAD;

public ModeradorCEN()
{
        this._IModeradorCAD = new ModeradorCAD ();
}

public ModeradorCEN(IModeradorCAD _IModeradorCAD)
{
        this._IModeradorCAD = _IModeradorCAD;
}

public IModeradorCAD get_IModeradorCAD ()
{
        return this._IModeradorCAD;
}

public int CrearModerador (int p_muro, string p_nombre, string p_telefono, string p_email, string p_direccion, string p_poblacion, string p_codigoPostal, string p_pais, String p_password, float p_valoracionMedia, string p_apellidos, string p_nif, Nullable<DateTime> p_fechaNacimiento, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum p_privacidad)
{
        ModeradorEN moderadorEN = null;
        int oid;

        //Initialized ModeradorEN
        moderadorEN = new ModeradorEN ();

        if (p_muro != -1) {
                // El argumento p_muro -> Property muro es oid = false
                // Lista de oids id
                moderadorEN.Muro = new NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN ();
                moderadorEN.Muro.Id = p_muro;
        }

        moderadorEN.Nombre = p_nombre;

        moderadorEN.Telefono = p_telefono;

        moderadorEN.Email = p_email;

        moderadorEN.Direccion = p_direccion;

        moderadorEN.Poblacion = p_poblacion;

        moderadorEN.CodigoPostal = p_codigoPostal;

        moderadorEN.Pais = p_pais;

        moderadorEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        moderadorEN.ValoracionMedia = p_valoracionMedia;

        moderadorEN.Apellidos = p_apellidos;

        moderadorEN.Nif = p_nif;

        moderadorEN.FechaNacimiento = p_fechaNacimiento;

        moderadorEN.Privacidad = p_privacidad;

        //Call to ModeradorCAD

        oid = _IModeradorCAD.CrearModerador (moderadorEN);
        return oid;
}

public void ModificarModerador (int p_Moderador_OID, string p_nombre, string p_telefono, string p_email, string p_direccion, string p_poblacion, string p_codigoPostal, string p_pais, String p_password, float p_valoracionMedia, string p_apellidos, string p_nif, Nullable<DateTime> p_fechaNacimiento, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum p_privacidad)
{
        ModeradorEN moderadorEN = null;

        //Initialized ModeradorEN
        moderadorEN = new ModeradorEN ();
        moderadorEN.Id = p_Moderador_OID;
        moderadorEN.Nombre = p_nombre;
        moderadorEN.Telefono = p_telefono;
        moderadorEN.Email = p_email;
        moderadorEN.Direccion = p_direccion;
        moderadorEN.Poblacion = p_poblacion;
        moderadorEN.CodigoPostal = p_codigoPostal;
        moderadorEN.Pais = p_pais;
        moderadorEN.Password = Utils.Util.GetEncondeMD5 (p_password);
        moderadorEN.ValoracionMedia = p_valoracionMedia;
        moderadorEN.Apellidos = p_apellidos;
        moderadorEN.Nif = p_nif;
        moderadorEN.FechaNacimiento = p_fechaNacimiento;
        moderadorEN.Privacidad = p_privacidad;
        //Call to ModeradorCAD

        _IModeradorCAD.ModificarModerador (moderadorEN);
}

public void BorrarModerador (int id)
{
        _IModeradorCAD.BorrarModerador (id);
}
}
}
