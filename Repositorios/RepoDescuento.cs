using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Repositorios
{
    public class RepoDescuento : IRepositorio<Descuento>
    {
        public bool Alta(Descuento obj)
        {
            throw new NotImplementedException();
        }

        public bool Baja(int id)
        {
            throw new NotImplementedException();
        }

        public Descuento BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public string GenerarArchivo()
        {
            string devolucion = "";
            //CAMBIAR XXXX POR LO QUE CORRESPONDA!!!!!!!
            string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=PortLog5; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "select * from Descuentos;";
            SqlCommand com = new SqlCommand(sql, con);

            try
            {
                

                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    devolucion += reader.GetInt32(0).ToString() + "#" + reader.GetDecimal(1).ToString() + "#" + reader.GetDecimal(2) + "\n";
                                        
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

        public bool Modificacion(Descuento obj)
        {
            throw new NotImplementedException();
        }

        public List<Descuento> TraerTodo()
        {
            List<Descuento> descuentos = new List<Descuento>();

            //CAMBIAR XXXX POR LO QUE CORRESPONDA!!!!!!!
            string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=PortLog5; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "select * from Descuentos";
            SqlCommand com = new SqlCommand(sql, con);

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Descuento desc = new Descuento
                    {
                        AntiguedadAplicable = reader.GetInt32(0),
                        DescuentoAplicable = reader.GetDecimal(1),
                        ComisionDiaria = reader.GetDecimal(2)
                    };

                    descuentos.Add(desc);
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

            return descuentos;
        }
    }
}
