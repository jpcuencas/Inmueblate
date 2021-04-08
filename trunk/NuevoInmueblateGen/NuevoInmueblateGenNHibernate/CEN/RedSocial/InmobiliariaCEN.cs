

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
 *      Definition of the class InmobiliariaCEN
 *
 */
public partial class InmobiliariaCEN
{
private IInmobiliariaCAD _IInmobiliariaCAD;

public InmobiliariaCEN()
{
        this._IInmobiliariaCAD = new InmobiliariaCAD ();
}

public InmobiliariaCEN(IInmobiliariaCAD _IInmobiliariaCAD)
{
        this._IInmobiliariaCAD = _IInmobiliariaCAD;
}

public IInmobiliariaCAD get_IInmobiliariaCAD ()
{
        return this._IInmobiliariaCAD;
}

public int CrearInmobiliaria (int p_muro, string p_nombre, string p_telefono, string p_email, string p_direccion, string p_poblacion, string p_codigoPostal, string p_pais, String p_password, float p_valoracionMedia, string p_descripcion, string p_cif)
{
        InmobiliariaEN inmobiliariaEN = null;
        int oid;

        //Initialized InmobiliariaEN
        inmobiliariaEN = new InmobiliariaEN ();

        if (p_muro != -1) {
                // El argumento p_muro -> Property muro es oid = false
                // Lista de oids id
                inmobiliariaEN.Muro = new NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN ();
                inmobiliariaEN.Muro.Id = p_muro;
        }

        inmobiliariaEN.Nombre = p_nombre;

        inmobiliariaEN.Telefono = p_telefono;

        inmobiliariaEN.Email = p_email;

        inmobiliariaEN.Direccion = p_direccion;

        inmobiliariaEN.Poblacion = p_poblacion;

        inmobiliariaEN.CodigoPostal = p_codigoPostal;

        inmobiliariaEN.Pais = p_pais;

        inmobiliariaEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        inmobiliariaEN.ValoracionMedia = p_valoracionMedia;

        inmobiliariaEN.Descripcion = p_descripcion;

        inmobiliariaEN.Cif = p_cif;

        //Call to InmobiliariaCAD

        oid = _IInmobiliariaCAD.CrearInmobiliaria (inmobiliariaEN);
        return oid;
}

public void ModificarInmobilaria (int p_Inmobiliaria_OID, string p_nombre, string p_telefono, string p_email, string p_direccion, string p_poblacion, string p_codigoPostal, string p_pais, String p_password, float p_valoracionMedia, string p_descripcion, string p_cif)
{
        InmobiliariaEN inmobiliariaEN = null;

        //Initialized InmobiliariaEN
        inmobiliariaEN = new InmobiliariaEN ();
        inmobiliariaEN.Id = p_Inmobiliaria_OID;
        inmobiliariaEN.Nombre = p_nombre;
        inmobiliariaEN.Telefono = p_telefono;
        inmobiliariaEN.Email = p_email;
        inmobiliariaEN.Direccion = p_direccion;
        inmobiliariaEN.Poblacion = p_poblacion;
        inmobiliariaEN.CodigoPostal = p_codigoPostal;
        inmobiliariaEN.Pais = p_pais;
        inmobiliariaEN.Password = Utils.Util.GetEncondeMD5 (p_password);
        inmobiliariaEN.ValoracionMedia = p_valoracionMedia;
        inmobiliariaEN.Descripcion = p_descripcion;
        inmobiliariaEN.Cif = p_cif;
        //Call to InmobiliariaCAD

        _IInmobiliariaCAD.ModificarInmobilaria (inmobiliariaEN);
}

public void BorrarInmobiliaria (int id)
{
        _IInmobiliariaCAD.BorrarInmobiliaria (id);
}

public System.Collections.Generic.IList<InmobiliariaEN> DameTodasLasInmobiliarias (int first, int size)
{
        System.Collections.Generic.IList<InmobiliariaEN> list = null;

        list = _IInmobiliariaCAD.DameTodasLasInmobiliarias (first, size);
        return list;
}
public InmobiliariaEN DameInmobiliariaPorOID (int id)
{
        InmobiliariaEN inmobiliariaEN = null;

        inmobiliariaEN = _IInmobiliariaCAD.DameInmobiliariaPorOID (id);
        return inmobiliariaEN;
}
}
}
