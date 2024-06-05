using System.Security.Cryptography;
using System.Text;

namespace UsuariosApp.Domain.Helpers
{
    /// <summary>
    /// Classe para criptografia padrão SHA256
    /// </summary>
    public class SHA256CryptoHelper
    {
        /// <summary>
        /// Gera o hash SHA256 de uma string de entrada.
        /// </summary>
        /// <param name="input">A string de entrada a ser criptografada.</param>
        /// <returns>O hash SHA256 como uma string hexadecimal.</returns>
        public static string ComputeHash(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException(nameof(input), "Input cannot be null or empty");

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                // Convertendo o array de bytes em uma string hexadecimal
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
