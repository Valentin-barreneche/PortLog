using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;
using Repositorios;
using PortLog.ViewModels;


namespace PortLog.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return Redirect("/usuario/index");
        }

        [HttpGet]
        public ActionResult Alta()
        {
            if (Session["rol"] != null)
            {
                ClienteViewModel nuevoCliente = new ClienteViewModel();
                return View(nuevoCliente);
            }
            else
            {
                return Redirect("/usuario/index");
            }
        }

        [HttpPost]
        public ActionResult Alta(ClienteViewModel cliente)
        {
            if (cliente != null) {


                if (cliente.Nombre != null && cliente.AntiguedadFecha != null && cliente.Rut != null)
                {
                    if (FachadaDistribuidora.TraerClientePorRut(cliente.Rut) == null)
                    {
                        if (cliente.Nombre != "" && cliente.Rut.Length == 12)
                        {
                            bool exito = FachadaDistribuidora.AltaCliente(cliente.Rut, cliente.Nombre, cliente.AntiguedadFecha);
                            if (exito)
                            {
                                ViewBag.mensaje = "Cliente agregado con exito.";
                            }
                            else
                            {
                                ViewBag.mensaje = "Error, asegurese que el RUT tenga 12 digitos.";
                            }
                        }
                        else
                        {
                            ViewBag.mensaje = "Error, asegurse que el RUT tenga 12 digitos.";
                        }
                    }
                    else {
                        ViewBag.mensaje = "El cliente ya existe, ingrese otro RUT.";
                    }

                }
                else
                {
                    ViewBag.mensaje = "Error.";
                }

            }
            return View(cliente);
        }

    }
}