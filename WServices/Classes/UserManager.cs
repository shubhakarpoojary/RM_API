using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
//using WinApps.Models;

namespace WServices.Classes
{
    public class UserManager
    {

        public string encryptData(string wordtoEncrypt)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[wordtoEncrypt.Length];
            encode = Encoding.UTF8.GetBytes(wordtoEncrypt);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }
        public string decryptData(string wordtoDecrypt)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(wordtoDecrypt);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }

        

     }
}