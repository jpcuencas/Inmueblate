
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.AdaptersEN.RedSocial
{
public class CaracteristicaDTOENAdapter {
public static CaracteristicaEN Convert (CaracteristicaDTO dto)
{
        CaracteristicaEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new CaracteristicaEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Nombre = dto.Nombre;
                        newinstance.Valor = dto.Valor;
                        if (dto.Inmuebles_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IInmuebleCAD inmuebleCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.InmuebleCAD ();

                                newinstance.Inmuebles = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN>();
                                foreach (int entry in dto.Inmuebles_oid) {
                                        newinstance.Inmuebles.Add (inmuebleCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Habitaciones_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IHabitacionCAD habitacionCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.HabitacionCAD ();

                                newinstance.Habitaciones = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN>();
                                foreach (int entry in dto.Habitaciones_oid) {
                                        newinstance.Habitaciones.Add (habitacionCAD.ReadOIDDefault (entry));
                                }
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
