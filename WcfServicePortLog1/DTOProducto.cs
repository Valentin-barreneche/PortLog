using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using Dominio;

namespace WcfServicePortLog1
{
    [DataContract]
    public class DTOProducto
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public Cliente Cliente { get; set; }
        [DataMember]
        public float PesoUnidad { get; set; }

    }
}