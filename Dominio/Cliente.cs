//CLASE CLIENTE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente
    {
        private string rut;
        private string nombre;
        private DateTime antiguedadFecha;
        public DateTime AntiguedadFecha
        {
            get { return antiguedadFecha;}
            set { antiguedadFecha = value;} 
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        public string Rut
        {
            get { return rut; }
            set { rut = value; }
        }

        public int CantidadDias() {
            int i = 0;
            TimeSpan iT = DateTime.Today - antiguedadFecha;
            i = iT.Days;
            return i;
        }

    }
}
