using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Mocking;

namespace TestNinja.Tests.MockingTests
{
    [TestFixture]
    class EmployeeControllerTests
    {
        //CLASS OBJECT FOR TEST
        private EmployeeController _employeeControllerClass;

        //MOCK OBJECT
        private Mock<IEmployeeStorage> _mockEmployeeStorage;

        [SetUp]
        public void SetUp()
        {
            _mockEmployeeStorage = new Mock<IEmployeeStorage>();
            _employeeControllerClass = new EmployeeController(_mockEmployeeStorage.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockEmployeeStorage = null;
            _employeeControllerClass = null;
        }

        [Test]
        public void DeleteEmployee_WhenCalled_DeleteEmployeeFromDb()
        {
            //Arrange
            _mockEmployeeStorage.Setup(mes => mes.DeleteEmployee(1));

            //Act
            var result = _employeeControllerClass.DeleteEmployee(1);

            //Assert
            _mockEmployeeStorage.Verify(mes => mes.DeleteEmployee(1));
        }
    }
}
