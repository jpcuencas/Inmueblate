
using System;
using System.Runtime.Serialization;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial
{
[DataContract (Name = "PreferenciasBusquedaDTO")]
public partial class PreferenciasBusquedaDTO
{
private int id;
[DataMember]
public int Id {
        get { return id; } set { id = value;  }
}
private int distanciaTolerable;
[DataMember]
public int DistanciaTolerable {
        get { return distanciaTolerable; } set { distanciaTolerable = value;  }
}
private float precioMax;
[DataMember]
public float PrecioMax {
        get { return precioMax; } set { precioMax = value;  }
}
private float precioMin;
[DataMember]
public float PrecioMin {
        get { return precioMin; } set { precioMin = value;  }
}


public int usuario_oid;
[DataMember]
public int Usuario_oid {
        get { return usuario_oid; } set { usuario_oid = value;  }
}

[DataMember]
public int Usuario;


public int grupo_oid;
[DataMember]
public int Grupo_oid {
        get { return grupo_oid; } set { grupo_oid = value;  }
}

[DataMember]
public int Grupo;


public int geolocalizacion_oid;
[DataMember]
public int Geolocalizacion_oid {
        get { return geolocalizacion_oid; } set { geolocalizacion_oid = value;  }
}

[DataMember]
public int Geolocalizacion;
}
}
