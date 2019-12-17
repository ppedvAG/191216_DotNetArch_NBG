using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.TombstoneStrong.Data.EF.Tests
{
    [TestFixture]
    public class EFContextTests
    {
        [Test]
        public void CanCreateEFContext()
        {
            using (EFContext context = new EFContext())
            {
                // ...
            }
        }

        [Test]
        public void EFContext_Can_Create_DB()
        {
            using (EFContext context = new EFContext())
            {
                Assert.IsTrue(context.Database.EnsureCreated());
            }
        }
    }
}
