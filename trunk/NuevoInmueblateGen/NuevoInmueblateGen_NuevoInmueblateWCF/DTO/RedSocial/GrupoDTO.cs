
using System;
using System.Runtime.Serialization;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial
{
[DataContract (Name = "GrupoDTO")]
public partial class GrupoDTO
{
private int id;
[DataMember]
public int Id {
        get { return id; } set { id = value;  }
}
private NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoGrupoEnum tipo;
[DataMember]
public NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoGrupoEnum Tipo {
        get { return tipo; } set { tipo = value;  }
}
private string nombre;
[DataMember]
public string Nombre {
        get { return nombre; } set { nombre = value;  }
}
private string descripcion;
[DataMember]
public string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}


public System.Collections.Generic.IList<int> miembros_oid;
[DataMember]
public System.Collections.Generic.IList<int> Miembros_oid {
        get { return miembros_oid; } set { miembros_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> Miembros;


public int muro_oid;
[DataMember]
public int Muro_oid {
        get { return muro_oid; } set { muro_oid = value;  }
}

[DataMember]
public int Muro;


public int preferenciasBusqueda_oid;
[DataMember]
public int PreferenciasBusqueda_oid {
        get { return preferenciasBusqueda_oid; } set { preferenciasBusqueda_oid = value;  }
}

[DataMember]
public int PreferenciasBusqueda;
}
}
