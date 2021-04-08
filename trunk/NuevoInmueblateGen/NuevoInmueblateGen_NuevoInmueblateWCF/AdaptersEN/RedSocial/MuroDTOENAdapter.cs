
using System;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.AdaptersEN.RedSocial
{
public class MuroDTOENAdapter {
public static MuroEN Convert (MuroDTO dto)
{
        MuroEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new MuroEN ();



                        newinstance.Id = dto.Id;
                        newinstance.PendienteModeracion = dto.PendienteModeracion;
                        if (dto.PropietarioUsuario_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.ISuperUsuarioCAD superUsuarioCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.SuperUsuarioCAD ();

                                newinstance.PropietarioUsuario = superUsuarioCAD.ReadOIDDefault (dto.PropietarioUsuario_oid);
                        }
                        if (dto.PropietarioGrupo_oid != -1) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IGrupoCAD grupoCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.GrupoCAD ();

                                newinstance.PropietarioGrupo = grupoCAD.ReadOIDDefault (dto.PropietarioGrupo_oid);
                        }
                        if (dto.Entradas_oid != null) {
                                NuevoInmueblateGenNHibernate.CAD.RedSocial.IEntradaCAD entradaCAD = new NuevoInmueblateGenNHibernate.CAD.RedSocial.EntradaCAD ();

                                newinstance.Entradas = new System.Collections.Generic.List<NuevoInmueblateGenNHibernate.EN.RedSocial.EntradaEN>();
                                foreach (int entry in dto.Entradas_oid) {
                                        newinstance.Entradas.Add (entradaCAD.ReadOIDDefault (entry));
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
