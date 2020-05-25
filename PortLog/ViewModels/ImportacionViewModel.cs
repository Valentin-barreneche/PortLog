using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PortLog.ViewModels
{
    public class ImportacionViewModel
    {

        [Display(Name = "Fecha de Ingreso de la importacion: ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Salida Prevista de la importacion: ")]
        public DateTime FechaSalidaPrevista { get; set; }

        [Display(Name = "Codigo del Producto importado: ")]
        public int CodigoProd { get; set; }

        [Display(Name = "Cantidad de productos importados: ")]
        public int Cantidad { get; set; }

        [Display(Name = "Precio de productos importados: ")]
        public decimal PrecioUnidad { get; set; }

    }
}