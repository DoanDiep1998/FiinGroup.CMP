using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace StoxPlus.Library
{
    public static class Encryption
    {
        public static object FormsAuthentication { get; private set; }

        /// <summary>
        /// Gets the password key.
        /// </summary>
        /// <param name="passwordKey">The password key.</param>
        /// <param name="format">The format.</param>
        /// <returns></returns>
        private static string GetPasswordKey(Guid passwordKey, string format = "N")
        {
            return passwordKey.ToString(format);
        }

        public static string EncryptionSHA(this string password, Guid salt)
        {
            string concatSaltAndPassword = string.Concat(password, GetPasswordKey(salt));

            SHA1 sha = new SHA1CryptoServiceProvider();
            // This is one implementation of the abstract class SHA1.

            byte[] hased = sha.ComputeHash(Encoding.UTF8.GetBytes(concatSaltAndPassword));
            var sb = new StringBuilder();
            foreach (byte b in hased)
            {
                sb.AppendFormat("{0:x2}", b);
            };

            return sb.ToString();
        }
        public static string EncryptionSHA(this string password, string salt)
        {
            string concatSaltAndPassword = string.Concat(password, salt);

            SHA1 sha = new SHA1CryptoServiceProvider();
            // This is one implementation of the abstract class SHA1.

            byte[] hased = sha.ComputeHash(Encoding.UTF8.GetBytes(concatSaltAndPassword));
            var sb = new StringBuilder();
            foreach (byte b in hased)
            {
                sb.AppendFormat("{0:x2}", b);
            };

            return sb.ToString();

        }

        private readonly static string _key = "fiintrade_2024";

        public static string EncryptMD5(string text)
        {
            using (var md5 = MD5.Create())
            {
                using (var tdes = TripleDES.Create())
                {
                    tdes.Key = md5.ComputeHash(Encoding.UTF8.GetBytes(_key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = Encoding.UTF8.GetBytes(text);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }

        public static string DecryptMD5(string cipher)
        {
            using (var md5 = MD5.Create())
            {
                using (var tdes = TripleDES.Create())
                {
                    tdes.Key = md5.ComputeHash(Encoding.UTF8.GetBytes(_key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        byte[] cipherBytes = Convert.FromBase64String(cipher);
                        byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                        return Encoding.UTF8.GetString(bytes);
                    }
                }
            }
        }
    }
}
