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
    public class RepoCliente : IRepositorio<Cliente>
    {
        public bool Alta(Cliente obj)
        {
                bool ret = false;

                    //CAMBIAR XXXX POR LO QUE CORRESPONDA!!!!!!!
                    string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=PortLog5; Integrated Security=SSPI;";
                    SqlConnection con = new SqlConnection(strCon);

                    string sql = "insert into Clientes(rut, nombreCli, antiguedadFecha) values(@rut, @nombreCli, @antiguedadFecha);";
                    SqlCommand com = new SqlCommand(sql, con);

                    com.Parameters.AddWithValue("@rut", obj.Rut);
                    com.Parameters.AddWithValue("@nombreCli", obj.Nombre);
                    com.Parameters.AddWithValue("@antiguedadFecha", obj.AntiguedadFecha);

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

        public Cliente BuscarPorId(int rut)
        {
            Cliente cli = null;
            string rutI = rut.ToString();
            //CAMBIAR XXXX POR LO QUE CORRESPONDA!!!!!!!
            string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=PortLog5; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "select * from Clientes where rut=@rut;";
            SqlCommand com = new SqlCommand(sql, con);

            com.Parameters.AddWithValue("@rut", rutI);

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    cli = new Cliente
                    {
                        Rut = reader.GetString(0),
                        Nombre = reader.GetString(1),
                        AntiguedadFecha = reader.GetDateTime(2)
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

            return cli;
        }

        public string GenerarArchivo()
        {
            string devolucion = "";
            //CAMBIAR XXXX POR LO QUE CORRESPONDA!!!!!!!
            string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=PortLog5; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "select * from Clientes;";
            SqlCommand com = new SqlCommand(sql, con);

            try
            {
                

                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    devolucion += reader.GetString(0) + "#" + reader.GetString(1) + "#" + reader.GetDateTime(2).ToString() + "\n" ;
                    
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

        public bool Modificacion(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> TraerTodo()
        {
            List<Cliente> clientes = new List<Cliente>();

            //CAMBIAR XXXX POR LO QUE CORRESPONDA!!!!!!!
            string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=PortLog5; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "select * from Clientes";
            SqlCommand com = new SqlCommand(sql, con);

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cli = new Cliente
                    {
                        Rut = reader.GetString(0),
                        Nombre = reader.GetString(1),
                        AntiguedadFecha = reader.GetDateTime(2)
                    };

                    clientes.Add(cli);
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

            return clientes;
        }

        public Cliente BuscarPorRut(string rut)
        {
            Cliente cli = null;
           
            //CAMBIAR XXXX POR LO QUE CORRESPONDA!!!!!!!
            string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=PortLog5; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "select * from Clientes where rut=@rut;";
            SqlCommand com = new SqlCommand(sql, con);

            com.Parameters.AddWithValue("@rut", rut);

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    cli = new Cliente
                    {
                        Rut = reader.GetString(0),
                        Nombre = reader.GetString(1),
                        AntiguedadFecha = reader.GetDateTime(2)
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

            return cli;
        }

    }
}
