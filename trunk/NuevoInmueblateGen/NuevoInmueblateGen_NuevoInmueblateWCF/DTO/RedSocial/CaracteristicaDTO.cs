
using System;
using System.Runtime.Serialization;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial
{
[DataContract (Name = "CaracteristicaDTO")]
public partial class CaracteristicaDTO
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
private string valor;
[DataMember]
public string Valor {
        get { return valor; } set { valor = value;  }
}


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
}
}
