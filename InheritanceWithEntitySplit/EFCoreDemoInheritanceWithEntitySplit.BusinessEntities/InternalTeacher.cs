using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemoInheritanceWithEntitySplit.BusinessEntities
{
    public partial class InternalTeacher
    {
        public Teacher Teacher { get; set; }
        public string StaffCode { get; set; }
        public int SalaryGrade { get; set; }
    }
}
