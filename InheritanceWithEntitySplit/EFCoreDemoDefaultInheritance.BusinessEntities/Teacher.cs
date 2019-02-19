using System;

namespace EFCoreDemoDefaultInheritance.BusinessEntities
{
    public partial class Teacher : User
    {
        public string StaffCode { get; set; }
        public int SalaryGrade { get; set; }
    }
}
