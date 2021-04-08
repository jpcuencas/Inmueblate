
using System;
using System.Runtime.Serialization;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial
{
[DataContract (Name = "PeticionAmistadDTO")]
public partial class PeticionAmistadDTO
{
private int id;
[DataMember]
public int Id {
        get { return id; } set { id = value;  }
}
private string asunto;
[DataMember]
public string Asunto {
        get { return asunto; } set { asunto = value;  }
}
private string cuerpo;
[DataMember]
public string Cuerpo {
        get { return cuerpo; } set { cuerpo = value;  }
}
private NuevoInmueblateGenNHibernate.Enumerated.RedSocial.EstadoSolicitudAmistadEnum estado;
[DataMember]
public NuevoInmueblateGenNHibernate.Enumerated.RedSocial.EstadoSolicitudAmistadEnum Estado {
        get { return estado; } set { estado = value;  }
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
