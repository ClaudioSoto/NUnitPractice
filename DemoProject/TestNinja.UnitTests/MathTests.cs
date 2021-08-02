using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Math = TestNinja.Fundamentals.Math;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class MathTests
    {
        //creamos el objeto para no crearlo en cada test
        private Math _math;

        //con setup limpiamos o volvemos a crear el objeto antes de ejecutar cada test
        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            //Arrange
            //Math math = new Math();

            //Act
            //agregar valores simples para no confundir
            int result = _math.Add(1, 2);

            //Assert
            Assert.AreEqual(3, result);
        }

        //CUANDO LOS TEST CASES SON IGUALES PERO CON PARAMETROS DIFERENTES
        //SE DEBE DE PONER UN NOMBRE AL METHODO MAS GENERICO Y LA ETIQUETA [TestCase()] y parametros
        [Test]
        [TestCase(2,1,2)]
        [TestCase(1, 2, 2)]
        [TestCase(2, 2, 2)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expected)
        {

            //Act
            int result = _math.Max(a, b);

            //Assert
            Assert.AreEqual(result, expected);

        }

        //METODO PARA PROBAR ARREGLOS Y COLECCIONES
        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToTheLimit()
        {
            //Arrange - Act
            var result = _math.GetOddNumbers(5);

            //Assert
            Assert.That(result, Is.EqualTo(new[] { 1, 3, 5 }));
        }



    }
}
