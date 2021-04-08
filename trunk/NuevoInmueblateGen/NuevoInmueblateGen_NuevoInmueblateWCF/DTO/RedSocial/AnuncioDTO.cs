
using System;
using System.Runtime.Serialization;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial
{
[DataContract (Name = "AnuncioDTO")]
public partial class AnuncioDTO
{
private int id;
[DataMember]
public int Id {
        get { return id; } set { id = value;  }
}
private string imagen;
[DataMember]
public string Imagen {
        get { return imagen; } set { imagen = value;  }
}
private string descripcion;
[DataMember]
public string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}
private Nullable<DateTime> fechaCaducidad;
[DataMember]
public Nullable<DateTime> FechaCaducidad {
        get { return fechaCaducidad; } set { fechaCaducidad = value;  }
}
private NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum tipo;
[DataMember]
public NuevoInmueblateGenNHibernate.Enumerated.RedSocial.TipoAnuncioEnum Tipo {
        get { return tipo; } set { tipo = value;  }
}
private string uRL;
[DataMember]
public string URL {
        get { return uRL; } set { uRL = value;  }
}
}
}
