
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.Adapters.RedSocial
{
public class HabitacionAdapter {
public static HabitacionDTO Convert (HabitacionEN en)
{
        HabitacionDTO newinstance = null;

        if (en != null) {
                newinstance = new HabitacionDTO ();


                newinstance.Id = en.Id;
                newinstance.PendienteModeracion = en.PendienteModeracion;
                newinstance.Descripcion = en.Descripcion;
                newinstance.MetrosCuadrados = en.MetrosCuadrados;
                newinstance.Alquiler = en.Alquiler;
                if (en.Inquilinos != null) {
                        newinstance.Inquilinos_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN entry in en.Inquilinos)
                                newinstance.Inquilinos_oid.Add (entry.Id);
                }
                if (en.Caracteristicas != null) {
                        newinstance.Caracteristicas_oid = new System.Collections.Generic.List<int>();
                        foreach (NuevoInmueblateGenNHibernate.EN.RedSocial.CaracteristicaEN entry in en.Caracteristicas)
                                newinstance.Caracteristicas_oid.Add (entry.Id);
                }
                if (en.Inmueble != null) {
                        newinstance.Inmueble_oid = en.Inmueble.Id;
                }
        }

        return newinstance;
}
}
}
