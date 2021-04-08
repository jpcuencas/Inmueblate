
using System;
using System.Runtime.Serialization;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial
{
[DataContract (Name = "InmobiliariaDTO")]
public partial class InmobiliariaDTO                    :                           NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.SuperUsuarioDTO


{
public System.Collections.Generic.IList<int> inmuebles_oid;
[DataMember]
public System.Collections.Generic.IList<int> Inmuebles_oid {
        get { return inmuebles_oid; } set { inmuebles_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> Inmuebles;


public System.Collections.Generic.IList<int> paginaCorporativa_oid;
[DataMember]
public System.Collections.Generic.IList<int> PaginaCorporativa_oid {
        get { return paginaCorporativa_oid; } set { paginaCorporativa_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> PaginaCorporativa;


public System.Collections.Generic.IList<int> eventos_oid;
[DataMember]
public System.Collections.Generic.IList<int> Eventos_oid {
        get { return eventos_oid; } set { eventos_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> Eventos;
private string descripcion;
[DataMember]
public string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}
private string cif;
[DataMember]
public string Cif {
        get { return cif; } set { cif = value;  }
}
}
}
