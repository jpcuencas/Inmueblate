
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.AdaptersEN.RedSocial
{
public class HabitacionDTOENAdapter {
public static HabitacionEN Convert (HabitacionDTO dto)
{
        HabitacionEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new HabitacionEN ();



                        newinstance.Id = dto.Id;
                        newinstance.PendienteModeracion = dto.PendienteModeracion;
                        newinstance.Descripcion = dto.Descripcion;
                        newinstance.MetrosCuadrados = dto.MetrosCuadrados;
                        newinstance.Alquiler = dto.Alquiler;
                        if (dto.Inquilinos_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IUsuarioCAD usuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.UsuarioCAD ();

                                newinstance.Inquilinos = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN>();
                                foreach (int entry in dto.Inquilinos_oid) {
                                        newinstance.Inquilinos.Add (usuarioCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Caracteristicas_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.ICaracteristicaCAD caracteristicaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.CaracteristicaCAD ();

                                newinstance.Caracteristicas = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN>();
                                foreach (int entry in dto.Caracteristicas_oid) {
                                        newinstance.Caracteristicas.Add (caracteristicaCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Inmueble_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmuebleCAD inmuebleCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmuebleCAD ();

                                newinstance.Inmueble = inmuebleCAD.ReadOIDDefault (dto.Inmueble_oid);
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
