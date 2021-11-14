using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Automanager.Core
{
    public class SercurityUtils
    {
        public static string EncryptMd5(string yourString)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            encrypt = md5.ComputeHash(encode.GetBytes(yourString));
            StringBuilder encryptdata = new StringBuilder();
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }

        //EncryptBase64: ma hoa base 64
        public static string EncryptBase64(string originalString, string key)
        {
            try
            {
                var bytes = Encoding.ASCII.GetBytes(key);
                if (string.IsNullOrEmpty(originalString))
                    throw new ArgumentNullException("The string which needs to be encrypted can not be null.");

                var cryptoProvider = new DESCryptoServiceProvider
                {
                    Padding = PaddingMode.PKCS7,
                    Mode = CipherMode.ECB,
                    Key = bytes,
                    IV = bytes
                };
                var memoryStream = new MemoryStream();
                var cryptoStream =
                    new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(), CryptoStreamMode.Write);

                var writer = new StreamWriter(cryptoStream);
                writer.Write(originalString);
                writer.Flush();
                cryptoStream.FlushFinalBlock();
                writer.Flush();

                return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            }
            catch
            {
                throw new Exception("EncryptBase64 Exception.");
            }
        }
        //giai ma
        public static string DecryptBase64(string cryptedString, string key)
        {
            try
            {
                var x = Encoding.ASCII.GetBytes(key);
                if (string.IsNullOrEmpty(cryptedString))
                    throw new ArgumentNullException("The string which needs to be decrypted can not be null.");

                var cryptoProvider = new DESCryptoServiceProvider
                {
                    Padding = PaddingMode.PKCS7,
                    Mode = CipherMode.ECB,
                    Key = x,
                    IV = x
                };
                var memoryStream = new MemoryStream(Convert.FromBase64String(cryptedString));
                var cryptoStream =
                    new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(), CryptoStreamMode.Read);
                var reader = new StreamReader(cryptoStream);

                return reader.ReadToEnd();
            }
            catch
            {
                throw new Exception("EncryptBase64 Exception.");
            }
        }
    }
}
