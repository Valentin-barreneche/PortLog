//CLASE DESCUENTO
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Descuento
    {
        public int AntiguedadAplicable { get; set; }
        public decimal DescuentoAplicable { get; set; }

        public decimal ComisionDiaria { get; set; }

    }
}
