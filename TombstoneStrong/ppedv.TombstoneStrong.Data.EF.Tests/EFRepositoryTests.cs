using FluentAssertions;
using NUnit.Framework;
using ppedv.TombstoneStrong.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.TombstoneStrong.Data.EF.Tests
{
    [TestFixture]
    public class EFRepositoryTests
    {
        [SetUp]
        public void TestSetup()
        {
            context = new EFContext();
            context.Database.EnsureCreated();

            repo = new EFRepository(context);
        }
        private EFContext context;
        private EFRepository repo;

        [TearDown]
        public void TestTearDown()
        {
            context.Database.EnsureDeleted();
        }

        [Test]
        public void EFRepository_can_Add()
        {
            Employee item = new Employee { Name = "Tom Ate", Department = "Gemüseabteilung" };
            repo.Add(item);
            repo.Save();

            // Check:
            var loadedItem = repo.GetByID<Employee>(item.ID);
            loadedItem.Should().NotBeNull();
            loadedItem.Should().BeEquivalentTo(item);
        }

        [Test]
        public void EFRepository_can_Delete()
        {
            Employee item = new Employee { Name = "Tom Ate", Department = "Gemüseabteilung" };
            repo.Add(item);
            repo.Save();

            // Check:
            var loadedItem = repo.GetByID<Employee>(item.ID);
            loadedItem.Should().NotBeNull();
            loadedItem.Should().BeEquivalentTo(item);
        }

        [Test]
        public void EFRepository_can_CRUD_Employee()
        {
            Employee item = new Employee { Name = "Tom Ate", Department = "Gemüseabteilung" };
            string newName = "Anna Nass";

            // Create
            using (EFContext context = new EFContext())
            {
                context.Add(item);
                context.SaveChanges();
            }

            // Check Create
            using(EFContext context = new EFContext())
            {
                var loaded = context.Employee.Find(item.ID);
                loaded.Should().NotBeNull();
                loaded.Should().BeEquivalentTo(item);

                // Update
                loaded.Name = newName;
                context.SaveChanges();
            }

            // Check Update
            using(EFContext context = new EFContext())
            {
                var loaded = context.Employee.Find(item.ID);
                loaded.Should().NotBeNull();
                loaded.Name.Should().Be(newName);

                // Delete
                context.Remove(loaded);
                context.SaveChanges();
            }

            using(EFContext context = new EFContext())
            {
                var loaded = context.Employee.Find(item.ID);
                loaded.Should().BeNull();
            }
        }
    }
}
