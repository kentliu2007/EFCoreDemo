using BOEmployee = EFDemo.BusinessObjects.Employee;

namespace EFDemo.DataAccess
{
    public partial class Employee : BOEmployee
    {
        public Employee() { }
        public Employee(BOEmployee employee) : this()
        {
            if (employee != null)
            {
                this.EmployeeCode = employee.EmployeeCode;
                this.FirstName = employee.FirstName;
                this.LastName = employee.LastName;
                this.JoinDate = employee.JoinDate;
            }
        }
    }
}
