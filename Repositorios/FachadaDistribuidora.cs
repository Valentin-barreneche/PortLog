using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorios
{
    public static class FachadaDistribuidora
    {
        public static bool AltaUsuario(int cedula, string contrasenia,string rol)
        {
            bool ret = false;
            Usuario usu = new Usuario()
            {
                Cedula= cedula,
                Contrasenia = contrasenia,
                Rol = rol,
                
            };
            RepoUsuario repoUsu= new RepoUsuario();
            ret = repoUsu.Alta(usu);
            return ret;
        }

        public static Usuario BuscarUsuarioPorCi(string ci)
        {
            
            Usuario usuarioEncontrado = new Usuario();
            RepoUsuario repoUsu = new RepoUsuario();
            usuarioEncontrado = repoUsu.BuscarPorId(Convert.ToInt32(ci));
            return usuarioEncontrado;
        }

        public static bool AltaCliente(string rut, string nombre, DateTime antiguedadFecha)
        {
            bool ret = false;
            Cliente clie = new Cliente()
            {
                Rut = rut,
                Nombre = nombre,
                AntiguedadFecha = antiguedadFecha

            };
            RepoCliente repoCli = new RepoCliente();
            ret = repoCli.Alta(clie);
            return ret;
        }

        public static List<Cliente> TraerClientes() {
            List<Cliente> clientes = new List<Cliente>();
            RepoCliente repoCli = new RepoCliente();
            clientes = repoCli.TraerTodo();
            return clientes;
        }

        public static Cliente TraerCliente(string rut) {
            Cliente cliente = new Cliente();
            RepoCliente repoCli = new RepoCliente();
            cliente = repoCli.BuscarPorId(Int32.Parse(rut));
            return cliente;
        }

        public static Cliente TraerClientePorRut(string rut)
        {
            Cliente cliente = new Cliente();
            RepoCliente repoCli = new RepoCliente();
            cliente = repoCli.BuscarPorRut(rut);
            return cliente;
        }

        public static bool AltaProducto(string nombre, Cliente cliente, float pesoUnidad) {

            bool ret = false;
            Producto prod = new Producto()
            {
                Nombre = nombre,
                Cliente = cliente,
                PesoUnidad = pesoUnidad

            };
            RepoProducto repoProd = new RepoProducto();
            ret = repoProd.Alta(prod);
            return ret;
        }

        public static Producto BuscarProductoPorId(string id)
        {

            Producto productoEncontrado = new Producto();
            RepoProducto repoProd = new RepoProducto();
            productoEncontrado = repoProd.BuscarPorId(Convert.ToInt32(id));
            return productoEncontrado;
        }

        public static List<Importacion> TraerImportaciones() {
            List<Importacion> importaciones = new List<Importacion>();
            RepoImportacion RepoImp = new RepoImportacion();
            importaciones = RepoImp.TraerTodo();
            return importaciones;
        }
        
        public static string GenerarArchivoCliente() {
            RepoCliente repoCli = new RepoCliente();
            string devolucion = repoCli.GenerarArchivo();
            return devolucion;
        }

        public static string GenerarArchivoDescuento()
        {
            RepoDescuento repoDesc = new RepoDescuento();
            string devolucion = repoDesc.GenerarArchivo();
            return devolucion;
        }

        public static string GenerarArchivoImportacion()
        {
            RepoImportacion repoImpo= new RepoImportacion();
            string devolucion = repoImpo.GenerarArchivo();
            return devolucion;
        }

        public static string GenerarArchivoProducto()
        {
            RepoProducto repoProd= new RepoProducto();
            string devolucion = repoProd.GenerarArchivo();
            return devolucion;
        }

        public static string GenerarArchivoUsuario()
        {
            RepoUsuario repoUsu = new RepoUsuario();
            string devolucion = repoUsu.GenerarArchivo();
            return devolucion;
        }
    }
}
