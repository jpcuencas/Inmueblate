
using System;
using System.Runtime.Serialization;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial
{
[DataContract (Name = "ElementoMultimediaDTO")]
public partial class ElementoMultimediaDTO
{
private int id;
[DataMember]
public int Id {
        get { return id; } set { id = value;  }
}


public System.Collections.Generic.IList<int> mensaje_oid;
[DataMember]
public System.Collections.Generic.IList<int> Mensaje_oid {
        get { return mensaje_oid; } set { mensaje_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> Mensaje;


public int galeria_oid;
[DataMember]
public int Galeria_oid {
        get { return galeria_oid; } set { galeria_oid = value;  }
}

[DataMember]
public int Galeria;


public System.Collections.Generic.IList<int> entradas_oid;
[DataMember]
public System.Collections.Generic.IList<int> Entradas_oid {
        get { return entradas_oid; } set { entradas_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> Entradas;


public System.Collections.Generic.IList<int> aparicionComentarios_oid;
[DataMember]
public System.Collections.Generic.IList<int> AparicionComentarios_oid {
        get { return aparicionComentarios_oid; } set { aparicionComentarios_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> AparicionComentarios;


public int inmueble_oid;
[DataMember]
public int Inmueble_oid {
        get { return inmueble_oid; } set { inmueble_oid = value;  }
}

[DataMember]
public int Inmueble;


public int usuario_oid;
[DataMember]
public int Usuario_oid {
        get { return usuario_oid; } set { usuario_oid = value;  }
}

[DataMember]
public int Usuario;
private Nullable<DateTime> fecha;
[DataMember]
public Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}
private string descripcion;
[DataMember]
public string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}
private string nombre;
[DataMember]
public string Nombre {
        get { return nombre; } set { nombre = value;  }
}
private bool pendienteModeracion;
[DataMember]
public bool PendienteModeracion {
        get { return pendienteModeracion; } set { pendienteModeracion = value;  }
}
private string uRL;
[DataMember]
public string URL {
        get { return uRL; } set { uRL = value;  }
}
}
}
