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
    public class ImportacionController : Controller
    {


        [HttpGet]
        public ActionResult Index(int id)
        {
            if (Session["rol"] != null)
            {
                if (Session["rol"].ToString() == "deposito")
                {
                    Producto productoImportado = FachadaDistribuidora.BuscarProductoPorId(Convert.ToString(id));
                    ViewBag.NombreProd = productoImportado.Nombre;
                    ViewBag.CodigoProd = productoImportado.Codigo;
                    //armar objeto ImportacionViewModel y pasarlo con parametro pal id
                    ImportacionViewModel imporV = new ImportacionViewModel();
                    imporV.CodigoProd = id;
                    return View(imporV);
                }
                else
                {
                    return Redirect("/usuario/Index");
                }

            }
            else
            {
                return Redirect("/usuario/Index");
            }

        }

        [HttpPost]
        public ActionResult Index(ImportacionViewModel importacionN, int id)
        {
            Producto productoImportado = FachadaDistribuidora.BuscarProductoPorId(Convert.ToString(id));
            ViewBag.NombreProd = productoImportado.Nombre;
            ViewBag.CodigoProd = productoImportado.Codigo;
            if (Session["rol"].ToString() == "deposito")
            {
                if (importacionN != null)
                {
                    if (importacionN.FechaSalidaPrevista > importacionN.FechaIngreso)
                    {
                        if (importacionN.Cantidad > 0 && importacionN.PrecioUnidad > 0)
                        {
                            Service1Client proxy = new Service1Client();
                            proxy.Open();
                            bool exito = proxy.AltaImportacion(importacionN.Cantidad, importacionN.FechaIngreso, importacionN.FechaSalidaPrevista, importacionN.CodigoProd, importacionN.PrecioUnidad);
                            ViewBag.Mensaje = "Exito";
                        }
                        else
                        {
                            ViewBag.Mensaje = "La cantidad de productos importados y su precio deben ser superior a cero.";
                        }

                    }
                    else
                    {
                        ViewBag.Mensaje = "La Fecha de Salida Prevista no puede ser anterior a la Fecha de Ingreso";
                    }
                }
                else
                {
                    ViewBag.Mensaje = "Error";
                }
                return View(importacionN);
            }
            else
            {
                return Redirect("/usuario/Index");
            }
        }


        [HttpGet]
        public ActionResult PrevisionGanancia()
        {

            if (Session["rol"] != null)
            {
                if (Session["rol"].ToString() == "admin")
                {
                    RepoCliente repoCli = new RepoCliente();
                    List<Cliente> listaCli = repoCli.TraerTodo();
                    return View(listaCli);
                }
                else
                {
                    return Redirect("/usuario/Index");
                }

            }
            else
            {
                return Redirect("/usuario/Index");
            }

        }

        [HttpGet]
        public ActionResult CalcularGanancia(string id)
        {
            
            if (Session["rol"] != null)
            {
                if (Session["rol"].ToString() == "admin")
                {
                    //aca conseguimos todos los decuentos de la base de dato y los guardamos en un objeto
                    RepoDescuento repoDes = new RepoDescuento();
                    List<Descuento> descuentos = repoDes.TraerTodo();
                    Descuento descuentoObj = descuentos[0];
                    int antiguedadAplicableEnDias = descuentoObj.AntiguedadAplicable;
                    decimal comisionDiaria = descuentoObj.ComisionDiaria;
                    decimal descuentoAplicable = descuentoObj.DescuentoAplicable;

                    //aca creamos el objeto cliente
                    RepoCliente repoCli = new RepoCliente();
                    Cliente cliente = repoCli.BuscarPorRut(id);

                    //aca conseguimos la lista de todas las importaciones de la base de datos
                    decimal costoTotal = 0;
                    RepoImportacion repoImp = new RepoImportacion();
                    List<Importacion> listaImp = repoImp.TraerTodo();

                    //aca filtramos todas las importaciones por las pertinentes a un cliente en particular
                    List<Importacion> importacionesPorCliente = new List<Importacion>();
                    foreach (Importacion impo1 in listaImp)
                    {
                        if (impo1.Producto.Cliente.Rut == id.ToString())
                        {
                            importacionesPorCliente.Add(impo1);
                        }
                    }

                    //aca filtramos las importaciones por aquellas q estan en el rango de fechas que aplica para el calculo
                    // la fecha de ingreso tiene que ser anterior a la fecha de hoy. Y fecha de salida mayor a la de hoy. 
                    List<Importacion> importacionesCalculables = new List<Importacion>();
                    foreach (Importacion impo2 in importacionesPorCliente)
                    {
                        if (impo2.EsCalculable())
                        {
                            importacionesCalculables.Add(impo2);
                        }
                    }

                    //aca calculamos el costo de todas las importaciones
                    foreach (Importacion impo3 in importacionesCalculables)
                    {
                        costoTotal += impo3.CalcularCosto();
                    }
                    costoTotal = costoTotal * ((comisionDiaria) / 100);

                    //aca vemos si aplica descuento por antiguedad, en cuyo caso, lo aplicamos
                    if (cliente.CantidadDias() >= antiguedadAplicableEnDias)
                    {
                        costoTotal = costoTotal - (costoTotal * ((descuentoAplicable) / 100));
                    }
                    ViewBag.Mensaje = costoTotal;
                    return View(cliente);
                } 
            }
            else
            {
                return Redirect("/usuario/Index");
            }
           
            return Redirect("/usuario/Index");
        }
    }
}