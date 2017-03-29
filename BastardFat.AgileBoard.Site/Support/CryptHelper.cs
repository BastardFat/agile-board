using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace BastardFat.AgileBoard.Site.Support
{
    public static class CryptHelper
    {
        public static string SHA1(string param)
        {
            var buffer = Encoding.Default.GetBytes(param);
            var cryptoTransformSHA1 = new SHA1CryptoServiceProvider();
            return BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");
        }

        public static string[] DecodeAndSplit(string param) =>
            Encoding.Default.GetString(Convert.FromBase64String(param)).Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);

        public static string JoinAndEncode(params string[] param) =>
            Convert.ToBase64String(Encoding.Default.GetBytes(String.Join(":", param)));
    }
}