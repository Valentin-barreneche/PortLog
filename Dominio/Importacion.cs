//CLASE IMPORTACION
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Importacion
    {
        private DateTime fechaIngreso;
        private DateTime fechaSalidaPrevista;
        private Producto producto;
        private int cantidad;
        private int codigoImp;
        public decimal PrecioPorUnidad { get; set; }

        public DateTime FechaSalida
        {
            get { return fechaSalidaPrevista; }
            set { fechaSalidaPrevista = value; }
        }
        public int CodigoImp
        {
            get { return codigoImp; }
            set { codigoImp= value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }


        public Producto Producto
        {
            get { return producto; }
            set { producto = value; }
        }


        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }

        public decimal CalcularCosto() {
            int cantidadDias = 0;
            cantidadDias = ((TimeSpan)(fechaSalidaPrevista - fechaIngreso)).Days;
            decimal costo = Cantidad * PrecioPorUnidad * cantidadDias;
            return costo;
        }

        public bool EsCalculable() {
            bool esCalculable = false;            
            if (fechaIngreso < DateTime.Now && fechaSalidaPrevista > DateTime.Now) {
                esCalculable = true;
            }
            return esCalculable;
        }

       
    }
}
