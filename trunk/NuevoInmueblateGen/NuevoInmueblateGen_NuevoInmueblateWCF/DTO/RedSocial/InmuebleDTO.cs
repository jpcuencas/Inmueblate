
using System;
using System.Runtime.Serialization;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial
{
[DataContract (Name = "InmuebleDTO")]
public partial class InmuebleDTO
{
private int id;
[DataMember]
public int Id {
        get { return id; } set { id = value;  }
}
private bool pendienteModeracion;
[DataMember]
public bool PendienteModeracion {
        get { return pendienteModeracion; } set { pendienteModeracion = value;  }
}
private string descripcion;
[DataMember]
public string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}
private NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoInmuebleEnum tipo;
[DataMember]
public NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoInmuebleEnum Tipo {
        get { return tipo; } set { tipo = value;  }
}
private int metrosCuadrados;
[DataMember]
public int MetrosCuadrados {
        get { return metrosCuadrados; } set { metrosCuadrados = value;  }
}
private bool alquiler;
[DataMember]
public bool Alquiler {
        get { return alquiler; } set { alquiler = value;  }
}
private float precio;
[DataMember]
public float Precio {
        get { return precio; } set { precio = value;  }
}


public System.Collections.Generic.IList<int> inquilinos_oid;
[DataMember]
public System.Collections.Generic.IList<int> Inquilinos_oid {
        get { return inquilinos_oid; } set { inquilinos_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> Inquilinos;


public int geolocalizacion_oid;
[DataMember]
public int Geolocalizacion_oid {
        get { return geolocalizacion_oid; } set { geolocalizacion_oid = value;  }
}

[DataMember]
public int Geolocalizacion;


public System.Collections.Generic.IList<int> caracteristicas_oid;
[DataMember]
public System.Collections.Generic.IList<int> Caracteristicas_oid {
        get { return caracteristicas_oid; } set { caracteristicas_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> Caracteristicas;


public System.Collections.Generic.IList<int> habitaciones_oid;
[DataMember]
public System.Collections.Generic.IList<int> Habitaciones_oid {
        get { return habitaciones_oid; } set { habitaciones_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> Habitaciones;


public System.Collections.Generic.IList<int> elementosMultimedia_oid;
[DataMember]
public System.Collections.Generic.IList<int> ElementosMultimedia_oid {
        get { return elementosMultimedia_oid; } set { elementosMultimedia_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> ElementosMultimedia;


public int inmobiliaria_oid;
[DataMember]
public int Inmobiliaria_oid {
        get { return inmobiliaria_oid; } set { inmobiliaria_oid = value;  }
}

[DataMember]
public int Inmobiliaria;
}
}
