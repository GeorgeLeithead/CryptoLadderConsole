using System.Security.Cryptography;
using System.Text;

namespace CryptoLadder.Client {

    public static class Signature
    {
        public static string Create (string secret, string message) {
            var sigBits = Hmacsha256 (Encoding.UTF8.GetBytes (secret), Encoding.UTF8.GetBytes (message));
            return ByteArrayToString (sigBits);
        }

        private static byte[] Hmacsha256 (byte[] keyByte, byte[] messageBytes) {
            using (var hash = new HMACSHA256 (keyByte)) {
                return hash.ComputeHash (messageBytes);
            }
        }

        private static string ByteArrayToString (byte[] ba) {
            StringBuilder hex = new StringBuilder (ba.Length * 2);
            foreach (byte b in ba) {
                hex.AppendFormat ("{0:x2}", b);
            }

            return hex.ToString ();
        }
    }
}