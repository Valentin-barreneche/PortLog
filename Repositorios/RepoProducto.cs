using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data;
using System.Data.SqlClient;
using Repositorios;
using System.Globalization;
using System.IO;

namespace Repositorios
{
    public class RepoProducto : IRepositorio<Producto>
    {
        public bool Alta(Producto obj)
        {

                bool ret = false;

                //CAMBIAR XXXX POR LO QUE CORRESPONDA!!!!!!!
                string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=PortLog5; Integrated Security=SSPI;";
                SqlConnection con = new SqlConnection(strCon);

                string sql = "insert into Productos(nombreProd, pesoUnidad, rut) values(@nom, @pesoU, @rut);";
                SqlCommand com = new SqlCommand(sql, con);

                com.Parameters.AddWithValue("@nom", obj.Nombre);
                com.Parameters.AddWithValue("@pesoU", obj.PesoUnidad);
                com.Parameters.AddWithValue("@rut", obj.Cliente.Rut);

                try
                {
                    con.Open();
                    int afectadas = com.ExecuteNonQuery();
                    con.Close();

                    ret = afectadas == 1;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (con.State == ConnectionState.Open) con.Close();
                }

                return ret;

        }

        public bool Baja(int id)
        {
            throw new NotImplementedException();
        }

        public Producto BuscarPorId(int id)
        {
            Producto productoExistente = null;

            //CAMBIAR XXXX POR LO QUE CORRESPONDA!!!!!!!
            string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=PortLog5; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "select * from Productos where IdProd=@id;";
            SqlCommand com = new SqlCommand(sql, con);

            com.Parameters.AddWithValue("@id", id);

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    productoExistente = new Producto
                    {
                        Codigo = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        PesoUnidad = (float)reader.GetDouble(2),
                        Cliente = FachadaDistribuidora.TraerClientePorRut(reader.GetString(3))
                    };
                }
                con.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
            return productoExistente;
        }

        public string GenerarArchivo()
        {
            string devolucion = "";
            //CAMBIAR XXXX POR LO QUE CORRESPONDA!!!!!!!
            string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=PortLog5; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "select * from Productos;";
            SqlCommand com = new SqlCommand(sql, con);

            try
            {
                
                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    devolucion+= reader.GetInt32(0).ToString() + "#" + reader.GetString(1) + "#" + reader.GetDouble(2).ToString() + "#" + reader.GetString(3) + "\n";
                    
                }
                con.Close();
                
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }

            return devolucion;
        }

        public bool Modificacion(Producto obj)
        {
            throw new NotImplementedException();
        }

        public List<Producto> TraerTodo()
        {
            List<Producto> productos = new List<Producto>();

            //CAMBIAR XXXX POR LO QUE CORRESPONDA!!!!!!!
            string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=PortLog5; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "select * from Productos;";
            SqlCommand com = new SqlCommand(sql, con);

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();
                
                while (reader.Read())
                {
                    
                    Producto producto = new Producto
                    {
                        Codigo = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        PesoUnidad = (float)reader.GetDouble(2),
                        Cliente = FachadaDistribuidora.TraerClientePorRut(reader.GetString(3))
                    };
                    
                    productos.Add(producto);
                    
                }
                con.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }

            return productos;
        }
    }
}