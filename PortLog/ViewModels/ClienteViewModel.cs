using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace PortLog.ViewModels
{
    public class ClienteViewModel
    {

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Antiguedad del cliente: ")]
        public DateTime AntiguedadFecha { get; set; }
   
        [Display(Name = "Nombre del cliente: ")]
        public string Nombre { get; set; }


        [Display(Name = "Rut del cliente: ")]
        public string Rut { get; set; }

    }
}