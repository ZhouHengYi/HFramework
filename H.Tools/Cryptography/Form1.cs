using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cryptography
{
    public partial class Cryptography : Form
    {
        public Cryptography()
        {
            InitializeComponent();
        }

        private void btn_Encrypt_Click(object sender, EventArgs e)
        {
            textBox2.Text = Encrypt(textBox1.Text);
        }

        private void btn_Decrypt_Click(object sender, EventArgs e)
        {
            textBox2.Text = Decrypt(textBox1.Text);
        }


        #region Encrypt & Decrypt

        private const string m_LongDefaultKey = "Nesc.Oversea";
        private const string m_LongDefaultIV = "Oversea3";

        internal static string Encrypt(string encryptionText)
        {
            string result = string.Empty;

            if (encryptionText.Length > 0)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(encryptionText);
                byte[] inArray = Encrypt(bytes);
                if (inArray.Length > 0)
                {
                    result = Convert.ToBase64String(inArray);
                }


            }
            return result;

        }

        internal static string Decrypt(string encryptionText)
        {
            string result = string.Empty;

            if (encryptionText.Length > 0)
            {
                byte[] bytes = Convert.FromBase64String(encryptionText);
                byte[] inArray = Decrypt(bytes);
                if (inArray.Length > 0)
                {
                    result = Encoding.Unicode.GetString(inArray);
                }

            }
            return result;

        }

        private static byte[] Encrypt(byte[] bytesData)
        {
            byte[] result = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                ICryptoTransform cryptoServiceProvider = CreateAlgorithm().CreateEncryptor();
                using (CryptoStream stream2 = new CryptoStream(stream, cryptoServiceProvider, CryptoStreamMode.Write))
                {
                    try
                    {
                        stream2.Write(bytesData, 0, bytesData.Length);
                        stream2.FlushFinalBlock();
                        stream2.Close();
                        result = stream.ToArray();
                    }
                    catch (Exception exception)
                    {
                        throw new Exception("Error while writing decrypted data to the stream: \n" + exception.Message);
                    }
                }
                stream.Close();
            }
            return result;
        }

        private static byte[] Decrypt(byte[] bytesData)
        {
            byte[] result = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                ICryptoTransform cryptoServiceProvider = CreateAlgorithm().CreateDecryptor();
                using (CryptoStream stream2 = new CryptoStream(stream, cryptoServiceProvider, CryptoStreamMode.Write))
                {
                    try
                    {
                        stream2.Write(bytesData, 0, bytesData.Length);
                        stream2.FlushFinalBlock();
                        stream2.Close();
                        result = stream.ToArray();
                    }
                    catch (Exception exception)
                    {
                        throw new Exception("Error while writing encrypted data to the stream: \n" + exception.Message);
                    }
                }
                stream.Close();
            }
            return result;
        }

        private static Rijndael CreateAlgorithm()
        {
            Rijndael rijndael = new RijndaelManaged();
            rijndael.Mode = CipherMode.CBC;
            byte[] key = Encoding.Unicode.GetBytes(m_LongDefaultKey);
            byte[] iv = Encoding.Unicode.GetBytes(m_LongDefaultIV);
            rijndael.Key = key;
            rijndael.IV = iv;
            return rijndael;
        }

        #endregion
    }
}
