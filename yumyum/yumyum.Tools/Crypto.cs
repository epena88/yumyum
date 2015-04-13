using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace yumyum.Tools
{
    public class Crypto
    {
        public static string GetSalt()
        {
            return Guid.NewGuid().ToString();
        }

        public static string GenerateSaltedSHA256(string plainTextString, byte[] _salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();
            var saltBytes = _salt;
            var plainTextBytes = Encoding.UTF8.GetBytes(plainTextString);

            var plainTextWithSaltBytes = AppendByteArray(plainTextBytes, saltBytes);
            var saltedSHA1Bytes = algorithm.ComputeHash(plainTextWithSaltBytes);
            var saltedSHA1WithAppendedSaltBytes = AppendByteArray(saltedSHA1Bytes, saltBytes);

            return Convert.ToBase64String(saltedSHA1WithAppendedSaltBytes);
        }

        #region Private Method     
        private static byte[] AppendByteArray(byte[] byteArray1, byte[] byteArray2)
        {
            var byteArrayResult =
                    new byte[byteArray1.Length + byteArray2.Length];
            for (var i = 0; i < byteArray1.Length; i++)
                byteArrayResult[i] = byteArray1[i];
            for (var i = 0; i < byteArray2.Length; i++)
                byteArrayResult[byteArray1.Length + i] = byteArray2[i];

            return byteArrayResult;
        }
        #endregion
    }
}
