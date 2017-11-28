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
            result = repository.All();
            Assert.IsInstanceOf<IEnumerable<Employee>>(result);
        }
        [Test]
        public void Repository_Save_Should_Add_Item_To_List()
        {
            var emp = AddEmployeeToRepo();

            var all = repository.All();
            Assert.IsTrue(all.Contains(emp));
        }

        [Test]
        public void Repository_Save_Should_Remove_And_Add_Item_To_List()
        {
            var emp = AddEmployeeToRepo();
            var all = repository.All();

            var emp2 = AddEmployeeToRepo();
           
            Assert.IsTrue(all.Count() == 1);
        }


        [Test]
        public void Repository_Save_Should_Not_Throw_Exception_When_Item_Is_Null()
        {
           repository.Save(null);

            Assert.IsTrue(true);
        }

        [Test]
        public void Repository_Delete_Should_Add_Item_To_List()
        {
            var itemToDelete = AddEmployeeToRepo();

            var beforeDeleteCount = repository.All().Count();
            repository.Delete(itemToDelete.Id);
            var afterDeleteCount = repository.All().Count();
            Assert.IsTrue(beforeDeleteCount - 1 == afterDeleteCount);
        }



        [Test]
        public void Repository_Delete_Should_Not_Throw_Exception_When_No_Id_Is_Passed()
        {
             repository.Delete(null);

            Assert.IsTrue(true);
        }


        [Test]
        public void Repository_FindById_Should_Return_Item_From_List()
        {
            var emps = getEmployees();
            var itemToFind = AddEmployeesToRepo(emps).Last();
            var found = repository.FindById(itemToFind.Id);
            
            Assert.IsNotNull(found);
            Assert.IsTrue(found.Id==itemToFind.Id);
        }


        [Test]
        public void Repository_FindById_Should_Return_Null_When_Id_Is_Null()
        {
           
            var found = repository.FindById(null);
            Assert.IsNull(found);
           
        }

        private IEnumerable<Employee> getEmployees()
        {
            return new List<Employee>
            { new Employee {Id = 1, FirstName = "John", LastName = "Doe" },
             new Employee {Id = 2, FirstName = "Peter", LastName = "Horne" },
             new Employee {Id = 3, FirstName = "hello", LastName = "test" },

            };
        }

        private Employee AddEmployeeToRepo()
        {
            var emp = getEmployees().First();
            repository.Save(emp);
            return emp;
        }

        private IEnumerable<Employee> AddEmployeesToRepo(IEnumerable<Employee> emps)
        {
            foreach (var item in emps)
            {
                repository.Save(item);
            }
            return emps;
        }
    }
}