

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
 *      Definition of the class UsuarioCEN
 *
 */
public partial class UsuarioCEN
{
private IUsuarioCAD _IUsuarioCAD;

public UsuarioCEN()
{
        this._IUsuarioCAD = new UsuarioCAD ();
}

public UsuarioCEN(IUsuarioCAD _IUsuarioCAD)
{
        this._IUsuarioCAD = _IUsuarioCAD;
}

public IUsuarioCAD get_IUsuarioCAD ()
{
        return this._IUsuarioCAD;
}

public int CrearUsuario (int p_muro, string p_nombre, string p_telefono, string p_email, string p_direccion, string p_poblacion, string p_codigoPostal, string p_pais, String p_password, float p_valoracionMedia, string p_apellidos, string p_nif, Nullable<DateTime> p_fechaNacimiento, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum p_privacidad)
{
        UsuarioEN usuarioEN = null;
        int oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();

        if (p_muro != -1) {
                // El argumento p_muro -> Property muro es oid = false
                // Lista de oids id
                usuarioEN.Muro = new NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN ();
                usuarioEN.Muro.Id = p_muro;
        }

        usuarioEN.Nombre = p_nombre;

        usuarioEN.Telefono = p_telefono;

        usuarioEN.Email = p_email;

        usuarioEN.Direccion = p_direccion;

        usuarioEN.Poblacion = p_poblacion;

        usuarioEN.CodigoPostal = p_codigoPostal;

        usuarioEN.Pais = p_pais;

        usuarioEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        usuarioEN.ValoracionMedia = p_valoracionMedia;

        usuarioEN.Apellidos = p_apellidos;

        usuarioEN.Nif = p_nif;

        usuarioEN.FechaNacimiento = p_fechaNacimiento;

        usuarioEN.Privacidad = p_privacidad;

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.CrearUsuario (usuarioEN);
        return oid;
}

public void ModificarUsuario (int p_Usuario_OID, string p_nombre, string p_telefono, string p_email, string p_direccion, string p_poblacion, string p_codigoPostal, string p_pais, String p_password, float p_valoracionMedia, string p_apellidos, string p_nif, Nullable<DateTime> p_fechaNacimiento, NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum p_privacidad)
{
        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Id = p_Usuario_OID;
        usuarioEN.Nombre = p_nombre;
        usuarioEN.Telefono = p_telefono;
        usuarioEN.Email = p_email;
        usuarioEN.Direccion = p_direccion;
        usuarioEN.Poblacion = p_poblacion;
        usuarioEN.CodigoPostal = p_codigoPostal;
        usuarioEN.Pais = p_pais;
        usuarioEN.Password = Utils.Util.GetEncondeMD5 (p_password);
        usuarioEN.ValoracionMedia = p_valoracionMedia;
        usuarioEN.Apellidos = p_apellidos;
        usuarioEN.Nif = p_nif;
        usuarioEN.FechaNacimiento = p_fechaNacimiento;
        usuarioEN.Privacidad = p_privacidad;
        //Call to UsuarioCAD

        _IUsuarioCAD.ModificarUsuario (usuarioEN);
}

public void BorrarUsuario (int id)
{
        _IUsuarioCAD.BorrarUsuario (id);
}

public System.Collections.Generic.IList<UsuarioEN> DameTodosLosUsuarios (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> list = null;

        list = _IUsuarioCAD.DameTodosLosUsuarios (first, size);
        return list;
}
public UsuarioEN DameUsuarioPorOID (int id)
{
        UsuarioEN usuarioEN = null;

        usuarioEN = _IUsuarioCAD.DameUsuarioPorOID (id);
        return usuarioEN;
}

public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> ObtenerPorApellidos (string p_apellido)
{
        return _IUsuarioCAD.ObtenerPorApellidos (p_apellido);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> ObtenerAmigos (int pe_usuario, int first, int size)
{
        return _IUsuarioCAD.ObtenerAmigos (pe_usuario, first, size);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> ObtenerAmigosSP (int pe_usuario)
{
        return _IUsuarioCAD.ObtenerAmigosSP (pe_usuario);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> ObtenerBloqueadosSP (int pe_usuario)
{
        return _IUsuarioCAD.ObtenerBloqueadosSP (pe_usuario);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> ObtenerBloqueados (int pe_usuario, int first, int size)
{
        return _IUsuarioCAD.ObtenerBloqueados (pe_usuario, first, size);
}
public void AnyadirElementosMultimedia (int p_Usuario_OID, System.Collections.Generic.IList<int> p_elementos_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.AnyadirElementosMultimedia (p_Usuario_OID, p_elementos_OIDs);
}
public void BorrarElementosMultimedia (int p_Usuario_OID, System.Collections.Generic.IList<int> p_elementos_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.BorrarElementosMultimedia (p_Usuario_OID, p_elementos_OIDs);
}
}
}
