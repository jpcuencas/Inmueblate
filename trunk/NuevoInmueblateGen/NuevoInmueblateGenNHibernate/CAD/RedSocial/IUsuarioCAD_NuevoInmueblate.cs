
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial interface IUsuarioCAD
{
NuevoInmueblateGenNHibernate.EN.RedSocial.MuroEN                GetMuroOfPropietarioUsuario_NuevoInmueblate (int id);

System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.InmuebleEN>  GetAllInmueblesOfInquilinos_NuevoInmueblate (int id);

System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>        GetAllFotosOfFusuario_NuevoInmueblate (int id);

System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.ElementoMultimediaEN>        GetAllVideosOfVusuario_NuevoInmueblate (int id);

NuevoInmueblateGenNHibernate.EN.RedSocial.PreferenciasBusquedaEN                GetPreferenciasBusquedaOfUsuario_NuevoInmueblate (int id);

NuevoInmueblateGenNHibernate.EN.RedSocial.GustosEN              GetGustosOfUsuario_NuevoInmueblate (int id);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> GetAllUsuario_NuevoInmueblate ();
}
}
