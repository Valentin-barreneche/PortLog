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
    public class RepoUsuario : IRepositorio<Usuario>
    {
        public bool Alta(Usuario obj)
        {
            {
                bool ret = false;

                if (ValidarRol(obj.Rol) && ValidateCedula(Convert.ToString(obj.Cedula)) && ValidatePassword(obj.Contrasenia)) {

                    //CAMBIAR XXXX POR LO QUE CORRESPONDA!!!!!!!
                    string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=PortLog5; Integrated Security=SSPI;";
                    SqlConnection con = new SqlConnection(strCon);

                    string sql = "insert into Usuarios(cedula, contraseña, rol) values(@cedula, @pw, @rol);";
                    SqlCommand com = new SqlCommand(sql, con);

                    com.Parameters.AddWithValue("@cedula", obj.Cedula);
                    com.Parameters.AddWithValue("@pw", obj.Contrasenia);
                    com.Parameters.AddWithValue("@rol", obj.Rol);

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

                }
                
                return ret;
            }

        }

        public bool Baja(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorId(int cedulaEnviada)
        {
            Usuario usuarioExistente = null;

            //CAMBIAR XXXX POR LO QUE CORRESPONDA!!!!!!!
            string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=PortLog5; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "select * from Usuarios where cedula=@ci;";
            SqlCommand com = new SqlCommand(sql, con);

            com.Parameters.AddWithValue("@ci", cedulaEnviada);

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    usuarioExistente = new Usuario
                    {
                        Cedula = reader.GetInt32(0),
                        Contrasenia = reader.GetString(1),
                        Rol = reader.GetString(2)
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
            return usuarioExistente;
        }

        public bool Modificacion(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> TraerTodo()
        {
            throw new NotImplementedException();
        }

        private static bool ValidateCedula(string cedula)
        {
            var input = cedula;
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }
            var hasMiniMaxChars = new Regex(@".{6,15}");
            if (!hasMiniMaxChars.IsMatch(input))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static bool ValidatePassword(string password)
        {
            var input = password;
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{6,15}");
            var hasLowerChar = new Regex(@"[a-z]+");

            if (!hasLowerChar.IsMatch(input))
            {
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static bool ValidarRol(string rolAsignado)
        {
            bool esValido = false;
            if (rolAsignado == "deposito" || rolAsignado == "admin")
            {
                esValido = true;
            }
            return esValido;
        }

        public string GenerarArchivo()
        {
            string devolucion = "";
            //CAMBIAR XXXX POR LO QUE CORRESPONDA!!!!!!!
            string strCon = "Data Source=(local)\\SQLEXPRESS; Initial Catalog=PortLog5; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "select * from Usuarios;";
            SqlCommand com = new SqlCommand(sql, con);

            try
            {
               
                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    devolucion += reader.GetInt32(0).ToString() + "#" + reader.GetString(1) + "#" + reader.GetString(2)+ "\n";
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
    }

}
