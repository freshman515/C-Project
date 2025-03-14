using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Extensions {
    public static class ExtensionString {
        public static string GetMD5(this string str) {
            if (string.IsNullOrWhiteSpace(str)) {
                return "";
            }
            var hash = MD5.Create().ComputeHash(Encoding.Default.GetBytes(str));
            return Convert.ToBase64String(hash);
        }

        public static string GenerateSalt(int length) {
            byte[] saltBytes = new byte[length];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create()) // 使用新的 RandomNumberGenerator
            {
                rng.GetBytes(saltBytes); // 填充 saltBytes 数组
            }
            return Convert.ToBase64String(saltBytes);
        }

        public static string HashPassword(string password, string salt) {
            using (SHA256 sha256 = SHA256.Create()) {
                byte[] combinedBytes = Encoding.UTF8.GetBytes(password + salt);
                byte[] hashBytes = sha256.ComputeHash(combinedBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
