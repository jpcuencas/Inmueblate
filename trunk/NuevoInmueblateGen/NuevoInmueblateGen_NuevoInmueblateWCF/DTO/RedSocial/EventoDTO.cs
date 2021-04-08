
using System;
using System.Runtime.Serialization;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial
{
[DataContract (Name = "EventoDTO")]
public partial class EventoDTO
{
private int id;
[DataMember]
public int Id {
        get { return id; } set { id = value;  }
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
private Nullable<DateTime> fecha;
[DataMember]
public Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}
private NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum categoria;
[DataMember]
public NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoEventoEnum Categoria {
        get { return categoria; } set { categoria = value;  }
}


public int inmobiliaria_oid;
[DataMember]
public int Inmobiliaria_oid {
        get { return inmobiliaria_oid; } set { inmobiliaria_oid = value;  }
}

[DataMember]
public int Inmobiliaria;


public int geolocalizacion_oid;
[DataMember]
public int Geolocalizacion_oid {
        get { return geolocalizacion_oid; } set { geolocalizacion_oid = value;  }
}

[DataMember]
public int Geolocalizacion;
}
}
