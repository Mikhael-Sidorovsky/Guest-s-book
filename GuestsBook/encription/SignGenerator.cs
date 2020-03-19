using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace GuestsBook.encription
{
    public static class SignGenerator
    {
        public static string GenerateSign(string data)
        {
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            byte[] sign = provider.ComputeHash(Encoding.Default.GetBytes(data));
            return BitConverter.ToString(sign).ToLower().Replace("-", "");
        }
    }
}