using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EFDemo.DataAccess;
using System.Linq;

namespace EFDemoDataAccessUnitTest
{
    [TestClass]
    public class BusinessEntitiesDataAccessTester
    {
        [TestMethod]
        public void TestClientDataAccess()
        {
            string clientCode = "CLIENT01";
            string cellPhoneNo = "1234567890";
            using (var context = new EFDemoEntities())
            {
                context.Clients.Add(new Client() { ClientCode = clientCode, CellPhoneNo = cellPhoneNo, ClientName = "ClientName" });
                context.SaveChanges();
            }
            using (var context = new EFDemoEntities())
            {
                var v = context.Clients.FirstOrDefault(e => e.ClientCode == clientCode);
                Assert.AreEqual((v != null && v.CellPhoneNo == cellPhoneNo), true);
                context.Clients.Remove(v);
                context.SaveChanges();
            }
        }

    }
}
