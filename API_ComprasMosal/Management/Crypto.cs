using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ComprasMosal.Management
{
    public class Crypto
    {
        public static string Encrypt(string _cadenaAencriptar)
        {
            try
            {
                byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
                return Convert.ToBase64String(encryted);
            }
            catch (Exception)
            {
                return _cadenaAencriptar;
            }
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public static string Decrypt(string _cadenaAdesencriptar)
        {
            try
            {
                byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
                return System.Text.Encoding.Unicode.GetString(decryted);
            }
            catch (Exception)
            {
                return _cadenaAdesencriptar;
            }
        }
    }
}
