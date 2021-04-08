
using System;
using System.Runtime.Serialization;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial
{
[DataContract (Name = "ValoracionDTO")]
public partial class ValoracionDTO
{
private int id;
[DataMember]
public int Id {
        get { return id; } set { id = value;  }
}
private float valoracion;
[DataMember]
public float Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}
private string descripcion;
[DataMember]
public string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}
private bool pendienteModeracion;
[DataMember]
public bool PendienteModeracion {
        get { return pendienteModeracion; } set { pendienteModeracion = value;  }
}


public int emisor_oid;
[DataMember]
public int Emisor_oid {
        get { return emisor_oid; } set { emisor_oid = value;  }
}

[DataMember]
public int Emisor;


public int receptor_oid;
[DataMember]
public int Receptor_oid {
        get { return receptor_oid; } set { receptor_oid = value;  }
}

[DataMember]
public int Receptor;
}
}
