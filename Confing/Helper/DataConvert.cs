using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Security.Cryptography;
using System.IO;

namespace Confing.Helper
{

    public class DataConvert 
    {
        /// <summary>
        /// 将值转为指定的数据类型
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object ChangeType(object value, Type type)
        {
            //判断convertsionType类型是否为泛型，因为nullable是泛型类,
            if (type.IsGenericType &&
                //判断convertsionType是否为nullable泛型类
                type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null || value.ToString().Length == 0)
                {
                    return null;
                }

                //如果convertsionType为nullable类，声明一个NullableConverter类，该类提供从Nullable类到基础基元类型的转换
                NullableConverter nullableConverter = new NullableConverter(type);
                //将convertsionType转换为nullable对的基础基元类型
                type = nullableConverter.UnderlyingType;
            }
            return System.Convert.ChangeType(value, type);
        }

        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptStr">需要加密的字符串</param>
        /// <param name="encryptKey">加密所用的Key</param>
        /// <returns></returns>
        public static string EncryptForDES(string encryptStr, string encryptKey)
        {
            byte[] byKey = null;
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            try
            {
                if (encryptKey.Length > 8) encryptKey = encryptKey.Substring(0, 8);
                byKey = System.Text.Encoding.UTF8.GetBytes(encryptKey);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptStr);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                //生成加密字符串
                return Convert.ToBase64String(ms.ToArray());
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 解密DES密码
        /// </summary>
        /// <param name="decryptStr">要解密的字符串</param>
        /// <param name="decryptKey">解密的Key</param>
        /// <returns></returns>
        public static string DecryptForDES(string decryptStr, string decryptKey)
        {
            try
            {
                byte[] byKey = null;
                byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
                byte[] inputByteArray = new Byte[decryptStr.Length];
                if (decryptKey.Length > 8) decryptKey = decryptKey.Substring(0, 8);
                byKey = System.Text.Encoding.UTF8.GetBytes(decryptKey);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = System.Convert.FromBase64String(decryptStr);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = new System.Text.UTF8Encoding();
                return encoding.GetString(ms.ToArray());
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 加密RSA字符串
        /// </summary>
        /// <param name="encryptStr">需要加密的字符串</param>
        /// <param name="encryptKey">加密所用的Key</param>
        /// <returns></returns>
        public static string EncryptForRSA(string encryptStr, string encryptKey)
        {
            CspParameters RSAParams = new CspParameters();
            RSAParams.Flags = CspProviderFlags.UseMachineKeyStore;
            System.Security.Cryptography.RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024, RSAParams);
            byte[] plaindata = Encoding.Default.GetBytes(encryptStr);//将要加密的字符串转换为字节数组
            byte[] encryptdata = rsa.Encrypt(plaindata, false);//将加密后的字节数据转换为新的加密字节数组
            return Convert.ToBase64String(encryptdata);//将加密后的字节数组转换为字符串
        }
        /// <summary>
        /// 解密RSA密码
        /// </summary>
        /// <param name="decryptStr">要解密的字符串</param>
        /// <param name="decryptKey">解密的Key</param>
        /// <returns></returns>
        public static string DecryptForRSA(string decryptStr, string decryptKey)
        {
            if (string.IsNullOrWhiteSpace(decryptStr)) return string.Empty;
            CspParameters RSAParams = new CspParameters();
            RSAParams.Flags = CspProviderFlags.UseMachineKeyStore;
            System.Security.Cryptography.RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024, RSAParams);
            byte[] encryptdata = Convert.FromBase64String(decryptStr);
            byte[] decryptdata = rsa.Decrypt(encryptdata, false);
            return Encoding.Default.GetString(decryptdata);
        }
        /// <summary>
        /// 加密字符为base64
        /// </summary>
        /// <param name="encryptStr"></param>
        /// <returns></returns>
        public static string EncryptForBase64(string encryptStr)
        {
            byte[] bytes = Encoding.Default.GetBytes(encryptStr);
            return Convert.ToBase64String(bytes);
        }
        /// <summary>
        /// 加密字符为base64，并进行url编码
        /// </summary>
        /// <param name="encryptStr"></param>
        /// <returns></returns>
        public static string EncryptForBase64UrlEncode(string encryptStr)
        {
            byte[] bytes = Encoding.Default.GetBytes(encryptStr);
            string base64 = Convert.ToBase64String(bytes);
            return System.Web.HttpUtility.UrlEncode(base64);
        }
        /// <summary>
        /// 解密base64字符
        /// </summary>
        /// <param name="decryptStr"></param>
        /// <returns></returns>
        public static string DecryptForBase64(string decryptStr)
        {
            byte[] outputb = Convert.FromBase64String(decryptStr);
            return Encoding.Default.GetString(outputb);
        }
    }
}
