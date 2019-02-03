using Microsoft.VisualStudio.TestTools.UnitTesting;
using EFCoreDemo.DataAccess;
using EFCoreDemo.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EFCoreDemo.BusinessEntitiesUnitTest
{
    [TestClass]
    public class ClientDataAccessTester
    {
        private DbContextOptionsBuilder<EfdemoContext> _optionsBuilder = new DbContextOptionsBuilder<EfdemoContext>();
        private const string CONNECTIONSTRING = "Data Source=(local);Initial Catalog=EFDemo;Integrated Security=True";

        public ClientDataAccessTester()
        {
            _optionsBuilder.UseLazyLoadingProxies(true).UseSqlServer(CONNECTIONSTRING);
        }
        [TestMethod]
        public void TestClientDataAccess()
        {
            string clientCode = "CLIENT01";
            string cellPhoneNo = "1234567890";
            using (var context = new EfdemoContext(_optionsBuilder.Options))
            {
                context.Clients.Add(new Client() { ClientCode = clientCode, CellPhoneNo = cellPhoneNo, ClientName = "ClientName" });
                context.SaveChanges();
            }
            using (var context = new EfdemoContext(_optionsBuilder.Options))
            {
                var v = context.Clients.FirstOrDefault(e => e.ClientCode == clientCode);
                Assert.AreEqual((v != null && v.CellPhoneNo == cellPhoneNo), true);
                context.Clients.Remove(v);
                context.SaveChanges();
            }
        }
    }
}
