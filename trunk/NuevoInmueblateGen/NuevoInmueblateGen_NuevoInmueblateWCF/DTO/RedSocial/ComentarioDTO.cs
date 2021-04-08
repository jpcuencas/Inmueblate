
using System;
using System.Runtime.Serialization;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial
{
[DataContract (Name = "ComentarioDTO")]
public partial class ComentarioDTO
{
private int id;
[DataMember]
public int Id {
        get { return id; } set { id = value;  }
}
private string cuerpo;
[DataMember]
public string Cuerpo {
        get { return cuerpo; } set { cuerpo = value;  }
}
private bool pendienteModeracion;
[DataMember]
public bool PendienteModeracion {
        get { return pendienteModeracion; } set { pendienteModeracion = value;  }
}
private Nullable<DateTime> fechaPublicacion;
[DataMember]
public Nullable<DateTime> FechaPublicacion {
        get { return fechaPublicacion; } set { fechaPublicacion = value;  }
}


public int creador_oid;
[DataMember]
public int Creador_oid {
        get { return creador_oid; } set { creador_oid = value;  }
}

[DataMember]
public int Creador;


public System.Collections.Generic.IList<int> reportadores_oid;
[DataMember]
public System.Collections.Generic.IList<int> Reportadores_oid {
        get { return reportadores_oid; } set { reportadores_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> Reportadores;


public int entrada_oid;
[DataMember]
public int Entrada_oid {
        get { return entrada_oid; } set { entrada_oid = value;  }
}

[DataMember]
public int Entrada;


public System.Collections.Generic.IList<int> elementosMultimedia_oid;
[DataMember]
public System.Collections.Generic.IList<int> ElementosMultimedia_oid {
        get { return elementosMultimedia_oid; } set { elementosMultimedia_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> ElementosMultimedia;
}
}
