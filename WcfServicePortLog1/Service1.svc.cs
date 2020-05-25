using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Dominio;
using Repositorios;

namespace WcfServicePortLog1
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public bool AltaImportacion(int cantidad, DateTime fechaIngreso, DateTime fechaSalidaPrevista, int idProd, decimal precioProducto)
        {
            RepoImportacion repoImp = new RepoImportacion();
            Importacion impoNueva = new Importacion()
            {
                FechaIngreso = fechaIngreso,
                FechaSalida = fechaSalidaPrevista,
                Producto = FachadaDistribuidora.BuscarProductoPorId(Convert.ToString(idProd)),
                Cantidad = cantidad,
                PrecioPorUnidad = precioProducto
            };
            bool exito = repoImp.Alta(impoNueva);
            return exito;
        }

        public List<DTOProducto> TraerProductos()
        {
            List<DTOProducto> listaDtoProd = new List<DTOProducto>();
            List<Producto> listaProd = new List<Producto>();

            RepoProducto repo = new RepoProducto();
            listaProd = repo.TraerTodo();

            if (listaProd != null)
            {
                foreach (Producto unProd in listaProd)
                {
                    DTOProducto dtoProd = new DTOProducto();
                    dtoProd = new DTOProducto()
                    {
                        Codigo = unProd.Codigo,
                        Nombre = unProd.Nombre,
                        Cliente = unProd.Cliente,
                        PesoUnidad = unProd.PesoUnidad
                    };
                    listaDtoProd.Add(dtoProd);

                }
            }
            return listaDtoProd;
        }
    }
}
