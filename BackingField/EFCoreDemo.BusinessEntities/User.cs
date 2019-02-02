using System;

namespace EFCoreDemo.BusinessEntities
{
    public partial class User
    {

        public string LoginName { get; set; }
        public string Password
        {
            get { return _password; }
            set { _password = PasswordHelper.EncryptPassword(value); }
        }

        protected string _password;

    }
}
