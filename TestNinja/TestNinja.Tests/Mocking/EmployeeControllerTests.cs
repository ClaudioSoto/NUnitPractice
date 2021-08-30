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
        [Test]
        public void DeleteEmployee_WhenCalled_DeleteEmployeeFromDb()
        {
            //Arrange
            var mockEmployeeStorage = new Mock<IEmployeeStorage>();
            var employeeControllerClassObject = new EmployeeController(mockEmployeeStorage.Object);

            //Act
            employeeControllerClassObject.DeleteEmployee(1);

            //Assert
            mockEmployeeStorage.Verify(mes => mes.deleteEmployee(1));
        }
    }
}
