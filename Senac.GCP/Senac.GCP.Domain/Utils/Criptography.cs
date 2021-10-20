using System;
using System.Security.Cryptography;
using System.Text;

namespace Senac.GCP.Domain.Utils
{
    public static class Criptography
    {
        private const string securityKey = "gCp@&aN3r1s";

        public static string Encrypt(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Value is not defined in encrypt");
            }

            using var provider = new TripleDESCryptoServiceProvider();
            using var md5 = new MD5CryptoServiceProvider();
            var bytes = Encoding.ASCII.GetBytes(securityKey);
            provider.Key = md5.ComputeHash(bytes);
            provider.Mode = CipherMode.ECB;
            var encryptor = provider.CreateEncryptor();
            var buffer = Encoding.ASCII.GetBytes(value);
            var encryptorBytes = encryptor.TransformFinalBlock(buffer, 0, buffer.Length);
            string result = Convert.ToBase64String(encryptorBytes);
            return result;
        }

        public static string Decrypt(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Value is not defined in decrypt");
            }

            using var provider = new TripleDESCryptoServiceProvider();
            using var md5 = new MD5CryptoServiceProvider();
            var bytes = Encoding.ASCII.GetBytes(securityKey);
            provider.Key = md5.ComputeHash(bytes);
            provider.Mode = CipherMode.ECB;
            var decryptor = provider.CreateDecryptor();
            var buffer = Convert.FromBase64String(value);
            var decriptorBytes = decryptor.TransformFinalBlock(buffer, 0, buffer.Length);
            string result = Encoding.ASCII.GetString(decriptorBytes);
            return result;
        }
    }
}
