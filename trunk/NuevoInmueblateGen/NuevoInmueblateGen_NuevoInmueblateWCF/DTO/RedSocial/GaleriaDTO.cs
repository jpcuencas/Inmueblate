
using System;
using System.Runtime.Serialization;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial
{
[DataContract (Name = "GaleriaDTO")]
public partial class GaleriaDTO                 :                           NuevoInmueblateGen_NuevoInmueblateWCF.DTO.RedSocial.ElementoMultimediaDTO


{
public System.Collections.Generic.IList<int> elementosMultimedia_oid;
[DataMember]
public System.Collections.Generic.IList<int> ElementosMultimedia_oid {
        get { return elementosMultimedia_oid; } set { elementosMultimedia_oid = value;  }
}

[DataMember]
public System.Collections.Generic.IList<int> ElementosMultimedia;
}
}
