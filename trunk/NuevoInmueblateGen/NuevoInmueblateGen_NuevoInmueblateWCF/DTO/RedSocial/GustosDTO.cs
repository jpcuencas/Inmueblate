
using System;
using System.Runtime.Serialization;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial
{
[DataContract (Name = "GustosDTO")]
public partial class GustosDTO
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
private System.Collections.Generic.IList<string> musica;
[DataMember]
public System.Collections.Generic.IList<string> Musica {
        get { return musica; } set { musica = value;  }
}
private System.Collections.Generic.IList<string> libros;
[DataMember]
public System.Collections.Generic.IList<string> Libros {
        get { return libros; } set { libros = value;  }
}
private System.Collections.Generic.IList<string> peliculas;
[DataMember]
public System.Collections.Generic.IList<string> Peliculas {
        get { return peliculas; } set { peliculas = value;  }
}
private System.Collections.Generic.IList<string> juegos;
[DataMember]
public System.Collections.Generic.IList<string> Juegos {
        get { return juegos; } set { juegos = value;  }
}


public int usuario_oid;
[DataMember]
public int Usuario_oid {
        get { return usuario_oid; } set { usuario_oid = value;  }
}

[DataMember]
public int Usuario;
}
}
