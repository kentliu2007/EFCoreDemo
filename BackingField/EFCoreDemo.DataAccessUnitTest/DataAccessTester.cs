using Microsoft.VisualStudio.TestTools.UnitTesting;
using EFCoreDemo.DataAccess;
using EFCoreDemo.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFCoreDemo.DataAccessUnitTest
{
    [TestClass]
    public class DataAccessTester
    {
        private DbContextOptionsBuilder<EfdemoContext> _optionsBuilder = new DbContextOptionsBuilder<EfdemoContext>();
        private const string CONNECTIONSTRING = "Data Source=(local);Initial Catalog=EFDemo;Integrated Security=True";

        public DataAccessTester()
        {
            _optionsBuilder.UseLazyLoadingProxies(true).UseSqlServer(CONNECTIONSTRING);
        }

        [TestMethod]
        public void TestUserDataAccess()
        {
            string loginName = "TestUser_" + Guid.NewGuid().ToString();
            string password = Guid.NewGuid().ToString();
            using (var context = new EfdemoContext(_optionsBuilder.Options))
            {
                context.Users.Add(new User() { LoginName = loginName, Password = password });
                context.SaveChanges();
            }
            using (var context = new EfdemoContext(_optionsBuilder.Options))
            {
                var v = context.Users.FirstOrDefault(e => e.LoginName == loginName);
                Assert.AreEqual((v != null && v.Password == PasswordHelper.EncryptPassword(password)), true);
                context.Users.Remove(v);
                context.SaveChanges();
            }
        }
        [TestMethod]
        public void TestClientDataAccess()
        {
            string clientCode = "CLIENT01";
            string clientName = "ClientName";
            using (var context = new EfdemoContext(_optionsBuilder.Options))
            {
                context.Clients.Add(new Client() { ClientCode = clientCode, ClientName = "ClientName" });
                context.SaveChanges();
            }
            using (var context = new EfdemoContext(_optionsBuilder.Options))
            {
                var v = context.Clients.FirstOrDefault(e => e.ClientCode == clientCode);
                Assert.AreEqual((v != null && v.ClientName == clientName), true);
                context.Clients.Remove(v);
                context.SaveChanges();
            }
        }
        [TestMethod]
        public void TestClientAccountBalance()
        {
            string clientCode = "CLIENT01";
            string currencyCode = "CURRX";
            double balance = 9876.54321;
            using (var context = new EfdemoContext(_optionsBuilder.Options))
            {
                context.Clients.Add(
                    new Client()
                    {
                        ClientCode = clientCode,
                        ClientName = "ClientName",
                        AccountBalance = new ClientAccountBalance()
                        {
                            Currency = new Currency() { CurrencyCode = currencyCode, CurrencyName = "Currency X", DecimalPlaces = 5 },
                            Amount = balance
                        }
                    });
                context.SaveChanges();
            }
            using (var context = new EfdemoContext(_optionsBuilder.Options))
            {
                var v = context.Clients.FirstOrDefault(e => e.ClientCode == clientCode);
                Assert.AreEqual((v != null && v.AccountBalance != null && v.AccountBalance.Amount == balance), true);
                context.Clients.Remove(v);
                context.Currencies.Remove(context.Currencies.FirstOrDefault(e => e.CurrencyCode == currencyCode));
                context.SaveChanges();
            }
        }
    }
}
