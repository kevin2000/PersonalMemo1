using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
/* ==============================================================================
 * 功能描述：加密解密工具  
  * 创 建 者：liqiao
  * 创建日期：2017/5/19 15:56:10
  * email:120911940@qq.com
  * ==============================================================================*/
namespace PersonalMemo.common
{
    public class EncryptUtil
    {
        //des加密解密所用
        private static byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes("12345678");//必须是8个字符，64bit
        private static byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes("hgfedcba");//必须是8个字符，64bit
        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string EncryptMd5(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] palindata = Encoding.Default.GetBytes(text);//将要加密的字符串转换为字节数组
            byte[] encryptdata = md5.ComputeHash(palindata);//将字符串加密后也转换为字符数组
            return Convert.ToBase64String(encryptdata);//将加密后的字节数组转换为加密字符串
        }
        /// <summary>
        /// md5盐值加密
        /// </summary>
        /// <param name="text">字符串</param>
        /// <param name="salt">盐</param>
        /// <returns></returns>
        public static string EncryptMd5Salt(string text, string salt)
        {
            return EncryptMd5(text);
        }
        /// <summary>
        /// des加密
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string EncryptDes(string plainText)
        {
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cst);
            sw.Write(plainText);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }
        /// <summary>
        /// des解密
        /// </summary>
        /// <param name="cypherText"></param>
        /// <returns></returns>
        public static string DecryptDes(string cypherText)
        {
            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(cypherText);
            }
            catch
            {
                return null;
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            return sr.ReadToEnd();
        }
        /// <summary>
        /// 加密文件
        /// </summary>
        /// <param name="inName"></param>
        /// <param name="outName"></param>
        /// <param name="desKey"></param>
        /// <param name="desIV"></param> 
        private static void EncryptData(String inName, String outName, byte[] desKey, byte[] desIV)
        {
            //Create the file streams to handle the input and output files.
            FileStream fin = new FileStream(inName, FileMode.Open, FileAccess.Read);
            FileStream fout = new FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write);
            fout.SetLength(0);
            //Create variables to help with read and write.
            byte[] bin = new byte[100]; //This is intermediate storage for the encryption.
            long rdlen = 0;              //This is the total number of bytes written.
            long totlen = fin.Length;    //This is the total length of the input file.
            int len;                     //This is the number of bytes to be written at a time.
            DES des = new DESCryptoServiceProvider();
            CryptoStream encStream = new CryptoStream(fout, des.CreateEncryptor(desKey, desIV), CryptoStreamMode.Write);
            //Read from the input file, then encrypt and write to the output file.
            while (rdlen < totlen)
            {
                len = fin.Read(bin, 0, 100);
                encStream.Write(bin, 0, len);
                rdlen = rdlen + len;
            }
            encStream.Close();
            fout.Close();
            fin.Close();
        }
        /// <summary>
        /// 解密文件
        /// </summary>
        /// <param name="inName"></param>
        /// <param name="outName"></param>
        /// <param name="desKey"></param>
        /// <param name="desIV"></param>
        private static void DecryptData(String inName, String outName, byte[] desKey, byte[] desIV)
        {
            //Create the file streams to handle the input and output files.
            FileStream fin = new FileStream(inName, FileMode.Open, FileAccess.Read);
            FileStream fout = new FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write);
            fout.SetLength(0);
            //Create variables to help with read and write.
            byte[] bin = new byte[100]; //This is intermediate storage for the encryption.
            long rdlen = 0;              //This is the total number of bytes written.
            long totlen = fin.Length;    //This is the total length of the input file.
            int len;                     //This is the number of bytes to be written at a time.
            DES des = new DESCryptoServiceProvider();
            CryptoStream encStream = new CryptoStream(fout, des.CreateDecryptor(desKey, desIV), CryptoStreamMode.Write);
            //Read from the input file, then encrypt and write to the output file.
            while (rdlen < totlen)
            {
                len = fin.Read(bin, 0, 100);
                encStream.Write(bin, 0, len);
                rdlen = rdlen + len;
            }
            encStream.Close();
            fout.Close();
            fin.Close();
        }
        /// <summary>
        /// 移位方式简单加密
        /// 加密后的字符串的第一个字符是原先字符串的最后一个字符，
        //   其余的每一个字符是对应的原字符串中的前一个字符的值加
        //   上3。
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static string EncryptOffset(string strInput)
        {
            string strFont, strEnd;
            string strOutput;
            char[] charFont;
            int i, len, intFont;

            len = strInput.Length;
            //Console.WriteLine(" strInput 's length is :{0} /n", len);
            strFont = strInput.Remove(len - 1, 1);
            strEnd = strInput.Remove(0, len - 1);

            //Console.WriteLine(" strFont is : {0} /n" , strFont);                                 
            //Console.WriteLine(" strEnd is : {0} /n" , strEnd);                                 

            charFont = strFont.ToCharArray();
            for (i = 0; i < strFont.Length; i++)
            {
                intFont = (int)charFont[i] + 3;
                //Console.WriteLine(" intFont is : {0} /n", intFont);                                 

                charFont[i] = Convert.ToChar(intFont);
                //Console.WriteLine("charFont[{0}] is : {1}/n", i, charFont[i]);                                 
            }
            strFont = ""; //let strFont  null
            for (i = 0; i < charFont.Length; i++)
            {
                strFont += charFont[i];
            }
            strOutput = strEnd + strFont;
            return strOutput; 
        }
        /// <summary>
        /// 加密后的字符串的第一个字符是原先字符串的最后一个字符，
        //   其余的每一个字符是对应的原字符串中的前一个字符的值加
        //   上3。
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static string DecryptOffset(string strInput)
        {
            string strFont, strEnd;
            string strOutput;
            char[] charFont;
            int i, len, intFont;

            len = strInput.Length;
            //Console.WriteLine(" strInput 's length is :{0} /n", len);
            strFont = strInput.Substring(1);
            strEnd = strInput.Substring(0,1);

            //Console.WriteLine(" strFont is : {0} /n" , strFont);                                 
            //Console.WriteLine(" strEnd is : {0} /n" , strEnd);                                 

            charFont = strFont.ToCharArray();
            for (i = 0; i < strFont.Length; i++)
            {
                intFont = (int)charFont[i] - 3;
                //Console.WriteLine(" intFont is : {0} /n", intFont);                                 

                charFont[i] = Convert.ToChar(intFont);
                //Console.WriteLine("charFont[{0}] is : {1}/n", i, charFont[i]);                                 
            }
            strFont = ""; //let strFont  null
            for (i = 0; i < charFont.Length; i++)
            {
                strFont += charFont[i];
            }
            strOutput = strFont+strEnd;
            return strOutput;
        }
        /// <summary>
        /// 字符串解密成数字
        /// </summary>
        /// <param name="text"></param>
        /// <param name="checkKey">加密的字符串</param>
        /// <returns></returns>
        public static int DecryptStr2Int(string InValue, string CheckString)
        {
            if (CheckString.Length < 10)
                return 0;
            else
            {
                string result=""; 
                for (int i = 0; i < InValue.Length; i++)
                { 
                    result += CheckString.IndexOf(InValue[i]).ToString(); 
                }

                try
                {
                    return int.Parse(result);
                }
                catch { return 0; }
            }
        }
        /// <summary>
        /// 获取10位随机字符串
        /// </summary>
        /// <returns></returns>
        private static string GetRandomStr()
        {
            String myKey = "abcdefghijklmnopqrstuvwxyz"; 
            String result = "";
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            { 
                int position = random.Next(myKey.Length);
                result = result + myKey[position];

                myKey = myKey.Remove(position, 1);
            }
            return result;
        }
        /// <summary>
        /// 数字加密成字符串
        /// </summary>
        /// <param name="text">string格式的数字，例如 "123.123"</param>
        /// <param name="checkKey">加密的key</param>
        /// <returns></returns>
        public static string EncryptInt2Str(string text,out string checkKey) 
        {
            checkKey = GetRandomStr(); 
            string result = "";
            int index = 0;
            for (int i = 0; i < text.Length; i++)
            {
                index=int.Parse(text[i].ToString());
                result += checkKey[index];
            }
            return result;
        }

    }
}
