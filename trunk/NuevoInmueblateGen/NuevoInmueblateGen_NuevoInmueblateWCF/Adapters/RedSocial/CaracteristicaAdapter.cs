
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial
{
public class CaracteristicaAdapter {
public static CaracteristicaDTO Convert (CaracteristicaEN en)
{
        CaracteristicaDTO newinstance = null;

        if (en != null) {
                newinstance = new CaracteristicaDTO ();


                newinstance.Id = en.Id;
                newinstance.Nombre = en.Nombre;
                newinstance.Valor = en.Valor;
                if (en.Inmuebles != null) {
                        newinstance.Inmuebles_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN entry in en.Inmuebles)
                                newinstance.Inmuebles_oid.Add (entry.Id);
                }
                if (en.Habitaciones != null) {
                        newinstance.Habitaciones_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN entry in en.Habitaciones)
                                newinstance.Habitaciones_oid.Add (entry.Id);
                }
        }

        return newinstance;
}
}
}
