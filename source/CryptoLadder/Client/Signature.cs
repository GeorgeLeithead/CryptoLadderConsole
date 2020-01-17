using System.Security.Cryptography;
using System.Text;

namespace CryptoLadder.Client
{
    /// <summary>Creating an encryption signature.</summary>
    public static class Signature
    {
        /// <summary>Create a signature.</summary>
        /// <param name="secret">Secret key.</param>
        /// <param name="message">Message to encrypt.</param>
        /// <returns>Encrypted message.</returns>
        public static string Create(string secret, string message)
        {
            byte[] sigBits = Hmacsha256(Encoding.UTF8.GetBytes(secret), Encoding.UTF8.GetBytes(message));
            return ByteArrayToString(sigBits);
        }

        private static byte[] Hmacsha256(byte[] keyByte, byte[] messageBytes)
        {
            using HMACSHA256 hash = new HMACSHA256(keyByte);
            return hash.ComputeHash(messageBytes);
        }

        private static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
            {
                hex.AppendFormat("{0:x2}", b);
            }

            return hex.ToString();
        }
    }
}