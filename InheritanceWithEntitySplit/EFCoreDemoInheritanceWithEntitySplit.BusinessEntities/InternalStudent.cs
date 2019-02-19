using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemoInheritanceWithEntitySplit.BusinessEntities
{
    public partial class InternalStudent
    {
        public Student Student { get; set; }
        public string StudentCode { get; set; }
        public int GradeLevel { get; set; }
    }
}
