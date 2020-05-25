using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;
using Repositorios;
using PortLog.ServiceReference1;
using System.ServiceModel;
using PortLog.ViewModels;

namespace PortLog.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            return Redirect("/usuario/index");
        }

        [HttpGet]
        public ActionResult AltaProducto() {
            
            if (Session["rol"] != null)
            {
                List<Cliente> listaClientes = new List<Cliente>();
                listaClientes = FachadaDistribuidora.TraerClientes();
                if (listaClientes != null)
                {
                    ViewBag.listaClientes = listaClientes;
                }
                return View();
            }
            else
            {
                return Redirect("/usuario/index");
            }

        }


        [HttpPost]
        public ActionResult AltaProducto(Producto producto, string rut)
        {
            List<Cliente> listaClientes = new List<Cliente>();
            if (Session["rol"] != null)
            {
                listaClientes = FachadaDistribuidora.TraerClientes();
                ViewBag.listaClientes = listaClientes;
                Cliente clienteAsociado = FachadaDistribuidora.TraerClientePorRut(rut);
                producto.Cliente = clienteAsociado;
                //controlar q peso sea > 0
                if (producto.PesoUnidad > 0 && producto.Nombre != null)
                {
                    bool exito = FachadaDistribuidora.AltaProducto(producto.Nombre, producto.Cliente, producto.PesoUnidad);
                    if (exito)
                    {
                        ViewBag.mensaje = "Producto agregado con exito";
                    }
                    else
                    {
                        ViewBag.mensaje = "Error";
                    }
                    return View(producto);
                }
                else
                {
                    ViewBag.mensaje = "El peso debe ser superior a cero y el producto debe tener un nombre.";
                    return View(producto);
                }

            }
            else {
                return Redirect("/usuario/index");
            }
            

        }


        [HttpGet]
        public ActionResult TraerProductos() {
            if (Session["rol"] != null)
            {
                #region Intento1
                Service1Client proxy = new Service1Client(); //este es el metodo con el que intentamos primero, y nos daba un error System.ServiceModel.EndpointNotFoundException
                proxy.Open();
                List<DTOProducto> listaDTOProd = proxy.TraerProductos().ToList();
                proxy.Close();
                List<ProductoViewModel> listaProd = new List<ProductoViewModel>();
                List<Importacion> listaImpor = FachadaDistribuidora.TraerImportaciones();
                foreach (DTOProducto dtoProd in listaDTOProd)
                {
                    int stockActual = 0;
                    foreach (Importacion impor1 in listaImpor)
                    {
                        if (impor1.Producto.Codigo == dtoProd.Codigo)
                        {
                            if (impor1.EsCalculable()) {
                                stockActual += impor1.Cantidad;
                            }
                        }
                    }
                    ProductoViewModel nuevoProd = new ProductoViewModel()
                    {
                        Codigo = dtoProd.Codigo,
                        Nombre = dtoProd.Nombre,
                        Stock = stockActual
                    };
                    listaProd.Add(nuevoProd);
                }
                return View(listaProd);
                #endregion
            }
            else 
            {
                return Redirect("/usuario/index");
            }

        }

    }
}