using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PortLog.ViewModels
{
    public class ProductoViewModel
    {
        [Display(Name = "Codigo del Producto: ")]
        public int Codigo { get; set; }
      
        [Display(Name = "Nombre del Producto: ")]
        public string Nombre { get; set; }
       
        [Display(Name = "Stock del Producto: ")]
        public int Stock { get; set; }
        
    } 
}

/*public int Codigo { get; set; }
        [Display(Name = "Codigo del Producto: ")]

        public string Nombre { get; set; }
        [Display(Name = "Nombre del Producto: ")]

        public int Stock { get; set; }
        [Display(Name = "Stock del Producto: ")]
*/