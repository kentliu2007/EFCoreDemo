using System;

namespace EFCoreDemoDefaultInheritance.BusinessEntities
{
    public partial class Student : User
    {
        public string StudentCode { get; set; }
        public int GradeLevel { get; set; }
    }
}
