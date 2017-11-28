using System.Diagnostics;
using System.Linq;
using System;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace Interview
{
    [TestFixture]
    public class RepositoryTests
    {
        private Repository<Employee> repository;
        private object result;
        [SetUp]
        public void setupForTest()
        {
            repository = new Repository<Employee>();
        }

        [Test]
        public void Repository_All_Should_ReturnIEnumerableTypeOnly()
        {
           result= repository.All();
            Assert.IsInstanceOf<IEnumerable<Employee>>(result);
        }
        [Test]
        public void Repository_Save_Should_Add_Item_To_List()
        {
            var emp = getEmployee();

            repository.Save(emp);

            Assert.IsInstanceOf<IEnumerable<Employee>>(result);
        }



        private Employee getEmployee() {
            return new Employee { Id = 1, FirstName = "John", LastName = "Doe" };
        }
    }
}