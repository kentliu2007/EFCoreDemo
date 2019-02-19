using Microsoft.VisualStudio.TestTools.UnitTesting;
using EFCoreDemoDefaultInheritance.BusinessEntities;
using EFCoreDemoDefaultInheritance.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
namespace EFCoreDemoDefaultInheritance.DataAccessUnitTest
{
    [TestClass]
    public class BusinessEntityTesterV2
    {
        private DbContextOptionsBuilder<EFCoreDemoDefaultInheritanceV2Context> _optionsBuilder = new DbContextOptionsBuilder<EFCoreDemoDefaultInheritanceV2Context>();
        private const string CONNECTIONSTRING = "Data Source = (local); Initial Catalog = EFDemo; Integrated Security = True";

        public BusinessEntityTesterV2()
        {
            _optionsBuilder.UseSqlServer(CONNECTIONSTRING);
        }
        [TestMethod]
        public void TestUser()
        {
            Exception checkingException = null;

            string loginName = "loginA";
            string staffCode = "TEAX";
            string password = Guid.NewGuid().ToString();
            try
            {
                using (var context = new EFCoreDemoDefaultInheritanceV2Context(_optionsBuilder.Options))
                {
                    context.Users.Add(new Teacher()
                    {
                        LoginName = loginName,
                        FirstName = "login",
                        LastName = "A",
                        Password = password,
                        StaffCode = staffCode,
                        SalaryGrade = 1
                    });
                    context.SaveChanges();
                }
                using (var context = new EFCoreDemoDefaultInheritanceV2Context(_optionsBuilder.Options))
                {
                    var v = context.Users.FirstOrDefault(e => e.LoginName == loginName) as Teacher;
                    Assert.AreEqual((v != null && v.StaffCode == staffCode && v.Password == password), true);
                    context.Users.Remove(v);
                    context.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                checkingException = ex;
            }
            // we should get exception, for EFCore V2.2, current Exception will be Microsoft.EntityFrameworkCore.DbUpdateException
            // with some messages as following:
            // Invalid column name 'TeacherID'.
            //Invalid column name 'Discriminator'.
            //Invalid column name 'SalaryGrade'.
            //Invalid column name 'StaffCode'.
            // if we got exception, then it means our test case is passed
            Assert.IsTrue(checkingException != null);

        }
        [TestMethod]
        public void TestTeacher()
        {
            Exception checkingException = null;

            string loginName = "loginB";
            string staffCode = "TEAB";
            string password = Guid.NewGuid().ToString();
            try
            {
                using (var context = new EFCoreDemoDefaultInheritanceV2Context(_optionsBuilder.Options))
                {
                    context.Teachers.Add(new Teacher()
                    {
                        LoginName = loginName,
                        FirstName = "login",
                        LastName = "B",
                        Password = password,
                        StaffCode = staffCode,
                        SalaryGrade = 1
                    });
                    context.SaveChanges();
                }
                using (var context = new EFCoreDemoDefaultInheritanceV2Context(_optionsBuilder.Options))
                {
                    var v = context.Teachers.FirstOrDefault(e => e.LoginName == loginName);
                    Assert.AreEqual((v != null && v.StaffCode == staffCode && v.Password == password), true);
                    context.Teachers.Remove(v);
                    context.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                checkingException = ex;
            }
            // we should get exception, for EFCore V2.2, current Exception will be Microsoft.EntityFrameworkCore.DbUpdateException
            // with some messages as following:
            // Invalid column name 'TeacherID'.
            //Invalid column name 'Discriminator'.
            //Invalid column name 'SalaryGrade'.
            //Invalid column name 'StaffCode'.
            // if we got exception, then it means our test case is passed
            Assert.IsTrue(checkingException != null);
        }
    }
}
