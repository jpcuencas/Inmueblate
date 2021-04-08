
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial
{
public class GrupoAdapter {
public static GrupoDTO Convert (GrupoEN en)
{
        GrupoDTO newinstance = null;

        if (en != null) {
                newinstance = new GrupoDTO ();


                newinstance.Id = en.Id;
                newinstance.Tipo = en.Tipo;
                newinstance.Nombre = en.Nombre;
                newinstance.Descripcion = en.Descripcion;
                if (en.Miembros != null) {
                        newinstance.Miembros_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN entry in en.Miembros)
                                newinstance.Miembros_oid.Add (entry.Id);
                }
                if (en.Muro != null) {
                        newinstance.Muro_oid = en.Muro.Id;
                }
                if (en.PreferenciasBusqueda != null) {
                        newinstance.PreferenciasBusqueda_oid = en.PreferenciasBusqueda.Id;
                }
        }

        return newinstance;
}
}
}
