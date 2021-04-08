
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (int id);

int CrearUsuario (UsuarioEN usuario);

void ModificarUsuario (UsuarioEN usuario);


void BorrarUsuario (int id);


System.Collections.Generic.IList<UsuarioEN> DameTodosLosUsuarios (int first, int size);


UsuarioEN DameUsuarioPorOID (int id);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> ObtenerPorApellidos (string p_apellido);



System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> DameUsuariosFiltro (string p_nif, string p_email, string p_apellidos, Nullable<DateTime> p_fechaNacimiento, string p_direccion, string p_poblacion, int first, int size);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> ObtenerAmigos (int pe_usuario, int first, int size);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> ObtenerAmigosSP (int pe_usuario);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> ObtenerBloqueadosSP (int pe_usuario);


System.Collections.Generic.IList<NuevoInmueblateGenNHibernate.EN.RedSocial.UsuarioEN> ObtenerBloqueados (int pe_usuario, int first, int size);


void AnyadirElementosMultimedia (int p_Usuario_OID, System.Collections.Generic.IList<int> p_elementos_OIDs);

void BorrarElementosMultimedia (int p_Usuario_OID, System.Collections.Generic.IList<int> p_elementos_OIDs);
}
}
