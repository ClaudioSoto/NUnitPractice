using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.Tests.Fundamentals
{
    [TestFixture]
    class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnTrue()
        {
            //Arrange
            var reservationClassObject = new Reservation();
            var userAuxObject = new User();
            userAuxObject.IsAdmin = true;

            //Act
            var result = reservationClassObject.CanBeCancelledBy(userAuxObject);

            //Assert
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void CanBeCancelledBy_IsMadeByUser_ReturnTrue()
        {
            //Arrange
            var reservationClassObject = new Reservation();
            var userAuxObject = new User();
            reservationClassObject.MadeBy = userAuxObject;

            //Act
            var result = reservationClassObject.CanBeCancelledBy(userAuxObject);

            //Assert
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void CanBeCancelledBy_IsNotAdmin_ReturnFalse()
        {
            //Arrange
            var reservationClassObject = new Reservation();
            var userAuxObject = new User();
            userAuxObject.IsAdmin = false;

            //Act
            var result = reservationClassObject.CanBeCancelledBy(userAuxObject);

            //Assert
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void CanBeCancelledBy_IsNotMadeByUser_ReturnFalse()
        {
            //Arrange
            var reservationClassObject = new Reservation();
            var userAuxObject = new User();

            //Act
            var result = reservationClassObject.CanBeCancelledBy(userAuxObject);

            //Assert
            Assert.That(result, Is.EqualTo(false));
        }

    }
}
