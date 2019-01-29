using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemo.BusinessObjects
{
    [Serializable]
    public class Employee
    {
        public Employee() { }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime JoinDate { get; set; }

    }
}
