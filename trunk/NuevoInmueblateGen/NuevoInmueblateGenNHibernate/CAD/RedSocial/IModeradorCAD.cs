
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGenNHibernate.CAD.RedSocial
{
public partial interface IModeradorCAD
{
ModeradorEN ReadOIDDefault (int id);

int CrearModerador (ModeradorEN moderador);

void ModificarModerador (ModeradorEN moderador);


void BorrarModerador (int id);
}
}
