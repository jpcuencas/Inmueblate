
using System;
using System.Runtime.Serialization;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial
{
[DataContract (Name = "MensajeDTO")]
public partial class MensajeDTO
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
private Nullable<DateTime> fechaEnvio;
[DataMember]
public Nullable<DateTime> FechaEnvio {
        get { return fechaEnvio; } set { fechaEnvio = value;  }
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
private bool leido;
[DataMember]
public bool Leido {
        get { return leido; } set { leido = value;  }
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


public System.Collections.Generic.IList<int> elementosMultimedia_oid;
[DataMember]
public System.Collections.Generic.IList<int> ElementosMultimedia_oid {
        get { return elementosMultimedia_oid; } set { elementosMultimedia_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> ElementosMultimedia;
}
}
