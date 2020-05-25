using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;

namespace Repositorios
{
    public class RepoImportacion : IRepositorio<Importacion>
    {
        public bool Alta(Importacion obj)
        {
            bool ret = false;

            //CAMBIAR XXXX POR LO QUE CORRESPONDA!!!!!!!
            string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=PortLog5; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "insert into Importaciones (cantidad, fechaIngreso, fechaSalidaPrevista, IdProd, precioPorUnidad) values(@cant, @fechaI, @fechaS, @idProd, @precioPorUnidad);";
            SqlCommand com = new SqlCommand(sql, con);

            com.Parameters.AddWithValue("@cant", obj.Cantidad);
            com.Parameters.AddWithValue("@fechaI", obj.FechaIngreso);
            com.Parameters.AddWithValue("@fechaS", obj.FechaSalida);
            com.Parameters.AddWithValue("@idProd", obj.Producto.Codigo);
            com.Parameters.AddWithValue("@precioPorUnidad", obj.PrecioPorUnidad);


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

        public Importacion BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public string GenerarArchivo()
        {
            string devolucion = "";
            //CAMBIAR XXXX POR LO QUE CORRESPONDA!!!!!!!
            string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=PortLog5; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "select * from Importaciones;";
            SqlCommand com = new SqlCommand(sql, con);

            try
            {
                
                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    devolucion+= reader.GetInt32(0).ToString() + "#" + reader.GetInt32(1).ToString() + "#" + reader.GetDecimal(2).ToString() + "#" + reader.GetDateTime(3).ToString() + "#" + reader.GetDateTime(4).ToString() + "#" + reader.GetInt32(5).ToString() + "\n";

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

        public bool Modificacion(Importacion obj)
        {
            throw new NotImplementedException();
        }

        public List<Importacion> TraerTodo()
        {
            List<Importacion> importaciones = new List<Importacion>();

            //CAMBIAR XXXX POR LO QUE CORRESPONDA!!!!!!!
            string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=PortLog5; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "select * from Importaciones;";
            SqlCommand com = new SqlCommand(sql, con);

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {

                    Importacion importacion = new Importacion
                    {
                        CodigoImp = reader.GetInt32(0),
                        Cantidad = reader.GetInt32(1),
                        PrecioPorUnidad= reader.GetDecimal(2),
                        FechaIngreso = reader.GetDateTime(3),
                        FechaSalida = reader.GetDateTime(4),
                        Producto = FachadaDistribuidora.BuscarProductoPorId((Convert.ToString(reader.GetInt32(5))))
                        
                    };

                    importaciones.Add(importacion);

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

            return importaciones;
        }

       
    }
}
