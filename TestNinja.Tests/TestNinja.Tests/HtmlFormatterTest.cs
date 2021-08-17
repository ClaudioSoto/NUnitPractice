using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.Tests
{
    [TestFixture]
    class HtmlFormatterTest
    {
        private HtmlFormatter _htmlFromatter;

        [SetUp]
        public void SetUp()
        {
            _htmlFromatter = new HtmlFormatter();
        }

        [TearDown]
        public void TearDown()
        {
            _htmlFromatter = null;
        }

        [Test]
        public void FormatAsBold_WhenCalled_ReturnStrongPlusString()
        {
            //Arrange - Act 
            var result = _htmlFromatter.FormatAsBold("claudio");

            //Assert
            Assert.That(result, Is.EqualTo("<strong>claudio</strong>"));
        }
    }
}
