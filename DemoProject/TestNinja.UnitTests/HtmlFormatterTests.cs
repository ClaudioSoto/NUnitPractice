using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class HtmlFormatterTests
    {

        [Test]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
        {   
            //Arrange
            HtmlFormatter formatter = new HtmlFormatter();

            //Act 
            var result = formatter.FormatAsBold("abc");

            //Assert
            //solucion especifica
            //Assert.AreEqual(result,"<strong>abc</strong>");

            //solucion mas general
            Assert.That(result, Does.StartWith("<strong>").IgnoreCase);
            Assert.That(result, Does.EndWith("</strong>").IgnoreCase);
            Assert.That(result, Does.Contain("abc").IgnoreCase);
        }
    }
}
