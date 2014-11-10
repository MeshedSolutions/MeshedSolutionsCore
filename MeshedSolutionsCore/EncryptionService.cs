using System.Security.Cryptography;
using System.Text;

namespace MeshedSolutionsCore
{
    public class EncryptionService
    {
        /// <summary>
        /// Creates a hash of the provided value
        /// </summary>
        /// <param name="password">Value to encrypt</param>
        /// <returns>Encrypted hash of the provided value</returns>
        public static string GetHash(string password)
        {
            MD5 md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }
    }
}
