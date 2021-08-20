using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestNinja.Mocking;

namespace TestNinja.Tests.Mocking
{
    [TestFixture]
    public class BookingHelperTests
    {
        private BookingHelper _bookingHelper;
        private Booking _booking;
        private Mock<IBookingRepository> _mockBookingRepository;

        [SetUp]
        public void SetUp()
        {
            _bookingHelper = new BookingHelper();

            _booking = new Booking
            {
                Id = 2,
                ArrivalDate = ArriveOn(2017, 1, 15),
                DepartureDate = Departure(2017, 1, 20),
                Reference = "a"
            };

            _mockBookingRepository = new Mock<IBookingRepository>();

            //Act
            _mockBookingRepository.Setup(mbr => mbr.GetActiveBookings(1)).Returns(new List<Booking>
            {
                _booking
            }.AsQueryable());
        }

        [Test]
        public void OverlappingBookingsExist_BookingStartsAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
        {
            //Arrange
            var bookingHelper = _bookingHelper;
            

            var result = bookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_booking.ArrivalDate, days:2),
                DepartureDate = Before(_booking.ArrivalDate),
                Reference = "b"
            }, _mockBookingRepository.Object);

            //Assert
            Assert.That(result, Is.Empty);
 
        }

        [Test]
        public void OverlappingBookingsExist_BookingStartsBeforeAndFinishesInTheMiddleAnExistingBooking_ReturnExistingBookingsReference()
        {
            //Arrange
            var bookingHelper = _bookingHelper;


            var result = bookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_booking.ArrivalDate, days: 2),
                DepartureDate = After(_booking.ArrivalDate),
                Reference = "b"
            }, _mockBookingRepository.Object);

            //Assert
            Assert.That(result, Is.EqualTo(_booking.Reference));

        }

        [Test]
        public void OverlappingBookingsExist_BookingStartsBeforeAndFinishesAfterAnExistingBooking_ReturnExistingBookingsReference()
        {
            //Arrange
            var bookingHelper = _bookingHelper;


            var result = bookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_booking.ArrivalDate),
                DepartureDate = After(_booking.DepartureDate),
                Reference = "b"
            }, _mockBookingRepository.Object);

            //Assert
            Assert.That(result, Is.EqualTo(_booking.Reference));

        }

        [Test]
        public void OverlappingBookingsExist_BookingStartsAndFinishesInTheMiddleOfAnExistingBooking_ReturnExistingBookingsReference()
        {
            //Arrange
            var bookingHelper = _bookingHelper;


            var result = bookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(_booking.ArrivalDate),
                DepartureDate = Before(_booking.DepartureDate),
                Reference = "b"
            }, _mockBookingRepository.Object);

            //Assert
            Assert.That(result, Is.EqualTo(_booking.Reference));

        }

        [Test]
        public void OverlappingBookingsExist_BookingStartsInTheMiddleAndFinishesInTheAfterOfAnExistingBooking_ReturnExistingBookingsReference()
        {
            //Arrange
            var bookingHelper = _bookingHelper;


            var result = bookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(_booking.ArrivalDate),
                DepartureDate = After(_booking.DepartureDate),
                Reference = "b"
            }, _mockBookingRepository.Object);

            //Assert
            Assert.That(result, Is.EqualTo(_booking.Reference));

        }

        [Test]
        public void OverlappingBookingsExist_BookingStartsAndFinishesAfterAnExistingBooking_ReturnEmptyString()
        {
            //Arrange
            var bookingHelper = _bookingHelper;


            var result = bookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(_booking.DepartureDate),
                DepartureDate = After(_booking.DepartureDate, days:2),
                Reference = "b"
            }, _mockBookingRepository.Object);

            //Assert
            Assert.That(result, Is.Empty);

        }

        [Test]
        public void OverlappingBookingsExist_BookingOverlapButNewBookingIsCancelled_ReturnEmptyString()
        {
            //Arrange
            var bookingHelper = _bookingHelper;


            var result = bookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(_booking.ArrivalDate),
                DepartureDate = After(_booking.DepartureDate),
                Reference = "b",
                Status = "Cancelled"
            }, _mockBookingRepository.Object);

            //Assert
            Assert.That(result, Is.Empty);

        }

        //HELPER METHOD TO CREATE ARRIVAL
        private DateTime ArriveOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 14, 0, 0);
        }

        private DateTime Departure(int year, int month, int day)
        {
            return new DateTime(year, month, day, 10, 0, 0);
        }

        //HELPER METHOD TO CREATE DEPARTURE
        private DateTime Before(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(-days);
        }

        private DateTime After(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(days);
        }

    }
}
