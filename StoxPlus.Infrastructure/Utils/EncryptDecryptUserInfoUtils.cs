using System.Security.Cryptography;
using System.Text;

namespace StoxPlus.Infrastructure.Utils
{
    public static class EncryptDecryptUserInfoUtils
    {
        public static string EncryptUserInfo(string userInfoJson, string email, string serverSecret)
        {
            byte[] key = DeriveKey(email, serverSecret);

            using Aes aes = Aes.Create();
            aes.KeySize = 256;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = key;
            aes.GenerateIV();

            byte[] plainBytes = Encoding.UTF8.GetBytes(userInfoJson);

            using ICryptoTransform encryptor = aes.CreateEncryptor();
            byte[] cipherBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

            byte[] result = new byte[aes.IV.Length + cipherBytes.Length];
            Buffer.BlockCopy(aes.IV, 0, result, 0, aes.IV.Length);
            Buffer.BlockCopy(cipherBytes, 0, result, aes.IV.Length, cipherBytes.Length);

            return Convert.ToBase64String(result);
        }

        public static string DecryptUserInfo(string encryptData, string email, string serverSecret)
        {
            byte[] fullData = Convert.FromBase64String(encryptData);
            byte[] key = DeriveKey(email, serverSecret);

            using Aes aes = Aes.Create();
            aes.KeySize = 256;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = key;

            byte[] iv = new byte[16];
            byte[] cipherBytes = new byte[fullData.Length - 16];

            Buffer.BlockCopy(fullData, 0, iv, 0, 16);
            Buffer.BlockCopy(fullData, 16, cipherBytes, 0, cipherBytes.Length);

            aes.IV = iv;

            using ICryptoTransform decryptor = aes.CreateDecryptor();
            byte[] plainBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);

            return Encoding.UTF8.GetString(plainBytes);
        }

        private static byte[] DeriveKey(string email, string serverSecret)
        {
            string emailPart = email.Trim().ToLowerInvariant().Substring(0, Math.Min(10, email.Length));
            string input = emailPart + "|" + serverSecret;
            using SHA256 sha = SHA256.Create();
            return sha.ComputeHash(Encoding.UTF8.GetBytes(input));
        }
    }
}
