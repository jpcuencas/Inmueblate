

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
 *      Definition of the class HabitacionCEN
 *
 */
public partial class HabitacionCEN
{
private IHabitacionCAD _IHabitacionCAD;

public HabitacionCEN()
{
        this._IHabitacionCAD = new HabitacionCAD ();
}

public HabitacionCEN(IHabitacionCAD _IHabitacionCAD)
{
        this._IHabitacionCAD = _IHabitacionCAD;
}

public IHabitacionCAD get_IHabitacionCAD ()
{
        return this._IHabitacionCAD;
}

public int CrearHabitacion (bool p_pendienteModeracion, string p_descripcion, int p_metrosCuadrados, bool p_alquiler, System.Collections.Generic.IList<int> p_inquilinos, int p_inmueble)
{
        HabitacionEN habitacionEN = null;
        int oid;

        //Initialized HabitacionEN
        habitacionEN = new HabitacionEN ();
        habitacionEN.PendienteModeracion = p_pendienteModeracion;

        habitacionEN.Descripcion = p_descripcion;

        habitacionEN.MetrosCuadrados = p_metrosCuadrados;

        habitacionEN.Alquiler = p_alquiler;


        habitacionEN.Inquilinos = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN>();
        if (p_inquilinos != null) {
                foreach (int item in p_inquilinos) {
                        NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN en = new NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN ();
                        en.Id = item;
                        habitacionEN.Inquilinos.Add (en);
                }
        }

        else{
                habitacionEN.Inquilinos = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN>();
        }


        if (p_inmueble != -1) {
                // El argumento p_inmueble -> Property inmueble es oid = false
                // Lista de oids id
                habitacionEN.Inmueble = new NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN ();
                habitacionEN.Inmueble.Id = p_inmueble;
        }

        //Call to HabitacionCAD

        oid = _IHabitacionCAD.CrearHabitacion (habitacionEN);
        return oid;
}

public void ModificarHabitacion (int p_oid, bool p_pendienteModeracion, string p_descripcion, int p_metrosCuadrados, bool p_alquiler)
{
        HabitacionEN habitacionEN = null;

        //Initialized HabitacionEN
        habitacionEN = new HabitacionEN ();
        habitacionEN.Id = p_oid;
        habitacionEN.PendienteModeracion = p_pendienteModeracion;
        habitacionEN.Descripcion = p_descripcion;
        habitacionEN.MetrosCuadrados = p_metrosCuadrados;
        habitacionEN.Alquiler = p_alquiler;
        //Call to HabitacionCAD

        _IHabitacionCAD.ModificarHabitacion (habitacionEN);
}

public void BorrarHabitacion (int id)
{
        _IHabitacionCAD.BorrarHabitacion (id);
}

public void AnyadirCaracteristica (int p_habitacion, System.Collections.Generic.IList<int> p_caracteristica)
{
        //Call to HabitacionCAD

        _IHabitacionCAD.AnyadirCaracteristica (p_habitacion, p_caracteristica);
}
public void AnyadirInquilino (int p_habitacion, System.Collections.Generic.IList<int> p_usuario)
{
        //Call to HabitacionCAD

        _IHabitacionCAD.AnyadirInquilino (p_habitacion, p_usuario);
}
public void BorrarCaracteristica (int p_habitacion, System.Collections.Generic.IList<int> p_caracteristica)
{
        //Call to HabitacionCAD

        _IHabitacionCAD.BorrarCaracteristica (p_habitacion, p_caracteristica);
}
public void BorrarInquilino (int p_habitacion, System.Collections.Generic.IList<int> p_usuario)
{
        //Call to HabitacionCAD

        _IHabitacionCAD.BorrarInquilino (p_habitacion, p_usuario);
}
public System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.HabitacionEN> ObtenerHabitacionPendienteModeracion ()
{
        return _IHabitacionCAD.ObtenerHabitacionPendienteModeracion ();
}
public HabitacionEN DameHabitacionPorOID (int id)
{
        HabitacionEN habitacionEN = null;

        habitacionEN = _IHabitacionCAD.DameHabitacionPorOID (id);
        return habitacionEN;
}

public System.Collections.Generic.IList<HabitacionEN> DameTodasLasHabitaciones (int first, int size)
{
        System.Collections.Generic.IList<HabitacionEN> list = null;

        list = _IHabitacionCAD.DameTodasLasHabitaciones (first, size);
        return list;
}
}
}
