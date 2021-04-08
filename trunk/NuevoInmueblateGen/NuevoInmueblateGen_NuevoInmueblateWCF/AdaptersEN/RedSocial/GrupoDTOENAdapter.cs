
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.AdaptersEN.RedSocial
{
public class GrupoDTOENAdapter {
public static GrupoEN Convert (GrupoDTO dto)
{
        GrupoEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new GrupoEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Tipo = dto.Tipo;
                        newinstance.Nombre = dto.Nombre;
                        newinstance.Descripcion = dto.Descripcion;
                        if (dto.Miembros_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.ISuperUsuarioCAD superUsuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.SuperUsuarioCAD ();

                                newinstance.Miembros = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.SuperUsuarioEN>();
                                foreach (int entry in dto.Miembros_oid) {
                                        newinstance.Miembros.Add (superUsuarioCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Muro_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IMuroCAD muroCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.MuroCAD ();

                                newinstance.Muro = muroCAD.ReadOIDDefault (dto.Muro_oid);
                        }
                        if (dto.PreferenciasBusqueda_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IPreferenciasBusquedaCAD preferenciasBusquedaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.PreferenciasBusquedaCAD ();

                                newinstance.PreferenciasBusqueda = preferenciasBusquedaCAD.ReadOIDDefault (dto.PreferenciasBusqueda_oid);
                        }
                }
        }
        catch (Exception ex)
        {
                throw ex;
        }
        return newinstance;
}
}
}
