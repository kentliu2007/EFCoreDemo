using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TableSplitting.BusinessEntities;
using TableSplitting.DataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;

namespace TableSplitting.BusinessEntitiesUnitTest
{
    [TestClass]
    public class BusinessEntityTester
    {
        private DbContextOptionsBuilder<TableSplittingContext> _optionsBuilder = new DbContextOptionsBuilder<TableSplittingContext>();
        private const string CONNECTIONSTRING = "Data Source=(local);Initial Catalog=EFDemo;Integrated Security=True";
        public BusinessEntityTester()
        {
            _optionsBuilder.UseSqlServer(CONNECTIONSTRING);
        }
        [TestMethod]
        public void TestClient()
        {
            string code = "code1";
            string email = "abc@abc.com";
            
            using (var context = new TableSplittingContext(_optionsBuilder.Options))
            {
                var c = new Client(){ Code = code, Name = "name1", Email = email };
                context.Clients.Add(c);
                IDbContextTransaction tx = null;
                try
                {
                    tx = context.Database.BeginTransaction();
                    context.SaveChanges();
                    tx.Commit();
                }
                catch (System.Exception ex)
                {
                    if (tx != null) tx.Rollback();
                }
            }
            using (var context = new TableSplittingContext(_optionsBuilder.Options))
            {
                IDbContextTransaction tx = null;
                try
                {
                    var x = context.Clients.FirstOrDefault(e => e.Code == code);
                    Assert.AreEqual(x != null && x.Email == email, true);
                    context.Clients.Remove(x);
                    tx = context.Database.BeginTransaction();
                    context.SaveChanges();
                    tx.Commit();
                }
                catch (System.Exception ex)
                {
                    if (tx != null) tx.Rollback();
                }
            }
        }
    }
}
