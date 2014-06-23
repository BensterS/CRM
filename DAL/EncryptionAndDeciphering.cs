using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace DAL
{
    public class EncryptionAndDeciphering
    {
        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="pToEncrypt">加密字符串</param>
        /// <param name="sKey">密钥</param>
        /// <returns></returns>
        public static string string_Encrypt(string pToEncrypt, string sKey)
        {
            if (pToEncrypt == "") return "";
            if (sKey.Length < 8) sKey = sKey + "xuE29xWp";
            if (sKey.Length > 8) sKey = sKey.Substring(0, 8);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
            des.Key = ASCIIEncoding.Default.GetBytes(sKey);
            des.IV = ASCIIEncoding.Default.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="pToDecrypt">解密字符串</param>
        /// <param name="sKey">解密密钥</param>
        /// <param name="outstr">返回值</param>
        /// <returns></returns> 
        public static bool string_Decrypt(string pToDecrypt, string sKey, out string outstr)
        {
            if (pToDecrypt == "")
            {
                outstr = "";
                return true;
            };
            if (sKey.Length < 8) sKey = sKey + "xuE29xWp";
            if (sKey.Length > 8) sKey = sKey.Substring(0, 8);
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
                for (int x = 0; x < pToDecrypt.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }
                des.Key = ASCIIEncoding.Default.GetBytes(sKey);
                des.IV = ASCIIEncoding.Default.GetBytes(sKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                StringBuilder ret = new StringBuilder();
                outstr = System.Text.Encoding.Default.GetString(ms.ToArray());
                return true;
            }
            catch
            {
                outstr = "";
                return false;
            }
        }
    }
}
