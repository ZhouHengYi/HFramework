using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace H.Core.Utility
{
    public class EncryHelper
    {
        // Fields
        private static byte[] desIV = Encoding.Unicode.GetBytes("Oversea3");
        private static byte[] desKey = Encoding.Unicode.GetBytes("Nesc.Oversea");

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="key"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public string DoEncrypt(string plainText, string key, Encoding encoding)
        {
            desKey = Encoding.Unicode.GetBytes(key);
            MemoryStream stream = new MemoryStream(200);
            stream.SetLength(0L);
            byte[] bytes = Encoding.Unicode.GetBytes(plainText);
            Rijndael rijndael = new RijndaelManaged();
            CryptoStream stream2 = new CryptoStream(stream, rijndael.CreateEncryptor(desKey, desIV), CryptoStreamMode.Write);
            stream2.Write(bytes, 0, bytes.Length);
            stream2.FlushFinalBlock();
            stream.Flush();
            stream.Seek(0L, SeekOrigin.Begin);
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            stream2.Close();
            stream.Close();
            string retStr = Convert.ToBase64String(buffer, 0, buffer.Length);

            retStr = retStr.Replace("=", "{z1}");
            retStr = retStr.Replace("&", "{z2}");
            return retStr;
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="encryptedText"></param>
        /// <param name="key"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public string DoDecrypt(string encryptedText, string key, Encoding encoding)
        {
            try
            {
                desKey = Encoding.Unicode.GetBytes(key);
                encryptedText = encryptedText.Replace("{z1}", "=");
                encryptedText = encryptedText.Replace("{z2}", "&");
                MemoryStream stream = new MemoryStream(200);
                stream.SetLength(0L);
                byte[] buffer = Convert.FromBase64String(encryptedText);
                Rijndael rijndael = new RijndaelManaged();
                rijndael.KeySize = 0x100;
                CryptoStream stream2 = new CryptoStream(stream, rijndael.CreateDecryptor(desKey, desIV), CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                stream.Flush();
                stream.Seek(0L, SeekOrigin.Begin);
                byte[] buffer2 = new byte[stream.Length];
                stream.Read(buffer2, 0, buffer2.Length);
                stream2.Close();
                stream.Close();
                return Encoding.Unicode.GetString(buffer2);
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
