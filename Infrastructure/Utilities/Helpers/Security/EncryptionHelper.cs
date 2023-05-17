using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Dashboard.Common.Helpers.Security
{
    public class EncryptionHelper
    {
        public const string EncryptionKey = "KA@DF$5&";

        public static string DecryptString(string stringToDecrypt)
        {
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
            byte[] inputByteArray = new byte[stringToDecrypt.Length + 1];
            try
            {
                stringToDecrypt = stringToDecrypt.Replace("@@", "+").Replace("$$", "/"); ;
                byte[] key = Encoding.UTF8.GetBytes(EncryptionKey);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(stringToDecrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                Encoding encoding = Encoding.UTF8;
                string result = encoding.GetString(ms.ToArray());

                return result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static List<string> DecryptListString(List<string> list)
        {
            List<string> decryptedValues = new List<string>();
            foreach (var item in list)
            {
                string stringToDecrypt = item;

                byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
                byte[] inputByteArray = new byte[stringToDecrypt.Length + 1];
                try
                {
                    stringToDecrypt = stringToDecrypt.Replace("@@", "+").Replace("$$", "/"); ;
                    byte[] key = Encoding.UTF8.GetBytes(EncryptionKey);
                    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                    inputByteArray = Convert.FromBase64String(stringToDecrypt);
                    MemoryStream ms = new MemoryStream();
                    CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    Encoding encoding = Encoding.UTF8;
                    string result = encoding.GetString(ms.ToArray());

                    decryptedValues.Add(result);
                }
                catch (Exception e)
                {
                    continue;
                }
            }
            return decryptedValues;
        }

        public static string EncryptString(string stringToEncrypt)
        {
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
            try
            {

                byte[] key = Encoding.UTF8.GetBytes(EncryptionKey);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                string result = Convert.ToBase64String(ms.ToArray());
                result = result.Replace("+", "@@").Replace("/", "$$");
                return result;

            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        #region AES encryption
        /// <summary>
        /// This method makes encryption data for security 
        /// </summary>
        /// <param name="toEncrypt">Input data you want to work with encryption example: Password</param>
        /// <param name="encryptKey">key that will use to encrypt</param>
        /// <param name="logPath">path for log file</param>
        /// <param name="useHashing">if useHashing=true Doing encryption Uses Encode UTF8 else The encryption process does not</param>
        /// <returns></returns>
        public static string EncryptAES(string toEncrypt, bool useHashing = true)
        {
            #region Vars
            string returnvalue = string.Empty;
            byte[] keyArray;
            #endregion

            try
            {
                if (!string.IsNullOrWhiteSpace(toEncrypt) && !string.IsNullOrWhiteSpace(EncryptionKey))
                {
                    byte[] toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);
                    if (useHashing)
                    {
                        MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                        keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(EncryptionKey));
                        hashmd5.Clear();
                    }
                    else
                        keyArray = Encoding.UTF8.GetBytes(EncryptionKey);
                    if (keyArray != null && keyArray.Count() > new int())
                    {
                        AesCryptoServiceProvider tdes = new AesCryptoServiceProvider();
                        tdes.Key = keyArray;
                        tdes.Mode = CipherMode.ECB;
                        tdes.Padding = PaddingMode.PKCS7;
                        ICryptoTransform cTransform = tdes.CreateEncryptor();
                        tdes.Clear();
                        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                        if (resultArray != null && resultArray.Count() > new int())
                            returnvalue = Convert.ToBase64String(resultArray, 0, resultArray.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                //_logger.Error(exception, MethodBase.GetCurrentMethod());
            }
            return returnvalue;
        }
        #endregion

        #region AES Decryption
        /// <summary>
        /// This method makes Decryption data 
        /// </summary>
        /// <param name="cipherString">Input data you want to work with Decryption example: Password</param>
        /// <param name="useHashing">if useHashing=true Doing Decryption Uses Encode UTF8 else The Decryption process does not</param>
        /// <returns></returns>
        public static string DecryptAES(string cipherString, bool useHashing = true)
        {
            #region Vars
            string returnvalue = string.Empty;

            #endregion
            try
            {

                if (!string.IsNullOrWhiteSpace(cipherString) && !string.IsNullOrWhiteSpace(EncryptionKey))
                {
                    byte[] keyArray;
                    cipherString = cipherString.Replace(" ", "+");
                    byte[] toEncryptArray = Convert.FromBase64String(cipherString);
                    if (useHashing)
                    {
                        MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(EncryptionKey));
                        hashmd5.Clear();
                    }
                    else
                    {
                        keyArray = UTF8Encoding.UTF8.GetBytes(EncryptionKey);
                    }
                    AesCryptoServiceProvider tdes = new AesCryptoServiceProvider();
                    tdes.Key = keyArray;
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;
                    ICryptoTransform cTransform = tdes.CreateDecryptor();
                    byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                    tdes.Clear();
                    returnvalue = Encoding.UTF8.GetString(resultArray);
                }
            }
            catch
            {
                // _logger.Error(exception, MethodBase.GetCurrentMethod());
            }
            return returnvalue;
            #endregion
        }
    }

}
