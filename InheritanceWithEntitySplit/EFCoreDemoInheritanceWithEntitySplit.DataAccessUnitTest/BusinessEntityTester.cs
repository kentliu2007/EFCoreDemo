using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EFCoreDemoInheritanceWithEntitySplit.BusinessEntities;
using EFCoreDemoInheritanceWithEntitySplit.DataAccess;
using System.Linq;
using System.Collections.Generic;

namespace EFCoreDemoInheritanceWithEntitySplit.DataAccessUnitTest
{
    [TestClass]
    public class BusinessEntityTester
    {
        private DbContextOptionsBuilder<EFCoreDemoInheritanceWithEntitySplitContext> _optionsBuilder = new DbContextOptionsBuilder<EFCoreDemoInheritanceWithEntitySplitContext>();
        private const string CONNECTIONSTRING = "Data Source = (local); Initial Catalog = EFCoreDemoB; Integrated Security = True";

        public BusinessEntityTester()
        {
            _optionsBuilder.UseSqlServer(CONNECTIONSTRING);
        }

        [TestMethod]
        public void TestUser()
        {
            string loginName = "loginA";
            string staffCode = "TEAX";
            string password = Guid.NewGuid().ToString();
            using (var context = new EFCoreDemoInheritanceWithEntitySplitContext(_optionsBuilder.Options))
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
            using (var context = new EFCoreDemoInheritanceWithEntitySplitContext(_optionsBuilder.Options))
            {
                var v = context.Users.FirstOrDefault(e => e.LoginName == loginName) as Teacher;
                Assert.AreEqual((v != null && v.StaffCode == staffCode && v.Password == password), true);
                context.Users.Remove(v);
                context.SaveChanges();
            }

        }
        [TestMethod]
        public void TestTeacher()
        {
            string loginName = "loginB";
            string staffCode = "TEAB";
            string password = Guid.NewGuid().ToString();
            using (var context = new EFCoreDemoInheritanceWithEntitySplitContext(_optionsBuilder.Options))
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
            using (var context = new EFCoreDemoInheritanceWithEntitySplitContext(_optionsBuilder.Options))
            {
                var v = context.Teachers.FirstOrDefault(e => e.LoginName == loginName);
                Assert.AreEqual((v != null && v.StaffCode == staffCode && v.Password == password), true);
                context.Teachers.Remove(v);
                context.SaveChanges();
            }

        }
        [TestMethod]
        public void MakeDemoData()
        {
            List<User> testData = new List<User>()
            {
                new Teacher() {
                    LoginName = "demoA",
                    FirstName = "demo",
                    LastName = "A",
                    Password = Guid.NewGuid().ToString(),
                    StaffCode = "demoA",
                    SalaryGrade = 1
                },
                new Student() {
                    LoginName = "demoB",
                    FirstName = "demo",
                    LastName = "B",
                    Password = Guid.NewGuid().ToString(),
                    StudentCode = "demoB",
                    GradeLevel = 1
                },
                new Teacher() {
                    LoginName = "demoC",
                    FirstName = "demo",
                    LastName = "C",
                    Password = Guid.NewGuid().ToString(),
                    StaffCode = "demoC",
                    SalaryGrade = 1
                },
                new Student() {
                    LoginName = "demoD",
                    FirstName = "demo",
                    LastName = "D",
                    Password = Guid.NewGuid().ToString(),
                    StudentCode = "demoD",
                    GradeLevel = 1
                },
                new Teacher() {
                    LoginName = "demoE",
                    FirstName = "demo",
                    LastName = "E",
                    Password = Guid.NewGuid().ToString(),
                    StaffCode = "demoE",
                    SalaryGrade = 1
                },
                new Student() {
                    LoginName = "demoF",
                    FirstName = "demo",
                    LastName = "F",
                    Password = Guid.NewGuid().ToString(),
                    StudentCode = "demoF",
                    GradeLevel = 1
                },

            };
            using (var context = new EFCoreDemoInheritanceWithEntitySplitContext(_optionsBuilder.Options))
            {
                foreach (User user in testData)
                {
                    var x = context.Users.FirstOrDefault(e => e.LoginName == user.LoginName);
                    if (x != null) context.Users.Remove(x);
                }
                context.SaveChanges();
                context.Users.AddRange(testData);
                context.SaveChanges();
            }
        }
    }
}
