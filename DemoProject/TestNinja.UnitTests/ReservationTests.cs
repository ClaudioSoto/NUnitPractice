using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        /*
         * Los nombres de los test cases es NombreDeLaFuncion_Scenario_ExpectedBehavior
         */

        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnTrue()
        {
            //Arrange
            Reservation objReservation = new Reservation();

            //Act
            bool result = objReservation.CanBeCancelledBy(new User { IsAdmin = true });

            //Assert
            Assert.IsTrue(result);

        }

        [Test]
        public void CanBeCancelledBy_MadeByUser_ReturnTrue()
        {
            //Arrange
            User user = new User();
            Reservation objReservation = new Reservation { MadeBy = user};

            //Act
            bool result = objReservation.CanBeCancelledBy(user);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_MadeByNotUser_ReturnFalse()
        {
            //Arrange
            User user = new User();
            Reservation objReservation = new Reservation { MadeBy = new User() };

            //Act
            bool result = objReservation.CanBeCancelledBy(new User());

            //Assert
            Assert.IsFalse(result);
        }
    }
}