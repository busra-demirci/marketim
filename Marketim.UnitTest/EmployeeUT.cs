using System;
using Marketim.DAL;
using Marketim.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Marketim.UnitTest
{
    [TestClass]
    public class EmployeeUT
    {
        private EmployeeOperations employeeOperations;

        [TestInitialize]
        public void Setup()
        {
            employeeOperations = new EmployeeOperations();
        }

        [TestMethod]
        public void List()
        {
            //Dispose edilmesni istediğim nesneleri using bloğu içerisinde kullanmalıyız.
            using (EmployeeOperations empOperations1 = new EmployeeOperations())
            {
                var result = empOperations1.List();

                Assert.IsNotNull(result);
            }

            //EmployeeOperations empOperations2 = new EmployeeOperations();
            //try
            //{
            //    var result = empOperations2.List();

            //    Assert.IsNotNull(result);
            //}
            //finally
            //{
            //    empOperations2.Dispose();
            //}
        }

        [TestMethod]
        public void Save()
        {
            Employee employee = new Employee
            {
                FirstName = "Bülent",
                LastName = "Başyurt",
                TCKN = "12345678900",
                BirthDate = new DateTime(1987, 12, 27),
                MobilePhone = "05412279878",
                EmailAddress = "bulentbasyurt@gmail.com",
                PositionId = 1,
                Salary = 5000,
                CreatedBy = 1
            };

            int result = employeeOperations.Save(employee);

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void Update()
        {
            Employee employee = new Employee
            {
                EmployeeId = 2,
                FirstName = "Bülent",
                LastName = "Başyurt",
                TCKN = "12345678900",
                BirthDate = new DateTime(1987, 12, 27),
                MobilePhone = "05412279878",
                EmailAddress = "bulentbasyurt@gmail.com",
                PositionId = 1,
                Salary = 5000,
                ModifiedBy = 1
            };

            int result = employeeOperations.Update(employee);

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void Delete()
        {
            int employeeId = 2;
            int deletedBy = 1;

            int result = employeeOperations.Delete(employeeId, deletedBy);

            Assert.IsTrue(result > 0);
        }
    }
}
