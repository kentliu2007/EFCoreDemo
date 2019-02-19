using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public partial class UserType
    {
        public UserType()
        {
            Users = new HashSet<User>();
        }

        public int UserTypeID { get; set; }
        public string UserTypeDesc { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}