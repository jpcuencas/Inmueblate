
using System;
using System.Runtime.Serialization;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial
{
[DataContract (Name = "EntradaDTO")]
public partial class EntradaDTO
{
private int id;
[DataMember]
public int Id {
        get { return id; } set { id = value;  }
}
private Nullable<DateTime> fechaPublicacion;
[DataMember]
public Nullable<DateTime> FechaPublicacion {
        get { return fechaPublicacion; } set { fechaPublicacion = value;  }
}
private string titulo;
[DataMember]
public string Titulo {
        get { return titulo; } set { titulo = value;  }
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


public int muro_oid;
[DataMember]
public int Muro_oid {
        get { return muro_oid; } set { muro_oid = value;  }
}

[DataMember]
public int Muro;


public System.Collections.Generic.IList<int> usuariosMeGusta_oid;
[DataMember]
public System.Collections.Generic.IList<int> UsuariosMeGusta_oid {
        get { return usuariosMeGusta_oid; } set { usuariosMeGusta_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> UsuariosMeGusta;


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


public System.Collections.Generic.IList<int> comentarios_oid;
[DataMember]
public System.Collections.Generic.IList<int> Comentarios_oid {
        get { return comentarios_oid; } set { comentarios_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> Comentarios;


public System.Collections.Generic.IList<int> elementosMultimedia_oid;
[DataMember]
public System.Collections.Generic.IList<int> ElementosMultimedia_oid {
        get { return elementosMultimedia_oid; } set { elementosMultimedia_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> ElementosMultimedia;
}
}
