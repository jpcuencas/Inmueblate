
using System;
using System.Runtime.Serialization;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial
{
[DataContract (Name = "PaginaCorporativaDTO")]
public partial class PaginaCorporativaDTO
{
private int id;
[DataMember]
public int Id {
        get { return id; } set { id = value;  }
}
private string contenido;
[DataMember]
public string Contenido {
        get { return contenido; } set { contenido = value;  }
}
private string uRL;
[DataMember]
public string URL {
        get { return uRL; } set { uRL = value;  }
}


public int inmobiliaria_oid;
[DataMember]
public int Inmobiliaria_oid {
        get { return inmobiliaria_oid; } set { inmobiliaria_oid = value;  }
}

[DataMember]
public int Inmobiliaria;
}
}
