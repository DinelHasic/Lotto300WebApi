using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSystem.Security.Cryptography;

namespace Loto300WebAPI.Services.Extension
{
    public static class Hashing
    {
        public static string  PasswordHashed(this string password)
        {
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();

            byte[] hashedBytes = mD5CryptoServiceProvider.ComputeHash(Encoding.ASCII.GetBytes(password));

            string hashedPassword = Encoding.ASCII.GetString(hashedBytes);

            return hashedPassword;
        }
    }
}
