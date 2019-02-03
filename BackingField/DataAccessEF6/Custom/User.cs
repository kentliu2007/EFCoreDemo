using System.Security.Cryptography;

namespace EFDemo.DataAccess
{
    public partial class User
    {
        public string Password
        {
            get { return rawPassword; }
            set { rawPassword = PasswordHelper.EncryptPassword(value); }
        }
    }
}
