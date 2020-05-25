//CLASE PRODUCTO
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        private int codigo;
        private string nombre;
        private Cliente cliente;

        public float PesoUnidad { get; set; }

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }


        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

    }
}