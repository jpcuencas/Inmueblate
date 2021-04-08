
using System;
using System.Runtime.Serialization;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial
{
[DataContract (Name = "UsuarioDTO")]
public partial class UsuarioDTO                 :                           NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.SuperUsuarioDTO


{
public System.Collections.Generic.IList<int> listaAmigos_oid;
[DataMember]
public System.Collections.Generic.IList<int> ListaAmigos_oid {
        get { return listaAmigos_oid; } set { listaAmigos_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> ListaAmigos;


public System.Collections.Generic.IList<int> listaBloqueados_oid;
[DataMember]
public System.Collections.Generic.IList<int> ListaBloqueados_oid {
        get { return listaBloqueados_oid; } set { listaBloqueados_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> ListaBloqueados;


public System.Collections.Generic.IList<int> inmuebles_oid;
[DataMember]
public System.Collections.Generic.IList<int> Inmuebles_oid {
        get { return inmuebles_oid; } set { inmuebles_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> Inmuebles;


public System.Collections.Generic.IList<int> habitaciones_oid;
[DataMember]
public System.Collections.Generic.IList<int> Habitaciones_oid {
        get { return habitaciones_oid; } set { habitaciones_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> Habitaciones;


public System.Collections.Generic.IList<int> peticionesEnviadas_oid;
[DataMember]
public System.Collections.Generic.IList<int> PeticionesEnviadas_oid {
        get { return peticionesEnviadas_oid; } set { peticionesEnviadas_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> PeticionesEnviadas;


public System.Collections.Generic.IList<int> peticionesRecibidas_oid;
[DataMember]
public System.Collections.Generic.IList<int> PeticionesRecibidas_oid {
        get { return peticionesRecibidas_oid; } set { peticionesRecibidas_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> PeticionesRecibidas;


public int preferenciasBusqueda_oid;
[DataMember]
public int PreferenciasBusqueda_oid {
        get { return preferenciasBusqueda_oid; } set { preferenciasBusqueda_oid = value;  }
}

[DataMember]
public int PreferenciasBusqueda;


public int gustos_oid;
[DataMember]
public int Gustos_oid {
        get { return gustos_oid; } set { gustos_oid = value;  }
}

[DataMember]
public int Gustos;


public System.Collections.Generic.IList<int> elementos_oid;
[DataMember]
public System.Collections.Generic.IList<int> Elementos_oid {
        get { return elementos_oid; } set { elementos_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> Elementos;
private string apellidos;
[DataMember]
public string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}
private string nif;
[DataMember]
public string Nif {
        get { return nif; } set { nif = value;  }
}
private Nullable<DateTime> fechaNacimiento;
[DataMember]
public Nullable<DateTime> FechaNacimiento {
        get { return fechaNacimiento; } set { fechaNacimiento = value;  }
}
private NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum privacidad;
[DataMember]
public NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoPrivacidadEnum Privacidad {
        get { return privacidad; } set { privacidad = value;  }
}
}
}
