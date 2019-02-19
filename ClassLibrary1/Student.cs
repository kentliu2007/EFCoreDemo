using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public partial class Student
    {
        public int StudentID { get; set; }
        public string StudentCode { get; set; }
        public int GradeLevel { get; set; }

        public virtual User StudentNavigation { get; set; }
    }
}