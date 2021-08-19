using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Mocking;

namespace TestNinja.Tests.Mocking
{
    [TestFixture]
    class EmployeeControllerTests
    {
        private EmployeeController _employeeController;

        [SetUp]
        public void SetUp()
        {
            _employeeController = new EmployeeController();
        }

        [TearDown]
        public void TearDown()
        {
            _employeeController = null;
        }

        [Test]
        public void DeleteEmployee_WhenCalled_DeleteEmployeeFromDb()
        {
            //Arrange 
            var employeeController = _employeeController;
            var mockEmployeeStorage = new Mock<IEmployeeStorage>();
            employeeController.DeleteEmployee(1, mockEmployeeStorage.Object);

            //Act
            mockEmployeeStorage.Verify(mes => mes.DeleteEmployee(1));
        }


    }
}
