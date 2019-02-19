using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public partial class Teacher
    {
        public int TeacherID { get; set; }
        public string StaffCode { get; set; }
        public int SalaryGrade { get; set; }

        public virtual User TeacherNavigation { get; set; }
    }
}