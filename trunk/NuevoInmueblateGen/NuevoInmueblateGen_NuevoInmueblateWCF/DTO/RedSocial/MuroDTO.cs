
using System;
using System.Runtime.Serialization;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial
{
[DataContract (Name = "MuroDTO")]
public partial class MuroDTO
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


public int propietarioUsuario_oid;
[DataMember]
public int PropietarioUsuario_oid {
        get { return propietarioUsuario_oid; } set { propietarioUsuario_oid = value;  }
}

[DataMember]
public int PropietarioUsuario;


public int propietarioGrupo_oid;
[DataMember]
public int PropietarioGrupo_oid {
        get { return propietarioGrupo_oid; } set { propietarioGrupo_oid = value;  }
}

[DataMember]
public int PropietarioGrupo;


public System.Collections.Generic.IList<int> entradas_oid;
[DataMember]
public System.Collections.Generic.IList<int> Entradas_oid {
        get { return entradas_oid; } set { entradas_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> Entradas;
}
}
