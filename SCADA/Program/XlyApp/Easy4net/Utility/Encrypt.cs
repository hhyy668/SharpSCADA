using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Easy4net.Utility
{
    public static class Encrypt
    {
        #region AES加密    
   
        public static string Encryption(string toEncrypt)    
        {    
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes("12345678901234567890123456789012");    
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);    
   
            RijndaelManaged rDel = new RijndaelManaged();//using System.Security.Cryptography;    
            rDel.Key = keyArray;    
            rDel.Mode = CipherMode.ECB;//using System.Security.Cryptography;    
            rDel.Padding = PaddingMode.PKCS7;//using System.Security.Cryptography;    
   
            ICryptoTransform cTransform = rDel.CreateEncryptor();//using System.Security.Cryptography;    
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);    
   
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);    
        }   



        #endregion AES加密  

        #region AES解密    
   
        public static string Decryption(string toDecrypt)    
        {    
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes("12345678901234567890123456789012");    
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);    
   
            RijndaelManaged rDel = new RijndaelManaged();    
            rDel.Key = keyArray;    
            rDel.Mode = CipherMode.ECB;    
            rDel.Padding = PaddingMode.PKCS7;    
   
            ICryptoTransform cTransform = rDel.CreateDecryptor();    
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);    
   
            return UTF8Encoding.UTF8.GetString(resultArray);    
        }   



        #endregion AES解密    

        #region 产生加密密码

        /// <summary>
        /// 随机产生Salt
        /// </summary>
        public static string GenerateSalt()
        {
            byte[] bytSalt = new byte[8];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytSalt);
            string mysalt = Convert.ToBase64String(bytSalt);
            return mysalt;
        }

        public static string PasswordEncryption(string cleanString, string salt)
        {

            Byte[] clearBytes;
            Byte[] hashedBytes;

            System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("unicode");
            clearBytes = encoding.GetBytes(salt.ToLower().Trim() + cleanString.Trim());
            hashedBytes = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);
            return BitConverter.ToString(hashedBytes);
        }

        #endregion

        #region ========密码解密，web.config中数据库链接加密，因加密解密有方法调用有问题，暂时注释掉，后面如果需要加密再改。===========
        //#region ========加密======== 

        ///// <summary>
        ///// 加密
        ///// </summary>
        ///// <param name="Text"></param>
        ///// <returns></returns>
        //public static string Encrypt(string Text) 
        //{
        //    return Encrypt(Text, "litianping");
        //}
        ///// <summary> 
        ///// 加密数据 
        ///// </summary> 
        ///// <param name="Text"></param> 
        ///// <param name="sKey"></param> 
        ///// <returns></returns> 
        //public static string Encrypt(string Text,string sKey) 
        //{ 
        //    DESCryptoServiceProvider des = new DESCryptoServiceProvider(); 
        //    byte[] inputByteArray; 
        //    inputByteArray=Encoding.Default.GetBytes(Text); 
        //    des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8)); 
        //    des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8)); 
        //    System.IO.MemoryStream ms=new System.IO.MemoryStream(); 
        //    CryptoStream cs=new CryptoStream(ms,des.CreateEncryptor(),CryptoStreamMode.Write); 
        //    cs.Write(inputByteArray,0,inputByteArray.Length); 
        //    cs.FlushFinalBlock(); 
        //    StringBuilder ret=new StringBuilder(); 
        //    foreach( byte b in ms.ToArray()) 
        //    { 
        //        ret.AppendFormat("{0:X2}",b); 
        //    } 
        //    return ret.ToString(); 
        //} 

        //#endregion

        //#region ========解密======== 


        ///// <summary>
        ///// 解密
        ///// </summary>
        ///// <param name="Text"></param>
        ///// <returns></returns>
        //public static string Decrypt(string Text) 
        //{
        //    return Decrypt(Text, "litianping");
        //}
        ///// <summary> 
        ///// 解密数据 
        ///// </summary> 
        ///// <param name="Text"></param> 
        ///// <param name="sKey"></param> 
        ///// <returns></returns> 
        //public static string Decrypt(string Text,string sKey) 
        //{ 
        //    DESCryptoServiceProvider des = new DESCryptoServiceProvider(); 
        //    int len; 
        //    len=Text.Length/2; 
        //    byte[] inputByteArray = new byte[len]; 
        //    int x,i; 
        //    for(x=0;x<len;x++) 
        //    { 
        //        i = Convert.ToInt32(Text.Substring(x * 2, 2), 16); 
        //        inputByteArray[x]=(byte)i; 
        //    } 
        //    des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8)); 
        //    des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8)); 
        //    System.IO.MemoryStream ms=new System.IO.MemoryStream(); 
        //    CryptoStream cs=new CryptoStream(ms,des.CreateDecryptor(),CryptoStreamMode.Write); 
        //    cs.Write(inputByteArray,0,inputByteArray.Length); 
        //    cs.FlushFinalBlock(); 
        //    return Encoding.Default.GetString(ms.ToArray()); 
        //} 

        //#endregion 

        #endregion


        //RSA加密,随机生成公私钥对并作为出参返回
        static public string RSA_Encrypt(string str_Plain_Text, out string str_Public_Key, out string str_Private_Key)
        {
            str_Public_Key = "";
            str_Private_Key = "";
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] DataToEncrypt = ByteConverter.GetBytes(str_Plain_Text);
            try
            {
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                str_Public_Key = Convert.ToBase64String(RSA.ExportCspBlob(false));
                str_Private_Key = Convert.ToBase64String(RSA.ExportCspBlob(true));

                //OAEP padding is only available on Microsoft Windows XP or later.  
                byte[] bytes_Cypher_Text = RSA.Encrypt(DataToEncrypt, false);
                str_Public_Key = Convert.ToBase64String(RSA.ExportCspBlob(false));
                str_Private_Key = Convert.ToBase64String(RSA.ExportCspBlob(true));
                string str_Cypher_Text = Convert.ToBase64String(bytes_Cypher_Text);
                return str_Cypher_Text;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        //RSA解密
        static public string RSA_Decrypt(string str_Cypher_Text, string str_Private_Key)
        {
            byte[] DataToDecrypt = Convert.FromBase64String(str_Cypher_Text);
            try
            {
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                //RSA.ImportParameters(RSAKeyInfo);
                byte[] bytes_Public_Key = Convert.FromBase64String(str_Private_Key);
                RSA.ImportCspBlob(bytes_Public_Key);

                //OAEP padding is only available on Microsoft Windows XP or later.  
                byte[] bytes_Plain_Text = RSA.Decrypt(DataToDecrypt, false);
                UnicodeEncoding ByteConverter = new UnicodeEncoding();
                string str_Plain_Text = ByteConverter.GetString(bytes_Plain_Text);
                return str_Plain_Text;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
        //RSA加密解密范例
        //try
        //{
        //    string str_Plain_Text = "How are you?How are you?How are you?How are you?=-popopolA";
        //    Console.WriteLine("明文：" + str_Plain_Text);
        //    Console.WriteLine("长度：" + str_Plain_Text.Length.ToString());
        //    Console.WriteLine();

        //    RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

        //    string str_Public_Key;
        //    string str_Private_Key;
        //    string str_Cypher_Text = RSA_Encrypt(str_Plain_Text, out str_Public_Key,out str_Private_Key);
        //    Console.WriteLine("密文：" + str_Cypher_Text);
        //    Console.WriteLine("公钥：" + str_Public_Key);
        //    Console.WriteLine("私钥：" + str_Private_Key);

        //    string str_Plain_Text2 = RSA_Decrypt(str_Cypher_Text, str_Private_Key);
        //    Console.WriteLine("解密：" + str_Plain_Text2);

        //    Console.WriteLine();
        //}
        //catch (ArgumentNullException)
        //{
        //    Console.WriteLine("Encryption failed.");
        //}


        #region Base62 加密，常用于短网址
        private static string Alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        public static String Base62Encoding(ulong num)
        {
            if (num < 1)
                throw new Exception("num must be greater than 0.");

            StringBuilder sb = new StringBuilder();
            for (; num > 0; num /= 62)
            {
                sb.Append(Alphabet[(int)(num % 62)]);
            }
            return sb.ToString();
        }

        public static ulong Base62Decoding(String str)
        {
            str = str.Trim();
            if (str.Length < 1)
                throw new Exception("str must not be empty.");

            ulong result = 0;
            for (int i = 0; i < str.Length; i++)
            {
                result += (ulong)(Alphabet.IndexOf(str[i]) * Math.Pow(62, i));
            }
            return result;
        }
        #endregion 
    }    
}
