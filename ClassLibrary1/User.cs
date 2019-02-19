using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public partial class User
    {
        public int UserID { get; set; }
        public string LoginName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int UserTypeID { get; set; }

        public virtual UserType UserType { get; set; }
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}