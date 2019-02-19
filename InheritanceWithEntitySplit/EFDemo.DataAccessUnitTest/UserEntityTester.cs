using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EFDemo.DataAccess;
using System.Linq;
using System.Collections.Generic;

namespace EFDemo.DataAccessUnitTest
{
    [TestClass]
    public class UserEntityTester
    {
        [TestMethod]
        public void TestUserEntity()
        {
            string loginName = "loginA";
            string staffCode = "TEAX";
            string password = Guid.NewGuid().ToString();
            using (var context = new EFDemoEntities())
            {
                context.Users.Add(new Teacher() {
                    LoginName = loginName,
                    FirstName = "login",
                    LastName = "A",
                    Password = password,
                    StaffCode = staffCode, 
                    SalaryGrade = 1
                });
                context.SaveChanges();
            }
            using (var context = new EFDemoEntities())
            {
                var v = context.Users.FirstOrDefault(e => e.LoginName == loginName) as Teacher;
                Assert.AreEqual((v != null && v.StaffCode == staffCode && v.Password == password), true);
                context.Users.Remove(v);
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
            using (var context = new EFDemoEntities())
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
