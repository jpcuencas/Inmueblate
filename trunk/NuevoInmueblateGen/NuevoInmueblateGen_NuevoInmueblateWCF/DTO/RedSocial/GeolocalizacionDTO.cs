
using System;
using System.Runtime.Serialization;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial
{
[DataContract (Name = "GeolocalizacionDTO")]
public partial class GeolocalizacionDTO
{
private int id;
[DataMember]
public int Id {
        get { return id; } set { id = value;  }
}
private float longitud;
[DataMember]
public float Longitud {
        get { return longitud; } set { longitud = value;  }
}
private float latitud;
[DataMember]
public float Latitud {
        get { return latitud; } set { latitud = value;  }
}
private string direccion;
[DataMember]
public string Direccion {
        get { return direccion; } set { direccion = value;  }
}
private string poblacion;
[DataMember]
public string Poblacion {
        get { return poblacion; } set { poblacion = value;  }
}


public int preferenciasBusqueda_oid;
[DataMember]
public int PreferenciasBusqueda_oid {
        get { return preferenciasBusqueda_oid; } set { preferenciasBusqueda_oid = value;  }
}

[DataMember]
public int PreferenciasBusqueda;


public int inmueble_oid;
[DataMember]
public int Inmueble_oid {
        get { return inmueble_oid; } set { inmueble_oid = value;  }
}

[DataMember]
public int Inmueble;


public int evento_oid;
[DataMember]
public int Evento_oid {
        get { return evento_oid; } set { evento_oid = value;  }
}

[DataMember]
public int Evento;
}
}
