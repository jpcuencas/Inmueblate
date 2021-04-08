
using System;
using System.Runtime.Serialization;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial
{
[DataContract (Name = "HabitacionDTO")]
public partial class HabitacionDTO
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


public System.Collections.Generic.IList<int> inquilinos_oid;
[DataMember]
public System.Collections.Generic.IList<int> Inquilinos_oid {
        get { return inquilinos_oid; } set { inquilinos_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> Inquilinos;


public System.Collections.Generic.IList<int> caracteristicas_oid;
[DataMember]
public System.Collections.Generic.IList<int> Caracteristicas_oid {
        get { return caracteristicas_oid; } set { caracteristicas_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> Caracteristicas;


public int inmueble_oid;
[DataMember]
public int Inmueble_oid {
        get { return inmueble_oid; } set { inmueble_oid = value;  }
}

[DataMember]
public int Inmueble;
}
}
