//CLASE USUARIO
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Dominio
{
    public class Usuario
    {
        private int cedula;
        private string contrasenia;
        private string rol;

        public string Rol
        {
            get { return rol; }
            set { rol = value; }
        }


        public string Contrasenia
        {
            get { return contrasenia; }
            set { contrasenia = value; }
        }

        public int Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }

        public static bool ValidateCedula(string cedula)
        {
            var input = cedula;
            if (string.IsNullOrWhiteSpace(input))
            {
               return false;
            }
            var hasMiniMaxChars = new Regex(@".{7,9}");
            if (!hasMiniMaxChars.IsMatch(input))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ValidatePassword(string password)
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

        public static bool ValidarRol(string rolAsignado) {
            bool esValido = false;
            if (rolAsignado == "deposito" || rolAsignado == "admin")
            {
                esValido = true;
            }
            return esValido;
        }

    }
}
