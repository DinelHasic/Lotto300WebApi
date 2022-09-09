using System.Text;
using XSystem.Security.Cryptography;

namespace Loto300WebAPI.Storage.Helper
{
    public static class HasingPassword
    {
        public static string GetPassword(string password)
        {
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();

            byte[] hashedBytes = mD5CryptoServiceProvider.ComputeHash(Encoding.ASCII.GetBytes(password));

            string hashedPassword = Encoding.ASCII.GetString(hashedBytes);

            return hashedPassword;
        }
    }
}
