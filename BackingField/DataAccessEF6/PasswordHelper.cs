using System;
using System.Security.Cryptography;
using System.Text;

namespace EFDemo.DataAccess
{
    public class PasswordHelper
    {
        private static MD5 _md5 = MD5.Create();

        public static string EncryptPassword(string password)
        {
            return string.IsNullOrEmpty(password) ? string.Empty : Convert.ToBase64String(_md5.ComputeHash(Encoding.Unicode.GetBytes(password)));
        }
    }
}
