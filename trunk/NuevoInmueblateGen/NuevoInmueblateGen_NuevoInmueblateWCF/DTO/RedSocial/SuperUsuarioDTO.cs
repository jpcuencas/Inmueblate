
using System;
using System.Runtime.Serialization;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial
{
[DataContract (Name = "SuperUsuarioDTO")]
public partial class SuperUsuarioDTO
{
private int id;
[DataMember]
public int Id {
        get { return id; } set { id = value;  }
}


public int muro_oid;
[DataMember]
public int Muro_oid {
        get { return muro_oid; } set { muro_oid = value;  }
}

[DataMember]
public int Muro;


public System.Collections.Generic.IList<int> grupos_oid;
[DataMember]
public System.Collections.Generic.IList<int> Grupos_oid {
        get { return grupos_oid; } set { grupos_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> Grupos;


public System.Collections.Generic.IList<int> mensajesEnviados_oid;
[DataMember]
public System.Collections.Generic.IList<int> MensajesEnviados_oid {
        get { return mensajesEnviados_oid; } set { mensajesEnviados_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> MensajesEnviados;


public System.Collections.Generic.IList<int> mensajesRecibidos_oid;
[DataMember]
public System.Collections.Generic.IList<int> MensajesRecibidos_oid {
        get { return mensajesRecibidos_oid; } set { mensajesRecibidos_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> MensajesRecibidos;


public System.Collections.Generic.IList<int> valoracionEmitida_oid;
[DataMember]
public System.Collections.Generic.IList<int> ValoracionEmitida_oid {
        get { return valoracionEmitida_oid; } set { valoracionEmitida_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> ValoracionEmitida;


public System.Collections.Generic.IList<int> valoracionRecibida_oid;
[DataMember]
public System.Collections.Generic.IList<int> ValoracionRecibida_oid {
        get { return valoracionRecibida_oid; } set { valoracionRecibida_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> ValoracionRecibida;


public System.Collections.Generic.IList<int> entradasMeGusta_oid;
[DataMember]
public System.Collections.Generic.IList<int> EntradasMeGusta_oid {
        get { return entradasMeGusta_oid; } set { entradasMeGusta_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> EntradasMeGusta;


public System.Collections.Generic.IList<int> entradas_oid;
[DataMember]
public System.Collections.Generic.IList<int> Entradas_oid {
        get { return entradas_oid; } set { entradas_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> Entradas;


public System.Collections.Generic.IList<int> entradasReportadas_oid;
[DataMember]
public System.Collections.Generic.IList<int> EntradasReportadas_oid {
        get { return entradasReportadas_oid; } set { entradasReportadas_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> EntradasReportadas;


public System.Collections.Generic.IList<int> comentarios_oid;
[DataMember]
public System.Collections.Generic.IList<int> Comentarios_oid {
        get { return comentarios_oid; } set { comentarios_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> Comentarios;


public System.Collections.Generic.IList<int> comentariosReportados_oid;
[DataMember]
public System.Collections.Generic.IList<int> ComentariosReportados_oid {
        get { return comentariosReportados_oid; } set { comentariosReportados_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> ComentariosReportados;
private string nombre;
[DataMember]
public string Nombre {
        get { return nombre; } set { nombre = value;  }
}
private string telefono;
[DataMember]
public string Telefono {
        get { return telefono; } set { telefono = value;  }
}
private string email;
[DataMember]
public string Email {
        get { return email; } set { email = value;  }
}
private string direccion;
[DataMember]
public string Direccion {
        get { return direccion; } set { direccion = value;  }
}
private string poblacion;
[DataMember]
public string Poblacion {
        get { return poblacion; } set { poblacion = value;  }
}
private string codigoPostal;
[DataMember]
public string CodigoPostal {
        get { return codigoPostal; } set { codigoPostal = value;  }
}
private string pais;
[DataMember]
public string Pais {
        get { return pais; } set { pais = value;  }
}
private String password;
[DataMember]
public String Password {
        get { return password; } set { password = value;  }
}
private float valoracionMedia;
[DataMember]
public float ValoracionMedia {
        get { return valoracionMedia; } set { valoracionMedia = value;  }
}
}
}
