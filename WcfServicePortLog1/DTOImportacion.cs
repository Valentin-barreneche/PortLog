using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using Dominio;

namespace WcfServicePortLog1
{
    [DataContract]
    public class DTOImportacion
    {
        [DataMember]
        public int CodigoImp { get; set; }

        [DataMember]
        public int Cantidad { get; set; }

        [DataMember]
        public DateTime FechaIngreso { get; set; }

        [DataMember]
        public DateTime FechaSalidaPrevista { get; set; }

        [DataMember]
        public int IdProd { get; set; }

    }
}